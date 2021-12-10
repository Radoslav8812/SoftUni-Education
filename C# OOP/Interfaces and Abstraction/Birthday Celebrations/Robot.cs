using System;
namespace BirthdayCelebration
{
    public class Robot
    {
        public Robot(string model, string id)
        {
            this.Name = model;
            this.ID = id;
        }

        public string Name { get; set; }
        public string ID { get; set; }
    }
}
