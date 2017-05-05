namespace KNGSoftware.Areas.Admin.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Models.BindingModels.News;
    using Models.ViewModels.Newses;
    using Services;

    [RouteArea("Admin")]
    [RoutePrefix("News")]
    [Authorize(Roles = "KNGAdmin")]
    public class NewsController : Controller
    {
        private AdminNewsService service;

        public NewsController()
        {
            this.service = new AdminNewsService();    
        }
        [Route]
        public ActionResult All()
        {
            IEnumerable<KNGNewsVm> vms = this.service.GetAllNewses();
            return this.View(vms);
        }

        [HttpGet]
        [Route("details/{id}")]
        public ActionResult Details(int id)
        {
            KNGDetailsNewsVm vm = this.service.GetDetails(id);
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
        public ActionResult Add(AddKNGNewsBm bind)
        {
            if (this.ModelState.IsValid)
            {
                this.service.AddNewKNGNews(bind);
                return this.RedirectToAction("All");
            }

            return this.View();
            
        }
        [HttpGet]
        [Route("Edit/{id}")]
        public ActionResult Edit(int id)
        {
            KNGEditNewsVm editNews = this.service.GetEditNews(id);
            return this.View(editNews);
        }

        [HttpPost]
        [Route("Edit/{id}")]
        public ActionResult Edit(int id, KNGEditNewsVm bind)
        {
            if (this.ModelState.IsValid)
            {
                this.service.EditKNGNews(id,bind);
                return this.RedirectToAction("All");
            }

            return this.View();
        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int id)
        {
            KNGNewsVm deleteNews = this.service.GetNewsBy(id);
            return this.View(deleteNews);
        }

        [HttpPost]
        [Route("delete/{id}")]
        public ActionResult Delete(KNGNewsVm bind)
        {
            if (this.ModelState.IsValid)
            {
                this.service.DeleteNews(bind.Id);
                return this.RedirectToAction("All");
            }
            return this.View();
        }
    }
}
