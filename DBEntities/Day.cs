using System;
using System.Collections.Generic;

#nullable disable

namespace HopeBookAppointment.DBEntities
{
    public partial class Day
    {
        public Day()
        {
            PatientAppointments = new HashSet<PatientAppointment>();
        }

        public int DayId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PatientAppointment> PatientAppointments { get; set; }
    }
}
