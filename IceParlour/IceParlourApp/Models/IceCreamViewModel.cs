using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IceParlourApp.Models
{
    public class IceCreamViewModel
    {
        public int IceCreamId { get; set; }
        public IEnumerable<IceCreamMaster> IceCreamList { get; set; }
        public string Name { get; set; }
    }
}
