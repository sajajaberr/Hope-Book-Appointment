using System;
using System.Collections.Generic;

#nullable disable

namespace HopeBookAppointment.DBEntities
{
    public partial class PatientAppointment
    {
        public int PatientAppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DeviceId { get; set; }
        public int DayId { get; set; }
        public int DeviceWorkingHourId { get; set; }
        public decimal Price { get; set; }

        public virtual Day Day { get; set; }
        public virtual Device Device { get; set; }
        public virtual DeviceWorkingHour DeviceWorkingHour { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
