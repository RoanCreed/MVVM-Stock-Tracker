using ModernDesign.MVVM.ViewModels;
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
        private readonly MessageStore _messageStore;
        
        public App()
        {
            _stocksList = new StocksList();
            _navigationStore = new NavigationStore();
            _messageStore = new MessageStore();
            
        }

        protected override void OnStartup(StartupEventArgs e)
        {

            _navigationStore.CurrentViewModel = CreateHomeViewModel();


            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore, new GlobalMessageViewModel(_messageStore), CreateHomeViewModel, CreateAddStockViewModel, CreateEditStockViewModel)
            };
            MainWindow.Show();


            base.OnStartup(e);
        }

        private HomeViewModel CreateHomeViewModel()
        {
            return new HomeViewModel(_stocksList);
        }

        private EditStockViewModel CreateEditStockViewModel()
        {
            return new EditStockViewModel(_stocksList, _navigationStore, _messageStore, new GlobalMessageViewModel(_messageStore));
        }

        private AddStockViewModel CreateAddStockViewModel()
        {
            return new AddStockViewModel(_navigationStore, _messageStore, new GlobalMessageViewModel(_messageStore));
        }

        private GlobalMessageViewModel CreateGlobalMessageViewModel()
        {
            return new GlobalMessageViewModel(_messageStore);
        }


    }
}
