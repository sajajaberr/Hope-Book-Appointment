using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HopeBookAppointment.Controllers
{
    public class DeviceController : Controller
    {
        DBEntities.HopeBookAppointmentContext context = new DBEntities.HopeBookAppointmentContext();
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult AddNewDevice(Models.DeviceModel deviceModel)
        {
            string folderName = "Device";
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files/" + folderName);

            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string fileName = deviceModel.Image.FileName;
            string fileNameWithPath = Path.Combine(path, fileName);

            using (var steam = new FileStream(fileNameWithPath, FileMode.Create))
            {
                deviceModel.Image.CopyTo(steam);
            }

            var host = HttpContext.Request.Host.Value; // will get www.mywebsite.com
          

            DBEntities.Device obj = new DBEntities.Device();
            obj.DeviceName = deviceModel.DeviceName;
            obj.ResponsibleEmployee = deviceModel.ResponsibleEmployee;
            obj.Description = deviceModel.Description;
            obj.Price = deviceModel.Price;
            obj.Image = "http://" + host + "/Files/" + folderName + "/" + fileName;

            context.Devices.Add(obj);
            context.SaveChanges();

            return RedirectToAction("GetAllDevice");
        }

        public IActionResult Update()
        {
            var result = context.Devices.Where(x => x.DeviceId == 3).FirstOrDefault();
            Models.DeviceModel deviceModel = new Models.DeviceModel();

            deviceModel.DeviceName = result.DeviceName;
            deviceModel.Description = result.Description;
            deviceModel.ImageFullPath = result.Image;
            ViewBag.ImageFullPath = result.Image;
            return View(deviceModel);

        }

        public IActionResult GetAllDevice()
        {
            List<Models.DeviceModel> lst = new List<Models.DeviceModel>();
            lst = (from obj in context.Devices.ToList()
                   select new Models.DeviceModel
                   {
                       DeviceName = obj.DeviceName,
                       ResponsibleEmployee = obj.ResponsibleEmployee,
                       Description = obj.Description,
                       DeviceId = obj.DeviceId,
                       ImageFullPath = obj.Image,
                       Price = obj.Price,
                   }).ToList();

            return View(lst);
        }
    }
}
