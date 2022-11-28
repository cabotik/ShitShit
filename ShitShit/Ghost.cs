using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShitShit
{
    public class Ghost
    {
        public string Name { get; set; }
        public int Food = 100;
        public int Sleep = 100;
        public int Health = 100;
        public int Happy = 100;

        public int Healthing()
        { return Health = Health + 50; }        
        public int EatFear()
        { return Food = Food + 10; }
        public int EatPersonsSoul()
        { return Food = Food + 30; }
        public int EatRatsSoul()
        { return Food = Food + 20; }
        public int PlayWithPerson()
        { return Happy = Happy + 30; }
        public int PlayWithRats()
        { return Happy = Happy + 20; }
        public int PlayWithBones()
        { return Happy = Happy + 10; }

        public int FoodReturn()
        { return Food; }
        public int HealthReturn()
        { return Health; }
        public int SleepReturn()
        { return Sleep; }
        public int HappyReturn()
        { return Happy;}




    }
}
