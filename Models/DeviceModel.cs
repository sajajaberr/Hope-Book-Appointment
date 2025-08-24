using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HopeBookAppointment.Models
{
    public class DeviceModel
    {
        public int DeviceId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string DeviceName { get; set; }
        public string Description { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public decimal Price { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public IFormFile Image { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string ResponsibleEmployee { get; set; }

        public string ImageFullPath { get; set; }

    }
}
