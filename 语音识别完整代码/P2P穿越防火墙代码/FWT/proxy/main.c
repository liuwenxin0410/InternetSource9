#include "common.h"
#include "init.h"
#include "client_handler.h"
#include "server_loop.h"

MASTER_FD master;

int main(int argc, char* argv[])
{

#if defined(WIN32) || defined(__WIN32__)
  {
    char buff[1024];
    if (WSAStartup(0x0202,(WSADATA *) &buff[0]))
    {
      if(verbose){
        handle_error(__FILE__, __LINE__);
      }
      return -1;

    }
  }
#endif
	init(argc, argv);
  init_master(&master);
#if defined(WIN32) || defined(__WIN32__)
	InitializeCriticalSection(&master.lock);
#endif
  server_loop(
  	&client_handler, &get_client_data, &get_addr, buf, sock_data,
	  listen_port, &hello, &master, &timer_event
  );

	return 0;
}

void *get_client_data(SOCKET sock, struct sockaddr_in addr){
	CLIENT_DATA *res = (CLIENT_DATA*)malloc(sizeof(CLIENT_DATA));
  memset(res, 0, sizeof(CLIENT_DATA));
  res->sock = sock;
  res->addr = addr;
  res->client_type = CLIENT_TYPE_CLIENT;
  if(!has_key_pair){
  	res->authorized = 1;
  }
  return res;
}

 
