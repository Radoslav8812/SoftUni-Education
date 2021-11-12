
namespace BorderControl
{
    public class Citizen : IFakable
    {
        public Citizen(string name, int age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
        }
        public string Name {get; set;}

        public int Age { get; set; }

        public string Id { get; set;}
    }
}
