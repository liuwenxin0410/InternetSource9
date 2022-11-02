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
  #define delay(x) Sleep(x)
  #define ERRNO_EQUALS(val) (WSAGetLastError() == (val))
  #define HAS_SOCKET_ERROR(expr) ((expr) == SOCKET_ERROR)
  #define SOCKET_IS_INVALID(expr) ((expr) == INVALID_SOCKET)
  #define EINTR WSAEINTR
  #define ECONNRESET WSAECONNRESET
  #define EADDRINUSE WSAECONNRESET
#else
  #define delay(x) usleep(x*1000)
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
        typedef unsigned long       DWORD;
  #define closesocket(x) close(x)
  #ifndef __cdecl
     #define __cdecl
  #endif
  #define ERRNO_EQUALS(val) (errno == (val))
  #define HAS_SOCKET_ERROR(expr) ((expr) < 0)
  #define SOCKET_IS_INVALID(expr) ((expr) < 0)
#endif
#include "error_handler.h"
#define BUFFER_SIZE (65*1024)
#define SELECT_TIMEOUT_SEC 0
#define SELECT_TIMEOUT_USEC 500000
#define FW_DELAY_MSEC 100

#if !defined(WIN32) && !defined(__WIN32__)
key_t get_key(void);
#endif

#ifndef PROXY_SOCKET_FUNCTIONS
#define PROXY_SOCKET_FUNCTIONS
#endif

#ifndef AUTH
#define AUTH
#endif

#ifndef OVER_TCP
#define OVER_TCP
#endif

#endif

