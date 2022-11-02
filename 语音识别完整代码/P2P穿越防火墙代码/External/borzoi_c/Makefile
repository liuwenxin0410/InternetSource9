
ifeq (,$(PLATFORM))
include ../../arch.mk
PROJECT_ROOT = $(shell pwd)/../..
endif
include ../../COMMON/common.mk


OBJDIR = $(shell pwd)/../../OBJ/$(PLATFORM)/BORZOI
LIBDIR = $(shell pwd)/../../LIB/$(PLATFORM)
BINDIR = $(shell pwd)/../../BIN/$(PLATFORM)

bin   = $(BINDIR)/genpair
alib  = $(LIBDIR)/libborzoi.$(aext)
solib = $(LIBDIR)/libborzoi.$(soext)

.PHONY: all clean

ifeq (yes,$(SOLIB))
all: $(BINDIR) $(OBJDIR) $(LIBDIR) $(bin) $(solib)
else
all: $(BINDIR) $(OBJDIR) $(LIBDIR) $(bin)
endif

clean:
	rm -fr  $(OBJDIR)/*.o $(OBJDIR)/*.d $(bin) $(alib) $(solib)

cpp_sources = \
aes.cpp          ecdsa.cpp        ec_primitives.cpp    \
asn.cpp          ecies.cpp        hash.cpp             \
borzoi_c.cpp     eckas_dh1.cpp    curve.cpp            \
ec_key_pair.cpp  math_mpi.cpp     utilities.cpp

c_sources = mpi.c rng.c rijndael-alg-fst.c

cpp_objs := $(patsubst   %.cpp, $(OBJDIR)/%.o, $(cpp_sources))
c_objs   := $(patsubst   %.c,   $(OBJDIR)/%.o, $(c_sources))
cpp_deps := $(patsubst   %.cpp, $(OBJDIR)/%.d, $(cpp_sources))
c_deps   := $(patsubst   %.c,   $(OBJDIR)/%.d, $(c_sources))

$(alib): $(c_objs) $(cpp_objs) ../include/borzoi_c.h
	ar rc $@ $(cpp_objs) $(c_objs)
	ranlib $@

$(solib): $(c_objs) $(cpp_objs) ../include/borzoi_c.h
	$(CXX) $(CFLAGS) --shared -o $@ $(cpp_objs) $(c_objs)

$(bin): $(OBJDIR)/main.o $(alib)
	$(CXX) $(CFLAGS) -o $@ $(OBJDIR)/main.o $(alib)

$(cpp_objs): $(OBJDIR)/%.o: %.cpp
	@echo Compile $<
	$(CXX) $(CFLAGS) -o $@ -c $<

$(c_objs) $(OBJDIR)/main.o: $(OBJDIR)/%.o: %.c
	@echo Compile $<
	$(CC) $(CFLAGS) -o $@ -c $<

../include/borzoi_c.h: borzoi_c.h
	cp -rf $< $@

$(cpp_deps): $(OBJDIR)/%.d: %.cpp
	@echo Make dependancy for $<
	$(CXX) $(CFLAGS) $< -MM -MT $(patsubst %.d,%.o,$@) -MF $@

$(c_deps) $(OBJDIR)/main.d: $(OBJDIR)/%.d: %.c
	@echo Make dependancy for $<
	$(CC) $(CFLAGS)  $< -MM -MT $(patsubst %.d,%.o,$@) -MF $@

$(OBJDIR)/main.d $(c_deps) $(cpp_deps): $(OBJDIR)

$(BINDIR) $(OBJDIR) $(LIBDIR):
	mkdir -p $@

include $(c_deps) $(cpp_deps) $(OBJDIR)/main.d


