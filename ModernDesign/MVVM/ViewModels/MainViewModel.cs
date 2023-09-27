using ModernDesign.Core;
using ModernDesign.MVVM.ViewModels;
using ModernDesign.Stores;
using System;
using System.Windows.Input;

namespace MVVMSettings.MVVM.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        public ICommand AddStockViewCommand { get; }
        public ICommand HomeViewCommand { get; }
        public ICommand EditStockViewCommand { get; }

        public GlobalMessageViewModel GlobalMessageViewModel { get; }

        public MainViewModel(NavigationStore navigationStore, MessageStore messageStore, GlobalMessageViewModel globalMessageViewModel, Func<ViewModelBase> CreateHomeViewModel, Func<ViewModelBase> CreateAddStockViewModel, Func<ViewModelBase> CreateEditStockViewModel)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            GlobalMessageViewModel = globalMessageViewModel;

           

            HomeViewCommand = new NavigationCommand(navigationStore, CreateHomeViewModel, messageStore);
            AddStockViewCommand = new NavigationCommand(navigationStore, CreateAddStockViewModel, messageStore);
            EditStockViewCommand = new NavigationCommand(navigationStore, CreateEditStockViewModel, messageStore);


        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        
    }
}
