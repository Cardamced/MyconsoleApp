namespace Constructors
{
    // Déclaration d'une classe statique `Program` contenant la méthode `Main`.
    public static class Program
    {
        // Point d'entrée du programme, la méthode `Main`.
        public static void Main()
        {
            // Création d'une nouvelle instance de `Building` en appelant son constructeur
            // avec la valeur 5.89 pour la hauteur.
            Building building = new Building(5.89);
            
            // Appel de la méthode `GetHeight` pour obtenir la hauteur du bâtiment.
            // le type double sert à afficher les valeurs décimales sur 8 octets. (cf. float/double/decimal)
            double height = building.GetHeight();
            
            // Affichage de la hauteur dans la console.
            System.Console.WriteLine(height);
        }
    }

    // Déclaration de la classe `Building`.
    public class Building
    {
        // Champ privé pour stocker la hauteur du bâtiment.
        // On ne peut y accéder que depuis cette classe.
        private double _height;

        // Constructeur de la classe `Building` qui prend un paramètre `height`.
        // Ce constructeur initialise le champ `_height` avec la valeur du paramètre.
        public Building(double height)
        {
            _height = height;
        }

        // Méthode publique pour obtenir la valeur du champ privé `_height`.
        // Cette méthode agit comme un (getter) accesseur en lecture pour `_height`
        // On y recourt parce que le champ `_height` est privé.
        public double GetHeight()
        {
            return _height;
        }
    }
}