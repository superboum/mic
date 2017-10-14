#!/bin/bash
TARGET="$(dirname $0)/gtk-working-directory"

mkdir -p $TARGET
pushd $TARGET

rm -r ./../../vendors
mkdir -p ./../../vendors/{lib,share}

wget https://dl.xamarin.com/GTKforWindows/Windows/gtk-sharp-2.12.45.msi
msiextract *.msi

cp Program\ Files/GtkSharp/2.12/bin/*.dll ./../../vendors/lib
cp -r Program\ Files/GtkSharp/2.12/lib/gtk-2.0 ./../../vendors/lib
cp -r Program\ Files/GtkSharp/2.12/share/themes ./../../vendors/share

ls -lah
popd

rm -r $TARGET

