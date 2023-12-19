using ETend.DataAccess.Repository.IRepository;
using ETend.Models;
using ETend.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;

namespace ETend.Areas.Retailer.Controllers
{
    [Area("Admin")]
    public class DriverController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DriverController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Driver> objDriverList = _unitOfWork.Driver.GetAll();
            return View(objDriverList);
        }
        //GET
        public IActionResult Upsert(int? id)
        {
            DriverVM driverVM = new()
            {
                Driver = new(),
                VehicleList = _unitOfWork.Vehicle.GetAll().Select(i => new SelectListItem
                {
                    Text = i.VehicleName,
                    Value = i.Id.ToString()
                }),
            };

            if (id == null || id == 0)
            {
                return View(driverVM);
            }
            else
            {
				driverVM.Driver = _unitOfWork.Driver.GetFirstOrDefault(u => u.Id == id);
                return View(driverVM);

                //update Driver
            }
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(DriverVM obj)
        {

            if (ModelState.IsValid)
            {
               
                if (obj.Driver.Id == 0)
                {
                    _unitOfWork.Driver.Add(obj.Driver);
                }
                else
                {
                    _unitOfWork.Driver.Update(obj.Driver);
                }
                _unitOfWork.Save();
                TempData["success"] = "Driver added successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
		#region API CALLS
		[HttpGet]
		public IActionResult GetAll()
		{
			var driverList = _unitOfWork.Driver.GetAll(includeProperties: "Vehicle");
			return Json(new { data = driverList });
		}

		//POST
		[HttpDelete]
		public IActionResult Delete(int? id)
		{
			var obj = _unitOfWork.Driver.GetFirstOrDefault(u => u.Id == id);
			if (obj == null)
			{
				return Json(new { success = false, message = "Error while deleting" });
			}

			_unitOfWork.Driver.Remove(obj);
			_unitOfWork.Save();
			return Json(new { success = true, message = "Delete Successful" });

		}
		#endregion
	}

}
