using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace The_Next_Car.Controller
{
    class Car
    {
        AccuBatteryController accuBatteryController;
        DoorController doorController;
        OnCarEngineStatusChangesd callbackCarEngineStatusChanges;

        public Car(AccuBatteryController accuBatteryController, DoorController doorController, OnCarEngineStatusChangesd callbackCarEngineStatusChanges)
        {
            this.accuBatteryController = accuBatteryController;
            this.doorController = doorController;
            this.callbackCarEngineStatusChanges = callbackCarEngineStatusChanges;
        }

        public void turnOnPower()
        {
            this.accuBatteryController.turnOn();
        }
        public void turnOffPower()
        {
            this.accuBatteryController.turnoff();
        }
        public bool PowerIsReady()
        {
            return this.accuBatteryController.accubatterryIsOn();
        }
        public void closeTheDoor()
        {
            this.doorController.close();
        }
        public void openTheDoor()
        {
            this.doorController.open();
        }
        public void lockTheDoor()
        {
            this.doorController.activateLock();
        }
        public void unlockTheDoor()
        {
            this.doorController.unlock();
        }
        private bool doorIsClosed()
        {
            return this.doorController.isClose();
        }
        private bool doorIsLocked()
        {
            return this.doorController.isLocked();
        }
        public void togglestartEngineButton()
        {
            if (!doorIsClosed())
            {
                this.callbackCarEngineStatusChanges.carEngineStatusChanged("STOPED", "Door Is Open");
                MessageBox.Show("Door Is Open", "Warning!");
                return;
            }
            if (!doorIsLocked())
            {
                this.callbackCarEngineStatusChanges.carEngineStatusChanged("STOPED", "Door Unlocked");
                MessageBox.Show("Door Unlocked", "Warning!");
                return;
            }
            if (!PowerIsReady())
            {
                this.callbackCarEngineStatusChanges.carEngineStatusChanged("STOPED", "No Power Available");
                MessageBox.Show("No Power Available", "Warning!");
                return;
            }
            this.callbackCarEngineStatusChanges.carEngineStatusChanged("STARTED", "Engine Started");
        }
        
        public void toggleTheLoockDoorButton()
        {
            if (!doorIsLocked())
            {
                this.lockTheDoor();
            }
            else
            {
                this.unlockTheDoor();
            }
        }
        public void toggleTheDoorButton()
        {
            if (!doorIsClosed())
            {
                this.closeTheDoor();
            }
            else
            {
                this.openTheDoor();
            }
        }
        public void toggleThePowerButton()
        {
            if (!PowerIsReady())
            {
                this.turnOnPower();
            }
            else
            {
                this.turnOffPower();
            }
        }
    }
    interface OnCarEngineStatusChangesd
    {
        void carEngineStatusChanged(string value, string message);
    }
}
