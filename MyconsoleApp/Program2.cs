using System;

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
        bool attackMissed = random.Next(0, 100) < 10; // soit 10% de rater son attaque

        if (attackMissed)
        {
            Console.WriteLine($"{Name} tente une attaque contre {opponent.Name} mais rate son coup.");
        }
        else
        {
            // Définir une plage de variation pour les dommages (par exemple, +/- 20% de la force d'attaque)
            int minDamage = (int)(AttackStrength * 0.8);
            int maxDamage = (int)(AttackStrength * 1.2);

            int damage = random.Next(minDamage, maxDamage + 1) - opponent.DefenseStrength;

            // On empêche les points de vie négatifs.
            if (damage > 0)
            {
                opponent.HealthPoints = Math.Max(0, opponent.HealthPoints - damage);
            }

            // Vérifier si l'opposant est KO après l'attaque
            if (opponent.HealthPoints <= 0)
            {
                Console.WriteLine($"{Name} attaque {opponent.Name} et lui cause {damage} dégâts. {opponent.Name} est KO.");
            }
            else
            {
                Console.WriteLine($"{Name} attaque {opponent.Name} et lui cause {damage} dégâts. {opponent.Name} a encore {opponent.HealthPoints} points de vie.");
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Character character1 = new Character("🐥", 100, 20, 10);
            Character character2 = new Character("🐰", 100, 20, 10);

            while (character1.IsAlive() && character2.IsAlive())
            {
                character1.Attack(character2);
                if (character2.IsAlive())
                {
                    character2.Attack(character1);
                }
            }

            if (character1.IsAlive())
            {
                Console.WriteLine($"{character1.Name} gagne!");
            }
            else
            {
                Console.WriteLine($"{character2.Name} gagne!");
            }
        }
    }
}