#include "input_params.h"

void parse_input_params(int argc, char **argv, void (__cdecl *func)(char*, int, char**)){
	char **p, **last;
  	char *selector = "";
  	int n = 0;
  	int start = 1;
  	last = p = argv + 1;
  	while((p - argv) < argc){
    	char *pp = (char*)strchr(*p, '-');
    	if(pp == *p){
      		if(!start){
      			func(selector, n, last);
      		}
      		n = 0;
      		selector = (*p + 1);
      		last = p + 1;
      		start = 0;
    	}
    	else {
    		n++;
    	}
    	p++;
  	}
	func(selector, n, last);
}

