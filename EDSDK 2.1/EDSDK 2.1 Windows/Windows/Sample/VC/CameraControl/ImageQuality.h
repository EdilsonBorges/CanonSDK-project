#pragma once

#include "PropertyComboBox.h"
#include "Observer.h"
#include "ActionSource.h"
// CImageQuality

class CImageQuality : public CPropertyComboBox, public ActionSource , public Observer  
{
	DECLARE_DYNAMIC(CImageQuality)

public:
	CImageQuality();
	virtual ~CImageQuality();

	//observer
	virtual void update(Observable* from, CameraEvent *e);

protected:
	void OnSelChange();
	afx_msg LRESULT OnPropertyChanged(WPARAM wParam, LPARAM lParam);
	afx_msg LRESULT OnPropertyDescChanged(WPARAM wParam, LPARAM lParam);

	DECLARE_MESSAGE_MAP()
};


