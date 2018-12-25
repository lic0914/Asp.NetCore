﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.API.Model
{
    public class AppUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        public string Title { get; set; }
    }
}
