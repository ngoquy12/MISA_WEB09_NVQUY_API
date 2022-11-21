using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.KeToan.Common.Attributes
{
    public sealed class PrimarykeyAttribute : Attribute
    {
        /// <summary>
        /// Thông báo lỗi 
        /// </summary>
        /// 
        public string? ErrorMessage { get; set; }
        public PrimarykeyAttribute()
        {
        }
        public PrimarykeyAttribute(string? errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}

