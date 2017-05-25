using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyWizard.WebApiDataAccess.Core
{
    public class Agency
    {
        public string Code { get; set; }
        public string Name { get; set; }
        //public string LongName { get; set; }


        public Agency(string code, string name)
        {
            Code = code;
            Name = name;
        }

        //public static Agency Parse(string description)
        //{
        //    if(description == )
        //}

    }
}
