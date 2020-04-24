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
    public class UserPermissionsLinksController : Controller
    {
        private Fumigate_LiveEntities1 db = new Fumigate_LiveEntities1();

        // GET: UserPermissionsLinks
        public async Task<ActionResult> Index()
        {
            var userPermissionsLinks = db.UserPermissionsLinks.Include(u => u.Permission).Include(u => u.User);
            return View(await userPermissionsLinks.ToListAsync());
        }

        // GET: UserPermissionsLinks/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserPermissionsLink userPermissionsLink = await db.UserPermissionsLinks.FindAsync(id);
            if (userPermissionsLink == null)
            {
                return HttpNotFound();
            }
            return View(userPermissionsLink);
        }

        // GET: UserPermissionsLinks/Create
        public ActionResult Create()
        {
            ViewBag.PermissionId = new SelectList(db.Permissions, "Id", "Name");
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Name");
            return View();
        }

        // POST: UserPermissionsLinks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,UserId,PermissionId")] UserPermissionsLink userPermissionsLink)
        {
            if (ModelState.IsValid)
            {
                db.UserPermissionsLinks.Add(userPermissionsLink);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PermissionId = new SelectList(db.Permissions, "Id", "Name", userPermissionsLink.PermissionId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Name", userPermissionsLink.UserId);
            return View(userPermissionsLink);
        }

        // GET: UserPermissionsLinks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserPermissionsLink userPermissionsLink = await db.UserPermissionsLinks.FindAsync(id);
            if (userPermissionsLink == null)
            {
                return HttpNotFound();
            }
            ViewBag.PermissionId = new SelectList(db.Permissions, "Id", "Name", userPermissionsLink.PermissionId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Name", userPermissionsLink.UserId);
            return View(userPermissionsLink);
        }

        // POST: UserPermissionsLinks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,UserId,PermissionId")] UserPermissionsLink userPermissionsLink)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userPermissionsLink).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PermissionId = new SelectList(db.Permissions, "Id", "Name", userPermissionsLink.PermissionId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "Name", userPermissionsLink.UserId);
            return View(userPermissionsLink);
        }

        // GET: UserPermissionsLinks/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserPermissionsLink userPermissionsLink = await db.UserPermissionsLinks.FindAsync(id);
            if (userPermissionsLink == null)
            {
                return HttpNotFound();
            }
            return View(userPermissionsLink);
        }

        // POST: UserPermissionsLinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            UserPermissionsLink userPermissionsLink = await db.UserPermissionsLinks.FindAsync(id);
            db.UserPermissionsLinks.Remove(userPermissionsLink);
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
