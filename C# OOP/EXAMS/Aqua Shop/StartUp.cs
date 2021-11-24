namespace AquaShop
{
    using AquaShop.Core;
    using AquaShop.Core.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            IEngine engine = new Engine();
            engine.Run();

            System.Console.WriteLine(typeof(Engine).Name);
            System.Console.WriteLine(engine.GetType().Name);
        }
    }
}
