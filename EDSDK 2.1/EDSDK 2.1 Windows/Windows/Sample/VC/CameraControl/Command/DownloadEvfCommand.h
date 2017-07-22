/******************************************************************************
*                                                                             *
*   PROJECT : EOS Digital Software Development Kit EDSDK                      *
*      NAME : DownloadEvfCommand.h	                                          *
*                                                                             *
*   Description: This is the Sample code to show the usage of EDSDK.          *
*                                                                             *
*                                                                             *
*******************************************************************************
*                                                                             *
*   Written and developed by Camera Design Dept.53                            *
*   Copyright Canon Inc. 2006 All Rights Reserved                             *
*                                                                             *
*******************************************************************************
*   File Update Information:                                                  *
*     DATE      Identify    Comment                                           *
*   -----------------------------------------------------------------------   *
*   07-02-15    F-001        create first version.                            *
*                                                                             *
******************************************************************************/

#pragma once

#include "Command.h"
#include "CameraEvent.h"
#include "EDSDK.h"


typedef struct _EVF_DATASET 
{
	EdsStreamRef stream; // JPEG stream.
	EdsUInt32 zoom;
	EdsPoint zoomPosition;
	EdsPoint imagePosition;
	EdsUInt32 histogram[256 * 4]; //(YRGB) YRGBYRGBYRGBYRGB....
}EVF_DATASET;


class DownloadEvfCommand : public Command
{

public:
	DownloadEvfCommand(CameraModel *model) : Command(model){}


	virtual bool execute()
	{
	
		EdsError err = EDS_ERR_OK;

		EdsEvfImageRef evfImage = NULL;
		EdsStreamRef stream = NULL;
		EdsUInt32 bufferSize = 2 * 1024 * 1024;

		// Exit unless during live view.
		if ((_model->getEvfOutputDevice() & kEdsEvfOutputDevice_PC) == 0)
		{
			return true;
		}

		// Create memory stream.
		err = EdsCreateMemoryStream(bufferSize, &stream);

		// When creating to a file.
		//err = EdsCreateFileStream("test.jpg", kEdsFileCreateDisposition_CreateAlways, kEdsAccess_ReadWrite, &stream);


		// Create EvfImageRef.
		if (err == EDS_ERR_OK)
		{
			err = EdsCreateEvfImageRef(stream, &evfImage);
		}

		// Download live view image data.
		if (err == EDS_ERR_OK)
		{
			err = EdsDownloadEvfImage(_model->getCameraObject(), evfImage);
		}

		// Get meta data for live view image data.
		if (err == EDS_ERR_OK)
		{
			EVF_DATASET dataSet;

			dataSet.stream = stream;

			// Get magnification ratio (x1, x5, or x10).
			EdsGetPropertyData(evfImage, kEdsPropID_Evf_Zoom, 0, sizeof(dataSet.zoom),  &dataSet.zoom);

			// Get position of the focus border.
			// Upper left coordinate of the focus border using JPEG Large size as a reference.
			EdsGetPropertyData(evfImage, kEdsPropID_Evf_ZoomPosition, 0, sizeof(dataSet.zoomPosition), &dataSet.zoomPosition);

			// Get position of image data. (when enlarging)
			// Upper left coordinate using JPEG Large size as a reference.
			EdsGetPropertyData(evfImage, kEdsPropID_Evf_ImagePosition, 0, sizeof(dataSet.imagePosition), &dataSet.imagePosition);

			// Get histogram (RGBY).
			EdsGetPropertyData(evfImage, kEdsPropID_Evf_Histogram, 0, sizeof(dataSet.histogram), dataSet.histogram);

			// Set to model.
			_model->setEvfZoom(dataSet.zoom);
			_model->setEvfZoomPosition(dataSet.zoomPosition);

			// Live view image transfer complete notification.
			if (err == EDS_ERR_OK)
			{
				CameraEvent e("EvfDataChanged", &dataSet);
				_model->notifyObservers(&e);		
			}
		}


		if(stream != NULL)
		{
			EdsRelease(stream);
			stream = NULL;
		}
		
		if(evfImage != NULL)
		{
			EdsRelease(evfImage);
			evfImage = NULL;
		}
         
		//Notification of error
		if(err != EDS_ERR_OK)
		{
		
			// Retry getting image data if EDS_ERR_OBJECT_NOTREADY is returned
			// when the image data is not ready yet.
			if(err == EDS_ERR_OBJECT_NOTREADY)
			{
				return false;
			}

			// It retries it at device busy
			if(err == EDS_ERR_DEVICE_BUSY)
			{
				CameraEvent e("DeviceBusy");
				_model->notifyObservers(&e);
				return false;
			}

			CameraEvent e("error", &err);
			_model->notifyObservers(&e);
		}

		return true;
	}


};