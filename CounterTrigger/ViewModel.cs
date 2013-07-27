using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace CounterTrigger
{
    [ImplementPropertyChanged]
    class ViewModel
    {

        #region Properties
        public DateTime TimeCommand { get; set; }
        public int Counter { get; set; }
        public int CounterDiv2 { get; set; }
        public int CounterDiv3 { get; set; }
        public int CounterDiv4 { get; set; }
        public int CounterDiv5 { get; set; }
        public int CounterDiv6 { get; set; }
        public int CounterTemp { get; set; }
        public string CounterString { get; set; } 
        #endregion


        #region Fields
        bool Reset = false;
        int TempCounter = 1; 
        #endregion

        public ViewModel()
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
            Counter = 0;
            CounterTemp = 0;

        }

        /// <summary>
        /// Handles the Tick event of the dispatcherTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Counters();

            Measurement3();
            
            MeasurementDisplay();

        }

        private void Counters()
        {
            TimeCommand = DateTime.Now;

            if (Reset == false)
            {
                CounterDiv2 = Counter / 2;
                CounterDiv3 = Counter / 3;
                CounterDiv4 = Counter / 4;
                CounterDiv5 = Counter / 5;
                CounterDiv6 = Counter / 6;
                Counter++;
            }
            else
            {
                Counter = 0;
                CounterDiv2 = Counter / 2;
                CounterDiv3 = Counter / 3;
                CounterDiv4 = Counter / 4;
                CounterDiv5 = Counter / 5;
                CounterDiv6 = Counter / 6;
                Counter++;
                Reset = false;
            }
        }

        private void MeasurementDisplay()
        {
            if ((CounterTemp % 2) == 0)
            {
                CounterString = "Measurement " + TempCounter.ToString();
                TempCounter++;
            }
            else
            {
                CounterString = "Adjustment";
                TempCounter = 1;
            }
        }

        private void Measurement1()
        {
            if (Counter % 2 != 0)
            {
                CounterTemp++;
                Counter++;
                Reset = true;
            }
            else
            {
                CounterTemp = Counter;
            }
        }

        private void Measurement2()
        {
            if (CounterDiv2 % 2 != 0)
            {
                CounterTemp++;
                Counter++;
                Reset = true;
            }
            else
            {
                CounterTemp = CounterDiv2;
            }
        }

        private void Measurement3()
        {
            if (CounterDiv3 % 2 != 0)
            {
                CounterTemp++;
                Counter++;
                Reset = true;
            }
            else
            {
                CounterTemp = CounterDiv3;
            }
        }

        private void Measurement4()
        {
            if (CounterDiv4 % 2 != 0)
            {
                CounterTemp++;
                Counter++;
                Reset = true;
            }
            else
            {
                CounterTemp = CounterDiv4;
            }
        }

        private void Measurement5()
        {
            if (CounterDiv5 % 2 != 0)
            {
                CounterTemp++;
                Counter++;
                Reset = true;
            }
            else
            {
                CounterTemp = CounterDiv5;
            }
        }

        private void Measurement6()
        {
            if (CounterDiv6 % 2 != 0)
            {
                CounterTemp++;
                Counter++;
                Reset = true;
            }
            else
            {
                CounterTemp = CounterDiv6;
            }
        }
    }
}
