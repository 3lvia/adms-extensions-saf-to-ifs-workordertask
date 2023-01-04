using Amqp.Framing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    public class UniqueIdResult
    {
        public int pageNumber { get; set; }

        public int pageSize { get; set; }

        public int totalPages { get; set; }

        public int totalRecords  { get; set; }

        public Data[] data { get; set; }

    }


    public class Data
    {
        public Guid mrid { get; set; }   
  
        public string objectType { get; set; }

        public Names[] names { get; set; }

    }

    public class Names
    {
        public string name { get; set; }
        public DateTime created { get; set; }

        public string Modified { get; set; }

        NameType[] nameType { get; set; }


    }

    public class NameType
    {
        public Guid mrid { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public string namingAuthority { get; set; }
      
    }







    public class UniqueIdOLD
    {

        public string mrid { get; set; }
 
        public string name { get; set; }

        public string description { get; set; }


    }
}
