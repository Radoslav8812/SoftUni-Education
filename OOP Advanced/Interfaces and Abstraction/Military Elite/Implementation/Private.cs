
namespace MilitaryElite
{
    public class Private : Soldier, IPrivate
    {
        public Private(int id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Salary = salary;
        }
        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary:f2}";
        }
    }
}
