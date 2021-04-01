using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		private List<Character> characters;
		private List<Item> items;
			
		public WarController()
		{
			characters = new List<Character>();
			items = new List<Item>();
		}

		public string JoinParty(string[] args)
		{
			Character character = null;
			string characterType = args[0];
			string name = args[1];

			if (characterType == "Warrior")
			{
				character = new Warrior(name);
			}
			else if (characterType == "Priest")
			{
				character = new Priest(name);
			}
			else
			{
				throw new ArgumentException(String.Format(ExceptionMessages.InvalidCharacterType, characterType));
			}
			characters.Add(character);
			return String.Format(SuccessMessages.JoinParty, name);
		}

		public string AddItemToPool(string[] args)
		{
			string itemName = args[0];
			Item item = null;
			if (itemName == "FirePotion")
			{
				item = new FirePotion();
			}
			else if (itemName == "HealthPotion")
			{
				item = new HealthPotion();
			}
			else
			{
				throw new ArgumentException(String.Format(ExceptionMessages.InvalidItem,itemName));
			}
			items.Add(item);
			return String.Format(SuccessMessages.AddItemToPool, itemName);
		}

		public string PickUpItem(string[] args)
		{
			string characterName = args[0];
			var character = characters.FirstOrDefault(x => x.Name == characterName);
			if (character == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
			}
			if (!items.Any())
			{
				throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
			}
			var item = items.Last();
			character.Bag.AddItem(item);


			return string.Format(SuccessMessages.PickUpItem, characterName,item.GetType().Name);

		}

		public string UseItem(string[] args)
		{
			string characterName = args[0];
			string itemName = args[1];
			var character = characters.FirstOrDefault(x => x.Name == characterName);			
			if (character == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty), characterName);
			}

			var item = character.Bag.GetItem(itemName);		
			character.UseItem(item);

			return string.Format(SuccessMessages.UsedItem, characterName, itemName);
		}

		public string GetStats()
		{
			StringBuilder sb = new StringBuilder();
			foreach (var character in characters.OrderByDescending(x=>x.IsAlive).ThenByDescending(x=>x.Health))
			{
				string status = "";
				if (character.IsAlive)
				{
					status = "Alive";
				}
				else
				{
					status = "Dead";
				}
				sb.AppendLine($"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {status}");
			}
			return sb.ToString().Trim();
		}

		public string Attack(string[] args)
		{
			string attackerName = args[0];
			string reciverName = args[1];

			Warrior attacker = (Warrior)characters.FirstOrDefault(x => x.Name == attackerName);
			var reciver = characters.FirstOrDefault(x => x.Name == reciverName);

			if (attacker == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
			}
			if (reciver == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, reciverName));
			}
			if (!attacker.IsAlive)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
			}
			if (!reciver.IsAlive)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, reciverName));
			}
			attacker.Attack(reciver);
			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"{attackerName} attacks {reciverName} for {attacker.AbilityPoints} hit points! {reciverName} has {reciver.Health}/{reciver.BaseHealth} HP and {reciver.Armor}/{reciver.BaseArmor} AP left!");
			if (!reciver.IsAlive)
			{
				sb.AppendLine($"{reciverName} is dead!");
			}
			return sb.ToString().Trim();
		}

		public string Heal(string[] args)
		{
			string healerName = args[0];
			string reciverName = args[1];
			Priest healer = (Priest)characters.FirstOrDefault(x => x.Name == healerName);
			var reciver = characters.FirstOrDefault(x => x.Name == reciverName);
			if (healer == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
			}
			if (reciver == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, reciverName));
			}
			if (!healer.IsAlive)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
			}
			if (!reciver.IsAlive)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, reciverName));
			}
			healer.Heal(reciver);
			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"{healer.Name} heals {reciver.Name} for {healer.AbilityPoints}! {reciver.Name} has {reciver.Health} health now!");

			return sb.ToString().Trim();
		}
	}
}
