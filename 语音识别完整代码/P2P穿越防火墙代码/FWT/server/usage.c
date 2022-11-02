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
	p = (char*)strrchr(program_name, path_del);
  printf("Usage: %s [options]\n", p == NULL ? program_name : (p + 1));
  printf("Options:\n");
  printf("--help | -h\t\t\tShows this text and exits\n");
  printf("--listen-port | -p\t\tListen port\n");
}
