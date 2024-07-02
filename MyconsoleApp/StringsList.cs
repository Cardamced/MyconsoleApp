// using System;

// namespace MyconsoleApp
// {
//     public class StringsList
//     {
//         static void Main()
//         {
//             // Initialiser une liste de strings
//             List<string> stringsCollection = new List<string>();
//             stringsCollection.Add("El");
//             stringsCollection.Add("famoso");
//             stringsCollection.Add("Coucou");

//             // Afficher le contenu initial de la liste
//             Console.WriteLine("\nÉléments de la liste initiale :");
//             foreach (var str in stringsCollection)
//             {
//                 Console.WriteLine(str);
//             }

//             // Opérations sur la liste
//             stringsCollection.RemoveAt(0);
//             int currentStringsCollection = stringsCollection.Count;
//             Console.WriteLine("\nNombre d'éléments dans la liste: " + currentStringsCollection);
//             stringsCollection.Remove("Coucou");
//             stringsCollection[0] = "Coucou";

//             // Afficher le contenu de la liste après les opérations
//             Console.WriteLine("\nÉtat final de la liste:");
//             foreach (var finalStringsList in stringsCollection)
//             {
//                 Console.WriteLine(finalStringsList);
//             }
//         }
//     }
// }