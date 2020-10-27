# The Next Car
The Next Car adalah program simulasi keamanan pada kendaraan.

### Cara Menggunakan
- User hanya menekan tombol pada program dan menyesuaikan saja.

### Kelebihan & Kekurangan
#### - Kelebihan
- Tampilan tidak membosankan
- Memberikan inovasi kepada orang lain

#### - Kekurangan
- Tampilan tidak bisa bergerak

### Penjelasan Koding
Pada program kali ini saya membuat beberapa Class yang digunakan untuk Model dan Controller.

    class Door
    {
        private bool closed;
        private bool locked;

        public void close()
        {
            this.closed = true;
        }
        public void open()
        {
            this.closed = false;
        }
    ...

Pada Class Door ini digunakan untuk deklarasi dan fungsi dari "Closed dan Locked", berikutnya :

    class AccuBattery
    {
        private int voltage;
        private Boolean stateOn = false;

        public AccuBattery(int voltage)
        {
            this.voltage = voltage;
        }
        public void turnOn()
        {
            this.stateOn = true;
        }
    ...

Pada Class AccuBattery ini berfungsi untuk deklarasi dan fungsi dari "Voltage dan StateOn", berikutnya kita masuk ke Class :

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
    ...

Di Class DoorController digunakan untuk Pengimplementasi dan logika program dengan objek Classnya adalah Door.cs, berikutnya : 

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
    ...

Pada Class ini juga memiliki fungsi yang sama pada Class yang diatas namun objek Classnya adalah Class AccuBattery.cs, berikutnya :

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
    ...

Class ini digunakan untuk menyatukan Class AccuBatteryController dan DoorController dan menyempurnakan logika untuk program ini.

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
    ...

Pada Class Utama ini berfungsi untuk memanggil dari fungsi-fungsi yang sudah dibuat pada Class sebelumnya.




