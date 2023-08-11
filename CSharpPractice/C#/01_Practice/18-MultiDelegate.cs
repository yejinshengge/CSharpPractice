namespace CSharpPractice.Class01;

public class MultiDelegate
{
    /**
     * 冷却器
     */
    public class Cooler
    {
        // 设定温度
        public float Temperature { get; set; }

        public Cooler(float ratedTemp)
        {
            Temperature = ratedTemp;
        }
        // 温度改变事件
        public void OnTemperatureChanged(object? thermostat,Thermostat.TemperatureArgs args)
        {
            Console.WriteLine("冷却器："+(args.NewTemp > Temperature? "开":"关"));
        }
    }
    
    /**
     * 加热器
     */
    public class Heater
    {
        // 设定温度
        public float Temperature { get; set; }

        public Heater(float ratedTemp)
        {
            Temperature = ratedTemp;
        }
        // 温度改变事件
        public void OnTemperatureChanged(object? thermostat,Thermostat.TemperatureArgs args)
        {
            Console.WriteLine("加热器："+(args.NewTemp < Temperature? "开":"关"));
        }
    }
    
    /**
     * 恒温器
     */
    public class Thermostat
    {
        // 当前温度
        private float _CurrentTemp;

        public float CurrentTemp
        {
            get => _CurrentTemp;
            set
            {
                if (value != _CurrentTemp)
                {
                    _CurrentTemp = value;
                    // OnTemperatureChanged(value);
                    // 防止为空
                    _OnTemperatureChanged?.Invoke(this,new TemperatureArgs(value));
                }
            }
        }
        // 委托
        // public Action<float>? OnTemperatureChanged { get; set; }
        public class TemperatureArgs : EventArgs
        {
            public float NewTemp { get; set; }
            public TemperatureArgs(float temperature)
            {
                NewTemp = temperature;
            }
        }
        // 事件
        // public event EventHandler<TemperatureArgs> OnTemperatureChanged = delegate {  };
        public event EventHandler<TemperatureArgs> OnTemperatureChanged
        {
            add
            {
                _OnTemperatureChanged = (EventHandler<TemperatureArgs>)Delegate.Combine(value, _OnTemperatureChanged);
            }
            remove
            {
                _OnTemperatureChanged = (EventHandler<TemperatureArgs>)Delegate.Remove(_OnTemperatureChanged, value);
            }
        }
        protected EventHandler<TemperatureArgs>? _OnTemperatureChanged;
    }

    public static void MultiDelegateMain()
    {
        Thermostat thermostat = new Thermostat();
        Heater heater = new Heater(20);
        Cooler cooler = new Cooler(30);
        // 注册事件
        thermostat.OnTemperatureChanged += heater.OnTemperatureChanged;
        thermostat.OnTemperatureChanged += cooler.OnTemperatureChanged;
        
        // thermostat.CurrentTemp = 40;
        // thermostat.OnTemperatureChanged(40);
        // thermostat.OnTemperatureChanged = cooler.OnTemperatureChanged;

    }
}