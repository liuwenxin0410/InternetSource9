CC	= g++

all: peerio_srv

clean:
	rm -fr  *.o *.d peerio_srv


search_wildcard  s := $(addsuffix /*.c,.)
objs := $(patsubst   %.c,%.o,$(wildcard   $(search_wildcard  s)))

peerio_srv: $(notdir $(objs))
	$(CC)  $^ -o $(subst .,../,$@) -lpthread

%.o: %.cpp
	$(CC) -c  -MD $(addprefix -I ,.) $<

include $(wildcard   *.d)


