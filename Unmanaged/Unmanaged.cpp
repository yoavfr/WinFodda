// This is the main DLL file.

#include "stdafx.h"

#include "Unmanaged.h"

namespace Unmanaged {

	void WiaProperties::ShowProperties (IntPtr ptr, ImportPics::IDebugOutput^ debugOutput)
	{
		debugOutput->DebugPrint("Properties:\n");
		//IntPtr iPtr = Marshal::GetIUnknownForObject(wiaItem);
		//IWiaItem2* item2 = (IWiaItem2*)wiaItem;
		IWiaPropertyStorage* pWiaPropertyStorage = (IWiaPropertyStorage*)(void*)ptr;
		if (pWiaPropertyStorage== NULL)
		{
			debugOutput->DebugPrint("Empty:\n");
			return;
		}
		unsigned long num;
		HRESULT result;
		//Guid^ guid = gcnew Guid("98B5E8A0-29CC-491a-AAC0-E6DB4FDCCEB6");
		//result = Marshal::QueryInterface(iPtr, guid, (void**)&pWiaPropertyStorage);
		//result = iPtr.QueryInterface(IID_IWiaPropertyStorage, (void**)&pWiaPropertyStorage);
		result = pWiaPropertyStorage->GetCount(&num);

		debugOutput->DebugPrint(num);
		
		PROPSPEC specDevType[1];
		specDevType[0].ulKind = PRSPEC_PROPID;
		specDevType[0].propid = WIA_IPA_ACCESS_RIGHTS;
		PROPVARIANT rgpropvar[1];
		pWiaPropertyStorage->ReadMultiple(1, specDevType, rgpropvar);

		debugOutput->DebugPrint("vt");
		debugOutput->DebugPrint((int)(rgpropvar[0].vt));
		debugOutput->DebugPrint(sizeof(int));
		debugOutput->DebugPrint((int)(rgpropvar[0].intVal));



	}
	
}