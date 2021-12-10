using System;
using static BorderControl.IFacable;

namespace BorderControl
{
    public class Citizen : IFakable
    {
        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.ID = id;
        }
        public int Age { get; private set; }
        public string Name { get; set; }
        public string ID { get; set; }
    }
}
