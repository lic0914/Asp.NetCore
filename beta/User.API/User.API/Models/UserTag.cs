﻿using System;

namespace User.API.Models
{
    public class UserTag
    {
        public int UserId { get; set; }
        public string Tag { get; set; }
        public DateTime CreatedTime { get; set; }

    }
}