using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.KeToan.Common
{
    public class BaseEntity
    {
        /// <summary>
        /// Ngày thêm
        /// </summary>
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Người thêm
        /// </summary>
        public string? CreatedBy { get; set; }
        /// <summary>
        /// Ngày chỉnh sửa gần 
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
        /// <summary>
        /// Người chỉnh sửa gần nhất 
        /// </summary>
        public string? ModifiedBy { get; set; }
    }
}
