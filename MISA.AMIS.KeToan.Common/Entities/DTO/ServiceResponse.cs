using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.KeToan.Common.Entities.DTO
{
    public class ServiceResponse
    {
        /// <summary>
        /// Trạng thái của dữ liệu truyền vào
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// Danh sách các lỗi xảy ra khi truyền dữ liệu vào
        /// </summary>
        public object Data { get; set; }

    }
}
