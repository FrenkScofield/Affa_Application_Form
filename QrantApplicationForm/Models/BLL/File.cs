﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QrantApplicationForm.Models.BLL
{
    public class File
    {
        public int id { get; set; }
        public string UniqKod { get; set; }
        public string FolderName { get; set; }
        public string Size { get; set; }
        public string UrlFile { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Type { get; set; }
        public string LinkFile { get; set; }
    }
}
