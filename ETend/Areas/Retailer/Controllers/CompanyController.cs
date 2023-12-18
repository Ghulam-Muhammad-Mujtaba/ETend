using ETend.DataAccess.Repository.IRepository;
using ETend.Models;
using ETend.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;

namespace ETend.Areas.Retailer.Controllers
{
    [Area("Retailer")]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Company> objCompanyList = _unitOfWork.Company.GetAll();
            return View(objCompanyList);
        }
        //GET
        public IActionResult Upsert(int? id)
        {
            CompanyVM companyVM = new()
            {
                Company = new(),
                AreaList = _unitOfWork.Area.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
            };

            if (id == null || id == 0)
            {
                return View(companyVM);
            }
            else
            {
                companyVM.Company = _unitOfWork.Company.GetFirstOrDefault(u => u.Id == id);
                return View(companyVM);

                //update company
            }
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(CompanyVM obj)
        {

            if (ModelState.IsValid)
            {
               
                if (obj.Company.Id == 0)
                {
                    _unitOfWork.Company.Add(obj.Company);
                }
                else
                {
                    _unitOfWork.Company.Update(obj.Company);
                }
                _unitOfWork.Save();
                TempData["success"] = "Company created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
		#region API CALLS
		[HttpGet]
		public IActionResult GetAll()
		{
			var areaList = _unitOfWork.Company.GetAll(includeProperties: "Area");
			return Json(new { data = areaList });
		}

		//POST
		[HttpDelete]
		public IActionResult Delete(int? id)
		{
			var obj = _unitOfWork.Company.GetFirstOrDefault(u => u.Id == id);
			if (obj == null)
			{
				return Json(new { success = false, message = "Error while deleting" });
			}

			_unitOfWork.Company.Remove(obj);
			_unitOfWork.Save();
			return Json(new { success = true, message = "Delete Successful" });

		}
		#endregion
	}

}
