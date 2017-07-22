#pragma once

#include "Observer.h"
#include "ActionSource.h"

// CEVFPictureBox

class CEVFPictureBox : public CStatic, public ActionSource , public Observer
{
	DECLARE_DYNAMIC(CEVFPictureBox)
	
private:
	BOOL active;

	void OnDrawImage(CDC *pDC, unsigned char* pbyteImage, int size);
	void OnDrawFocusRect(CDC *pDC, POINT zoomPosition);
public:
	CEVFPictureBox();
	virtual ~CEVFPictureBox();

	//observer
	virtual void update(Observable* from, CameraEvent *e);

protected:
	afx_msg LRESULT OnEvfDataChanged(WPARAM wParam, LPARAM lParam);
	DECLARE_MESSAGE_MAP()
};


