#!/bin/bash
TARGET="$(dirname $0)/gtk-working-directory"

mkdir -p $TARGET
pushd $TARGET
wget https://dl.xamarin.com/GTKforWindows/Windows/gtk-sharp-2.12.45.msi
msiextract *.msi
cp Program\ Files/GtkSharp/2.12/bin/*.dll ./../../vendors/
ls -lah
popd

rm -r $TARGET

