/******************************************************************************
*                                                                             *
*   PROJECT : EOS Digital Software Development Kit EDSDK                      *
*      NAME : DownloadCameraImages.cpp                                        *
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
*   06-03-22    F-001        create first version.                            *
*                                                                             *
******************************************************************************/

#ifdef __MACOS__
	#import <Carbon/Carbon.h>
#else
	#include <stdio.h>
#endif //__MACOS__

#include "EDSDK.h"



/*************************************************************************
*
* FUNC: Handle progress event. 
*
*
*************************************************************************/
EdsError EDSCALLBACK ProgressFunc (
								   EdsUInt32	inPercent,
								   EdsVoid*		inContext,
								   EdsBool*		outCancel
								   )
{
	char* fileName = (char*)inContext ;
	
	printf( "\rDownloading %s : %03d %%", fileName, inPercent ) ;	
	if ( inPercent == 100 ) printf( "\n" );
	
	return EDS_ERR_OK;
}


/*************************************************************************
*
* FUNC: Downloading images recursively.
*
*
*************************************************************************/
EdsError  RecursiveDownload( EdsDirectoryItemRef aDirRef )
{
	EdsUInt32 				count		= 0;
	EdsUInt32 				iCnt		= 0;
	EdsDirectoryItemRef		childRef	= NULL;
	EdsDirectoryItemInfo	objectInfo ;
	EdsStreamRef			stream		= NULL;
	EdsError                err			= EDS_ERR_OK ;

#ifdef __MACOS__
	CFStringRef cfsr ;
	CFURLRef    cfur ;
#endif
	if ( err == EDS_ERR_OK )
	{
		err = EdsGetChildCount( aDirRef, &count);
	}
	
	for ( iCnt = 0; iCnt < count && err == EDS_ERR_OK; iCnt ++ )
	{
		if ( err == EDS_ERR_OK )
		{
			err = EdsGetChildAtIndex( aDirRef, iCnt, &childRef );
		}

		if ( err == EDS_ERR_OK )
		{	
			err = EdsGetDirectoryItemInfo( childRef, &objectInfo ) ;
		}
	
		if ( err == EDS_ERR_OK )
		{
			if ( objectInfo.isFolder == TRUE )
			{
				// FOLDER
				err = RecursiveDownload( childRef ) ;
			}
			else
			{
#ifdef __MACOS__
				cfsr = CFStringCreateWithCString( NULL, objectInfo.szFileName, kCFStringEncodingMacJapanese );
				cfur = CFURLCreateWithFileSystemPath( NULL, cfsr, kCFURLWindowsPathStyle, false) ;
											   
				err = EdsCreateFileStreamEx( cfur, 
											 kEdsFileCreateDisposition_CreateAlways,
											 kEdsAccess_ReadWrite, &stream);

#else
				if ( err == EDS_ERR_OK )
				{
					err = EdsCreateFileStream(objectInfo.szFileName, 
										  kEdsFileCreateDisposition_CreateAlways, 
										  kEdsAccess_ReadWrite, &stream);
				}
#endif

				if ( err == EDS_ERR_OK )
				{		
					err = EdsSetProgressCallback(stream, ProgressFunc, kEdsProgressOption_Periodically, (void*)objectInfo.szFileName);
				}

				if ( err == EDS_ERR_OK )
				{		
					err = EdsDownload( childRef, objectInfo.size, stream );
				
				}

				if ( err == EDS_ERR_OK )
				{		
					err = EdsDownloadComplete( childRef );
			
				}


			}	// else // if ( objectInfo.isFolder == TRUE )
		}		// if ( err == EDS_ERR_OK )

		if( stream != NULL ) 
		{
			EdsRelease( stream ); 
			stream = NULL ;
		}

		if ( childRef != NULL )
		{
			EdsRelease( childRef ) ;
			childRef = NULL ;
		}

	}	// for 

	
	return err ;
}


