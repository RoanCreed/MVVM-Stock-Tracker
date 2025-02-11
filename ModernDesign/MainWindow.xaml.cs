using System.Windows;
using System.Windows.Input;

namespace MVVMSettings
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Topmost = true;
        }

        // Close the window with confirmation
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;  // Prevent the window from closing
            }
        }

        // Minimize Button Click Event
        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;  // Minimize the window
        }

        // Exit Button Click Event
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();  // Close the application
        }

        // Mouse Left Button Down event to allow window dragging
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Initiate dragging if the user clicks on the custom title bar
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                this.DragMove();  // Move the window with the mouse
            }
        }

        private void MainWindowView_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
