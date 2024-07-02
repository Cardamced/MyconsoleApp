using System;

public class Calculatrice
{
    public static void Main(string[] commandLineArguments)
    {
        // static float add(float x, float y){
        //     return x + y;
        // }
        static float add(float x, float y) => x + y; // syntaxe concise d'un return pour les fonctions simples.
        static float subtract(float x, float y) => x - y;
        static float Multiply(float x, float y) => x * y;
        static float divide(float x, float y) => x / y;
        static float modulo(float x, float y) => x % y;

        while (true)
        {
            {
                Console.WriteLine("Entrez un nombre à virgule : ");
                float x = float.Parse(Console.ReadLine()); // on récupère la saisie utilisateur et on la convertit en float

                Console.WriteLine("Choisissez une opération (+, -, * ou /) ou tapez exit pour quitter : ");
                string userOperation = Console.ReadLine(); // on récupère la saisie utilisateur

                if (userOperation == "exit")
                {
                    break;
                }
                Console.WriteLine("Entrez un nombre à virgule : ");
                float y = float.Parse(Console.ReadLine()); // on récupère la saisie utilisateur et on la convertit en float

                // ici commence la logique d'opération selon la saisie utilisateur
                switch (userOperation)
                {
                    case "+":
                        Console.WriteLine($"Résultat : {add(x, y)}");
                        break;
                    case "-":
                        Console.WriteLine($"Résultat : {subtract(x, y)}");
                        break;
                    case "*":
                        Console.WriteLine($"Résultat : {Multiply(x, y)}");
                        break;
                    case "/":
                        Console.WriteLine($"Résultat : {divide(x, y)}");
                        if (y != 0)
                        {
                            Console.WriteLine($"Reste: {modulo(x, y)}");
                        }
                        else
                        {
                            Console.WriteLine("Impossible de diviser par zéro.");
                        }
                        break;
                    default:
                        Console.WriteLine("Opération invalide.");
                        break;
                }
            }
        }
    }
}
// pseudo code :
// on affiche "type a float number: "
// En fonction de la saisie utilisateur qu'on récupère avec Console.ReadLine(), on convertit la saisie en float avec float.Parse()
// On Propose ensuite une des quatre opérations arithmétiques de base (addition, soustraction, multiplication, division) à l'utilisateur
// si c'est + on retourne x + integerToAdd
// si c'est - on retourne x - integerToAdd
// si c'est * on retourne x * integerToAdd
// si c'est / on retourne x / integerToAdd
// Si l'on divise, une fonction renvoie le reste de la division entre deux entiers.
// Quand le choix est fait on propose de nouveau de saisir un float
// Puis quand la seconde saisie est effectuée, on affiche le résultat de l'opération
