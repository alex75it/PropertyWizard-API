using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyWizard.DataAccess.Entities
{
    public class PostCode
    {
        public string Code { get; set; }
        public string Description { get; set; }

        public PostCode(string code, string description)
        {
            Code = code;
            Description = description;
        }
    }
}