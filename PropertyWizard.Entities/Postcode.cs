using System;
using System.Collections.Generic;
using System.Linq;

namespace PropertyWizard.Entities
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
