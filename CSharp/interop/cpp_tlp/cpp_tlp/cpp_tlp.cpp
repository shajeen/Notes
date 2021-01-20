#include <iostream>
#include <Windows.h>
#include<oaidl.h>

#import "MyCSharpClass.tlb" raw_interfaces_only

void CreateSafeArray(SAFEARRAY** saData)
{
	double data[3]; // some sample data to write into the created safearray
	SAFEARRAYBOUND  Bound;
	Bound.lLbound = 0;
	Bound.cElements = 3;

	*saData = SafeArrayCreate(VT_R8, 1, &Bound);

	double HUGEP *pdFreq;
	HRESULT hr = SafeArrayAccessData(*saData, (void HUGEP* FAR*)&pdFreq);
	if (SUCCEEDED(hr))
	{
		// copy sample values from data[] to this safearray
		for (DWORD i = 0; i < 3; i++)
		{
			*pdFreq++ = data[i];

		}
		SafeArrayUnaccessData(*saData);
	}
}

int wmain() {
	CoInitialize(0); // Init COM
	BSTR thing_to_send = ::SysAllocString(L"My thing, or ... ");
	BSTR returned_thing;
	MyCSharpClass::_TheClassPtr obj(__uuidof(MyCSharpClass::TheClass));
	HRESULT hResult = obj->GetTheThing(thing_to_send, &returned_thing);

	double return_val;
	HRESULT hresult = obj->GetTheThing_2(1.2, 1.4, 1.6, &return_val);

	CoUninitialize();
	if (hResult == S_OK && hresult == S_OK) {
		std::wcout << returned_thing << " " << return_val << " " << std::endl;
		return 0;
	}
	return 1;
}