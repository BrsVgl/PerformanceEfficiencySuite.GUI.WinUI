using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenHardwareMonitor;
using OpenHardwareMonitor.Hardware;
using OpenHardwareMonitor.Collections;

namespace PerformanceEfficiencySuite.GUI.WinUI.Models
{
  public class HardwareMonitor
  {
    Computer _computer;

		public HardwareMonitor() {
			_computer = new OpenHardwareMonitor.Hardware.Computer();
      _computer.Open();
      _computer.CPUEnabled= true;    
    }

    public float? CurrentPackagePower
    {
      get {
				var _hardware = _computer.Hardware[0];
				_hardware.Update();
				var _cpuPackageSensor = _hardware.Sensors.First(s =>	s.SensorType == SensorType.Power 
          && s.Name.Equals("CPU Package", StringComparison.InvariantCultureIgnoreCase));
				return _cpuPackageSensor.Value;
      }
    }
  }

}
