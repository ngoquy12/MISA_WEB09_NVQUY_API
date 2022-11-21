using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.KeToan.Common
{

    
    public class Procudure
    {
        /// <summary>
        /// Format tên của procedure lấy thông tin tất cả bản ghi
        /// </summary>
        public static string GET_ALL = "Proc_{0}_GetAll";
        /// <summary>
        /// Format tên của procedure lấy thông tin một bản ghi theo ID
        /// </summary>
        public static string GET_BY_ID = "Proc_{0}_GetByID";
        /// <summary>
        /// Format tên của procedure xóa thông tin một bản ghi theo ID
        /// </summary>
        public static string DELETE_BY_ID = "Proc_{0}_DeleteByID";
        /// <summary>
        /// Format tên của procedure thêm mới một bản ghi
        /// </summary>
        public static string INSERT = "Proc_{0}_Insert";
        /// <summary>
        /// Format tên của procedure cập nhật một bản ghi theo ID
        /// </summary>
        public static string UPDATE_BY_ID = "Proc_{0}_UpdateByID";
    }
}
