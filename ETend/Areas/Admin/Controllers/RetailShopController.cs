using ETend.DataAccess.Repository.IRepository;
using ETend.Models;
using ETend.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;

namespace ETend.Areas.Retailer.Controllers
{
    [Area("Admin")]
    public class RetailShopController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public RetailShopController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<RetailShop> objRetailShopList = _unitOfWork.RetailShop.GetAll();
            return View(objRetailShopList);
        }
        //GET
        public IActionResult Upsert(int? id)
        {
            RetailShopVM retailshopVM = new()
            {
                RetailShop = new(),
                AreaList = _unitOfWork.Area.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
            };

            if (id == null || id == 0)
            {
                return View(retailshopVM);
            }
            else
            {
                retailshopVM.RetailShop = _unitOfWork.RetailShop.GetFirstOrDefault(u => u.Id == id);
                return View(retailshopVM);

                //update company
            }
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(RetailShopVM obj)
        {

            if (ModelState.IsValid)
            {
               
                if (obj.RetailShop.Id == 0)
                {
                    _unitOfWork.RetailShop.Add(obj.RetailShop);
                }
                else
                {
                    _unitOfWork.RetailShop.Update(obj.RetailShop);
                }
                _unitOfWork.Save();
                TempData["success"] = "Retail Shop created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
		#region API CALLS
		[HttpGet]
		public IActionResult GetAll()
		{
			var areaList = _unitOfWork.RetailShop.GetAll(includeProperties: "Area");
			return Json(new { data = areaList });
		}

		//POST
		[HttpDelete]
		public IActionResult Delete(int? id)
		{
			var obj = _unitOfWork.RetailShop.GetFirstOrDefault(u => u.Id == id);
			if (obj == null)
			{
				return Json(new { success = false, message = "Error while deleting" });
			}

			_unitOfWork.RetailShop.Remove(obj);
			_unitOfWork.Save();
			return Json(new { success = true, message = "Delete Successful" });

		}
		#endregion
	}

}
