 // MainDlg.cpp : implementation file
//

#include "stdafx.h"
#include "speech.h"
#include "MainDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CMainDlg dialog


CMainDlg::CMainDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CMainDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CMainDlg)
		// NOTE: the ClassWizard will add member initialization here
	//}}AFX_DATA_INIT
}


void CMainDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CMainDlg)
		// NOTE: the ClassWizard will add DDX and DDV calls here
	//}}AFX_DATA_MAP
}


BEGIN_MESSAGE_MAP(CMainDlg, CDialog)
	//{{AFX_MSG_MAP(CMainDlg)
		ON_MESSAGE(WM_RECOEVENT, OnRecoEvent)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CMainDlg message handlers

int CMainDlg::DoModal() 
{
	// TODO: Add your specialized code here and/or call the base class
	
	return CDialog::DoModal();
}


void CMainDlg::OnRecoEvent(WPARAM wParam, LPARAM lParam)
{
	USES_CONVERSION;
	CSpEvent event;

	HRESULT hr = S_OK;
	if(m_SREngine.m_cpRecoContext)
	{
		while(event.GetFrom(m_SREngine.m_cpRecoContext) == S_OK)
		{
			//Get the ID
			switch(event.eEventId)
			{
			case SPEI_FALSE_RECOGNITION:
				break;
			case SPEI_HYPOTHESIS:
			case SPEI_RECOGNITION:
				  {
					  CComPtr <ISpRecoResult> cpResult;

					  CSpDynamicString dstrText;
					  CString strResult;

					  cpResult = event.RecoResult();

					  {
						  cpResult ->GetText(SP_GETWHOLEPHRASE, SP_GETWHOLEPHRASE, TRUE, &dstrText, NULL);

					  }
					  
					  strResult = W2T(dstrText);
					  ::MessageBox(NULL, strResult, "teXT", MB_OK);
					  if(strResult == CString("关闭"))
					  {
						  OnOK();
					  }
					  else if(strResult == CString("打开") )
					  {
						  ::MessageBox(NULL, "open", "识别结果", MB_OK);
					  }

					  else if(strResult == CString("电脑") )
					  {
						  ::MessageBox(NULL, "computer", "识别结果", MB_OK);
					  }
					 cpResult.Release();
				  }

				break;
			default:
				break;
			}
		}
	}
} 

BOOL CMainDlg::OnInitDialog() 
{
	CDialog::OnInitDialog();
	
	// TODO: Add extra initialization here
	HRESULT hr = m_SREngine.InitializeSapi(this->GetSafeHwnd(), WM_RECOEVENT);
	if(FAILED(hr))
	{
		return FALSE;
	}

	hr = m_SREngine.LoadCmdFromFile("CmdCtrl.xml");
	if(FAILED(hr))
	{
		//::MessageBox(NULL, "HERE","OK",MB_OK);
		return FALSE;
	}

	hr = m_SREngine.SetRuleState(NULL, NULL, TRUE);
	if(FAILED(hr))
	{
		return FALSE;
	}

	return TRUE;  // return TRUE unless you set the focus to a control
	              // EXCEPTION: OCX Property Pages should return FALSE
}
