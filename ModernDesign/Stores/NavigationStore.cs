using MVVMSettings.MVVM.ViewModels;
using System;


namespace ModernDesign.Stores
{
    public class NavigationStore
    {
        private ViewModelBase _currentViewModel;

       
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

        public event Action CurrentViewModelChanged;

    }
}
