namespace PlayersAndMonsters
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var dark = new DarkKnight("Black Stalion", 100);
            Console.WriteLine(dark);
        }
    }
}