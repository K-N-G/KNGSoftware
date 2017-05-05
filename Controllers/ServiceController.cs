namespace KNGSoftware.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Models.ViewModels.Services;
    using Services;

    [RoutePrefix("Services")]
    public class ServiceController : Controller
    {
        private ServiceService service;

        public ServiceController()
        {
            this.service = new ServiceService();
        }

        [HttpGet]
        [Route("all")]
        public ActionResult All()
        {
            IEnumerable<KNGServiceVm> vms = this.service.GetAllService();
            return this.View(vms);
        }

        [HttpGet]
        [Route("get/{id}")]
        public ActionResult Get(int id)
        {
            KNGServiceVm vm = this.service.GetServiceBy(id);
            return this.View(vm);
        }

        [HttpPost]
        [Route("get/{id}")]
        public ActionResult Delete(KNGServiceVm bind)
        {
            if (this.ModelState.IsValid)
            {
                string username = this.User.Identity.Name;
                this.service.GetToMyService(bind.Id,username);
                return this.RedirectToAction("All");
            }
            return this.View();
        }

    }
}