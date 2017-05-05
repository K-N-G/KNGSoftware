namespace KNGSoftware.Areas.Admin.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Models.BindingModels.Product;
    using Models.ViewModels.Products;
    using Services;

    [RouteArea("Admin")]
    [RoutePrefix("Product")]
    [Authorize(Roles = "KNGAdmin")]
    public class ProductController : Controller
    {
        private AdminProductService service;

        public ProductController()
        {
            this.service = new AdminProductService();
        }
        [Route]
        public ActionResult All()
        {
            IEnumerable<KNGProductVm> vms = this.service.GetAllProducts();
            return this.View(vms);
        }

        [HttpGet]
        [Route("details/{id}")]
        public ActionResult Details(int id)
        {
            KNGDetailsProductVm vm = this.service.GetDetails(id);
            return this.View(vm);
        }

        [HttpGet]
        [Route("Add")]
        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult Add(AddKNGProductBm bind)
        {
            if (this.ModelState.IsValid)
            {
                this.service.AddNewKNGProduct(bind);
                return this.RedirectToAction("All");
            }
            return this.View();
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public ActionResult Edit(int id)
        {
            KNGEditProductVm editProduct = this.service.GetEditProduct(id);
            return this.View(editProduct);
        }

        [HttpPost]
        [Route("Edit/{id}")]
        public ActionResult Edit(int id, KNGEditProductVm bind)
        {
            if (this.ModelState.IsValid)
            {
                this.service.EditKNGProduct(id, bind);
                return this.RedirectToAction("All");
            }
            return this.View();
        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int id)
        {
            KNGProductVm deleteProduct = this.service.GetProductBy(id);
            return this.View(deleteProduct);
        }

        [HttpPost]
        [Route("delete/{id}")]
        public ActionResult Delete(KNGProductVm bind)
        {
            if (this.ModelState.IsValid)
            {
                this.service.DeleteProduct(bind.Id);
                return this.RedirectToAction("All");
            }
            return this.View();
        }
    }
}