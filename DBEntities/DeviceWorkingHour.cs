using System;
using System.Collections.Generic;

#nullable disable

namespace HopeBookAppointment.DBEntities
{
    public partial class DeviceWorkingHour
    {
        public DeviceWorkingHour()
        {
            PatientAppointments = new HashSet<PatientAppointment>();
        }

        public int DeviceWorkingHourId { get; set; }
        public int DeviceId { get; set; }
        public DateTime WorkingDate { get; set; }
        public string FromToHour { get; set; }

        public virtual Device Device { get; set; }
        public virtual ICollection<PatientAppointment> PatientAppointments { get; set; }
    }
}
