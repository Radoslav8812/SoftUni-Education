using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
		// TODO: Implement the rest of the class.
		private string name;
		private readonly double baseHealth;
        private double health;
        private readonly double baseArmor;
        private double armor;
        protected double abilityPoints;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
			Name = name;
            baseHealth = health;
            Health = health;
            baseArmor = armor;
            Armor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
        }

		public bool IsAlive { get; set; } = true;

		public string Name
        {
            get
            {
				return name;
            }
			private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
					throw new ArgumentException("Name cannot be null or whitespace!");
                }
				name = value;
            }
        }

        public double BaseArmor
        {
            get
            {
                return baseArmor;
            }
        }

        public double BaseHealth
        {
            get
            {
                return baseHealth;
            }
        }

        public double Health
        {
            get
            {
                return health;
            }
            set
            {
                if (value <= baseHealth && value >= 0)
                {
                    health = value;
                }
            }
        }

        public double Armor
        {
            get
            {
                return armor;
            }
            set
            {
                if (value >= 0)
                {
                    armor = value;
                }
                else
                {
                    armor = 0;
                }
            }
        }

        public double AbilityPoints
        {
            get
            {
                return abilityPoints;
            }
            set
            {
                abilityPoints = value;
            }
        }

        public IBag Bag { get; set; }

        public virtual void TakeDamage(double hitPoints)
        {
            EnsureAlive();
            double healthReduce = hitPoints - Armor;
            Armor -= hitPoints;

            if (healthReduce > 0)
            {
                Health -= healthReduce;
            }

            if (Health == 0)
            {
                IsAlive = false;
            }
        }

        public virtual void UseItem(Item item)
        {
            EnsureAlive();
            item.AffectCharacter(this);
        }

        protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}
	}
}