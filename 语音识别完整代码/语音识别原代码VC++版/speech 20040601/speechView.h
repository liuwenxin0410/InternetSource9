// speechView.h : interface of the CSpeechView class
//
/////////////////////////////////////////////////////////////////////////////

#if !defined(AFX_SPEECHVIEW_H__120BA0ED_EDE8_4652_9C03_BD6426F053CC__INCLUDED_)
#define AFX_SPEECHVIEW_H__120BA0ED_EDE8_4652_9C03_BD6426F053CC__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000


class CSpeechView : public CView
{
protected: // create from serialization only
	CSpeechView();
	DECLARE_DYNCREATE(CSpeechView)

// Attributes
public:
	CSpeechDoc* GetDocument();

// Operations
public:

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CSpeechView)
	public:
	virtual void OnDraw(CDC* pDC);  // overridden to draw this view
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
	protected:
	virtual BOOL OnPreparePrinting(CPrintInfo* pInfo);
	virtual void OnBeginPrinting(CDC* pDC, CPrintInfo* pInfo);
	virtual void OnEndPrinting(CDC* pDC, CPrintInfo* pInfo);
	//}}AFX_VIRTUAL

// Implementation
public:
	virtual ~CSpeechView();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// Generated message map functions
protected:
	//{{AFX_MSG(CSpeechView)
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

#ifndef _DEBUG  // debug version in speechView.cpp
inline CSpeechDoc* CSpeechView::GetDocument()
   { return (CSpeechDoc*)m_pDocument; }
#endif

/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_SPEECHVIEW_H__120BA0ED_EDE8_4652_9C03_BD6426F053CC__INCLUDED_)
