
namespace MyconsoleApp
{
    public class Character
    {
        public string Name { get; set; }
        // public string Name définit une propriété publique de type string appelée Name. On peut y accéder depuis n'importe quelle autre classe ou méthode dans le projet (c'est la visibilité).
        // get ; set; permet de définir les accesseurs de la propriété. get permet de récupérer la valeur de la propriété, set permet de définir la valeur de la propriété.
        public int HealthPoints { get; set; }
        public int AttackStrength { get; set; }
        public int DefenseStrength { get; set; }
        private static Random random = new Random();

        public Character(string name, int healthPoints, int attackStrength, int defenseStrength)
        {
            Name = name;
            //Name est l'attribut de la classe Character ; name est le nom de la variable
            //Assignation de la valeur du paramètre name à la propriété (ou attribut) Name de l'instance.
            HealthPoints = healthPoints;
            AttackStrength = attackStrength;
            DefenseStrength = defenseStrength;
        }

        public bool IsAlive()
        {
            return HealthPoints > 0;
        }

        public void Attack(Character opponent)
        {
            // introduit la possibilité de rater son attaque
            bool attackMissed = random.Next(0, 100) < 2; // soit 2% de rater complètement son attaque

            if (attackMissed)
            {
                Console.WriteLine($"{Name} tente une attaque contre {opponent.Name} mais rate son coup.");
            }
            else
            {
                // Définir une plage de variation pour les dommages (par exemple, +/- 20% de la force d'attaque)
                int minDamage = (int)(AttackStrength * 0.8);
                int maxDamage = (int)(AttackStrength * 2);

                int damage = random.Next(minDamage, maxDamage + 1) - opponent.DefenseStrength;

                // On empêche les points de vie négatifs.
                if (damage > 0)
                {
                    opponent.HealthPoints = Math.Max(0, opponent.HealthPoints - damage);

                    // Vérifier si l'opposant est KO après l'attaque
                    if (opponent.HealthPoints <= 0)
                    {
                        Console.WriteLine($"{Name} attaque {opponent.Name} et lui cause {damage} points de dégâts. {opponent.Name} est KO.");
                    }
                    else
                    {
                        Console.WriteLine($"{Name} attaque {opponent.Name} et lui cause {damage} points de dégâts. {opponent.Name} a encore {opponent.HealthPoints} points de vie.");
                    }
                }
                else
                {
                    Console.WriteLine($"{Name} tente une attaque contre {opponent.Name} mais rate son coup.");
                }
            }
        }

        public class Program2
        {
            static void Main(string[] args)
            {
                Character character1 = new Character("🐥", 100, 20, 20);
                Character character2 = new Character("🐰", 100, 20, 20);
                Character character3 = new Character("🐷", 100, 20, 20);

                Random rand = new Random();
                List<Character> characters = new List<Character> { character1, character2, character3 };

                // On utilise un nombre aléatoire AVANT la BOUCLE de combat, pour déterminer qui attaque en premier.//
                int attackerIndex = random.Next(characters.Count);

                // plutôt qu'un switch/case 1, case 2, case 3 qui impose de répéter le même code, on crée une liste de characters sur laquelle on va boucler.

                while (characters.Count(c => c.IsAlive()) > 1)
                {
                    Character attacker = characters[attackerIndex];

                    // On récupère l'index du premier personnage vivant après l'attaquant.
                    // C'est donc le premier "defender" vivant.
                    {
                        int defenderIndex = (attackerIndex + 1) % characters.Count;
                        while (!characters[defenderIndex].IsAlive())
                        {
                            defenderIndex = (defenderIndex + 1) % characters.Count;
                        }

                        Character defender = characters[defenderIndex];

                        // L'attaquant attaque le défenseur.
                        if (attacker.IsAlive() && defender.IsAlive())
                        {
                            attacker.Attack(defender);
                        }

                        // Trouver l'index du prochain attaquant vivant.
                        attackerIndex = (defenderIndex + 1) % characters.Count;
                        while (!characters[attackerIndex].IsAlive())
                        {
                            attackerIndex = (attackerIndex + 1) % characters.Count;
                        }
                    }
                }

                // Après la boucle While qui gère les combats et la succession des attaques.

                // Affiche le vainqueur ou annonce un match nul.

                // EXPLICATIONS DE LA SYNTAXE var...

                // characters.Where(c => c.IsAlive()).ToList() utilise LINQ (Language Integrated Query)
                // pour filtrer la liste characters. Where est une méthode d'extension LINQ
                // qui applique un prédicat à chaque élément de la collection characters.
                // Le prédicat ici est c => c.IsAlive(), ce qui signifie que la méthode Where
                // sélectionne uniquement les éléments de characters pour lesquels la méthode
                // IsAlive() retourne true. Ça filtre tous les personnages qui sont "vivants" (non KO)
                // .ToList() convertit ensuite le résultat filtré en une nouvelle liste, List<Character>.

                // var aliveCharacters = ... : var est un mot-clé en C# qui permet de déclarer une variable
                // sans spécifier explicitement son type. Le type est déduit par le compilateur
                // à partir de l'expression utilisée pour initialiser la variable. Ici, comme ToList()
                // retourne une List<T>, où T est le type des éléments dans la collection characters
                // (probablement Character ou un type similaire), aliveCharacters sera de type List<Character>.

                var aliveCharacters = characters.Where(c => c.IsAlive()).ToList();
                if (aliveCharacters.Count == 1)
                {
                    // Il y a bien un seul survivant et donc un vainqueur unique.
                    Console.WriteLine($"{aliveCharacters[0].Name} gagne!");
                }
                else if (aliveCharacters.Count == 0)
                {
                    // Tous les personnages sont KO. (Erreur peu probable mais gérée quand même.)
                    Console.WriteLine($"Aucun vainqueur, match nul !");
                }
                else
                {
                    // Plusieurs survivants. Cas improbable mais géré pour la robustesse du code.
                    Console.WriteLine($"Erreur ! Il ne peut y avoir de vainqueur ex-aequo.");
                }
            }
        }
    }
}