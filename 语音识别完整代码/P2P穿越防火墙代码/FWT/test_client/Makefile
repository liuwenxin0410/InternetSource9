ifeq (,$(PROJECT_ROOT))
PROJECT_ROOT = $(shell pwd)/../..
endif

include ../../COMMON/common.mk

CC := g++

all: test_cl

clean:
	rm -fr   *.o *.d test_cl

search_wildcard  s := $(addsuffix /*.c,.)
objs := $(patsubst   %.c,%.o,$(wildcard   $(search_wildcard  s)))

test_cl: $(notdir $(objs)) ../../LIB/$(PLATFORM)/lib_proxy_socket.a ../../LIB/$(PLATFORM)/libborzoi.a
	$(CC)  -o $@ $^  -lpthread


%.o: %.c
	$(CC) -c  -MD $(addprefix -I ,. ../lib_proxy_socket) $<

include $(wildcard   *.d)


