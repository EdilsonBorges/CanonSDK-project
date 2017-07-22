
#pragma once


#include "ActionSource.h"


class CActionButton : public CButton , public ActionSource
{

public:
	CActionButton();


public:


public:



// インプリメンテーション
public:
	virtual ~CActionButton();

protected:
	void OnClicked();
	DECLARE_MESSAGE_MAP()
};

