using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Fumigate.Models;

namespace Fumigate.Controllers
{
    public class TicketVersionsController : Controller
    {
        private Fumigate_LiveEntities1 db = new Fumigate_LiveEntities1();

        // GET: TicketVersions
        public async Task<ActionResult> Index()
        {
            var ticketVersions = db.TicketVersions.Include(t => t.Status1).Include(t => t.Ticket).Include(t => t.User).Include(t => t.User3);
            return View(await ticketVersions.ToListAsync());
        }

        // GET: TicketVersions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketVersion ticketVersion = await db.TicketVersions.FindAsync(id);
            if (ticketVersion == null)
            {
                return HttpNotFound();
            }
            return View(ticketVersion);
        }

        // GET: TicketVersions/Create
        public ActionResult Create()
        {
            ViewBag.Status = new SelectList(db.Status, "Id", "Name");
            ViewBag.TicketId = new SelectList(db.Tickets, "TicketId", "TicketName");
            ViewBag.AssignedTo = new SelectList(db.Users, "UserId", "Name");
            ViewBag.ModifiedBy = new SelectList(db.Users, "UserId", "Name");
            return View();
        }

        // POST: TicketVersions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Version,TicketId,ModifiedBy,ModificationDate,Status,AssignedTo,Comment")] TicketVersion ticketVersion)
        {
            if (ModelState.IsValid)
            {
                db.TicketVersions.Add(ticketVersion);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Status = new SelectList(db.Status, "Id", "Name", ticketVersion.Status);
            ViewBag.TicketId = new SelectList(db.Tickets, "TicketId", "TicketName", ticketVersion.TicketId);
            ViewBag.AssignedTo = new SelectList(db.Users, "UserId", "Name", ticketVersion.AssignedTo);
            ViewBag.ModifiedBy = new SelectList(db.Users, "UserId", "Name", ticketVersion.ModifiedBy);
            return View(ticketVersion);
        }

        // GET: TicketVersions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketVersion ticketVersion = await db.TicketVersions.FindAsync(id);
            if (ticketVersion == null)
            {
                return HttpNotFound();
            }
            ViewBag.Status = new SelectList(db.Status, "Id", "Name", ticketVersion.Status);
            ViewBag.TicketId = new SelectList(db.Tickets, "TicketId", "TicketName", ticketVersion.TicketId);
            ViewBag.AssignedTo = new SelectList(db.Users, "UserId", "Name", ticketVersion.AssignedTo);
            ViewBag.ModifiedBy = new SelectList(db.Users, "UserId", "Name", ticketVersion.ModifiedBy);
            return View(ticketVersion);
        }

        // POST: TicketVersions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Version,TicketId,ModifiedBy,ModificationDate,Status,AssignedTo,Comment")] TicketVersion ticketVersion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticketVersion).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Status = new SelectList(db.Status, "Id", "Name", ticketVersion.Status);
            ViewBag.TicketId = new SelectList(db.Tickets, "TicketId", "TicketName", ticketVersion.TicketId);
            ViewBag.AssignedTo = new SelectList(db.Users, "UserId", "Name", ticketVersion.AssignedTo);
            ViewBag.ModifiedBy = new SelectList(db.Users, "UserId", "Name", ticketVersion.ModifiedBy);
            return View(ticketVersion);
        }

        // GET: TicketVersions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketVersion ticketVersion = await db.TicketVersions.FindAsync(id);
            if (ticketVersion == null)
            {
                return HttpNotFound();
            }
            return View(ticketVersion);
        }

        // POST: TicketVersions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TicketVersion ticketVersion = await db.TicketVersions.FindAsync(id);
            db.TicketVersions.Remove(ticketVersion);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
