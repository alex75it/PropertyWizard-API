using System;
using System.Collections.Generic;
using System.Linq;

namespace PropertyWizard.Entities
{
    public class PostCode
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }

        public PostCode(string code, string description, bool enabled)
        {
            Code = code;
            Description = description;
            Enabled = enabled;
        }
    }
}
