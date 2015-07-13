using MarkdownDeep;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Protiviti.Boilerplate.Docs.Controllers
{
    public class DocsController : Controller
    {
        public ActionResult Show(string page)
        {
            if (page == "" || page == null)
                page = "README";
            string path = string.Concat(HttpContext.Request.PhysicalApplicationPath, "\\Docs\\", page, ".md");
            string contents;

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    Markdown md = new Markdown();
                    contents = md.Transform(sr.ReadToEnd());

                }

                ViewBag.ConvertedMarkdown = contents;
                return View();
            }
            catch (Exception ex)
            {
                this.Response.StatusCode = 404;
                ViewBag.ConvertedMarkdown = "File not found.";
                return View();
            }
        }
    }
}