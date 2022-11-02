// SREngine.cpp: implementation of the CSREngine class.
//
//////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "speech.h"
#include "SREngine.h"

#ifdef _DEBUG
#undef THIS_FILE
static char THIS_FILE[]=__FILE__;
#define new DEBUG_NEW
#endif


//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

CSREngine::CSREngine()
{

}

CSREngine::~CSREngine()
{

}
HRESULT CSREngine::InitializeSapi(HWND hWnd, UINT Msg)
{
	HRESULT hr = S_OK;

	//FOR ONE NOT FOR ALL
	hr = m_cpRecognizer.CoCreateInstance( CLSID_SpInprocRecognizer);
	if(FAILED(hr))
	{
		MessageBox(NULL, "Error create recognizer", "Error", MB_OK);
		return hr;
	}

	//create a object for RecoContext
	hr = m_cpRecognizer->CreateRecoContext(&m_cpRecoContext);
	if(FAILED(hr))
	{
		MessageBox(NULL, "Error create recoContext", "Error", MB_OK);
		return hr;
	}

	//msg for speech to notify the application
	hr =  m_cpRecoContext->SetNotifyWindowMessage(hWnd, Msg, 0, 0);

	const ULONGLONG ullInterest = SPFEI(SPEI_RECOGNITION)|SPFEI(SPEI_FALSE_RECOGNITION);
	hr = m_cpRecoContext->SetInterest(ullInterest, ullInterest);
	if(FAILED(hr))
	{
		MessageBox(NULL, "Error set interest", "Error", MB_OK);
		return hr;
	}

	hr = SpCreateDefaultObjectFromCategoryId(SPCAT_AUDIOIN, &m_cpAudio);
	if(FAILED(hr))
	{
		MessageBox(NULL, "Create default audio object error", "Error", MB_OK);
		return hr;
	}

	hr = m_cpRecognizer ->SetInput(m_cpAudio, TRUE);
	if(FAILED(hr))
	{
		MessageBox(NULL, "Error setINPUT", "Error", MB_OK);
		return hr;
	}

}

HRESULT CSREngine::LoadCmdFromFile(CString XMLFileName)
{
	HRESULT hr = S_OK;

	if(!m_cpCmdGrammar)
	{
		//Create a grammar object
		hr = m_cpRecoContext ->CreateGrammar(GID_SRCMD_CN, &m_cpCmdGrammar);
			if(FAILED(hr))
		{
		MessageBox(NULL, "Error Creategammar", "Error", MB_OK);
		return hr;
		}

		WCHAR wszXMLFile[20] = L"";
		//ASNI TO UNICODE
		MultiByteToWideChar(CP_ACP, 0, (LPCSTR)XMLFileName, -1, wszXMLFile, 256);
		//LAOD RULE FROME XML FILE
		hr = m_cpCmdGrammar->LoadCmdFromFile(wszXMLFile, SPLO_DYNAMIC);
			if(FAILED(hr))
	{
		MessageBox(NULL, "Error LoadCmdFromFile", "Error", MB_OK);
		return hr;
	}
	}
	return hr;
}

HRESULT CSREngine::SetRuleState(const WCHAR * pszRuleName, const WCHAR *pszValue, BOOL fActivate)
{
	HRESULT hr = S_OK;

	if(fActivate)
	{
		hr = m_cpCmdGrammar ->SetRuleState(pszRuleName, NULL, SPRS_ACTIVE);
	}
	else
	{
		hr = m_cpCmdGrammar ->SetRuleState(pszRuleName, NULL, SPRS_INACTIVE);
	}
	return hr;

}