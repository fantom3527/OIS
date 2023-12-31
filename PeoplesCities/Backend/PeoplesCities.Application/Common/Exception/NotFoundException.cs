﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeoplesCities.Application.Common.Exception
{
    public class NotFoundException : IOException
    {
        public NotFoundException(string name, object key)
            : base($"Entity \"{name}\" ({key} not found)") { }
    }
}
