using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using The_Next_Car.Controller;

namespace The_Next_Car
{
    public partial class MainWindow : Window, OnDoorChanged, OnPowerChanged,OnCarEngineStatusChangesd
    {
        private Car nextcar;
        public MainWindow()
        {
            InitializeComponent();

            AccuBatteryController accuBatteryController = new AccuBatteryController(this);
            DoorController doorController = new DoorController(this);

            nextcar = new Car(accuBatteryController, doorController, this);
        }

        public void carEngineStatusChanged(string value, string message)
        {
            Status.Content = message;
            startButton.Content = value;
        }
        public void doorSecurityChanged(string value, string message)
        {
            this.LockOpenState.Content = message;
            this.LockDoorButton.Content = value;
        }
        public void doorStatusChanged(string value, string message)
        {
            this.DoorOpenState.Content = message;
            this.DoorOpenButton.Content = value;
        }
        public void onPowerChangedStatus (string value, string message)
        {
            this.AccuState.Content = message;
            this.AccuButton.Content = value;
        }
        private void OnStartButtonClicked(object sender, RoutedEventArgs e)
        {
            this.nextcar.togglestartEngineButton();
        }
        private void OnDoorOpenButtonClicked(object sender, RoutedEventArgs e)
        {
            this.nextcar.toggleTheDoorButton();
        }
        private void OnLockDoorButtonClicked(object sender, RoutedEventArgs e)
        {
            this.nextcar.toggleTheLoockDoorButton();
        }
        private void OnAccuButtonClicked(object sender, RoutedEventArgs e)
        {
            this.nextcar.toggleThePowerButton();
        }

        private void Image_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }
    }
}
