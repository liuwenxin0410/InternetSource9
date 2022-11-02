#include "arraylist.h"

ARRAYLIST *arraylist(void){
	ARRAYLIST *res = (ARRAYLIST *)malloc(sizeof(ARRAYLIST));
	res->list = (ARRAYLIST_ITEM *)malloc(sizeof(ARRAYLIST_ITEM));
	memset(res->list, 0, sizeof(ARRAYLIST_ITEM));
  	return res;
}

void arraylist_add(ARRAYLIST *al, char *obj){
	al->list = (ARRAYLIST_ITEM *)realloc(al->list, (al->list[0].size + 1) * sizeof(ARRAYLIST_ITEM));
  	memset(&al->list[al->list[0].size + 1], 0, sizeof(ARRAYLIST_ITEM));
  	al->list[0].size++;
  	al->list[al->list[0].size].item.value = obj;

}

unsigned arraylist_size(ARRAYLIST *al){
	return al->list[0].size;
}

char *arraylist_get(ARRAYLIST *al, unsigned index){
	return al->list[index + 1].item.value;
}

void arraylist_set(ARRAYLIST *al, unsigned index, char *obj){
	al->list[index + 1].item.value = obj;
}

