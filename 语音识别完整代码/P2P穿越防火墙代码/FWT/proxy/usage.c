#include "usage.h"
#include "init.h"

void usage(void){
	char path_del;
	char *p;
#if defined(WIN32) || defined(__WIN32__)
	path_del = '\\';
#else
	path_del = '/';
#endif
	p = strrchr(program_name, path_del);
  printf("Usage: %s [options]\n", p == NULL ? program_name : (p + 1));
  printf("Options:\n");
  printf("--help | -h\t\t\tShows this text and exits\n");
  printf("--server-address | -A\t\tServer address\n");
  printf("--server-port | -P\t\tServer port\n");
  printf("--listen-port | -p\t\tListen port\n");
  printf("--listen-address | -p\t\tLocal address\n");
  printf("--name | -n\t\tProxy name\n");
  printf("--registration-period | -r\tTime period between registartions on server (sec)\n");
  printf("--maximum_clients | -r\tNumber of maximium clients\n");
}
