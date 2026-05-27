using System;
using System.IO; // Required for file handling operations

namespace AlleBesiegen
{
	public class SaveSystem
	{
		private string saveFilePath = "savegame.txt";

		public void SaveGame(Player player)
		{
			string[] saveData =
			{
				player.Name,
				player.Class.ToString(),
				player.Health.ToString(),
				player.MaxHealth.ToString(),
				player.MinDamage.ToString(),
				player.MaxDamage.ToString(),
				player.Armor.ToString(),
				player.CurrentFloor.ToString()
			};

			File.WriteAllLines(saveFilePath, saveData);

			Console.WriteLine("💾 Game saved successfully!");
		}

		public Player? LoadGame()
		{
			if (!File.Exists(saveFilePath))
			{
				Console.WriteLine("No save file found.");
				return null;
			}

			string[] saveData = File.ReadAllLines(saveFilePath);

			string name = saveData[0];
			HeroClass heroClass = Enum.Parse<HeroClass>(saveData[1]);

			Player player = new Player(name, heroClass);

			player.Health = int.Parse(saveData[2]);
			player.MaxHealth = int.Parse(saveData[3]);
			player.MinDamage = int.Parse(saveData[4]);
			player.MaxDamage = int.Parse(saveData[5]);
			player.Armor = int.Parse(saveData[6]);
			player.CurrentFloor = int.Parse(saveData[7]);

			Console.WriteLine("💾 Game loaded successfully!");

			return player;
		}
	}
}