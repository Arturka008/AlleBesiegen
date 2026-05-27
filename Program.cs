using AlleBesiegen;
using System.Text;

Console.OutputEncoding = Encoding.UTF8; // Set console encoding to UTF-8 for emoji support

bool gameRunning = true;

while (gameRunning) // Main menu loop
{
	Console.Clear();
	Console.WriteLine("=================================");
	Console.WriteLine("        ⚔️ ALLE BESIEGEN ⚔️");
	Console.WriteLine("=================================");
	Console.WriteLine();
	Console.WriteLine("1. 🗡️ Start New Game");
	Console.WriteLine("2. 💾 Load Game");
	Console.WriteLine("3. 📖 Rules");
	Console.WriteLine("4. 🚪 Exit");
	Console.WriteLine();
	Console.Write("Choose an option: ");

	string choice = Console.ReadLine(); // Read user input for menu choice

	switch (choice) // Handle menu choices
	{
		case "1": // Start a new game by creating a new player and starting the dungeon
			Console.Clear();
			Player player = CreatePlayer();
			Console.Clear();
			player.ShowInfo();

			Console.WriteLine();
			Console.WriteLine("Press any key to start the dungeon.");
			Console.ReadKey();

			StartDungeon(player);

			break;

		case "2": // Load a saved game by reading player data from a file and starting the dungeon with that player
			Console.Clear();

			SaveSystem saveSystem = new SaveSystem();
			Player loadedPlayer = saveSystem.LoadGame();

			if (loadedPlayer != null)
			{
				Console.WriteLine();
				loadedPlayer.ShowInfo();

				Console.WriteLine();
				Console.WriteLine("Press any key to continue your dungeon.");
				Console.ReadKey();

				StartDungeon(loadedPlayer);
			}
			else
			{
				Console.WriteLine();
				Console.WriteLine("Press any key to return to the menu.");
				Console.ReadKey();
			}

			break;

		case "3": // Show the game rules and instructions for how to play, including the goal of the game, hero classes, combat mechanics, enemy intent, rewards and save/load functionality
			Console.Clear();
			Console.WriteLine("=== 📖 Rules ===");
			Console.WriteLine();
			Console.WriteLine("🎯 Goal:");
			Console.WriteLine("Defeat all enemies on the floors and beat the final boss.");
			Console.WriteLine();
			Console.WriteLine("🧙 Hero Classes:");
			Console.WriteLine("Warrior - high health and armor.");
			Console.WriteLine("Mage - high damage but low armor.");
			Console.WriteLine("Rogue - balanced and flexible.");
			Console.WriteLine();
			Console.WriteLine("⚔️ Combat:");
			Console.WriteLine("The game uses a turn-based combat system.");
			Console.WriteLine("Each round you can attack, defend or show player info.");
			Console.WriteLine();
			Console.WriteLine("👹 Enemy Intent:");
			Console.WriteLine("Before your action, you can see what the enemy wants to do.");
			Console.WriteLine("The enemy can use a weak attack, a strong attack or defend.");
			Console.WriteLine();
			Console.WriteLine("💥 Strong Attack:");
			Console.WriteLine("A strong attack deals more damage than a normal attack.");
			Console.WriteLine("But it has only a 75% chance to hit.");
			Console.WriteLine("That means there is also a 25% chance to miss.");
			Console.WriteLine();
			Console.WriteLine("🛡️ Defense:");
			Console.WriteLine("If you defend, the damage from the enemy is reduced.");
			Console.WriteLine("If the enemy defends, your damage is reduced in this round.");
			Console.WriteLine();
			Console.WriteLine("🎁 Rewards:");
			Console.WriteLine("After clearing a floor, you can choose a reward.");
			Console.WriteLine("Rewards can heal you, increase your damage or increase your armor.");
			Console.WriteLine();
			Console.WriteLine("💾 Save and Load:");
			Console.WriteLine("The game saves your character and current floor.");
			Console.WriteLine("You can continue later with Load Game.");
			Console.WriteLine();
			Console.WriteLine("Press any key to return to the menu.");
			Console.ReadKey();
			break;

		case "4":
			gameRunning = false;
			Console.WriteLine("Goodbye! =)");
			break;

		default: // Handle invalid input
			Console.Clear();
			Console.WriteLine("Invalid option. Please choose 1, 2, 3 or 4.");
			Console.WriteLine("Press any key to try again.");
			Console.ReadKey();
			break;
	}
	static Player CreatePlayer()
	{
		Console.WriteLine("===== 🗡️ Create Your Hero =====");
		Console.WriteLine();

		Console.Write("Enter your hero name: ");
		string name = Console.ReadLine();

		Console.WriteLine();
		Console.WriteLine("Choose your class:");
		Console.WriteLine("1. 🛡️ Warrior - high health and armor");
		Console.WriteLine("2. 🔥 Mage - high damage but low armor");
		Console.WriteLine("3. 🗡️ Rogue - balanced and flexible");
		Console.WriteLine();

		HeroClass heroClass;

		while (true)
		{
			Console.Write("Your choice: ");
			string choice = Console.ReadLine();

			if (choice == "1")
			{
				heroClass = HeroClass.Warrior;
				break;
			}
			else if (choice == "2")
			{
				heroClass = HeroClass.Mage;
				break;
			}
			else if (choice == "3")
			{
				heroClass = HeroClass.Rogue;
				break;
			}
			else
			{
				Console.WriteLine("Invalid choice. Please choose 1, 2 or 3.");
			}
		}

		Player player = new Player(name, heroClass);

		Console.WriteLine();
		Console.WriteLine("Hero created successfully!");
		Console.WriteLine("Press any key to continue.");
		Console.ReadKey();

		return player;
	}
	static void StartDungeon(Player player) // Main dungeon loop where player fights through 4 floors of enemies
	{
		CombatSystem combatSystem = new CombatSystem();
		RewardSystem rewardSystem = new RewardSystem();
		SaveSystem saveSystem = new SaveSystem();

		for (int floor = player.CurrentFloor; floor <= 6; floor++) 
		{
			Console.Clear();
			Console.WriteLine($"===== Floor {floor} =====");
			Console.WriteLine();

			Enemy enemy;

			if (floor == 1) //string name, int maxHp, int minDamage, int maxDamage, int defense
			{
				enemy = new Enemy("Goblin", 50, 10, 15, 2); 
			}
			else if (floor == 2)
			{
				enemy = new Enemy("Skeleton", 70, 10, 13, 3);
			}
			else if (floor == 3)
			{
				enemy = new Enemy("Dark Knight", 95, 12, 16, 5);
			}
			else if (floor == 4)
			{
				enemy = new Enemy("Orc Warrior", 115, 10, 18, 6);
			}
			else if (floor == 5)
			{
				enemy = new Enemy("Shadow Mage", 100, 10, 22, 4);
			}
			else
			{
				enemy = new Enemy("Boss", 200, 10, 20, 8);
				Console.WriteLine("Boss appears!");
			}

			Console.WriteLine($"Enemy: {enemy.Name}");
			Console.WriteLine("Press any key to start the fight.");
			Console.ReadKey();

			bool playerWon = combatSystem.StartFight(player, enemy);

			if (!playerWon) // If the player lost the fight, end the game and show a game over message with the floor they reached
			{
				Console.Clear();
				Console.WriteLine("Game Over!");
				Console.WriteLine($"You were defeated on floor {floor}.");
				Console.WriteLine();
				Console.WriteLine("Press any key to return to the menu.");
				Console.ReadKey();
				return;
			}

			Console.Clear();

			if (floor < 6) // If the player has cleared a regular floor, allow them to choose a reward and save their progress before moving to the next floor
			{
				Console.WriteLine($"Floor {floor} cleared!");
				Console.WriteLine("You can choose a reward.");
				Console.WriteLine();
				Console.WriteLine("Press any key to continue.");
				Console.ReadKey();

				rewardSystem.ChooseReward(player);
				player.CurrentFloor = floor + 1;
				saveSystem.SaveGame(player);
				Console.WriteLine();
				Console.WriteLine("Press any key to continue to the next floor.");
				Console.ReadKey();
			}
			else // If the player has defeated the final boss, show a congratulations message and display their final character status before returning to the menu
			{
				Console.Clear();
				Console.WriteLine("=================================");
				Console.WriteLine("        🎉 CONGRATULATIONS! 🎉");
				Console.WriteLine("=================================");
				Console.WriteLine();
				Console.WriteLine("🏆 Well done! You defeated the Boss!");
				Console.WriteLine("⚔️ You cleared all floors and won the game!");
				Console.WriteLine();
				Console.WriteLine("Final character status:");
				Console.WriteLine();
				player.ShowInfo();
				Console.WriteLine();
				Console.WriteLine("=================================");
				Console.WriteLine("Press any key to exit the dungeon...");
				Console.ReadKey();
			}
		}
	}
}