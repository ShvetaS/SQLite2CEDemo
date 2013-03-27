using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.IO;
using System.IO.IsolatedStorage;
using Microsoft.Phone.Tasks;

namespace SQLite2CEDemo
{
    public partial class Page1 : PhoneApplicationPage
    {
        
        private const string ConnectionString = @"isostore:/catappdb.sdf"; //Connection String to Database in Isolated Storage
        public static Catappdb myCatapp; //Database reference
        public static Questions selectNext; //Currently selected city (last city clicked on City pivot screen)

        /// <summary>
        /// MainPage Constructor.
        /// Initializes the connection to the database in isolated storage and copies a fresh copy of the database
        /// to isolated storage. If a copy of the database doesn't already exist in isolated storage then one
        /// is copied from content. Sets the Datacontext of the MainPage class to our MainViewModel through the
        /// App class. Sets an event handler for MainPage_Loaded.
        /// </summary>
        public Page1()
        {
            InitializeComponent();

            myCatapp = new Catappdb(ConnectionString);

            if (!myCatapp.DatabaseExists())
                copyDatabaseToIsolatedStorage();

            DataContext = App.ViewModel1;
            this.Loaded += new RoutedEventHandler(Page1_Loaded);
        }

        /// <summary>
        /// Event triggered when MainPage is loaded. If data from the ViewModel hasn't been loaded yet then
        /// do so.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page1_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel1.IsDataLoaded)
            {
                App.ViewModel1.LoadData();
            }
        }

        /// <summary>
        /// Using the application's isolated storage, copy the countries.sdf database from content into isolated
        /// storage.
        /// </summary>
        private void copyDatabaseToIsolatedStorage()
        {
            using (IsolatedStorageFile str = IsolatedStorageFile.GetUserStoreForApplication())
            {
                Stream database = Application.GetResourceStream(new Uri("catappdb.sdf", UriKind.Relative)).Stream;
                IsolatedStorageFileStream isoDatabase = new IsolatedStorageFileStream("catappdb.sdf", FileMode.Create, FileAccess.Write, str);
                database.CopyTo(isoDatabase);
                database.Close();
                isoDatabase.Close();
            }
        }


        private void QueListBox_Tap(object sender, GestureEventArgs e)
        {
            if (QueListBox.SelectedItem != null)
            {
                selectNext = QueListBox.SelectedItem as Questions;
                NavigationService.Navigate(new Uri("/Page1.xaml", UriKind.Relative));
            }
        }

        
    }
}
