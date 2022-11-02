#include "common.h"
#include "error_handler.h"

char res[64];

char * error_id(void){
  int ee;
  ee =
#if defined(WIN32) || defined(__WIN32__)
  	WSAGetLastError()
#else
  	errno
#endif
	;
  switch(ee){
#if defined(WIN32) || defined(__WIN32__)
    case WSAENOPROTOOPT:
      strcpy(res, "ENOPROTOOPT");
      break;
    case WSAENOTSOCK:
      strcpy(res, "ENOTSOCK");
      break;
    case WSANOTINITIALISED:
      strcpy(res, "WSANOTINITIALISED");
      break;
    case WSAENETDOWN:
      strcpy(res, "ENETDOWN");
      break;
    case WSAEACCES:
      strcpy(res, "EACCES");
      break;
    case WSAEINVAL:
      strcpy(res, "EINVAL");
      break;
    case WSAEINTR:
      strcpy(res, "EINTR");
      break;
    case WSAEINPROGRESS:
      strcpy(res, "EINPROGRESS");
      break;
    case WSAEFAULT:
      strcpy(res, "EFAULT");
      break;
    case WSAENETRESET:
      strcpy(res, "ENETRESET");
      break;
    case WSAENOBUFS:
      strcpy(res, "ENOBUFS");
      break;
    case WSAENOTCONN:
      strcpy(res, "ENOTCONN");
      break;
    case WSAEOPNOTSUPP:
      strcpy(res, "EOPNOTSUPP");
      break;
    case WSAESHUTDOWN:
      strcpy(res, "ESHUTDOWN");
      break;
    case WSAEWOULDBLOCK:
      strcpy(res, "EWOULDBLOCK");
      break;
    case WSAEMSGSIZE:
      strcpy(res, "EMSGSIZE");
      break;
    case WSAEHOSTUNREACH:
      strcpy(res, "EHOSTUNREACH");
      break;
    case WSAECONNABORTED:
      strcpy(res, "CONNABORTED");
      break;
    case WSAECONNRESET:
      strcpy(res, "ECONNRESET");
      break;
    case WSAEADDRNOTAVAIL:
      strcpy(res, "EADDRNOTAVAIL");
      break;
    case WSAEAFNOSUPPORT:
      strcpy(res, "EAFNOSUPPORT");
      break;
    case WSAEDESTADDRREQ:
      strcpy(res, "EDESTADDRREQ");
      break;
    case WSAENETUNREACH:
      strcpy(res, "ENETUNREACH");
      break;
    case WSAETIMEDOUT:
      strcpy(res, "ETIMEDOUT");
      break;
    case WSAEADDRINUSE:
      strcpy(res, "EADDRINUSE");
      break;
    case WSAEBADF:
      strcpy(res, "EBADF");
      break;
#else
    case ENOPROTOOPT:
      strcpy(res, "ENOPROTOOPT");
      break;
    case ENETDOWN:
      strcpy(res, "ENETDOWN");
      break;
    case EACCES:
      strcpy(res, "EACCES");
      break;
    case EINVAL:
      strcpy(res, "EINVAL");
      break;
    case EINTR:
      strcpy(res, "EINTR");
      break;
    case EINPROGRESS:
      strcpy(res, "EINPROGRESS");
      break;
    case EFAULT:
      strcpy(res, "EFAULT");
      break;
    case ENETRESET:
      strcpy(res, "ENETRESET");
      break;
    case ENOBUFS:
      strcpy(res, "ENOBUFS");
      break;
    case ENOTCONN:
      strcpy(res, "ENOTCONN");
      break;
    case ENOTSOCK:
      strcpy(res, "ENOTSOCK");
      break;
    case EOPNOTSUPP:
      strcpy(res, "EOPNOTSUPP");
      break;
    case ESHUTDOWN:
      strcpy(res, "ESHUTDOWN");
      break;
    case EWOULDBLOCK:
      strcpy(res, "EWOULDBLOCK");
      break;
    case EMSGSIZE:
      strcpy(res, "EMSGSIZE");
      break;
    case EHOSTUNREACH:
      strcpy(res, "EHOSTUNREACH");
      break;
    case ECONNABORTED:
      strcpy(res, "ECONNABORTED");
      break;
    case ECONNRESET:
      strcpy(res, "ECONNRESET");
      break;
    case EADDRNOTAVAIL:
      strcpy(res, "EADDRNOTAVAIL");
      break;
    case EAFNOSUPPORT:
      strcpy(res, "EAFNOSUPPORT");
      break;
    case EDESTADDRREQ:
      strcpy(res, "EDESTADDRREQ");
      break;
    case ENETUNREACH:
      strcpy(res, "ENETUNREACH");
      break;
    case ETIMEDOUT:
      strcpy(res, "ETIMEDOUT");
      break;
    case EADDRINUSE:
      strcpy(res, "EADDRINUSE");
      break;
    case EEXIST:
      strcpy(res, "EEXIST");
      break;
    case EIDRM:
      strcpy(res, "EIDRM");
      break;
    case ENOSPC:
      strcpy(res, "ENOSPC");
      break;
    case ENOENT:
      strcpy(res, "ENOENT");
      break;
    case ENOMEM:
      strcpy(res, "ENOMEM");
      break;
    case EBADF:
      strcpy(res, "EBADF");
      break;
#endif
    default:
    	{
  	    sprintf(res, "UNKNOWN: (%d)", errno);
      }
  }
  return res;
}

int handle_error(char *file, int line){
	char *res = error_id();
  printf("[%s:%d] %s\n", file, line, res);
  return 0;
}
