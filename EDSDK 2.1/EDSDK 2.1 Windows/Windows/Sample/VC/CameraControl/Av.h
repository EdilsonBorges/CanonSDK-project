#pragma once

#include "PropertyComboBox.h"
#include "Observer.h"
#include "ActionSource.h"
// CAv

class CAv : public CPropertyComboBox, public ActionSource , public Observer  
{
	DECLARE_DYNAMIC(CAv)

public:
	CAv();
	virtual ~CAv();

	//observer
	virtual void update(Observable* from, CameraEvent *e);

protected:
	void OnSelChange();
	afx_msg LRESULT OnPropertyChanged(WPARAM wParam, LPARAM lParam);
	afx_msg LRESULT OnPropertyDescChanged(WPARAM wParam, LPARAM lParam);

	DECLARE_MESSAGE_MAP()
};


