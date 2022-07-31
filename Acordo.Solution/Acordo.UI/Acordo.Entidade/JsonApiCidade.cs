using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acordo.Entidade
{
    public class JsonApiCidade
    {
        public List<weather> weather { get; set; }

        public String name { get; set; }

        public main main { get; set; }

        public sys sys { get; set; }
    }

    public class weather
    {
        public String main { get; set; }

        public String description { get; set; }
    }
    public class main
    {
        public String temp_min { get; set; }

        public String temp_max { get; set; }
    }
    public class sys
    {
        public String country { get; set; }

        public String temp_max { get; set; }
    }
}
