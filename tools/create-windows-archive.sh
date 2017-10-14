#!/bin/bash

CURRENT_FOLDER=$(dirname $0)
RELEASE=$CURRENT_FOLDER/../Mic/bin/Release

pushd $RELEASE
mkdir -p mic-data/lib
mv *.dll mic-data/lib
cp ../../../vendors/lib/* mic-data/lib
cp -r ../../../vendors/share mic-data
zip -r mic-windows-portable.zip .
popd
