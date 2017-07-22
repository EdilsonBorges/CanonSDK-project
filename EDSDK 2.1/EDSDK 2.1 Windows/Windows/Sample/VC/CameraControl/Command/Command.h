/******************************************************************************
*                                                                             *
*   PROJECT : EOS Digital Software Development Kit EDSDK                      *
*      NAME : Command.h	                                                      *
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


#pragma once

#include  "CameraModel.h"

class Command {

protected:
	// Camera Model
	CameraModel* _model;

public:
	Command(CameraModel *model) : _model(model) {}

	CameraModel* getCameraModel(){return _model;}

	// Execute command	
	virtual bool execute() = 0;
};

