#include "hashmap.h"

HASHMAP *hashmap(void){
  HASHMAP *res = (HASHMAP*)malloc(sizeof(HASHMAP));
  int i;
  memset(res, 0, sizeof(HASHMAP));
  for(i = 0; i < 1024; i++){
  	res->list[i] = NULL;
  }
  return res;
}

void hashmap_put(HASHMAP *hm, unsigned int key, void *value){
  unsigned int hash = key % 1024;

  HASHMAP_ENTRY *ptr = hm->list[hash];
  while(ptr != NULL){
    if(ptr->key == key){
    	ptr->value = (char*)value;
    	return;
    }
    ptr = ptr->next;
  }

  ptr = (HASHMAP_ENTRY*)malloc(sizeof(HASHMAP_ENTRY));
  ptr->next = hm->list[hash];
  ptr->key = key;
  ptr->value = (char*)value;

  hm->list[hash] = ptr;
}

void* hashmap_get(HASHMAP *hm, unsigned int key){
  unsigned int hash = key % 1024;

  HASHMAP_ENTRY *ptr = hm->list[hash];
  while(ptr != NULL){
    if(ptr->key == key){
    	return ptr->value;
    }
    ptr = ptr->next;
  }

  return NULL;
}

void *hashmap_remove(HASHMAP *hm, unsigned int key){
  unsigned int hash = key % 1024;
  void *res;

  HASHMAP_ENTRY *ptr = hm->list[hash];
  while(ptr != NULL){
    if(ptr->key == key){
    	res = ptr->value;
    	ptr->value = NULL;
      return res;
    }
    ptr = ptr->next;
  }
  return NULL;

}

void hashmap_print(HASHMAP *hm, void (__cdecl *print_value)(char*)){
	int i, j, n = 0;
  if(hm == NULL){
  	return;
  }
  printf("[");
  for(j = 0; j < 1024; j++){
	  HASHMAP_ENTRY *ptr = hm->list[j];
  	while(ptr != NULL){
      if(ptr->value != NULL){
	    	if(n > 0){
  	    	printf(", ");
    	  }
        printf("%d", ptr->key);
        if(print_value != NULL){
          print_value(ptr->value);
        }
        n++;
      }
	    ptr = ptr->next;
    }
  }
  printf("]\n");
}


