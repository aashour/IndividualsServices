﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public partial class User
    {
        public long Id { get; set; }
        public string UserName { get; set; }

        public string FullName { get; set; }
    }
}
