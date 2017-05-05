namespace KNGSoftware.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Models.ViewModels.Newses;
    using Services;
    
    public class HomeController : Controller
    {
        private HomeService service;

        public HomeController()
        {
            this.service  = new HomeService();
        }
        [Route]
        public ActionResult Index()
        {
            IEnumerable<KNGNewsVm> vms = this.service.GetAllNewses();
            return this.View(vms);
        }
        [Route("about")]
        public ActionResult About()
        {
            this.ViewBag.Message = "Your application description page.";

            return this.View();
        }
        [Route("contact")]
        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";

            return this.View();
        }
    }
}