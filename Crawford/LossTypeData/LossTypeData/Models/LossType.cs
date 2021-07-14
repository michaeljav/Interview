using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LossTypeData.Models
{
    public class LossType
    {
    
        public int LossTypeID { get; set; }    
        public string LossTypeCode { get; set; }
        public string LossTypeDescription { get; set; }
    }
}