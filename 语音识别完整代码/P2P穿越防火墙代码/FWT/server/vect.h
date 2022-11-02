//---------------------------------------------------------------------------

#ifndef vectH
#define vectH
//---------------------------------------------------------------------------
#include "common.h"
#if !defined(WIN32) && !defined(__WIN32__)
  #include <sys/ipc.h>
  #include <sys/shm.h>
#endif

typedef struct vect {
#if !defined(WIN32) && !defined(__WIN32__)
/*  unsigned flags_id;
	unsigned data_id;*/
	unsigned lock;
#else
 	CRITICAL_SECTION lock;
#endif
//  unsigned *flags;
  unsigned flags[4];
  char *data;
  int sorted;
  int (__cdecl * compare) (const void*, const void*);
} VECTOR;

#define VECTOR_SIZE_FLAG 					1
#define VECTOR_ITEM_WIDTH_FLAG 		2
//#if defined(WIN32) || defined(__WIN32__)
#define VECTOR_CAPACITY_FLAG 		3
//#endif

#
extern VECTOR *create_vector(unsigned initial_capacity, unsigned width, int (__cdecl *cmp)(const void*, const void*));
extern void delete_vector(VECTOR *v);
extern void vector_add(VECTOR *v, void* item);
extern void vector_insert(VECTOR *v, void* item, unsigned i);
extern void vector_delete(VECTOR *v, unsigned i);
extern int vector_bsearch(VECTOR *v, void* key, void* buf, int (__cdecl *replace)(void*, void*),
	void* new_item, int *replaced, int add);
extern void vector_walk(VECTOR *v, void (__cdecl *func)(void*, unsigned, unsigned, void*), void* func_data);
extern void print_item(VECTOR *v, void* name, char *file, int line, void* item);

#endif
