namespace KNGSoftware.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Models.ViewModels.Products;
    using Services;

    [RoutePrefix("Products")]
    public class ProductController : Controller
    {
        private ProductService service;
        
        public ProductController()
        {
            this.service = new ProductService();    
        }

        [HttpGet]
        [Route("all")]
        public ActionResult All()
        {
            IEnumerable<KNGProductVm> vms = this.service.GetAllProducts();
            return this.View(vms);
        }

        [HttpGet]
        [Route("get/{id}")]
        public ActionResult Get(int id)
        {
            KNGProductVm vm = this.service.GetProductBy(id);
            return this.View(vm);
        }

        [HttpPost]
        [Route("get/{id}")]
        public ActionResult Delete(KNGProductVm bind)
        {
            if (this.ModelState.IsValid)
            {
                string username = this.User.Identity.Name;
                this.service.GetToMyProduct(bind.Id, username);
                return this.RedirectToAction("All");
            }
            return this.View();
        }
    }
}