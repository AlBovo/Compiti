#!/bin/sh

# # # # # # # # # # # # # # # # # # # # # # # # #
# Script per sapere se una stringa è palindroma #
# # # # # # # # # # # # # # # # # # # # # # # # #

read NUMBER
SIZE=${#NUMBER}
echo $SIZE
for((i=0; i<SIZE/2; i++)); do
	if [[ ${NUMBER:i:1} != ${NUMBER:SIZE-i-1:1} ]]; then
		echo "The number is not echo palindrome"
		exit
	fi
done

echo "The number is palindrome"
