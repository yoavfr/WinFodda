// Unmanaged.h

#pragma once
#include <WiaDef.h>
#include <Wia_lh.h>

using namespace System;
using namespace System::Runtime::InteropServices;

namespace Unmanaged {

	public ref class WiaProperties
	{
	public:
		static void ShowProperties (IntPtr ptr, ImportPics::IDebugOutput^ debugOutput);
	};
}
