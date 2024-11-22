﻿using System;

namespace JM.Domain.DTOs
{
    public class BaseModelDTO
    {
        public int CompanyId { get; set; }
        public string CompanyName{ get; set; }
        public int CreateBy { get; set; }
        public string CreateByName { get; set; }
        public DateTime? CreateOn { get; set; }
        public string CreatePc { get; set; }
        public int UpdateBy { get; set; }
        public string UpdateByName { get; set; }
        public DateTime? UpdateOn { get; set; }
        public string UpdatePc { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int DeleteBy { get; set; }
        public string DeleteByName { get; set; }
        public DateTime? DeleteOn { get; set; }
        public string DeletePc { get; set; }

    }
}
