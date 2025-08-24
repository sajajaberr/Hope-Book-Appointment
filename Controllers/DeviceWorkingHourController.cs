using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HopeBookAppointment.Controllers
{
    public class DeviceWorkingHourController : Controller
    {
        DBEntities.HopeBookAppointmentContext context = new DBEntities.HopeBookAppointmentContext();
        public IActionResult Create()
        {
            ViewBag.Devices = context.Devices.ToList();
            ViewBag.Days = context.Days.ToList();
            return View();
        }

        public IActionResult AddNewDuration(Models.DeviceWorkingHourModel deviceWorkingHourModel)
        {
            DBEntities.DeviceWorkingHour obj = new DBEntities.DeviceWorkingHour();

            obj.DeviceId = deviceWorkingHourModel.DeviceId;
            obj.WorkingDate = deviceWorkingHourModel.WorkingDate;
            obj.FromToHour = deviceWorkingHourModel.FromToHour;

            context.DeviceWorkingHours.Add(obj);
            context.SaveChanges();

            return RedirectToAction("Home","Index");
        }

        public IActionResult GetAllDuration()
        {
            List<Models.DeviceWorkingHourModel> lst = new List<Models.DeviceWorkingHourModel>();

            lst = (from obj in context.DeviceWorkingHours.ToList()
                   join dev in context.Devices.ToList() on obj.DeviceId equals dev.DeviceId
                   select new Models.DeviceWorkingHourModel
                   {
                       DeviceName = dev.DeviceName,
                       WorkingDate = obj.WorkingDate,
                       FromToHour = obj.FromToHour,
                       WorkingDay = obj.WorkingDate.DayOfWeek.ToString(),

                   }).ToList();

            return View(lst);
        }
    }
}
