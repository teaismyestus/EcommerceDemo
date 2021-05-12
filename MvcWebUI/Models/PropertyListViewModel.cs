using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Models
{
    public class PropertyListViewModel
    {
        public List<Property> Properties { get; set; }
        public int CurrentProperty { get; set; }
    }
}
