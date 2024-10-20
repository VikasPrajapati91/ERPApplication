using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Template
    {
        public int TemplateId { get; set; }
        public string TemplateName { get; set; }

        // Navigation properties
        public ICollection<TemplateMenu> TemplateMenus { get; set; } = new List<TemplateMenu>();
    }

}
