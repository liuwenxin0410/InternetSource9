#include <signal.h>
#include "init.h"
#include "input_params.h"
#include "usage.h"
#include "server_loop.h"


#ifdef AUTH
int has_key_pair = 0;
char public_key[PUBLIC_KEY_LEN];
char private_key[PUBLIC_KEY_LEN];
#endif

unsigned short listen_port;
struct sockaddr_in server_addr;
char *listen_address;
char *program_name;
int registration_period;
char *proxyname = NULL;
int registration_timeout = 3;
int verbose = 0;
char buf[BUFFER_SIZE];    			// buffer for client data
HASHMAP *sock_data;

void read_param(char *selector, int argc, char **argv){
	int i;
  if(!strcmp(selector, "-help") || !strcmp(selector, "h")){
  	usage();
    exit(0);
  }
  else if(!strcmp(selector, "-server-address") || !strcmp(selector, "A")){
	  server_addr.sin_addr.s_addr = inet_addr(argv[0]);
  }
  else if(!strcmp(selector, "-server-port") || !strcmp(selector, "P")){
	  server_addr.sin_port = htons(atoi(argv[0]));
  }
  else if(!strcmp(selector, "-listen-port") || !strcmp(selector, "p")){
	  listen_port = atoi(argv[0]);
  }
  else if(!strcmp(selector, "-listen-address") || !strcmp(selector, "a")){
	  listen_address = argv[0];
  }
  else if(!strcmp(selector, "-verbose")){
	  verbose = 1;
    tcp_verbose = 1;
  }
  else if(!strcmp(selector, "-name") || !strcmp(selector, "n")){
  	proxyname = strdup(argv[0]);
  }
}

int init(int argc, char* argv[]){
  CLIENT_DATA *timer_data;
	struct sockaddr_in timer_addr;

	program_name = argv[0];
  listen_port = LISTEN_PORT;
  listen_address = LISTEN_ADDRESS;
  server_addr.sin_family = AF_INET;
  server_addr.sin_port = htons(SERVER_PORT);
  registration_period = 60;
  parse_input_params(argc, argv, read_param);
#ifdef AUTH
	if(proxyname != NULL){
  	if(
    	(open_public_key(proxyname, public_key) == 0)
      && (open_private_key(proxyname, private_key) == 0)
    ){
      has_key_pair = 1;
    }
    else {
    	printf("[%s,%d] Key pair \"%s\" not found! Exiting.\n", __FILE__,__LINE__, proxyname);
      exit(-1);
    }
  }
#endif
  sock_data = hashmap();
  return 0;
}

char *hello(void){
	return strdup(pHello);
}

struct sockaddr_in get_addr(void* client_data){
	return ((CLIENT_DATA *)client_data)->addr;
}


