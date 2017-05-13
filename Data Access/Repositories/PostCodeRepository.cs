﻿using PropertyWizard.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyWizard.WebApiDataAccess.Repositories
{
    public class PostCodeRepository
    {

        public IEnumerable<PostCode> List()
        {
            var list = new List<PostCode>() { };

            list.Add(new PostCode("EC1", "London EC1"));
            list.Add(new PostCode("EC2", "London EC2"));
            list.Add(new PostCode("EC3", "London EC3"));
            list.Add(new PostCode("SE17", "London SE17"));
            
            return list;
        }


        public PostCode Get(string code)
        {
            return List().SingleOrDefault(p => p.Code == code);
        }

    }
}