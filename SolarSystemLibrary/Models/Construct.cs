using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystemLibrary.Models
{
    class Construct : IConstruct
    {
        public Construct()
        {
        }

        public string ConstructType { get; set; }
        public ConstructStatus ConstructStatus { get; set; }
        public ConstructSize ConstructSize { get; set; }
        public string Information { get; set; }

        public override string ToString()
        {
            return
                string.Format(
                    "Construct Type: {0}\r\n\tStatus: {1}\t\tSize: {2}\r\n\tInformation: {3}\r\n",
                    this.ConstructType,
                    this.ConstructStatus,
                    this.ConstructSize,
                    Information);
        }
    }
}
