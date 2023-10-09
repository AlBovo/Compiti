#!/bin/sh

echo -en "Inserisci l'operazione da eseguire: "
read -r QUERY
echo -en "Inserisci il primo numero: "
read -r NUMBER1
echo -en "Inserisci il secondo numero: "
read -r NUMBER2

if [[ $QUERY == "SUM" ]]; then
	echo "$(( $NUMBER1 + $NUMBER2 ))"
elif [[ $QUERY == "SUB" ]]; then
	echo "$(( NUMBER1 - NUMBER2 ))"
elif [[ $QUERY == "MOL" ]]; then
	echo "$(( NUMBER1 * NUMBER2 ))"
elif [[ $QUERY == "DIV" ]]; then
	echo "$(( NUMBER1 / NUMBER2 ))"
else
	echo "Operazione non conosciuta"
fi
