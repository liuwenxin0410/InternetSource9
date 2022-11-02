#include "common.h"
#include "init.h"
#include "client_handler.h"
#include "server_loop.h"

int main(int argc, char* argv[])
{
	MASTER_FD master;

	init(argc, argv);
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
  init_master(&master);
#if defined(WIN32) || defined(__WIN32__)
	InitializeCriticalSection(&master.lock);
#else
	master.lock = semget(get_key(), 1, 0666 | IPC_CREAT | IPC_EXCL);
  if(master.lock == -1){
    if(verbose){
      handle_error(__FILE__, __LINE__);
    }
		exit(0);
  }
  
#endif
  server_loop(
  	&client_handler, &get_client_data,  &get_addr, buf, sock_data,
    listen_port, &hello, &master, NULL
  );

	return 0;
}
//---------------------------------------------------------------------------
 