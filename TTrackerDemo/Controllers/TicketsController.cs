using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TTrackerDemo.Models;

namespace TTrackerDemo.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        // Default action for ticket controller, redirects to OpenTickets method
        public ActionResult Index()
        {
            return RedirectToAction("OpenTickets");
        }

        // Returns view with a list of all unresolved tickets
        public ActionResult OpenTickets()
        {
            var ticketList = _db.Tickets.ToList();
            var openTicketList = new List<Ticket>();

            foreach (var ticket in ticketList)
                if (!ticket.Resolved)
                    openTicketList.Add(ticket);

            return View(openTicketList);
        }

        // Returns view with a list of all tickets marked as resolved
        public ActionResult ClosedTickets()
        {
            var ticketList = _db.Tickets.ToList();
            var closedTicketList = new List<Ticket>();

            foreach (var ticket in ticketList)
                if (ticket.Resolved)
                    closedTicketList.Add(ticket);

            return View(closedTicketList);
        }


        // Allows any logged-in user to create a ticket
        public ActionResult Create()
        {
            return View();
        }


        // Validates submitted ticket parameters and saves new ticket to database 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DateCreated,Severity,Resolved,Issue,Resolution")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _db.Tickets.Add(ticket);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ticket);
        }


        // Allows admin user to edit a ticket
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var ticket = _db.Tickets.Find(id);
            if (ticket == null)
                return HttpNotFound();
            return View(ticket);
        }


        // Validates submitted ticket parameters and saves updated ticket to database
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Edit([Bind(Include = "Id,DateCreated,Severity,Resolved,Issue,Resolution")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(ticket).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ticket);
        }

        // Allows admin user to delete a ticket
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var ticket = _db.Tickets.Find(id);
            if (ticket == null)
                return HttpNotFound();
            return View(ticket);
        }

        // Once delete request is submitted, the ticket is located in database and removed
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var ticket = _db.Tickets.Find(id);
            _db.Tickets.Remove(ticket);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Disposes of the _db object 
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _db.Dispose();
            base.Dispose(disposing);
        }
    }
}