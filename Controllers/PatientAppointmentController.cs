using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HopeBookAppointment.Controllers
{
    public class PatientAppointmentController : Controller
    {
        DBEntities.HopeBookAppointmentContext context = new DBEntities.HopeBookAppointmentContext();
        public IActionResult Create()
        {
            ViewBag.Patients = (from obj in context.Patients.ToList()
                                select new
                                {
                                    Id = obj.PatientId,
                                    Name = obj.FirstName + " " + obj.LastName,
                                }).ToList();

            List<Models.PatientAppointmentModel> lst = new List<Models.PatientAppointmentModel>();

            lst = (from dev in context.Devices.ToList()
                   join work in context.DeviceWorkingHours.ToList() on dev.DeviceId equals work.DeviceId
                   select new Models.PatientAppointmentModel
                   {
                       DeviceName = dev.DeviceName,
                       DeviceId = dev.DeviceId,
                        Duration = work.FromToHour,
                        AppotimentDate = work.WorkingDate, 
                        DayName = work.WorkingDate.DayOfWeek.ToString(),
                        Status = RetrunStatus(dev.DeviceId, work.DeviceWorkingHourId),
                        DeviceWorkingHourId = work.DeviceWorkingHourId
                   }).ToList();

            return View(lst);
        }

        public string RetrunStatus(int DeviceId, int DeviceWorkingHourId)
        {
            int count = context.PatientAppointments.Where(x => x.DeviceId == DeviceId &&
            x.DeviceWorkingHourId == DeviceWorkingHourId).Count();

            if (count == 0)
                return "Avilable";
            else
                return "Booked";
        }

        public IActionResult BookThisTime(int DeviceId, int WorkingHourId)
        {
            DBEntities.PatientAppointment obj = new DBEntities.PatientAppointment();
            obj.DeviceId = DeviceId;
            obj.DeviceWorkingHourId = WorkingHourId;
            obj.Price = 10;
            obj.DayId = 2;
            obj.PatientId = 2;

            context.PatientAppointments.Add(obj);
            context.SaveChanges();

            return RedirectToAction("Create");
        }
    }
}
