﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JM.Domain.CommonDTO
{
    public class CommonDeleteDto
    {
        public string TableName { get; set; }
        public int UserId { get; set; }
        public string DeletedPC { get; set; }
        public string ColumnName { get; set; }
        public int PrimaryKey { get; set; }
        public int Companyid { get; set; }
    }
}