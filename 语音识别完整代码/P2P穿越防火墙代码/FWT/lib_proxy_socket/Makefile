
PROXY_SOCKET_FUNCTIONS = -DPROXY_SOCKET_FUNCTIONS
OVER_TCP	       = -DOVER_TCP
AUTH	               = -DAUTH

ifeq (,$(PROJECT_ROOT))
PROJECT_ROOT = $(shell pwd)/../..
endif
#ifneq (,$(PLATFORM))
include ../../COMMON/common.mk
#endif

LIBDIR := $(addsuffix /, $(lib))
lib    := $(addsuffix /, $(LIBDIR))lib_proxy_socket.a
objdir := $(addsuffix /FWT/, $(objroot))
c_ext  = c

ifneq ($(AUTH),)
	BORZOI		= ../../External/borzoi_c
	IBORZOI		= -I$(BORZOI)
	LIBBORZOI	= $(LIBDIR)/libborzoi.a
endif

sources := arraylist common error_handler hashmap input_params \
           protocol server_loop vect proxy_socket

ifneq (,$(AUTH))
sources += authenticating 
endif

objs = $(patsubst %, $(objdir)%.o, $(sources))
deps = $(patsubst %, $(objdir)%.d, $(sources))

all: $(LIBDIR) $(objdir) $(lib)
$(LIBDIR) $(objdir):
	mkdir -p $@
clean:
	rm -fr  $(objdir)*.d $(objdir)*.o $(lib)

$(lib): $(objs)
	@echo Create $@
	@ar rc $@ $^
	@ranlib $@

$(deps) : $(objdir)

$(objs): $(objdir)%.o : %.$(c_ext)
	@echo Compile $<
	$(CC) -g -c $< -o $@ $(OVER_TCP) $(AUTH) $(PROXY_SOCKET_FUNCTIONS) $(IBORZOI) $(addprefix -I ,.)

include $(deps)

$(deps): $(objdir)%.d : %.$(c_ext)
	@echo Make dep for $<
	$(CC) $< -M $(OVER_TCP) $(AUTH) $(PROXY_SOCKET_FUNCTIONS) $(IBORZOI) $(addprefix -I ,.) > $@
