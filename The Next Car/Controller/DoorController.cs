using System;
using System.Collections.Generic;
using System.Text;
using The_Next_Car.Model;

namespace The_Next_Car.Controller
{
    class DoorController
    {
        private Door door;
        private OnDoorChanged onDoorChanged;

        public DoorController(OnDoorChanged onDoorChanged)
        {
            this.door = new Door();
            this.onDoorChanged = onDoorChanged;
        }
        public void close()
        {
            this.door.close();
            this.onDoorChanged.doorStatusChanged("CLOSED", "Dor Is Closed");
        }
        public void open()
        {
            this.door.open();
            this.onDoorChanged.doorStatusChanged("OPENED", "Dor Is Opened");

        }
        public void activateLock()
        {
            if (this.door.isClosed())
            {
                this.door.activateLock();
                onDoorChanged.doorSecurityChanged("LOCKED", "Door Is Locked");
            }
            else
            {
                unlock();
            }
        }
        public void unlock()
        {
            this.door.unlock();
            onDoorChanged.doorSecurityChanged("UNLOCKED", "Door Is Unlocked");
        }
        public bool isClose()
        {
            return this.door.isClosed();
        }
        public bool isLocked()
        {
            return this.door.isLocked();
        }
    }
    interface OnDoorChanged
    {
        void doorSecurityChanged(string vale, string message);
        void doorStatusChanged(string vale, string message);
    }
}
