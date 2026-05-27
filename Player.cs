using System;

namespace AlleBesiegen
{


	public enum HeroClass // Enumeration for hero classes
	{
		Warrior,
		Mage,
		Rogue
	}

	public class Player // Class representing the player character
	{
		public string Name { get; set; }
		public HeroClass Class { get; set; }
		public int MaxHealth { get; set; }
		public int Health { get; set; }
		public int MinDamage { get; set; }
		public int MaxDamage { get; set; }
		public int Armor { get; set; }
		//public int Gold { get; set; }
		public int CurrentFloor { get; set; }
		public Player(string name, HeroClass heroClass) // Constructor to initialize player attributes based on chosen hero class
		{
			Name = name;
			Class = heroClass;
			//Gold = 0;

			if (heroClass == HeroClass.Warrior)
			{
				MaxHealth = 130;
				Health = MaxHealth;
				MinDamage = 16;
				MaxDamage = 20;
				Armor = 8;
			}
			else if (heroClass == HeroClass.Mage)
			{
				MaxHealth = 90;
				Health = MaxHealth;
				MinDamage = 20;
				MaxDamage = 30;
				Armor = 3;
			}
			else if (heroClass == HeroClass.Rogue)
			{
				MaxHealth = 100;
				Health = MaxHealth;
				MinDamage = 20;
				MaxDamage = 25;
				Armor = 5;
			}

			CurrentFloor = 1;
		}
		public void ShowInfo() // Method to display player information
		{
			Console.WriteLine("Player Information:");
			Console.WriteLine($"Name: {Name}");
			Console.WriteLine($"Class: {Class}");
			Console.WriteLine($"💖 Health: {Health}/{MaxHealth}");
			Console.WriteLine($"⚔️ Damage: {MinDamage}-{MaxDamage}");
			Console.WriteLine($"🛡️ Armor: {Armor}");
			//Console.WriteLine($"💰 Gold: {Gold}");
			Console.WriteLine($"🏰 Floor: {CurrentFloor}");
		}
		public void TakeDamage(int damage) // Method to apply damage to the player, considering armor
		{
			int finalDamage = damage - Armor;  // Calculate final damage after considering armor

			if (finalDamage < 1)
			{
				finalDamage = 1;
			}

			Health -= finalDamage; // Reduce health by the final damage amount

			if (Health < 0)
			{
				Health = 0;
			}

			Console.WriteLine($"💥 {Name} received {finalDamage} damage!");
		}

		public void TakeReducedDamage(int damage) // Method to apply reduced damage to the player, considering armor and halving the damage
		{
			int finalDamage = damage - Armor;

			if (finalDamage < 1)
			{
				finalDamage = 1;
			}

			finalDamage = finalDamage / 2;

			if (finalDamage < 1)
			{
				finalDamage = 1;
			}

			Health -= finalDamage;

			if (Health < 0)
			{
				Health = 0;
			}

			Console.WriteLine($"🛡️ {Name} defended and received only {finalDamage} damage!");
		}

		public void Heal(int amount) // Method to heal the player, ensuring health does not exceed maximum health
		{
			int oldHealth = Health;

			Health += amount;

			if (Health > MaxHealth)
			{
				Health = MaxHealth;
			}

			int healedAmount = Health - oldHealth;

			Console.WriteLine($"💖 {Name} healed {healedAmount} HP!");
		}

		public bool IsAlive() // Method to check if the player is still alive (health greater than 0)
		{
			return Health > 0;
		}
	}
}