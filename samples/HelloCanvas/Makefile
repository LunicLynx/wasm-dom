TOP=$(realpath $(CURDIR)/../..)

#Use either ' ' or '--debugrt' dependending on what you need
DRIVER_CONF=--debugrt
#DRIVER_CONF=

#Use either 'release' or 'debug' dependending on what you need
DOM_CONF=debug

WASM_SDK=$(TOP)/mono/sdks/
WASM_SDK_FRAMEWORK=$(TOP)/mono/sdks/framework
WASM_SDK_PACKAGER=$(TOP)/mono/sdks
#    WASM_SDK=$(TOP)/../mono/sdks/out/wasm-bcl/wasm
#    WASM_SDK_FRAMEWORK=$(TOP)/../mono/sdks/wasm
#    WASM_SDK_PACKAGER=$(TOP)/../mono/sdks/wasm

APP_SOURCES = \
	./Hello.cs

ASSETS = \
    --asset=index.html   \
	
HelloCanvas.dll: Canvas.cs
	msbuild HelloCanvas.csproj /p:configuration=$(DOM_CONF)

gen-runtime:
	mono $(WASM_SDK_PACKAGER)/packager.exe ${DRIVER_CONF} --copy=ifnewer --template=../runtime.js --out=publish --prefix=./bin/Debug/netstandard2.0 $(ASSETS) HelloCanvas.dll

build-managed: HelloCanvas.dll gen-runtime

build: build-managed

clean:
	rm -rf managed publish


