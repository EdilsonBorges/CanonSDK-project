
#pragma once


#include "ActionSource.h"


class CActionButton : public CButton , public ActionSource
{

public:
	CActionButton();


public:


public:



// �C���v�������e�[�V����
public:
	virtual ~CActionButton();

protected:
	void OnClicked();
	DECLARE_MESSAGE_MAP()
};

