using MISA.AMIS.KeToan.Common;
using System.ComponentModel.DataAnnotations;

namespace MISA.AMIS.KeToan.Common
{
    public class Employee : BaseEntity
    {
        /// <summary>
        /// ID nhân viên
        /// </summary>
        [Key]
        public Guid EmployeeID { get; set; }
        /// <summary>
        /// Mã nhân viên 
        /// </summary>
        [Required (ErrorMessage ="Mã nhân viên không được phép để trống")]
        public string EmployeeCode { get; set; }
        /// <summary>
        /// Tên nhân viên
        /// </summary>
        [Required (ErrorMessage ="Tên nhân viên không được phép để trống")]
        public string EmployeeName { get; set; }
        /// <summary>
        /// Giới tính
        /// </summary>
        public Gender? Gender { get; set; }
        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }
        ///<summary>
        ///Địa chỉ 
        /// </summary>
        public string? Address { get; set; }
        ///<summary>
        ///ID của phòng ban
        /// </summary>
        [Required (ErrorMessage ="Tên đơn vị không được phép để trống")]
        public Guid DepartmentID {get; set; }
        ///<summary>
        ///Số chứng minh nhân dân
        /// </summary>
        public string? IdentityNumber { get; set; }
        /// <summary>
        /// Ngày cấp chứng minh nhân dân
        /// </summary>
        public DateTime? IdentityIssueDate { get; set; }
        /// <summary>
        /// Nơi cấp chứng minh nhân dân
        /// </summary>
        public string? IdentityIssuePlace { get; set; }
        /// <summary>
        /// Chức danh
        /// </summary>
        public string? ContactTitle { get;set; }
        /// <summary>
        /// Số điện thoại di động
        /// </summary>
        public string? ContactMobile { get; set; }
        /// <summary>
        /// Số điện thoại cố định
        /// </summary>
        public  string? ContactFax { get; set; }
        /// <summary>
        /// Email
        /// </summary>

        public string? Email { get;set; }
        /// <summary>
        /// Tài khoản ngân hàng
        /// </summary>
        public string? BankAccount { get; set; }
        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        public string? BankName { get; set; }
        /// <summary>
        /// Tên chi nhánh ngân hàng
        /// </summary>
        public string? BankBranchName { get; set; }
      
    }
}
