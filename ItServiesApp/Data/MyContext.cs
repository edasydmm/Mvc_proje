﻿using ItServiesApp.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItServiesApp.Data
{
    public class MyContext :IdentityDbContext<ApplicationUser,ApplicationRole,string>
    {

        public MyContext(DbContextOptions options)
            : base(options)
        {
        }


    }
}