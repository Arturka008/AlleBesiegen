using System;

namespace AlleBesiegen
{
	public class RewardSystem
	{
		private Random random = new Random(); // Random number generator for reward values

		public void ChooseReward(Player player)

		{
			bool rewardChosen = false;

			int healAmount = random.Next(25, 50); // 25 to 50 HP
			int damageBonus = random.Next(1, 4); // 1 to 3 max damage
			int armorBonus = random.Next(1, 3); // 1 to 2 armor

			while (!rewardChosen)
			{
				Console.Clear();
				Console.WriteLine("===== 🎁 Choose Your Reward =====");
				Console.WriteLine();
				Console.WriteLine($"1. 💖 Heal {healAmount} HP");
				Console.WriteLine($"2. ⚔️ Increase max damage by {damageBonus}");
				Console.WriteLine($"3. 🛡️ Increase armor by {armorBonus}");
				Console.WriteLine();
				Console.Write("Your choice: ");

				string choice = Console.ReadLine();

				if (choice == "1")
				{
					player.Heal(healAmount);
					rewardChosen = true;
				}
				else if (choice == "2")
				{
					player.MaxDamage += damageBonus;
					Console.WriteLine($"⚔️ Max damage increased by {damageBonus}!");
					Console.WriteLine($"New max damage: {player.MaxDamage}");
					rewardChosen = true;
				}
				else if (choice == "3")
				{
					player.Armor += armorBonus;
					Console.WriteLine($"🛡️ Armor increased by {armorBonus}!");
					Console.WriteLine($"New armor: {player.Armor}");
					rewardChosen = true;
				}
				else
				{
					Console.WriteLine("Invalid choice. Please choose 1, 2 or 3.");
				}

				Console.WriteLine();
				Console.WriteLine("Press any key to continue...");
				Console.ReadKey();
			}
		}
	}
}