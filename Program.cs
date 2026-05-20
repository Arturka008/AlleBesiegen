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
		case "1":
			Console.Clear();
			Player player = CreatePlayer();
			Console.Clear();
			player.ShowInfo();
			Console.WriteLine();
			Console.WriteLine("Press any key to return to the menu.");
			Console.ReadKey();
			break;

		case "2":
			Console.Clear();
			Console.WriteLine("Load game is not available yet.");
			Console.WriteLine("Press any key to continue.");
			Console.ReadKey();
			break;

		case "3":
			Console.Clear();
			Console.WriteLine("=== 📖 Rules ===");
			Console.WriteLine("Choose a hero class.");
			Console.WriteLine("Fight enemies in turn-based battles.");
			Console.WriteLine("Defeat all enemies and the final boss.");
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
}