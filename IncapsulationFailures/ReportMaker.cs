

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incapsulation.Failures
{

    public class Common
    {
        public static int IsFailureSerious(int failureType)
        {
            if (failureType % 2 == 0) return 1;
            return 0;
        }


        public static int Earlier(object[] v, int day, int month, int year)
        {
            int vYear = (int)v[2];
            int vMonth = (int)v[1];
            int vDay = (int)v[0];
            if (vYear < year) return 1;
            if (vYear > year) return 0;
            if (vMonth < month) return 1;
            if (vMonth > month) return 0;
            if (vDay < day) return 1;
            return 0;
        }
    }
    
    public class ReportMaker
    {
        /// <summary>
        /// </summary>
        /// <param name="day"></param>
        /// <param name="failureTypes">
        /// 0 for unexpected shutdown, 
        /// 1 for short non-responding, 
        /// 2 for hardware failures, 
        /// 3 for connection problems
        /// </param>
        /// <param name="deviceId"></param>
        /// <param name="times"></param>
        /// <param name="devices"></param>
        /// <returns></returns>
        public static List<string> FindDevicesFailedBeforeDateObsolete(
            int day,
            int month,
            int year,
            int[] failureTypes,
            int[] deviceId,
            object[][] times,
            List<Dictionary<string, object>> devices)
        {
            DateTime Deadline = new DateTime(year, month, day);
            Device[] Devices = new Device[devices.Count];
            Failure[] Failures = new Failure[failureTypes.Length];

            // <Ugly code to readable code>

            foreach (var dev in devices)
            {
                Devices.Append(new Device 
                {
                    Id = (int)dev["DeviceId"],
                    Name = (string)dev["Name"]
                });
            }

            int i = 0;
            foreach (var failure in failureTypes)
            {
                Failures.Append(new Failure
                {
                    Date = new DateTime((int)times[i][2], (int)times[i][1], (int)times[i][0]),
                    DeviceId = deviceId[i],
                    Type = (FailureType)failureTypes[i]
                });
                i++;
            }
            // </Ugly code to readable code>

            return FindDevicesFailedBeforeDate(Deadline, Devices, Failures);
        }
        public static List<string> FindDevicesFailedBeforeDate(DateTime Deadline, Device[] Devices, Failure[] Failures)
        {
            var problematicDevices = new HashSet<int>();
            foreach (var fail in Failures)
            {
                if ((fail.Type == FailureType.Hardware ||
                     fail.Type == FailureType.UnexpectedShutdown) &&
                     fail.Date.CompareTo(Deadline) < 0) // <0 is Earlier 
                {
                    problematicDevices.Add(fail.DeviceId);
                }
            }
            var result = new List<string>();

            foreach (var Device in Devices)
                if (problematicDevices.Contains(Device.Id))
                    result.Add(Device.Name);

            return result;
        }
        public class Device
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public class Failure
        {
            public FailureType Type { get; set; }
            public DateTime Date { get; set; }
            public int DeviceId { get; set; }
        }
        public enum FailureType
        {
            UnexpectedShutdown = 0,
            NonResponding = 1,
            Hardware = 2,
            Connection = 3
        }
    }
}