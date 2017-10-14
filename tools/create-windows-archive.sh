#!/bin/bash

CURRENT_FOLDER=$(dirname $0)
RELEASE=$CURRENT_FOLDER/../Mic/bin/Release

pushd $RELEASE
mkdir -p mic-data/lib
mv *.dll mic-data/lib
cp ../../../vendors/* mic-data/lib
zip -r mic-windows-portable.zip .
popd
