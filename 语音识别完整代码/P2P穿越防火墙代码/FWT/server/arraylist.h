#ifndef arraylistH
#define arraylistH
#include "common.h"

typedef union arraylist_item {
	struct item {
  	char *value;
  } item;
  unsigned int size;
} ARRAYLIST_ITEM;

typedef struct arraylist {
	ARRAYLIST_ITEM *list;
} ARRAYLIST;

extern ARRAYLIST *arraylist(void);
extern void arraylist_add(ARRAYLIST *al, char *obj);
extern unsigned arraylist_size(ARRAYLIST *al);
extern char *arraylist_get(ARRAYLIST *al, unsigned index);
extern void arraylist_set(ARRAYLIST *al, unsigned index, char *obj);
#endif
