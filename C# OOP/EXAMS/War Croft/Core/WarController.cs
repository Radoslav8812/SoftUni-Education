using System;
using System.Linq;
using System.Collections.Generic;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;
using System.Text;
using WarCroft.Constants;

namespace WarCroft.Core
{
	public class WarController
	{
		private readonly IList<Character> party;
		private readonly Stack<Item> itemPool;

		public WarController()
		{
			party = new List<Character>();
			itemPool = new Stack<Item>();
		}

		public string JoinParty(string[] args)
		{
			if (args[0] == "Warrior")
            {
				party.Add(new Warrior(args[1]));
            }
			else if (args[0] == "Priest")
            {
				party.Add(new Priest(args[1]));
            }
            else
            {
				throw new ArgumentException($"Invalid character type {args[0]}");
            }

			return $"{args[1]} joined the party!";
		}

		public string AddItemToPool(string[] args)
		{
			if (args[0] == "HealthPotion")
            {
				itemPool.Push(new HealthPotion());
            }
			else if (args[0] == "FirePotion")
            {
				itemPool.Push(new FirePotion());
            }
            else
            {
				throw new ArgumentException($"Invalid item {args[0]}]!");
            }

			return $"{args[0]} added to pool.";
		}

		public string PickUpItem(string[] args)
		{
			var character = party.FirstOrDefault(x => x.Name == args[0]);

			if (character == null)
            {
				throw new ArgumentException($"Character {args[0]} not found!");
            }
            
            if (itemPool.Count == 0)
            {
				throw new InvalidOperationException("No items left in pool!");
            }

			var item = itemPool.Pop();
			character.Bag.AddItem(item);

			return $"{character.Name} picked up {item.GetType().Name}!";
		}

		public string UseItem(string[] args)
		{
			var character = party.FirstOrDefault(x => x.Name == args[0]);

			if (character == null)
            {
				throw new ArgumentException($"Character {args[0]} not found!");
            }

			Item item = character.Bag.GetItem(args[1]);
			character.UseItem(item);

			return $"{character.Name} used {item.GetType().Name}.";
		}

		public string GetStats()
		{
			var sb = new StringBuilder();
			var characters = party.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health);

			foreach (var item in characters)
			{
				sb.AppendLine($"{item.Name} - HP: {item.Health}/{item.BaseHealth}," +
                    $" AP: {item.Armor}/{item.BaseArmor}, Status: {(item.IsAlive ? "Alive" : "Dead")}");
			}

			return sb.ToString().TrimEnd();
		}

		public string Attack(string[] args)
		{
			var attacker = party.FirstOrDefault(x => x.Name == args[0]);
			var receiver = party.FirstOrDefault(x => x.Name == args[1]);

			if (attacker == null)
            {
				throw new ArgumentException($"Character {args[0]} not found!");
            }

			if (receiver == null)
			{
				throw new ArgumentException($"Character {args[1]} not found!");
			}

			Warrior warrior = attacker as Warrior;
			if (warrior == null)
            {
				throw new ArgumentException($"{attacker.Name} cannot attack!");
            }
			warrior.Attack(receiver);

			var result =  $"{warrior.Name} attacks {receiver.Name} for {warrior.AbilityPoints} hit points!" +
                $" {receiver.Name} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!";

			if (receiver.Health == 0)
            {
				var tepmplate = string.Format(SuccessMessages.AttackCharacter, receiver.Name);
				result = $"{result}\n\r {tepmplate}!";
			}

			return result;
		}

		public string Heal(string[] args)
		{
			var healer = party.FirstOrDefault(x => x.Name == args[0]);
			var receiver = party.FirstOrDefault(x => x.Name == args[1]);

			if (healer == null)
			{
				throw new ArgumentException($"Character {args[0]} not found!");
			}

			if (receiver == null)
			{
				throw new ArgumentException($"Character {args[1]} not found!");
			}

			Priest priest = healer as Priest;
			if (priest == null)
			{
				throw new ArgumentException($"{args[0]} cannot heal!");
			}

			return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
		}
	}
}
