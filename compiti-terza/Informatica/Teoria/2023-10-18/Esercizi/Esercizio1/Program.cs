using System;

namespace Esercizio1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Dichiarazione delle variabili
            int primoNumero, secondoNumero, tempNumero;
            string tempString;
            bool inputOK;
            #endregion

            #region Lettura dei due numeri
            do
            {
                Console.Write("Inserisci il primo termine dell MCD: ");
                tempString = Console.ReadLine();
                inputOK = int.TryParse(tempString, out primoNumero);

                if (!inputOK)
                {
                    Console.WriteLine("L'input inserito non è un numero intero, riprova ...");
                }
            } while (!inputOK);
            primoNumero = Math.Abs(primoNumero);

            do
            {
                Console.Write("Inserisci il secondo termine dell MCD: ");
                tempString = Console.ReadLine();
                inputOK = int.TryParse(tempString, out secondoNumero);

                if (!inputOK)
                {
                    Console.WriteLine("L'input inserito non è un numero intero, riprova ...");
                }
            } while (!inputOK);
            secondoNumero = Math.Abs(secondoNumero);
            #endregion

            #region Ordino i valori
            tempNumero = Math.Max(primoNumero, secondoNumero);
            secondoNumero = Math.Min(primoNumero, secondoNumero);
            primoNumero = tempNumero;
            #endregion

            #region Calcolo del MCD
            Console.Write($"L'MCD dei due numeri {primoNumero} e {secondoNumero} è: ");
            while (secondoNumero != 0)
            {
                tempNumero = secondoNumero;
                secondoNumero = primoNumero % secondoNumero;
                primoNumero = tempNumero;
            }
            Console.WriteLine(primoNumero);
            #endregion

            Console.Write("Premi un tasto per terminare l'esecuzione del programma ... ");
            Console.ReadKey();
        }
    }
}
