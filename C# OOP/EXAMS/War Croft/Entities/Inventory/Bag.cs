using System;
using System.Collections.Generic;
using System.Linq;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private int capacity;
        private List<Item> itemsList;

        protected Bag(int capacity)
        {
            Capacity = capacity;
            itemsList = new List<Item>();
        }

        public int Capacity
        {
            get
            {
                return capacity;
            }
            set
            {
                capacity = 100;
            }
        }

        public int Load
        {
            get
            {
                return Items.Sum(x => x.Weight);
            }
        }

        public IReadOnlyCollection<Item> Items
        {
            get
            {
                return itemsList.AsReadOnly();
            }
        }

        public void AddItem(Item item)
        {
            if (Load + item.Weight > capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            itemsList.Add(item);
        }

        public Item GetItem(string name)
        {
            if (itemsList.Count == 0)
            {
                throw new InvalidCastException("Bag is empty!");
            }

            Item item = itemsList.FirstOrDefault(x => x.GetType().Name == name);
            if (item == null)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            itemsList.Remove(item);
            return item;
        }
    }
}
