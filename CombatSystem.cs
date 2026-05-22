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

			bool playerDefending = false; // Track if player is defending to apply damage reduction

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
				else if (choice == "2") // Player chooses to defend, which will reduce damage from the next enemy attack
				{
					Console.WriteLine();
					Console.WriteLine($"🛡️ {player.Name} prepares to defend!");
					playerDefending = true;
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

				EnemyRandomAction(player, enemy, playerDefending);
				playerDefending = false;

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

		private void EnemyRandomAction(Player player, Enemy enemy, bool playerDefending) // Enemy randomly chooses to perform a weak attack, strong attack or defend
		{
			int action = random.Next(1, 4); // 1, 2 or 3

			if (action == 1)
			{
				EnemyWeakAttack(player, enemy, playerDefending);
			}
			else if (action == 2)
			{
				EnemyStrongAttack(player, enemy, playerDefending);
			}
			else if (action == 3)
			{
				EnemyDefend(enemy);
			}
		}

		private void EnemyWeakAttack(Player player, Enemy enemy, bool playerDefending) //
		{
			int damage = random.Next(enemy.MinDamage, enemy.MaxDamage + 1);
			damage = damage / 2;

			if (damage < 1)
			{
				damage = 1;
			}

			Console.WriteLine();
			Console.WriteLine($"👹 {enemy.Name} uses a weak attack!");

			if (playerDefending) // If player is defending, apply reduced damage
			{
				player.TakeReducedDamage(damage);
			}
			else
			{
				player.TakeDamage(damage);
			}
		}
		private void EnemyStrongAttack(Player player, Enemy enemy, bool playerDefending) // Strong attack has a 75% chance to hit and deals more damage than a normal attack( 75% weil es imba ist)
		{
			int hitChance = random.Next(1, 101);

			Console.WriteLine();
			Console.WriteLine($"💥 {enemy.Name} tries a strong attack!");

			if (hitChance <= 75)
			{
				int damage = random.Next(enemy.MaxDamage, enemy.MaxDamage + 8);

				if (playerDefending)
				{
					player.TakeReducedDamage(damage);
				}
				else
				{
					player.TakeDamage(damage);
				}
			}
			else
			{
				Console.WriteLine($"{enemy.Name} missed the strong attack!");
			}
		}
		private void EnemyDefend(Enemy enemy) // Enemy increases its defense for the next turn, which will reduce damage taken from the player's next attack
		{
			enemy.Defense += 2;

			Console.WriteLine();
			Console.WriteLine($"🛡️ {enemy.Name} increases defense by 2!");
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