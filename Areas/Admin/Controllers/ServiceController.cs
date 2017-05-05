namespace KNGSoftware.Areas.Admin.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Models.BindingModels.Service;
    using Models.ViewModels.Services;
    using Services;

    [RouteArea("Admin")]
    [RoutePrefix("Service")]
    [Authorize(Roles = "KNGAdmin")]
    public class ServiceController : Controller
    {
        private AdminServiceService service;

        public ServiceController()
        {
            this.service = new AdminServiceService();
        }

        [Route]
        public ActionResult All()
        {
            IEnumerable<KNGServiceVm> vms = this.service.GetAllService();
            return this.View(vms);
        }

        [HttpGet]
        [Route("details/{id}")]
        public ActionResult Details(int id)
        {
            KNGDetailsServiceVm vm = this.service.GetDetails(id);
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
        public ActionResult Add(AddKNGServiceBm bind)
        {
            if (this.ModelState.IsValid)
            {
                this.service.AddNewKNGService(bind);
                return this.RedirectToAction("All");
            }
            return this.View();
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public ActionResult Edit(int id)
        {
            KNGEditServiceVm editService = this.service.GetEditService(id);
            return this.View(editService);
        }

        [HttpPost]
        [Route("Edit/{id}")]
        public ActionResult Edit(int id, KNGEditServiceVm bind)
        {
            if (this.ModelState.IsValid)
            {
                this.service.EditKNGService(id, bind);
                return this.RedirectToAction("All");
            }
            return this.View();
        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int id)
        {
            KNGServiceVm deleteService = this.service.GetServiceBy(id);
            return this.View(deleteService);
        }

        [HttpPost]
        [Route("delete/{id}")]
        public ActionResult Delete(KNGServiceVm bind)
        {
            if (this.ModelState.IsValid)
            {
                this.service.DeleteService(bind.Id);
                return this.RedirectToAction("All");
            }
            return this.View();
        }
    }
}