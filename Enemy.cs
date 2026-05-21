namespace AlleBesiegen
{
	public class Enemy
	{
		public string Name { get; set; }
		public int CurrentHp { get; set; }
		public int MaxHp { get; set; }
		public int MinDamage { get; set; }
		public int MaxDamage { get; set; }
		public int Defense { get; set; }

		public Enemy(string name, int maxHp, int minDamage, int maxDamage, int defense) // Constructor to initialize enemy attributes
		{
			Name = name;
			MaxHp = maxHp;
			CurrentHp = maxHp;
			MinDamage = minDamage;
			MaxDamage = maxDamage;
			Defense = defense;
		}

		public void TakeDamage(int damage) // Method to apply damage to the enemy, considering defense
		{
			int finalDamage = damage - Defense;

			if (finalDamage < 1)
			{
				finalDamage = 1;
			}

			CurrentHp -= finalDamage;

			if (CurrentHp < 0)
			{
				CurrentHp = 0;
			}

			Console.WriteLine($"{Name} received {finalDamage} damage!");
		}

		public bool IsAlive() // Method to check if the enemy is still alive (current HP greater than 0)
		{
			return CurrentHp > 0;
		}

		public void ShowStatus()
		{
			Console.WriteLine("===== Enemy Status =====");
			Console.WriteLine($"Name: {Name}");
			Console.WriteLine($"HP: {CurrentHp}/{MaxHp}");
			Console.WriteLine($"Damage: {MinDamage}-{MaxDamage}");
			Console.WriteLine($"Defense: {Defense}");
			Console.WriteLine("========================");
		}
	}
}