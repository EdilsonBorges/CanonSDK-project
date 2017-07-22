#pragma once

#include "PropertyComboBox.h"
#include "Observer.h"
#include "ActionSource.h"
// CIso

class CIso : public CPropertyComboBox, public ActionSource , public Observer  
{
	DECLARE_DYNAMIC(CIso)

public:
	CIso();
	virtual ~CIso();

	//observer
	virtual void update(Observable* from, CameraEvent *e);

protected:
	void OnSelChange();
	afx_msg LRESULT OnPropertyChanged(WPARAM wParam, LPARAM lParam);
	afx_msg LRESULT OnPropertyDescChanged(WPARAM wParam, LPARAM lParam);

	DECLARE_MESSAGE_MAP()
};


