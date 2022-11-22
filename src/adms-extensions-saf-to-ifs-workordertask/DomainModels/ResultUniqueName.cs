using Amqp.Framing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    public class UniqueNameResult
    {
        public Guid mrid { get; set; }

        public DateTime created { get; set; }

        public Guid objectType { get; set; }

        public NamesName[] names { get; set; }

    }


    public class NamesName
    {
        public string name { get; set; }
        public DateTime created { get; set; }

        public string Modified { get; set; }

        NameTypeName[] nameType { get; set; }


    }

    public class NameTypeName
    {
        public Guid mrid { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public string namingAuthority { get; set; }
      
    }




}
