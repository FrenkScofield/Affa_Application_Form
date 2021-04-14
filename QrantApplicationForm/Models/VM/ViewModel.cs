using QrantApplicationForm.Models.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QrantApplicationForm.Models.VM
{
    public class ViewModel
    {
        public File File { get; set; }
        public IEnumerable<File> Files { get; set; }
        public ApplicationForm ApplicationForm { get; set; }
        public IEnumerable<ApplicationForm> ApplicationForms { get; set; }
    }
}
