namespace KNGSoftware.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using Models.BindingModels.MyKNG;
    using Models.BindingModels.Service;
    using Models.EntityModels;
    using Models.ViewModels.MyKNG;
    using Services;

    [RoutePrefix("MyKNG")]
    public class MyKNGController : Controller
    {
        private MyKNGService service;
        public MyKNGController()
        {
            this.service = new MyKNGService();
        }
        [Route]
        public ActionResult All()
        {
            string username = this.User.Identity.Name;
            KNGMyKNG vm = this.service.GetAllMyKNG(username);
            return this.View(vm);
        }
        [HttpGet]
        [Route("addserviceticket/{id}")]
        public ActionResult AddServiceTicket(int id)
        {
            return this.View();
        }
        [HttpPost]
        [Route("addserviceticket/{id}")]
        public ActionResult AddServiceTicket(AddServiceTicketBm bm,int id)
        {
            if (this.ModelState.IsValid)
            {
                bm.TicketKngUser = this.service.GetUser(this.User.Identity.Name);
                bm.TicketService = this.service.GetMyService(id);
                this.service.AddServiceTicket(bm);
                return this.RedirectToAction("TicketsServices",id);
            }
            return this.View();
        }
        [HttpGet]
        [Route("ticketsServices/{id}")]
        public ActionResult TicketsServices(int id)
        {
            string username = this.User.Identity.Name;
            IEnumerable<KNGTicketVm> vms = this.service.GetAllTicketByService(id,username);
            return this.View(vms);
        }
        [HttpGet]
        [Route("ticketsProducts/{id}")]
        public ActionResult TicketsProducts(int id)
        {
            string username = this.User.Identity.Name;
            IEnumerable<KNGTicketVm> vms = this.service.GetAllTicketByProduct(id, username);
            return this.View(vms);
        }
        [HttpGet]
        [Route("Messages/{id}")]
        public ActionResult Messages(int id)
        {
            KNGTicketVm vm = this.service.GetTicket(id);
            vm.Messages = this.service.GetAllMessages(id);
            return this.View(vm);
        }
        [HttpGet]
        [Route("addmessage/{id}")]
        public ActionResult AddMessage(int id)
        {
            return this.View();
        }
        [HttpPost]
        [Route("addmessage/{id}")]
        public ActionResult AddMessage(AddTicketMessageBm bm,int id)
        {
            if (this.ModelState.IsValid)
            {
                bm.MessageUser = this.service.GetUser(this.User.Identity.Name);
                bm.DateTimeMessage = DateTime.Now;
                this.service.AddMessege(bm,id);
                return this.RedirectToAction("Messages", id);
            }
            return this.View();
        }

        [HttpGet]
        [Route("addproductticket/{id}")]
        public ActionResult AddProductTicket(int id)
        {
            return this.View();
        }
        [HttpPost]
        [Route("addproductticket/{id}")]
        public ActionResult AddProductTicket(AddProductTicketBm bm, int id)
        {
            if (this.ModelState.IsValid)
            {
                bm.TicketKngUser = this.service.GetUser(this.User.Identity.Name);
                bm.TicketProduct = this.service.GetMyProduct(id);
                this.service.AddProductTicket(bm);
                return this.RedirectToAction("TicketsProducts", id);
            }
            return this.View();
        }
    }
}