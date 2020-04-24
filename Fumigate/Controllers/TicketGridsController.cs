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
    public class TicketGridsController : Controller
    {
        private Fumigate_LiveEntities1 db = new Fumigate_LiveEntities1();

        // GET: TicketGrids
        public async Task<ActionResult> Index()
        {
            return View(await db.TicketGrids.ToListAsync());
        }

        // GET: TicketGrids/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketGrid ticketGrid = await db.TicketGrids.FindAsync(id);
            if (ticketGrid == null)
            {
                return HttpNotFound();
            }
            return View(ticketGrid);
        }

        // GET: TicketGrids/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TicketGrids/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TicketId,TicketName,Author,CreationDate,Title,Priority,ID,Version,Expr1,ModifiedBy,ModificationDate,Status,AssignedTo,Comment")] TicketGrid ticketGrid)
        {
            if (ModelState.IsValid)
            {
                db.TicketGrids.Add(ticketGrid);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(ticketGrid);
        }

        // GET: TicketGrids/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketGrid ticketGrid = await db.TicketGrids.FindAsync(id);
            if (ticketGrid == null)
            {
                return HttpNotFound();
            }
            return View(ticketGrid);
        }

        // POST: TicketGrids/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TicketId,TicketName,Author,CreationDate,Title,Priority,ID,Version,Expr1,ModifiedBy,ModificationDate,Status,AssignedTo,Comment")] TicketGrid ticketGrid)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticketGrid).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ticketGrid);
        }

        // GET: TicketGrids/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketGrid ticketGrid = await db.TicketGrids.FindAsync(id);
            if (ticketGrid == null)
            {
                return HttpNotFound();
            }
            return View(ticketGrid);
        }

        // POST: TicketGrids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TicketGrid ticketGrid = await db.TicketGrids.FindAsync(id);
            db.TicketGrids.Remove(ticketGrid);
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
