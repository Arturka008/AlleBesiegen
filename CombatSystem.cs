using System;

namespace AlleBesiegen
{
	public class CombatSystem 
	{
		private Random random = new Random(); // Random number generator for damage calculations

		public bool StartFight(Player player, Enemy enemy) // Returns true if player wins, false if player loses
		{
			Console.Clear();
			Console.WriteLine($"⚔️ A wild {enemy.Name} appears!");
			Console.WriteLine();

			while (player.IsAlive() && enemy.IsAlive())
			{
				ShowFightStatus(player, enemy);

				Console.WriteLine("Choose your action:");
				Console.WriteLine("1. ⚔️ Attack");
				Console.WriteLine("2. 🛡️ Defend");
				Console.WriteLine("3. 📊 Show player info");
				Console.Write("Your choice: ");

				string choice = Console.ReadLine();

				if (choice == "1")
				{
					PlayerAttack(player, enemy);
				}
				else if (choice == "2")
				{
					PlayerDefend(player, enemy);
				}
				else if (choice == "3")
				{
					Console.Clear();
					player.ShowInfo();
					WaitForKey();
					Console.Clear();
					continue;
				}
				else
				{
					Console.WriteLine("Invalid input!");
					WaitForKey();
					Console.Clear();
					continue;
				}

				if (!enemy.IsAlive())
				{
					break;
				}

				EnemyAttack(player, enemy);

				WaitForKey();
				Console.Clear();
			}

			if (player.IsAlive())
			{
				Console.WriteLine($"✅ You defeated {enemy.Name}!");
				player.Gold += 10;
				Console.WriteLine("💰 You received 10 gold!");
				WaitForKey();
				return true;
			}
			else
			{
				Console.WriteLine("💀 You were defeated!");
				WaitForKey();
				return false;
			}
		}

		private void PlayerAttack(Player player, Enemy enemy) // Calculate and apply player attack damage
		{
			int damage = random.Next(player.MinDamage, player.MaxDamage + 1);

			Console.WriteLine();
			Console.WriteLine($"⚔️ {player.Name} attacks and deals {damage} base damage!");

			enemy.TakeDamage(damage);
		}

		private void PlayerDefend(Player player, Enemy enemy) // Calculate and apply reduced damage when player defends
		{
			int damage = random.Next(enemy.MinDamage, enemy.MaxDamage + 1);

			Console.WriteLine();
			Console.WriteLine($"🛡️ {player.Name} defends!");

			player.TakeReducedDamage(damage);
		}

		private void EnemyAttack(Player player, Enemy enemy) // Calculate and apply enemy attack damage
		{
			int damage = random.Next(enemy.MinDamage, enemy.MaxDamage + 1);

			Console.WriteLine();
			Console.WriteLine($"💥 {enemy.Name} attacks!");

			player.TakeDamage(damage);
		}

		private void ShowFightStatus(Player player, Enemy enemy) // Display current health of player and enemy
		{
			Console.WriteLine("========== Fight ==========");
			Console.WriteLine($"💖 {player.Name}: {player.Health}/{player.MaxHealth} HP");
			Console.WriteLine($"👹 {enemy.Name}: {enemy.CurrentHp}/{enemy.MaxHp} HP");
			Console.WriteLine("===========================");
			Console.WriteLine();
		}

		private void WaitForKey() 
		{
			Console.WriteLine();
			Console.WriteLine("Press any key to continue...");
			Console.ReadKey();
		}
	}
}