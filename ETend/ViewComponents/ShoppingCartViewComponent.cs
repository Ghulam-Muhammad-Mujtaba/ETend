using ETend.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ETend.Constants;
using Microsoft.VisualBasic;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

namespace ETend.ViewComponents
{
    public class ShoppingCartViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShoppingCartViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claim != null)
            {
                if (HttpContext.Session.GetInt32(Constants.Constants.SessionCart) != null)
                {
                    return View(HttpContext.Session.GetInt32(Constants.Constants.SessionCart));
                }
                else
                {
                    HttpContext.Session.SetInt32(Constants.Constants.SessionCart,
                        _unitOfWork.ShoppingCart.GetAll(u => u.CustomerId == claim.Value).ToList().Count);
                    return View(HttpContext.Session.GetInt32(Constants.Constants.SessionCart));
                }
            }
            else
            {
                HttpContext.Session.Clear();
                return View(0);
            }
        }
    }
}