/*************************************************************************
*
* FUNC: Mainf
*
*
*************************************************************************/
int main(int argc, char *argv[])
{
	EdsCameraListRef	theCameraList	= NULL ;
	EdsCameraRef		theCamera		= NULL ;	
	EdsVolumeRef 		theVolumeRef	= NULL ;
	EdsDirectoryItemRef	dirItemRef		= NULL;
	
	EdsError			err				= EDS_ERR_OK;
	EdsVolumeInfo       volumeInfo		= {0};
	EdsUInt32           iCnt			= 0;
	EdsUInt32 			count			= 0;
	
	err = EdsInitializeSDK();
	if(err != EDS_ERR_OK)
	{
		return err ;
	}

#ifdef __MACOS__
	/*
	 * Caution!
	 * About a console application, you need calling Carbon API "RunCurrentEventRoop()" 
	 * after calling "EdsInitializeSDK()".
	 * If you do not call this API, the program might stop when it execute OpenSession(), but
	 * we do not understand why it stops.
	 */
	RunCurrentEventLoop(10 * kEventDurationMillisecond) ;
#endif	
	
	// -----------------------------------------------------------------------------
	//
	// Initialize 
	//
	// -----------------------------------------------------------------------------
	
	
	// Get the camera list
	err = EdsGetCameraList(&theCameraList);
	
	// Get the number of cameras.
	if ( err == EDS_ERR_OK )
	{
		EdsUInt32 cameraCount = 0 ;
		err = EdsGetChildCount( theCameraList, &cameraCount );
		if ( cameraCount == 0 )
		{
			err = EDS_ERR_DEVICE_NOT_FOUND;
		}
	}
	
	// Get the first camera
	if ( err == EDS_ERR_OK )
	{	
		err = EdsGetChildAtIndex( theCameraList , 0 , &theCamera );	
	}
	
	// Open session 
	if ( err == EDS_ERR_OK )
	{
		err = EdsOpenSession( theCamera );
	}
	
	
	EdsUInt32 wkSaveTo = kEdsSaveTo_Host ;
	err = EdsSetPropertyData ( theCamera,kEdsPropID_SaveTo,0, 4, (void*)&wkSaveTo ) ;
	
	
	
	// -----------------------------------------------------------------------------
	//
	// Downloading files from Camera to PC. 
	//
	// -----------------------------------------------------------------------------
	
	// Get the number of Volumes
	if ( err == EDS_ERR_OK )
	{
		err = EdsGetChildCount( theCamera, &count );
		if ( count == 0 )
		{
			err = EDS_ERR_DEVICE_NOT_FOUND;
		}
	}
	
	//
	// Download Card No.0 contents
	//
	err = EdsGetChildAtIndex( theCamera, 0, &theVolumeRef );
	if ( err == EDS_ERR_OK )
	{
		err = EdsGetVolumeInfo( theVolumeRef, &volumeInfo ) ;
	}
	
	if ( err == EDS_ERR_OK )
	{
		err = EdsGetChildCount( theVolumeRef, &count );
		if ( err == EDS_ERR_OK )
		{
			/*
			 * Download all images from Camera 
			 */
			for ( iCnt = 0; iCnt < count; iCnt ++)
			{
				err = EdsGetChildAtIndex( theVolumeRef, iCnt, &dirItemRef ) ;
				if ( err == EDS_ERR_OK )
				{
					err = RecursiveDownload( dirItemRef ) ;

				}
				if ( dirItemRef != NULL )
				{
					EdsRelease( dirItemRef ) ;
					dirItemRef = NULL ;
				}
			}
		}
	}
	
	if ( dirItemRef != NULL )
	{
		EdsRelease( theVolumeRef ) ;
		theVolumeRef = NULL ;
	}


	// -----------------------------------------------------------------------------
	//
	// Downloading files from Camera to PC. 
	//
	// -----------------------------------------------------------------------------
	
	// Close session
	if ( err == EDS_ERR_OK ){
		err = EdsCloseSession( theCamera );
	}
	
	if ( theCamera != NULL ){
		EdsRelease( theCamera );
		theCamera = NULL ;
	}
	
	if ( theCameraList != NULL ){
		EdsRelease( theCameraList );
		theCameraList = NULL;
	}
	
	// EDSDK Termination
	err = EdsTerminateSDK();
	
	return err ;

}
