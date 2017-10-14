#!/bin/bash

CURRENT_FOLDER=$(dirname $0)
RELEASE=$CURRENT_FOLDER/../Mic/bin/Release

pushd $RELEASE
mkdir -p mic-data

cp -r ../../../vendors/lib mic-data
cp -r ../../../vendors/share mic-data
mv *.dll mic-data/lib

zip -r mic-windows-portable.zip .
popd
