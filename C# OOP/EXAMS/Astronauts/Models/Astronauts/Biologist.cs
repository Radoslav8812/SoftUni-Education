using System;
namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        public Biologist(string name) : base(name, 70)
        {
        }

        public override void Breath()
        {
            base.Breath();

            if (this.Oxygen - 5 > 0)
            {
                this.Oxygen -= 5;
            }
        }
    }
}
