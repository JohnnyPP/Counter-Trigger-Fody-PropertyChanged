using PropertyChanged;
using System;
using System.Windows.Input;
using System.Windows.Threading;

namespace CounterTrigger
{
    [ImplementPropertyChanged]
    public class ViewModel
    {
        //MeasurementsClass MC = new MeasurementsClass();

        #region Properties
        public DateTime TimeCommand { get; set; }
        public int Counter { get; set; }
        public int CounterDiv2 { get; set; }
        public int CounterDiv3 { get; set; }
        public int CounterDiv4 { get; set; }
        public int CounterDiv5 { get; set; }
        public int CounterDiv6 { get; set; }
        public int CounterTemp { get; set; }
        public int NumberOfMeasurements { get; set; }
        public string CounterString { get; set; }           //"Measurement " + TempCounter.ToString();
        #endregion


        #region Fields
        public bool Reset = false;
        public bool RunMeasurement = false;
        public int TempCounter = 1; 
        public int[] CountersArray = new int[6];
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
            TimeCommand = DateTime.Now;

            if (RunMeasurement==true)
            {
                Counters();

                MeasurementsFunction(NumberOfMeasurements, CountersArray);
              
                MeasurementDisplay(); 
            }
        }

        private void Counters()
        {
            if (Reset == false)
            {
                CounterDiv2 = Counter / 2;
                CounterDiv3 = Counter / 3;
                CounterDiv4 = Counter / 4;
                CounterDiv5 = Counter / 5;
                CounterDiv6 = Counter / 6;
                Counter++;

                CountersArray[0] = Counter;
                CountersArray[1] = CounterDiv2;
                CountersArray[2] = CounterDiv3;
                CountersArray[3] = CounterDiv4;
                CountersArray[4] = CounterDiv5;
                CountersArray[5] = CounterDiv6;
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

                CountersArray[0] = Counter;
                CountersArray[1] = CounterDiv2;
                CountersArray[2] = CounterDiv3;
                CountersArray[3] = CounterDiv4;
                CountersArray[4] = CounterDiv5;
                CountersArray[5] = CounterDiv6;

            }
        }

        public void MeasurementsFunction(int Measurement, int[] CountersArray)
        {
            switch (Measurement)
            {
                case 1:
                    if (CountersArray[0] % 2 != 0)          //is odd?
                    {

                        CounterTemp++;                      //measurement is on as long as CounterTemp==0 
                        Reset = true;
                    }
                    else                                    //is even? //this is the always the case 
                    {
                        CounterTemp = CountersArray[0];
                    }
                    break;
                case 2:
                    if (CountersArray[1] % 2 != 0)
                    {
                        CounterTemp++;
                        Reset = true;
                    }
                    else
                    {
                        CounterTemp = CountersArray[1];
                    }
                    break;
                case 3:
                    if (CountersArray[2] % 2 != 0)
                    {
                        CounterTemp++;
                        Reset = true;
                        RunMeasurement = false;             //stops measurement after adjustment
                    }
                    else
                    {
                        CounterTemp = CountersArray[2];
                    }
                    break;
                case 4:
                    if (CountersArray[3] % 2 != 0)
                    {
                        CounterTemp++;
                        Reset = true;
                        RunMeasurement = false;
                    }
                    else
                    {
                        CounterTemp = CountersArray[3];
                    }
                    break;
                case 5:
                    if (CountersArray[4] % 2 != 0)
                    {
                        CounterTemp++;
                        Reset = true;
                        RunMeasurement = false;
                    }
                    else
                    {
                        CounterTemp = CountersArray[4];
                    }
                    break;
                case 6:
                    if (CountersArray[5] % 2 != 0)
                    {
                        CounterTemp++;
                        Reset = true;
                        RunMeasurement = false;
                    }
                    else
                    {
                        CounterTemp = CountersArray[5];
                    }
                    break;
                default:
                    break;
            }


        }
        
