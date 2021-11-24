
namespace FoodShortage.Interfaces
{
    public interface IBuyer
    {
        public int Food { get; }
        public string Name { get; }
        void BuyFood();
    }
}
