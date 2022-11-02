#include "common.h"
#include "arraylist.h"

#if !defined(WIN32) && !defined(__WIN32__)
ARRAYLIST *keylist;

static int started = 0;

void clean_keylist(void){
	int i;
	for(i = 0; i < arraylist_size(keylist); i++){
  	char *tmp = (char*)arraylist_get(keylist, i);
  	unlink(tmp);
    free(tmp);
  }
  free(keylist->list);
  free(keylist);
}

key_t get_key(void){
	char temp[255];
  strcpy(temp, "/tmp/pckeyXXXXXX");
  if(mkstemp(temp) != -1){
    if(!started){
    	keylist = arraylist();
      started = 1;
    }
    arraylist_add(keylist, strdup(temp));
		return ftok(temp, getpid());
  }
  return -1;
}
#endif

