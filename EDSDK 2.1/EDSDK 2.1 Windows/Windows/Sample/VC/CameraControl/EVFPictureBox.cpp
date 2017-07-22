// EVFPictureBox.cpp : 
//

#include "stdafx.h"
#include <atlimage.h>

#include "CameraControl.h"
#include "EVFPictureBox.h"

#define WM_USER_EVF_DATA_CHANGED		WM_APP+1
// CEVFPictureBox

IMPLEMENT_DYNAMIC(CEVFPictureBox, CStatic)
CEVFPictureBox::CEVFPictureBox()
{
	active = FALSE;
}

CEVFPictureBox::~CEVFPictureBox()
{
}


BEGIN_MESSAGE_MAP(CEVFPictureBox, CStatic)
	ON_MESSAGE(WM_USER_EVF_DATA_CHANGED, OnEvfDataChanged)
END_MESSAGE_MAP()



// CEVFPictureBox messge handler

void CEVFPictureBox::update(Observable* from, CameraEvent *e)
{

	std::string event = e->getEvent();

	if(event == "EvfDataChanged")
	{
		EVF_DATASET data = *static_cast<EVF_DATASET *>(e->getArg());
	
		//The update processing can be executed from another thread. 
		::SendMessage(this->m_hWnd, WM_USER_EVF_DATA_CHANGED, (WPARAM) &data, NULL);

		// Download image data.
		fireEvent("downloadEVF");
	}
	
	if (event == "PropertyChanged")
	{
		EdsInt32 proeprtyID = *static_cast<EdsInt32 *>(e->getArg());
		if(proeprtyID == kEdsPropID_Evf_OutputDevice)
		{
			CameraModel* model = (CameraModel *)from;
			EdsUInt32 device = model->getEvfOutputDevice();

			// PC live view has started.
			if (!active && (device & kEdsEvfOutputDevice_PC) != 0)
			{
				active = TRUE;
				// Start download of image data.
				fireEvent("downloadEVF");
			}

			// PC live view has ended.
			if(active && (device & kEdsEvfOutputDevice_PC) == 0)
			{
				active = FALSE;
			}
		}
	}	
}

LRESULT CEVFPictureBox::OnEvfDataChanged(WPARAM wParam, LPARAM lParam)
{
	EVF_DATASET data = *(EVF_DATASET *)wParam;
	EdsUInt32 size;

	unsigned char* pbyteImage = NULL; 

	// Get image (JPEG) pointer.
	EdsGetPointer(data.stream, (EdsVoid**)&pbyteImage );
	
	if(pbyteImage != NULL)
	{
		EdsGetLength(data.stream, &size);

		CDC *pDC = GetDC();
	
		// Display image data.
		OnDrawImage(pDC, pbyteImage, size);

		// Display the focus border if displaying the entire image.
		if(data.zoom == 1)
		{
			OnDrawFocusRect(pDC, CPoint(data.zoomPosition.x, data.zoomPosition.y));
		}

		ReleaseDC(pDC);
	}

	return 0;
}



void CEVFPictureBox::OnDrawImage(CDC *pDC, unsigned char* pbyteImage, int size)
{
	CImage image;

	CComPtr<IStream> stream;
	stream = NULL;

	HGLOBAL hMem = ::GlobalAlloc(GHND, size); 
	LPVOID pBuff = ::GlobalLock(hMem);

	memcpy(pBuff, pbyteImage, size);

	::GlobalUnlock(hMem);
	CreateStreamOnHGlobal(hMem, TRUE, &stream);

	image.Load(stream);

	
	CRect rect;
	GetWindowRect(&rect);

	// Drawing
	SetStretchBltMode(pDC->GetSafeHdc() , COLORONCOLOR);
	image.StretchBlt(pDC->GetSafeHdc(),  0,0,rect.Width(),rect.Height(),0,0,image.GetWidth(), image.GetHeight(),SRCCOPY);
	//image.BitBlt(hDC, 0, 0);
	image.Destroy();

	::GlobalFree(hMem);
}


void CEVFPictureBox::OnDrawFocusRect(CDC *pDC, POINT zoomPosition)
{
	// Get window size.
	CRect rect;
	GetWindowRect(&rect);

	int cx = rect.Width();
	int cy = rect.Height();

	// The zoomPosition is given by the coordinates of the upper left of the focus border using Jpeg Large size (3888 x 2592) as a reference.
	
	// The size of the focus border is one fifth the size of Jpeg Large (3888 x 2592).
	// Because the image fills the entire window, the height and width to be drawn is one fifth of the window size.

	
	const int iw = 3888;
	const int ih = 2592;

	// Upper left coordinate to be drawn.
	CPoint topLeft(zoomPosition.x * cx / iw, zoomPosition.y * cy / ih);

	// Upper right coordinate to be drawn.
	CPoint topRight(topLeft.x + cx / 5, topLeft.y);

	// Lower right coordinate to be drawn.
	CPoint bottomRight(topRight.x, topLeft.y + cy / 5);

	// Lower left coordinate to be drawn.
	CPoint bottomLeft(topLeft.x, bottomRight.y);

	// Draw.
	CPen pen(PS_SOLID, 1, RGB(255, 255, 255));
	CPen *oldPen = pDC->SelectObject(&pen);
 	
	pDC->MoveTo(topLeft);
    pDC->LineTo(topRight);
    pDC->LineTo(bottomRight);
    pDC->LineTo(bottomLeft);
    pDC->LineTo(topLeft);

	pDC->SelectObject(oldPen);
	pen.DeleteObject();
}
