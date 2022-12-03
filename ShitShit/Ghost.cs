using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace ShitShit
{
    public class Ghost
    {
        public string Name { get; set; }
        public int Food = 10;
        public int Sleep = 50;
        public int Health = 30;
        public int Happy = 30;
        public int EatFear()
        {  return Food = Food + 10; }
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
        public void TimerForChangeParameters()
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 60000); ///120 000
            dispatcherTimer.Start();
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Food = Food - 10;
            Happy = Happy - 10;
            Health = Health - 5;
            Sleep = Sleep - 10;
        }
    }
}
