using System;
using System.Collections.Generic;

#nullable disable

namespace HopeBookAppointment.DBEntities
{
    public partial class Device
    {
        public Device()
        {
            DeviceWorkingHours = new HashSet<DeviceWorkingHour>();
            PatientAppointments = new HashSet<PatientAppointment>();
        }

        public int DeviceId { get; set; }
        public string DeviceName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string ResponsibleEmployee { get; set; }

        public virtual ICollection<DeviceWorkingHour> DeviceWorkingHours { get; set; }
        public virtual ICollection<PatientAppointment> PatientAppointments { get; set; }
    }
}
