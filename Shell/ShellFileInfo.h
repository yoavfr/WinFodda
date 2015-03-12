#include "Stdafx.h"
#include "IShellDirectoryInfo.h"
using namespace std;
using namespace System;
using namespace System::Collections;
using namespace System::Collections::Generic;
using namespace System::Runtime::InteropServices;
using namespace System::Drawing;


namespace Fodda
{
	public ref class ShellFileInfo
	{
		private:
			IShellDirectoryInfo ^m_Parent;
			LPMALLOC m_pMalloc; // memory manager, for freeing up PIDLs
			LPITEMIDLIST m_pidl; 
			String^ m_FullName;

		public:
			ShellFileInfo(IShellDirectoryInfo ^parent, LPITEMIDLIST pidl);
			~ShellFileInfo();
			DateTime^ GetCreationTime();
			void CopyTo(String^ destination);
			Image^ ShellFileInfo::GetThumbnail(Size^ size);
			property String^ FullName
			{
				String^ get();
			}
	};
}