using ModernDesign.Core;
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
        public MainViewModel(NavigationStore navigationStore, Func<ViewModelBase> CreateHomeViewModel, Func<ViewModelBase> CreateAddStockViewModel, Func<ViewModelBase> CreateEditStockViewModel)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;


            HomeViewCommand = new NavigationCommand(navigationStore, CreateHomeViewModel);
            AddStockViewCommand = new NavigationCommand(navigationStore, CreateAddStockViewModel);
            EditStockViewCommand = new NavigationCommand(navigationStore, CreateEditStockViewModel);


        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        
    }
}
