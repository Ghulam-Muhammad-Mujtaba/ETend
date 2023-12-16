using ETend.DataAccess.Repository.IRepository;
using ETend.Models;
using Microsoft.AspNetCore.Mvc;

namespace ETend.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AreaController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

		public AreaController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public IActionResult Index()
		{
			IEnumerable<Area> objAreaList = _unitOfWork.Area.GetAll();
			return View(objAreaList);
		}
		//GET
		public IActionResult Create()
		{
			return View();
		}

		//POST
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Area obj)
		{

			if (ModelState.IsValid)
			{
				_unitOfWork.Area.Add(obj);
				_unitOfWork.Save();
				TempData["success"] = "Area created successfully";
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
			var areaFromDbFirst = _unitOfWork.Area.GetFirstOrDefault(u => u.Id == id);
			if (areaFromDbFirst == null)
			{
				return NotFound();
			}
			return View(areaFromDbFirst);
		}

		//POST
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Area obj)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.Area.Update(obj);
				_unitOfWork.Save();
				TempData["success"] = "Area updated successfully";
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
			var areaFromDbFirst = _unitOfWork.Area.GetFirstOrDefault(u => u.Id == id);
			if (areaFromDbFirst == null)
			{
				return NotFound();
			}
			return View(areaFromDbFirst);
		}

		//POST
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeletePOST(int? id)
		{
			var obj = _unitOfWork.Area.GetFirstOrDefault(u => u.Id == id);
			if (obj == null)
			{
				return NotFound();
			}

			_unitOfWork.Area.Remove(obj);
			_unitOfWork.Save();
			TempData["success"] = "Area deleted successfully";
			return RedirectToAction("Index");

		}
	}
}
