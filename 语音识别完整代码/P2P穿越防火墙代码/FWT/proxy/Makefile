PROXY_SOCKET_FUNCTIONS = -DPROXY_SOCKET_FUNCTIONS
OVER_TCP	= -DOVER_TCP
AUTH	= -DAUTH

ifeq (,$(PROJECT_ROOT))
PROJECT_ROOT = $(shell pwd)/../..
endif
include ../../COMMON/common.mk

ifneq ($(AUTH),)
	BORZOI		= ../../External/borzoi_c
	IBORZOI		= -I$(BORZOI)
	LIBBORZOI	= $(lib)/libborzoi.a
endif

bin    = $(out)/peerio_ps
objdir = $(objroot)/FWT/proxy/
c_ext  = c

sources = arraylist client_handler common error_handler hashmap init \
          input_params main protocol server_loop usage vect

ifneq (,$(AUTH))
sources += auth
endif

ifneq (,$(OVER_TCP))
sources += over_tcp
endif

objs = $(patsubst %, $(objdir)%.o, $(sources))
deps = $(patsubst %, $(objdir)%.d, $(sources))

all: $(out) $(objdir) $(bin)

$(out) $(objdir):
	mkdir -p $@

clean:
	rm -fr  $(objdir)*.d $(objdir)*.o $(bin)

$(bin): $(objs)
	@echo Link $@
	$(CXX) -o $@ $^ $(LIBBORZOI) -lpthread 

$(deps): $(objdir)

$(objs): $(objdir)%.o : %.$(c_ext)
	@echo Compile $<
	$(CC) -c $< -o $@ $(OVER_TCP) $(AUTH) $(PROXY_SOCKET_FUNCTIONS) $(IBORZOI) $(addprefix -I ,.)

include $(deps)
$(deps): $(objdir)%.d : %.$(c_ext)
	$(CC) $< -M $(OVER_TCP) $(AUTH) $(PROXY_SOCKET_FUNCTIONS) $(IBORZOI) $(addprefix -I ,.) > $@
