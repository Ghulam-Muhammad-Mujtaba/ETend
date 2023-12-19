using ETend.DataAccess.Repository.IRepository;
using ETend.Models;
using Microsoft.AspNetCore.Mvc;

namespace ETend.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class VehicleController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

		public VehicleController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public IActionResult Index()
		{
			IEnumerable<Vehicle> objVehicleList = _unitOfWork.Vehicle.GetAll();
			return View(objVehicleList);
		}
		//GET
		public IActionResult Create()
		{
			return View();
		}

		//POST
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Vehicle obj)
		{

			if (ModelState.IsValid)
			{
				_unitOfWork.Vehicle.Add(obj);
				_unitOfWork.Save();
				TempData["success"] = "Vehicle created successfully";
				return RedirectToAction("Index");
			}
			return View(obj);
		}
		//GET
		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var vehicleFromDbFirst = _unitOfWork.Vehicle.GetFirstOrDefault(u => u.Id == id);
			if (vehicleFromDbFirst == null)
			{
				return NotFound();
			}
			return View(vehicleFromDbFirst);
		}

		//POST
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Vehicle obj)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.Vehicle.Update(obj);
				_unitOfWork.Save();
				TempData["success"] = "Vehicle updated successfully";
				return RedirectToAction("Index");
			}
			return View(obj);
		}

		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var vehicleFromDbFirst = _unitOfWork.Vehicle.GetFirstOrDefault(u => u.Id == id);
			if (vehicleFromDbFirst == null)
			{
				return NotFound();
			}
			return View(vehicleFromDbFirst);
		}

		//POST
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeletePOST(int? id)
		{
			var obj = _unitOfWork.Vehicle.GetFirstOrDefault(u => u.Id == id);
			if (obj == null)
			{
				return NotFound();
			}

			_unitOfWork.Vehicle.Remove(obj);
			_unitOfWork.Save();
			TempData["success"] = "Vehicle deleted successfully";
			return RedirectToAction("Index");

		}
	}
}
