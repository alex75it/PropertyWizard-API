using System;
using System.Linq;

namespace PropertyWizard.WebApi.Core.Entities
{
    public class Agency
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public Agency(string code, string name)
        {
            Code = code;
            Name = name;
        }

    }
}
