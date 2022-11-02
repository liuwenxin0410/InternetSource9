#ifndef hashmapH
#define hashmapH
#include "common.h"

typedef struct hashmap_entry {
  	struct hashmap_entry *next;
	unsigned int key;
	char *value;
} HASHMAP_ENTRY;

typedef struct hashmap {
	HASHMAP_ENTRY *list[1024];
} HASHMAP;

extern HASHMAP *hashmap(void);
extern void hashmap_put(HASHMAP *hm, unsigned int key, void *value);
extern void* hashmap_get(HASHMAP *hm, unsigned int key);
extern void* hashmap_remove(HASHMAP *hm, unsigned int key);
extern void hashmap_free(HASHMAP *hm);
extern void hashmap_print(HASHMAP *hm, void (*print_value)(char*));

#endif
