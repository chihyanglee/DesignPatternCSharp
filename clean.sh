#!/bin/bash
folders=( "bin" "obj" )
for i in "${folders[@]}"
do
  echo "===clean $i folder==="
  VAR=`find . -type d -name "$i" -print`
  # echo ${VAR}
  find . -type d -name "$i" -exec rm -rv {} +
  echo "===clean $i folder end==="
done

exit 0