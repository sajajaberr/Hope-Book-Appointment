using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HopeBookAppointment.Controllers
{
    public class PatientController : Controller
    {
        DBEntities.HopeBookAppointmentContext context = new DBEntities.HopeBookAppointmentContext();

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult AddNewPatient(Models.PatientModel patientModel)
        {
            DBEntities.Patient obj = new DBEntities.Patient();
            obj.FirstName = patientModel.FirstName;
            obj.LastName = patientModel.LastName;
            obj.Email = patientModel.Email;
            obj.Mobile = patientModel.Mobile;
            obj.Gender = patientModel.Gender == "1" ? true : false;
            obj.Password = patientModel.Password;

            context.Patients.Add(obj);
            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult GetAllPatient()
        {
            List<Models.PatientModel> lst = new List<Models.PatientModel>();

            lst = (from obj in context.Patients.ToList()
                   select new Models.PatientModel
                   {
                       FirstName = obj.FirstName,
                       LastName = obj.LastName,
                       Email = obj.Email,
                       Mobile = obj.Mobile,
                       Gender = obj.Gender == true ? "1" : "0",
                       HasHealthInsurance = obj.HasHealthInsurance,
                       PatientId = obj.PatientId,
                   }).ToList();

            return View(lst);
        }

        public IActionResult Update(int Id)
        {
            Models.PatientModel patientModel = new Models.PatientModel();
            var result = context.Patients.Where(x => x.PatientId == Id).FirstOrDefault();

            patientModel.FirstName = result.FirstName;
            patientModel.LastName = result.LastName;
            patientModel.Mobile = result.Mobile;
            patientModel.Email = result.Email;
            patientModel.Gender = result.Gender == true ? "1" : "0";
            patientModel.PatientId = result.PatientId;


            return View(patientModel);
        }

        public IActionResult UpdatePatient(Models.PatientModel patientModel)
        {
            DBEntities.Patient obj = new DBEntities.Patient();
            obj = context.Patients.Where(x => x.PatientId == patientModel.PatientId).FirstOrDefault();

            obj.FirstName = patientModel.FirstName;
            obj.LastName = patientModel.LastName;
            obj.Mobile = patientModel.Mobile;
            obj.Email = patientModel.Email;
            obj.Gender = patientModel.Gender == "1" ? true : false;
            obj.HasHealthInsurance = patientModel.HasHealthInsurance;

            context.SaveChanges();

            return RedirectToAction("GetAllPatient");

        }

        public IActionResult Delete(int Id)
        {
            DBEntities.Patient obj = new DBEntities.Patient();
            obj = context.Patients.Where(x => x.PatientId == Id).FirstOrDefault();

            context.Patients.Remove(obj);
            context.SaveChanges();

            return RedirectToAction("GetAllPatient");


        }
    }
}
