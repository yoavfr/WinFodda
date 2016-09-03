#include "Stdafx.h"

#include "IShellDirectoryInfo.h"
#include "ShellFileInfo.h"

using namespace std;
using namespace System;
using namespace System::Collections;
using namespace System::Collections::Generic;

namespace Fodda
{

	public ref class ShellDirectoryInfo : IShellDirectoryInfo
	{
	private:
		IShellFolder2* m_pShellFolder;
		IShellFolder2* m_pParentShellFolder;
		LPMALLOC m_pMalloc; // memory manager, for freeing up PIDLs
		LPITEMIDLIST m_pidl; 
	
	public:
		ShellDirectoryInfo(String ^folderName)
		{
			HRESULT hr;
			LPSHELLFOLDER pDesktopFolder;
			LPITEMIDLIST pidl;
			IShellFolder2* pFolder = NULL;
			//hr = CoInitialize(NULL); // initialize COM
			pin_ptr<const wchar_t> wFolderName = PtrToStringChars(folderName);
			
			// get desktop folder
			if ((hr = SHGetDesktopFolder(&pDesktopFolder)) != S_OK)
			{
				throw gcnew Exception(String::Format(L"Failed to get desktop folder. 0x{0:X8}",hr));
			}
			// get pidl for requested sub 
			if ((hr = pDesktopFolder->ParseDisplayName(NULL, NULL, (LPWSTR)wFolderName, NULL, &pidl, NULL)) != S_OK)
			{
				throw gcnew Exception(String::Format(L"Failed to parse display name. 0x{0:X8}",hr));
			}
			// bind to the sub
			if ((hr = pDesktopFolder->BindToObject(pidl, NULL, IID_IShellFolder2, (void**)&pFolder)) != S_OK)
			{
				throw gcnew Exception(String::Format(L"Failed to bind to desktop sub folder. 0x{0:X8}",hr));
			}

			pDesktopFolder->Release();
			Init(pFolder, pFolder, pidl);

		}


		ShellDirectoryInfo(IShellFolder2* pParentShellFolder, LPITEMIDLIST pidl)
		{
			HRESULT hr;
			IShellFolder2* pMyShellFolder = NULL;
			if ((hr = pParentShellFolder->BindToObject(pidl, NULL, IID_IShellFolder2, (void**)&pMyShellFolder)) != S_OK)
			{
				throw gcnew Exception(String::Format(L"Failed to bind to object. 0x{0:X8}",hr));
			}
			Init(pParentShellFolder, pMyShellFolder, pidl);
		}

		void Init(IShellFolder2* pParentShellFolder, IShellFolder2* pMyShellFolder, LPITEMIDLIST pidl)
		{
			HRESULT hr;
			m_pParentShellFolder = pParentShellFolder;
			m_pShellFolder = pMyShellFolder;
			m_pidl = pidl;
			LPMALLOC pMalloc;
			if ((hr = SHGetMalloc(&pMalloc)) != S_OK)
			{
				throw gcnew Exception(String::Format(L"Failed to obtain Malloc. 0x{0:X8}",hr));
			}
			m_pMalloc = pMalloc;
		}

		~ShellDirectoryInfo()
		{
			m_pShellFolder->Release();
			m_pMalloc->Free(m_pidl);
			m_pMalloc->Release();
		}

		property IShellFolder2* ShellFolder
		{
			virtual IShellFolder2* get()
			{
				return m_pShellFolder;
			}
			virtual void set(IShellFolder2* pShellFolder)
			{
				m_pShellFolder = pShellFolder;
			}
		}

		property String^ FullName
		{
			String^ get()
			{
				HRESULT hr;
				STRRET strDispName;

				if ((hr = m_pParentShellFolder->GetDisplayNameOf(m_pidl, SHGDN_FORPARSING | SHGDN_FORADDRESSBAR, &strDispName)) != S_OK)
				{
					// this reports failure - ignore, return empty string
					return String::Empty;
					//throw gcnew Exception(String::Format(L"Failed to get display name for directory. 0x{0:X8}",hr));
				}

				switch (strDispName.uType) 
				{
					case STRRET_CSTR :
						return gcnew String(strDispName.cStr);
					case STRRET_WSTR :
						return gcnew String(strDispName.pOleStr);
					case STRRET_OFFSET :
						return gcnew String(((char*)m_pidl) + strDispName.uOffset);
					default:
						return String::Empty;
				}
			}

		}

		cli::array<ShellDirectoryInfo^> ^GetDirectories()
		{
			HRESULT hr;
			LPENUMIDLIST pEnumIDL = NULL; // IEnumIDList interface for reading contents
			LPITEMIDLIST pidl; 	

			List<ShellDirectoryInfo^>^ directoryList = gcnew List<ShellDirectoryInfo^>();
			if ((hr = m_pShellFolder->EnumObjects(NULL, SHCONTF_FOLDERS | SHCONTF_INCLUDEHIDDEN, &pEnumIDL)) != S_OK)
			{
				throw gcnew Exception(String::Format(L"Failed to enumerate sub directories. 0x{0:X8}",hr));
			}
			hr = pEnumIDL->Next(1, &pidl, NULL);
			while(hr != S_FALSE) 
			{
				if (hr != NOERROR)
				{
					break;
				}
				
				ShellDirectoryInfo ^childFolder = gcnew ShellDirectoryInfo(m_pShellFolder, pidl);
				directoryList->Add(childFolder);
				hr = pEnumIDL->Next(1, &pidl, NULL);
			}
			pEnumIDL->Release();
			return directoryList->ToArray();
		}
		
		cli::array<ShellFileInfo^> ^ShellDirectoryInfo::GetFiles()
		{
			HRESULT hr;
			LPENUMIDLIST pEnumIDL = NULL; // IEnumIDList interface for reading contents
			LPITEMIDLIST pidl; 	
			
			List<ShellFileInfo^>^ directoryList = gcnew List<ShellFileInfo^>();
			if ((hr = m_pShellFolder->EnumObjects(NULL, SHCONTF_NONFOLDERS | SHCONTF_INCLUDEHIDDEN, &pEnumIDL)) != S_OK)
			{
				throw gcnew Exception(String::Format(L"Failed to enumerate files in directory. 0x{0:X8}",hr));
			}
			hr = pEnumIDL->Next(1, &pidl, NULL);
			while(hr != S_FALSE) 
			{
				if (hr != NOERROR)
				{
					break;
				}
				ShellFileInfo ^file = gcnew ShellFileInfo(this, pidl);
				directoryList->Add(file);
				hr = pEnumIDL->Next(1, &pidl, NULL);
			}
			pEnumIDL->Release();
			return directoryList->ToArray();
		}
	};
}