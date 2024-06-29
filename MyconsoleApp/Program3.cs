

// instanciation de trois variables à leur valeur maximum :

//     x -> en type int = int.MaxValue

//     y -> en type long = long.MaxValue

//     z -> en type short = short.MaxValue

// On additionne les trois dans une variable du type qui a
// suffisamment de bits pour coder le résultat de l'opération.
// En C#, ulong (unsigned long) est un type de 64 bits non signé,
// ce qui implique qu'il est toujours positif

using System;

namespace MyconsoleApp
{
    public class Program3
    {
        static void Main()
        {
            // Initialiser les variables avec leur valeur maximale
            int x = int.MaxValue; // .MaxValue est une propriété statique de la classe int (ou System.Int32, avec le namespace complet)
            // qui retourne la valeur maximale possible pour un int. Idem pour les autres typesci-après.
            long y = long.MaxValue;
            short z = short.MaxValue;

            // Effectuer l'addition et stocker le résultat dans une variable du type qui a suffisamment de bits
            // En C#, ulong (unsigned long) est un type de 64 bits non signé, suffisant pour stocker le résultat
            ulong result = (ulong)x + (ulong)y + (ulong)z;

            // Afficher les valeurs des variables et le résultat
            Console.WriteLine("x (int.MaxValue) = " + x); // soit 2147483647
            Console.WriteLine("y (long.MaxValue) = " + y); // soit 9223372036854775807
            Console.WriteLine("z (short.MaxValue) = " + z); // soit 32767
            Console.WriteLine("Résultat de l'addition = " + result); // soit 9223372036854801181
        }
    }
}