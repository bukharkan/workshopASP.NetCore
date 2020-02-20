using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkshopACCICore.DAL;

namespace WorkshopACCICore.Controllers
{
    public class MahasiswaController : Controller
    {
        private IMahasiswa _mhs;

        public IActionResult Index()
        {
            return View();
        }
        public MahasiswaController(IMahasiswa data)
        {
            _mhs = data;
        }
        public IActionResult DataMahasiswa()
        {
            var data = _mhs.GetAll();
            return View(data);
        }
        public IActionResult Details(string id)
        {
            var data = _mhs.GetById(id);
            return View(data);
        }
    }
}