        private void MeasurementDisplay()
        {
            if ((CounterTemp % 2) == 0)             //is even? //measurement is on as long as CounterTemp==0 
            {
                CounterString = "Measurement " + TempCounter.ToString();
                TempCounter++;                      //not needed in LabVIEW
            }
            else
            {
                CounterString = "Adjustment";
                TempCounter = 1;                    //not needed in LabVIEW
            }
        }

        private int CounterFunction(int Measurements)
        {
            if (Reset == false)
            {
                int temp;
                temp = Counter / Measurements;
                Counter++;
                return temp;
                
            }
            else
            {
                Counter = 0;
                Counter++;
                Reset = false;
                return Counter / Measurements;
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
                RunMeasurement = false;
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
                RunMeasurement = false;
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
                RunMeasurement = false;
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
                RunMeasurement = false;
            }
            else
            {
                CounterTemp = CounterDiv6;
            }
        }

        #region RelayCommand
        void RunMeasurementButtonCommand()
        {
            RunMeasurement = true;
        }

        /// <summary>
        /// Determines whether this instance [can exit application execute].
        /// </summary>
        /// <returns>
        /// <c>true</c> if this instance [can exit application execute]; otherwise, <c>false</c>.
        /// </returns>
        bool CanRunMeasurementButtonExecute()
        {
            return true;
        }

        /// <summary>
        /// Gets the exit application click.
        /// </summary>
        /// <value>
        /// The exit application click.
        /// </value>
        public ICommand RunMeasurementButtonClick //bind to "ExitApplicationClick" name in XAML
        {
            get { return new RelayCommand(RunMeasurementButtonCommand, CanRunMeasurementButtonExecute); }
        } 
        #endregion
    }


    //public class MeasurementsClass
    //{
    //    ViewModel VM = new ViewModel();

    //    public void MeasurementsFunction(int Measurement, int[] CountersArray)
    //    {
    //        switch (Measurement)
    //        {
    //            case 1:
    //                if (CountersArray[0] % 2 != 0)
    //                {

    //                    VM.CounterTemp++;
    //                    VM.Counter++;
    //                    VM.Reset = true;
    //                }
    //                else
    //                {
    //                    VM.CounterTemp = CountersArray[0];
    //                }
    //                break;
    //            case 2:
    //                if (CountersArray[1] % 2 != 0)
    //                {
    //                    VM.CounterTemp++;
    //                    VM.Counter++;
    //                    VM.Reset = true;
    //                }
    //                else
    //                {
    //                    VM.CounterTemp = CountersArray[1];
    //                }
    //                break;
    //            case 3:
    //                if (CountersArray[2] % 2 != 0)
    //                {
    //                    VM.CounterTemp++;
    //                    VM.Counter++;
    //                    VM.Reset = true;
    //                    VM.RunMeasurement = false;
    //                }
    //                else
    //                {
    //                    VM.CounterTemp = CountersArray[2];
    //                }
    //                break;
    //            case 4:
    //                if (CountersArray[3] % 2 != 0)
    //                {
    //                    VM.CounterTemp++;
    //                    VM.Counter++;
    //                    VM.Reset = true;
    //                    VM.RunMeasurement = false;
    //                }
    //                else
    //                {
    //                    VM.CounterTemp = CountersArray[3];
    //                }
    //                break;
    //            case 5:
    //                if (CountersArray[4] % 2 != 0)
    //                {
    //                    VM.CounterTemp++;
    //                    VM.Counter++;
    //                    VM.Reset = true;
    //                    VM.RunMeasurement = false;
    //                }
    //                else
    //                {
    //                    VM.CounterTemp = CountersArray[4];
    //                }
    //                break;
    //            case 6:
    //                if (CountersArray[5] % 2 != 0)
    //                {
    //                    VM.CounterTemp++;
    //                    VM.Counter++;
    //                    VM.Reset = true;
    //                    VM.RunMeasurement = false;
    //                }
    //                else
    //                {
    //                    VM.CounterTemp = CountersArray[5];
    //                }
    //                break;
    //            default:
    //                break;
    //        }


    //    }

    //}
}
