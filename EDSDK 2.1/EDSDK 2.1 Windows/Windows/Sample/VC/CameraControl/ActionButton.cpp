// ActionButton.cpp : 
//

#include "stdafx.h"
#include "ActionButton.h"


/////////////////////////////////////////////////////////////////////////////
// ActionButton

CActionButton::CActionButton()
{
}

CActionButton::~CActionButton()
{
}


BEGIN_MESSAGE_MAP(CActionButton, CButton)
	ON_CONTROL_REFLECT(BN_CLICKED, OnClicked)
END_MESSAGE_MAP()

//ActionButton  message handler
void CActionButton::OnClicked() 
{
	fireEvent();
}
