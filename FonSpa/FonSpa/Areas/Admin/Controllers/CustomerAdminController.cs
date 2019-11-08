using FonSpa.Services.IServices;
using Models.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FonSpa.Areas.Admin.Controllers
{
    public class CustomerAdminController : Controller
    {
        private readonly ICustomerAdminServices _customerAdminServices;
        public CustomerAdminController(ICustomerAdminServices customerAdminServices)
        {
            _customerAdminServices = customerAdminServices;
        }
        // GET: Admin/CusotmerAdmin
        public ActionResult Index(int? page, string searchString = null)
        {
            var listCustomer = _customerAdminServices.ListAllByName(searchString);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            var listCustomerPaged = listCustomer.ToPagedList(pageNumber, pageSize);
            return View(listCustomerPaged);
        }

        public ActionResult Edit(int id)
        {
            var customer = _customerAdminServices.GetDetail(id);
            if (customer == null) return RedirectToAction("Index");
            return View(customer);
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var editCustomerSuccess = _customerAdminServices.Edit(customer);
                if (!editCustomerSuccess) ModelState.AddModelError("", "Sửa sản phẩm không thành công !");
                return RedirectToAction("Index");
            }
            return View(customer);
        }


        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var deleteSuccess = _customerAdminServices.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var res = _customerAdminServices.ChangeStatus(id);
            return Json(new
            {
                Status = res
            });
        }
    }
}