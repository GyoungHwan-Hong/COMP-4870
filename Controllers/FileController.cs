using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using lab03.Models;

namespace lab03.Controllers
{
    public class FileController : Controller
    {

        private IWebHostEnvironment Environment;


        public static List<MyFile> FileLists = new List<MyFile>();

        public FileController(IWebHostEnvironment _environment)
        {
        Environment = _environment;
        }


        
        int i = 0;
        // GET: Process
        public ActionResult Index()
        {
            string[] filePaths = Directory.GetFiles("TextFiles");

            FileLists.Clear();

            foreach (string filepath in filePaths) {
                
                MyFile myfile = new MyFile();

                myfile.Id = i++;
                myfile.filename = Path.GetFileName(filepath);
                myfile.content = System.IO.File.ReadAllText(filepath);

                FileLists.Add(myfile);
            }

            return View(FileLists);
        }

        public ActionResult Content(int id) {

            MyFile fileToShow = new MyFile();

            fileToShow = FileLists[id];

            
            return View(fileToShow);
        }
    }
}