// SREngine.h: interface for the CSREngine class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_SRENGINE_H__D34D7DDC_8AEF_4CD1_BA3A_CB36368A4CDC__INCLUDED_)
#define AFX_SRENGINE_H__D34D7DDC_8AEF_4CD1_BA3A_CB36368A4CDC__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000
#include "atlbase.h"
#include "sapi.h"
#include "sphelper.h"
#define GID_SRCMD_CN 1234
class CSREngine  
{
public:
	//speech varibale
	CComPtr <ISpRecognizer> m_cpRecognizer;
	CComPtr <ISpRecoContext> m_cpRecoContext;
	CComPtr <ISpRecoGrammar> m_cpCmdGrammar;

	//audio variable
	CComPtr <ISpAudio> m_cpAudio;

public:
	CSREngine();
	virtual ~CSREngine();
public:
	HRESULT SetRuleState(const WCHAR * pszRuleName, const WCHAR *pszValue, BOOL fActivate);
	HRESULT LoadCmdFromFile(CString XMLFileName);
	HRESULT InitializeSapi(HWND hWnd, UINT Msg);

};

#endif // !defined(AFX_SRENGINE_H__D34D7DDC_8AEF_4CD1_BA3A_CB36368A4CDC__INCLUDED_)
