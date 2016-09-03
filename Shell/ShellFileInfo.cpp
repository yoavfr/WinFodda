#include "stdafx.h"

#include "IShellDirectoryInfo.h"
#include "ShellFileInfo.h"

namespace Fodda
{
	
		ShellFileInfo::ShellFileInfo(IShellDirectoryInfo ^parent, LPITEMIDLIST pidl)
		{
			HRESULT hr;
			m_Parent = parent;
			m_pidl = pidl;
			LPMALLOC pMalloc;
			if ((hr=SHGetMalloc(&pMalloc)) != S_OK)
			{
				throw gcnew Exception(String::Format(L"Failed to obtain Malloc. 0x{0:X8}",hr));
			}
			m_pMalloc = pMalloc;
		}

		ShellFileInfo::~ShellFileInfo()
		{
			m_pMalloc->Free(m_pidl);
			m_pMalloc->Release();
		}

		String^ ShellFileInfo::FullName::get()
		{
			HRESULT hr;
			if (m_FullName != nullptr)
			{
				return m_FullName;
			}
			STRRET strDispName;
			if ((hr = m_Parent->ShellFolder->GetDisplayNameOf(m_pidl, SHGDN_FORPARSING | SHGDN_FORADDRESSBAR, &strDispName)) != S_OK)
			{
				// this reports failure - ignore
				//throw gcnew Exception(String::Format(L"Failed to get display name. 0x{0:X8}",hr));
				return String::Empty;
			}

			switch (strDispName.uType) 
			{
				case STRRET_CSTR :
					m_FullName = gcnew String(strDispName.cStr);
					break;
				case STRRET_WSTR :
					m_FullName = gcnew String(strDispName.pOleStr);
					break;
				case STRRET_OFFSET :
					m_FullName = gcnew String(((char*)m_pidl) + strDispName.uOffset);
					break;
				default:
					m_FullName = String::Empty;
			}
			return m_FullName;
		}	

		DateTime^ ShellFileInfo::GetCreationTime()
		{
			HRESULT hr;
			PROPERTYKEY propertyKey;
			propertyKey.fmtid = FMTID_ImageProperties;
			propertyKey.pid = PID_FIRST_USABLE;
			VARIANT variant;

			if ((hr = m_Parent->ShellFolder->GetDetailsEx(m_pidl, &PKEY_DateCreated , &variant)) != S_OK)
			{
				throw gcnew Exception(String::Format(L"Failed to get shell folder details. 0x{0:X8}",hr));
			}
			COleDateTime *dateTime = new COleDateTime(variant.date);
			DateTime^ creationTime = gcnew DateTime(dateTime->GetYear(),dateTime->GetMonth(),dateTime->GetDay(),dateTime->GetHour(),dateTime->GetMinute(),dateTime->GetSecond());
			delete(dateTime);
			return creationTime;
		}

		void ShellFileInfo::CopyTo(String^ destination)
		{
			HRESULT hr;
			LPSTREAM sourceStream;
			LPSTREAM destinationStream;
			::STATSTG statInfo = {0};
			
			IntPtr ptr = Marshal::StringToHGlobalUni(destination);
			
			// create destination stream
			if ((hr = SHCreateStreamOnFile((LPCWSTR)ptr.ToPointer(), STGM_WRITE | STGM_CREATE, &destinationStream)) != S_OK)
			{
				throw gcnew Exception(String::Format(L"Failed to create destination stream. 0x{0:X8}",hr));
			}

			// bind to storage
			if ((hr = m_Parent->ShellFolder->BindToStorage(m_pidl, NULL, IID_IStream, (void**)&sourceStream)) != S_OK)
			{
				throw gcnew Exception(String::Format(L"Failed to bind to source file storage. 0x{0:X8}",hr));
			}

			// copy source to destination
			if ((hr = sourceStream->Stat(&statInfo, STATFLAG_NONAME )) != S_OK)
			{
				throw gcnew Exception(String::Format(L"Failed to obtains source stream stat. 0x{0:X8}",hr));
			}
			if ((hr = sourceStream->CopyTo(destinationStream, statInfo.cbSize, NULL, NULL)) != S_OK)
			{
				throw gcnew Exception(String::Format(L"Failed to copy to destination stream. 0x{0:X8}",hr));
			}
			if ((hr = destinationStream->Commit(0)) != S_OK)
			{
				throw gcnew Exception(String::Format(L"Failed to commit copy. 0x{0:X8}",hr));
			}
			
			sourceStream->Release();
			destinationStream->Release();

			Marshal::FreeHGlobal(ptr);
			//CoTaskMemFree(sourceStream);
			//m_pMalloc->Free(sourceStream);
			//m_pMalloc->Free(destinationStream);
		}
		
		Image^ ShellFileInfo::GetThumbnail(Size^ size)
		{
			HRESULT hr;
			LPEXTRACTIMAGE extractImage;
			LPCITEMIDLIST pidls[1];
			pidls[0] = m_pidl;
			
			// get UI object
			if ((hr = m_Parent->ShellFolder->GetUIObjectOf(NULL, 1, pidls, IID_IExtractImage, NULL, (void**)&extractImage)) != S_OK)
			{
				throw gcnew Exception(String::Format(L"Failed to obtain UI object (thumbnail). 0x{0:X8}",hr));
			}
			
			SIZE cSize;
			cSize.cx = size->Width;
			cSize.cy = size->Height;

			HBITMAP bitmap;
			WCHAR  pathBuffer[MAX_PATH];
			DWORD flags = IEIFLAG_ORIGSIZE | IEIFLAG_QUALITY | IEIFLAG_ASPECT;
			DWORD priority;

			// Extract the bitmap
			if ((hr = extractImage->GetLocation(pathBuffer, MAX_PATH, &priority, &cSize, 32, &flags)) != S_OK)
			{
				throw gcnew Exception(String::Format(L"Failed to get location of extracted image. 0x{0:X8}",hr));
			}
			if ((hr = extractImage->Extract(&bitmap)) != S_OK)
			{
				throw gcnew Exception(String::Format(L"Failed to extract bitmap. 0x{0:X8}",hr));
			}

			Image^ image = Bitmap::FromHbitmap((IntPtr)bitmap);

			extractImage->Release();
			//m_pMalloc->Free(&extractImage);
			return image;
		}




	


}