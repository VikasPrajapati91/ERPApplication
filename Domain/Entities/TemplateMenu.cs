using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TemplateMenu
    {
        public int TemplateId { get; set; }
        public int MenuId { get; set; }

        // Navigation properties
        public Template Template { get; set; }
        public Menu Menu { get; set; }
    }

}
