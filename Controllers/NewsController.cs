using System.Web.Mvc;

namespace KNGSoftware.Controllers
{
    using Models.ViewModels.Newses;
    using Services;

    [RoutePrefix("news")]
    public class NewsController : Controller
    {
        private NewsService service;

        public NewsController()
        {
            this.service = new NewsService();
        }

        [HttpGet]
        [Route("details/{id}")]
        public ActionResult Details(int id)
        {
            KNGDetailsNewsVm vm = this.service.GetDetails(id); 
            return this.View(vm);
        }
    }
}