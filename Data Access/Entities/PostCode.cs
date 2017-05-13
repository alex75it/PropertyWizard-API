using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PropertyWizard.DataAccess.Entities
{
    public class PostCode
    {
        public string Code { get; }
        public string Description { get; }

        public PostCode(string code, string description)
        {
            Code = code;
            Description = description;
        }
    }
}