using ETend.DataAccess.Repository.IRepository;
using ETend.Models;
using ETend.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;

namespace ETend.Areas.Retailer.Controllers
{
    [Area("Retailer")]
    public class HouseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HouseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<House> objHouseList = _unitOfWork.House.GetAll();
            return View(objHouseList);
        }
        //GET
        public IActionResult Upsert(int? id)
        {
            HouseVM houseVM = new()
            {
                House = new(),
                AreaList = _unitOfWork.Area.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
            };

            if (id == null || id == 0)
            {
                return View(houseVM);
            }
            else
            {
                houseVM.House = _unitOfWork.House.GetFirstOrDefault(u => u.Id == id);
                return View(houseVM);

                //update product
            }
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(HouseVM obj)
        {

            if (ModelState.IsValid)
            {
               
                if (obj.House.Id == 0)
                {
                    _unitOfWork.House.Add(obj.House);
                }
                else
                {
                    _unitOfWork.House.Update(obj.House);
                }
                _unitOfWork.Save();
                TempData["success"] = "House created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
		#region API CALLS
		[HttpGet]
		public IActionResult GetAll()
		{
			var areaList = _unitOfWork.House.GetAll(includeProperties: "Area");
			return Json(new { data = areaList });
		}

		//POST
		[HttpDelete]
		public IActionResult Delete(int? id)
		{
			var obj = _unitOfWork.House.GetFirstOrDefault(u => u.Id == id);
			if (obj == null)
			{
				return Json(new { success = false, message = "Error while deleting" });
			}

			_unitOfWork.House.Remove(obj);
			_unitOfWork.Save();
			return Json(new { success = true, message = "Delete Successful" });

		}
		#endregion
	}

}
