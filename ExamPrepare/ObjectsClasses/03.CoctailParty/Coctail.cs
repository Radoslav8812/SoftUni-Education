using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CocktailParty
{
    public class Cocktail
    {
        private readonly List<Ingredient> Ingredients;
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;

            Ingredients = new List<Ingredient>();
        }

        public int CurrentAlcoholLevel => Ingredients.Sum(x => x.Alcohol);
        public void Add(Ingredient ingredient)
        {
            bool isIngredient = false;
            foreach (var element in Ingredients)
            {
                if (element.Name == ingredient.Name)
                {
                    isIngredient = true;
                }
            }

            if (!isIngredient)
            {
                if (Ingredients.Count < Capacity && CurrentAlcoholLevel <= MaxAlcoholLevel)
                {
                    Ingredients.Add(ingredient);
                }
            }
        }
        public bool Remove(string name)
        {
            bool isIngredient = false;
            foreach (Ingredient ingredient in Ingredients)
            {
                if (ingredient.Name == name)
                {
                    isIngredient = true;

                }
            }

            if (isIngredient)
            {
                Ingredients.Remove(Ingredients.FirstOrDefault(ingredient => ingredient.Name == name));
                return true;
            }
            return false;
        }

        public Ingredient FindIngredient(string name)
        {
            return Ingredients.FirstOrDefault(x => x.Name == name);
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            return Ingredients.OrderByDescending(x => x.Alcohol).FirstOrDefault();
        }

        public string Report()
        {

            if (Ingredients.Count > 0)
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine($"Cocktail: {this.Name} - Current Alcohol Level: {CurrentAlcoholLevel}");

                foreach (Ingredient currentIngredient in Ingredients)
                {
                    sb.AppendLine(currentIngredient.ToString());
                }

                return sb.ToString().TrimEnd();
            }

            return null;
        }
    }
}

