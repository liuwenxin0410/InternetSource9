#ifndef commonH
#define commonH
	#include <stdlib.h>
	#include <stdio.h>
	#include <time.h>
	#include <string.h>
#if defined(WIN32) || defined(__WIN32__) || defined(_WIN32)
	#include <winsock2.h>
  #include <process.h>
  #include <windows.h>
  #define sleep(x) Sleep((x)*1000)
  #define close(x) closesocket(x)

#else
  #include <errno.h>
  #include <unistd.h>
  #include <sys/types.h>
  #include <sys/socket.h>
  #include <sys/select.h>
  #include <netinet/in.h>
  #include <arpa/inet.h>
	#include <pthread.h>
  # include <sys/ipc.h>
  typedef unsigned int SOCKET;
	typedef void * LPVOID;
	typedef unsigned long	    DWORD;
  #define closesocket(x) close(x)
  #ifndef __cdecl
     #define __cdecl
  #endif
#endif
#include "error_handler.h"
#define BUFFER_SIZE (65*1024)
#define SELECT_TIMEOUT_SEC 0
#define SELECT_TIMEOUT_USEC 500000

#if !defined(WIN32) && !defined(__WIN32__)
key_t get_key(void);
#endif

  #define PROXY_SOCKET_FUNCTIONS
  #define AUTH
  #define OVER_TCP
#endif
