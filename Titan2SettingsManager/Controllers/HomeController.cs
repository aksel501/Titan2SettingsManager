using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Titan2SettingsManager.Models;
using static Titan2SettingsManager.Models.Setting;

namespace Titan2SettingsManager.Controllers
{
    public class HomeController : Controller
    {
        private SettingsDBContext sdbc = new SettingsDBContext();

        public ActionResult Index()
        {
            List<DisplayEditSettingsViewModel> resultList = sdbc.Settings.Select(s => new DisplayEditSettingsViewModel()
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                Value = s.Value
            }).ToList();

            return View(resultList);
        }

        public ActionResult Edit(int id)
        {
            DisplayEditSettingsViewModel result = sdbc.Settings.Where(x => x.Id == id).Select(s => new DisplayEditSettingsViewModel()
            {
                Name = s.Name,
                Description = s.Description,
                Value = s.Value
            }).FirstOrDefault();

            return View(result);
        }

        [HttpPost]
        public ActionResult Edit(DisplayEditSettingsViewModel model)
        {
            Setting setting = sdbc.Settings.Where(x => x.Id == model.Id).SingleOrDefault();
            setting.Name = model.Name;
            setting.Description = model.Description;
            setting.Value = model.Value;
            sdbc.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateSettingsViewModel vm)
        {
            Setting setting = new Setting
            {
                Name = vm.Name,
                Description = vm.Description,
                Value = vm.Value,
                CreatedBy = Environment.MachineName,
                CreatedOn = DateTime.Now
            };

            sdbc.Settings.Add(setting);
            sdbc.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}