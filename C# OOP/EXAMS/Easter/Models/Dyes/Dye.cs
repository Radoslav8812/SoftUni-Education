using System;
using Easter.Models.Dyes.Contracts;

namespace Easter.Models.Dyes
{
    public class Dye :IDye
    {
        private int power;

        public Dye(int power)
        {
            Power = power;
        }

        public int Power
        {
            get
            {
                return power;
            }
            private set
            {
                power = value;

                if (value < 0)
                {
                    power = 0;
                }
            }
        }

        public bool IsFinished()
        {
            if (Power == 0)
            {
                return true;
            }
            return false;
        }

        public void Use()
        {
            Power -= 10;
        }
    }
}
