#ifndef authH
#define authH
#include "common.h"
#include "init.h"
#include "client_handler.h"
#include "borzoi_c.h"

extern int auth_1(CLIENT_DATA *cd, int nsize);
extern int auth_2(CLIENT_DATA *cd, int nsize);

#endif
