using System;
using System.Collections.Generic;

#nullable disable

namespace HopeBookAppointment.DBEntities
{
    public partial class Patient
    {
        public Patient()
        {
            PatientAppointments = new HashSet<PatientAppointment>();
        }

        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public bool Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool HasHealthInsurance { get; set; }

        public virtual ICollection<PatientAppointment> PatientAppointments { get; set; }
    }
}
