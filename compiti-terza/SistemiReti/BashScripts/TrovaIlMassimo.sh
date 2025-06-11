#!/bin/sh

# # # # # # # # # # # # # # # # # # # # # # #
# Trova il massimo in una sequenza di numeri#
# # # # # # # # # # # # # # # # # # # # # # #

MAXI=0

echo -en "Inserisci il numero di numeri: "
read NUMBERS
for((i=0; i<NUMBERS; i++)) do
	echo -en "Inserisci un numero: "
	read CHOICE
	if (( $CHOICE > $MAXI )); then
		MAXI=$CHOICE
	fi
done
echo "Questo è il numero maggiore: $MAXI"
