#include "init.h"

unsigned short listen_port;
char *program_name;
int always_proxy = 0;
int verbose = 0;
int registration_period;
HASHMAP *sock_data;
ARRAYLIST *proxy_data;
char buf[BUFFER_SIZE];    			// buffer for client data

void read_param(char *selector, int argc, char **argv){
	int i;
  if(!strcmp(selector, "-help") || !strcmp(selector, "h")){
  	usage();
    exit(0);
  }
  else if(!strcmp(selector, "-listen-port") || !strcmp(selector, "p")){
	  listen_port = atoi(argv[0]);
  }
  else if(!strcmp(selector, "-always-proxy")){
	  always_proxy = 1;
  }
  else if(!strcmp(selector, "-verbose")){
	  verbose = 1;
  }
  else if(!strcmp(selector, "-registration-period") || !strcmp(selector, "r")){
	  registration_period = atoi(argv[0]);
  }
}

int init(int argc, char* argv[]){
	program_name = argv[0];
  listen_port = LISTEN_PORT;
  always_proxy = 0;
  registration_period = REGISTRATION_PERIOD;
  parse_input_params(argc, argv, read_param);
  tcp_verbose = verbose;
  sock_data = hashmap();
  proxy_data = arraylist();
  return 0;

}

void *get_client_data(SOCKET sock, struct sockaddr_in addr){
	CLIENT_DATA *res = (CLIENT_DATA*)malloc(sizeof(CLIENT_DATA));
  memset(res, 0, sizeof(CLIENT_DATA));
  res->sock = sock;
  res->addr = addr;
  res->step = CLIENT_CONNECTED;
  res->client_type == CLIENT_TYPE_UNKNOWN;
  res->legal = 0;
if(tcp_verbose){printf("[%s,%d] %d\n", __FILE__, __LINE__, res->step);}
  return res;
}

struct sockaddr_in get_addr(void* client_data){
	return ((CLIENT_DATA *)client_data)->addr;
}

char *hello(void){
	return (char*)strdup(sHello);
}

