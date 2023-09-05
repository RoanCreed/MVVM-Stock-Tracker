using ModernDesign.Stores;
using MVVMSettings.MVVM.Models;
using MVVMSettings.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMSettings
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly StocksList _stocksList;
        private readonly NavigationStore _navigationStore;
        
        public App()
        {
            _stocksList = new StocksList();
            _navigationStore = new NavigationStore();
            
        }

        protected override void OnStartup(StartupEventArgs e)
        {

            _navigationStore.CurrentViewModel = CreateHomeViewModel();


            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore, CreateHomeViewModel, CreateAddStockViewModel)
            };
            MainWindow.Show();


            base.OnStartup(e);
        }

        private HomeViewModel CreateHomeViewModel()
        {
            return new HomeViewModel(_stocksList, _navigationStore);
        }

        private AddStockViewModel CreateAddStockViewModel()
        {
            return new AddStockViewModel(_stocksList, _navigationStore);
        }


    }
}
