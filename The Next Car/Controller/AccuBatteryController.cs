using System;
using System.Collections.Generic;
using System.Text;
using The_Next_Car.Model;

namespace The_Next_Car.Controller
{
    class AccuBatteryController
    {
        private AccuBattery accuBattery;
        private OnPowerChanged callBackOnPowerChanged;

        public AccuBatteryController(OnPowerChanged callBackOnPowerChanged)
        {
            this.accuBattery = new AccuBattery(12);
            this.callBackOnPowerChanged = callBackOnPowerChanged;
        }
        public bool accubatterryIsOn()
        {
            return this.accuBattery.isOn();
        }
        public void turnOn()
        {
            this.accuBattery.turnOn();
            this.callBackOnPowerChanged.onPowerChangedStatus("ON", "Power Is On");
        }
        public void turnoff()
        {
            this.accuBattery.turnOff();
            this.callBackOnPowerChanged.onPowerChangedStatus("OFF", "Power Is Off");
        }
    }
    interface OnPowerChanged
    {
        void onPowerChangedStatus(string value, string message);
    }
}
