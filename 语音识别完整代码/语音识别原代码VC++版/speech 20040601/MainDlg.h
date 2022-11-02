#if !defined(AFX_MAINDLG_H__9C470F0A_5F50_4E18_BBC6_0CFD390783CA__INCLUDED_)
#define AFX_MAINDLG_H__9C470F0A_5F50_4E18_BBC6_0CFD390783CA__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000
#define  WM_RECOEVENT WM_USER+100
#include "srengine.h"
// MainDlg.h : header file
//


/////////////////////////////////////////////////////////////////////////////
// CMainDlg dialog

class CMainDlg : public CDialog
{
// Construction
public:
	CMainDlg(CWnd* pParent = NULL);   // standard constructor
public:
CSREngine m_SREngine;
// Dialog Data
	//{{AFX_DATA(CMainDlg)
	enum { IDD = IDD_DIG_MAIN };
		// NOTE: the ClassWizard will add data members here
	//}}AFX_DATA


// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CMainDlg)
	public:
	virtual int DoModal();
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:

	// Generated message map functions
	//{{AFX_MSG(CMainDlg)
	afx_msg void OnRecoEvent(WPARAM wParam, LPARAM lParam);
	virtual BOOL OnInitDialog();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_MAINDLG_H__9C470F0A_5F50_4E18_BBC6_0CFD390783CA__INCLUDED_)
