#pragma once

#include <map>
// CPropertyComboBox

class CPropertyComboBox : public CComboBox
{
	DECLARE_DYNAMIC(CPropertyComboBox)

public:
	CPropertyComboBox();
	virtual ~CPropertyComboBox();

protected:
	void OnSelChange();

	DECLARE_MESSAGE_MAP()

	std::map<EdsUInt32, const char *> _propertyTable;

	void updateProperty(EdsUInt32 value);
	void updatePropertyDesc(const EdsPropertyDesc* desc);
};


