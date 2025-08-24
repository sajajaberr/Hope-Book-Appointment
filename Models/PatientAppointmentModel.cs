using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HopeBookAppointment.Models
{
    public class PatientAppointmentModel
    {
        public int PatientId { get; set; }
        public int DeviceId { get; set; }
        public int DayId { get; set; }
        public int DeviceWorkingHourId { get; set; }
        public decimal Price { get; set; }

        public string DeviceName { get; set; }

        public string DayName { get; set; }

        public string Duration { get; set; }

        public DateTime AppotimentDate { get; set; }

        public string Status { get; set; }


    }
}
