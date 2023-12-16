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
	}
}
