using ITUniver.Calc.DB.Models;
using ITUniver.Calc.DB.NH.Repositories;
using ITUniver.Calc.DB.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Security;
using System.Xml.Linq;
using WebCalc.Models;



namespace WebCalc.Controllers
{
    [Authorize]
    public class MyDocsController : Controller
    {
        private IMyDocRepository Doc { get; set; }
        private IUserRepository Users { get; set; }

        public MyDocsController()
        {
            Doc = new NHMyDocRepository();
            Users = new NHUserRepository();
        }

        // GET: Manage
        public ActionResult Index()
        {
            var users = Doc.GetAll().Where(n=>n.DocStatus == DocStatus.Active && n.Author == Users.GetByName(User.Identity.Name).Name);
            return View(users);
        }

        
        public ActionResult Delete(long id)
        {
            Doc.Delete(id);
            return RedirectToAction("Index"); 
        }


        [ChildActionOnly]
        public ActionResult Upload()
        {
            return PartialView();
        }

       
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase upload)
        {
            if (upload != null)
            {
                NHUserRepository Users = new NHUserRepository();
                NHMyDocRepository Docs = new NHMyDocRepository();

                // получаем имя файла
                string fileName = System.IO.Path.GetFileName(upload.FileName);
                var ch = Docs.CheckSame(fileName);

                if (upload != null && ch != true)
                {
                    // сохраняем файл в папку Files в проекте
                    upload.SaveAs(Server.MapPath("~/Files/" + fileName));

                    var thisAuthor = Users.GetByName(User.Identity.Name);

                    var NewDoc = new Doc()
                    {
                        Author = thisAuthor.Name,
                        DocName = fileName,
                        PubDate = DateTime.Now,
                        DocType = upload.ContentType,
                        DocPath = Server.MapPath("~/Files/" + fileName),
                        DocStatus = DocStatus.Active
                    };

                    Doc.Save(NewDoc);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public FileResult Download(long id)
        {
            var wantedFile = Doc.Find(id);
                var doc = new byte[0];
                doc = System.IO.File.ReadAllBytes(wantedFile.DocPath);
                return File(doc, wantedFile.DocType, wantedFile.DocName);
        }

        public ActionResult AnotherList()
        {
            var users = Doc.GetAll().Where(n => n.DocStatus == DocStatus.Active);
            return View(users);
        }

    
        public ActionResult AllDocs(string s, string name)
        {
            var Docum = Doc.GetAll().Where(n => n.DocStatus == DocStatus.Active);

            if (s == null && (name == null || name == ""))
            {
                return View(Docum);
            }
            if (s == "name")
            {
                Docum = Doc.GetAll().Where(n => n.DocStatus == DocStatus.Active).OrderBy(n => n.DocName);
                return View(Docum); 
            }
            if (s == "eman")
            {
                Docum = Doc.GetAll().Where(n => n.DocStatus == DocStatus.Active).OrderBy(n => n.DocName).Reverse();
                return View(Docum);
            }
            if (s == "author")
            {
                Docum = Doc.GetAll().Where(n => n.DocStatus == DocStatus.Active).OrderBy(n => n.Author);
                return View(Docum);
            }
            if (s == "rohtua")
            {
                Docum = Doc.GetAll().Where(n => n.DocStatus == DocStatus.Active).OrderBy(n => n.Author).Reverse();
                return View(Docum);
            }
            if (s == "date")
            {
                Docum = Doc.GetAll().Where(n => n.DocStatus == DocStatus.Active).OrderBy(n => n.PubDate);
                return View(Docum);
            }
            if (s == "etad")
            {
                Docum = Doc.GetAll().Where(n => n.DocStatus == DocStatus.Active).OrderBy(n => n.PubDate).Reverse();
                return View(Docum);
            }
            if (name != null || name !="")
            {
                Docum = Doc.GetAll().Where(n => n.DocStatus == DocStatus.Active && n.DocName.Contains(name));
                return View(Docum);
            }

            return View(Docum);
        }

        [ChildActionOnly]
        public ActionResult OpenDoc(long id)
        {
            var wantedFile = Doc.Find(id);
            var doc = new byte[0];
            doc = System.IO.File.ReadAllBytes(wantedFile.DocPath);
            var docum = System.Text.Encoding.Default.GetString(doc);
            ViewBag.Do = docum;
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult NewDocument()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult NewDocument(NewDocModel model)
        {
            var thisAuthor = Users.GetByName(User.Identity.Name);

            var NewDoc = new Doc()
            {
                Author = thisAuthor.Name,
                DocName = model.DocName,
                PubDate = DateTime.Now,
                DocType = "text/plane",
                DocPath = Server.MapPath("~/Files/" + model.DocName + ".txt"),
                DocStatus = DocStatus.Active
            };

            // запись в файл
            using (FileStream fstream = new FileStream(Server.MapPath("~/Files/" + model.DocName + ".txt"), FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты
                byte[] array = System.Text.Encoding.Default.GetBytes(model.DocText);
                // запись массива байтов в файл
                fstream.Write(array, 0, array.Length);
            }

            Doc.Save(NewDoc);

            return RedirectToAction("Index");
        }
    }
}