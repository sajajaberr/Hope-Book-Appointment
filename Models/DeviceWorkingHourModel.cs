using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HopeBookAppointment.Models
{
    public class DeviceWorkingHourModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public int DeviceId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public DateTime WorkingDate { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string FromToHour { get; set; }

        public string DeviceName { get; set; }

        public string WorkingDay { get; set; }
    }
}
