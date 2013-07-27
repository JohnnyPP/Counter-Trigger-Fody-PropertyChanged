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
        public DateTime TimeCommand { get; set; }
        public int Counter { get; set; }
        public int CounterDiv2 { get; set; }
        public int CounterDiv3 { get; set; }
        public string CounterString { get; set; }

        public ViewModel()
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        /// <summary>
        /// Handles the Tick event of the dispatcherTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            TimeCommand = DateTime.Now;
            Counter++;
            CounterDiv2 = Counter / 2;
            CounterDiv3 = Counter / 3;

            if ((Counter % 2) == 0)
            {
                CounterString = "Counter 1 is even";
            }
            else
            {
                CounterString = "Counter 1 is odd";
            }

        } 
    }
}
