using System;
namespace BirthdayCelebration
{
    public class Pet : IBirthable
    {
        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.BirthDate = birthdate;
        }
        public string Name { get; set; }
        public string BirthDate { get; set; }
    }
}
