using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;


namespace SQLite2CEDemo
{
    public class QueViewModel : INotifyPropertyChanged
    {
        public static Catappdb mycat;

          public QueViewModel()
        {
        //    this.yearData = new ObservableCollection<Tests>();
          //  this.categoryData = new ObservableCollection<Categories>();
         this.queOptions= new ObservableCollection<Quest>();
         //   this.countryPopulation = new ObservableCollection<CountryPopulationViewModel>();
        }

        /// <summary>
        /// A collection for Country objects.
        /// </summary>
      //  public ObservableCollection<Tests> yearData { get; private set; }

        /// <summary>
        /// A collection for City objects.
        /// </summary>
        //public ObservableCollection<Categories> categoryData { get; private set; }

        /// <summary>
        /// A collection for CountryCapitals objects.
        /// </summary>
      public ObservableCollection<Quest> queOptions { get; private set; }

        //// <summary>
        /// A collection for CountryPopulationViewModel objects.
        /// </summary>
   //     public ObservableCollection<CountryPopulationViewModel> countryPopulation { get; private set; }

        /// <summary>
        /// A boolean value representing wheter or not ViewModel data has been loaded.
        /// </summary>
        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Populates the ViewModel's data objects with items from the database.
        /// </summary>
     //   int i=490;
        public void LoadData()
        {
          
            IEnumerable<Quest> myQue = new Quest().GetResults(Page1.myCatapp);
         

            IEnumerable<Quest> myOpt = new Quest().GetResults1(Page1.myCatapp);
   
             IEnumerable<Quest> results = myQue.Union(myOpt);
          
            foreach (Quest thisQue in results)
            {
              this.queOptions.Add(thisQue);
              
            }

                    this.IsDataLoaded = true;
        }

       
        private IEnumerable<Questions> getAllQueData()
        {
            return from eachQue in Page1.myCatapp.Questions
                   select eachQue;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
            }
}