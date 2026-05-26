using System;

namespace AlleBesiegen
{
	public class RewardSystem
	{
		public void ChooseReward(Player player)
		{
			bool rewardChosen = false;

			while (!rewardChosen)
			{
				Console.Clear();
				Console.WriteLine("===== 🎁 Choose Your Reward =====");
				Console.WriteLine();
				Console.WriteLine("1. 💖 Heal 25 HP");
				Console.WriteLine("2. ⚔️ Increase max damage by 2");
				Console.WriteLine("3. 🛡️ Increase armor by 1");
				Console.WriteLine();
				Console.Write("Your choice: ");

				string choice = Console.ReadLine();

				if (choice == "1")
				{
					player.Heal(25);
					rewardChosen = true;
				}
				else if (choice == "2")
				{
					player.MaxDamage += 2;
					Console.WriteLine($"⚔️ Max damage increased to {player.MaxDamage}!");
					rewardChosen = true;
				}
				else if (choice == "3")
				{
					player.Armor += 1;
					Console.WriteLine($"🛡️ Armor increased to {player.Armor}!");
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