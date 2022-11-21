namespace MISA.AMIS.KeToan.Common
{
    public class Department : BaseEntity
    {
        #region

        #endregion


        /// <summary>
        /// ID của phòng ban
        /// </summary>
        public Guid DepartmentID { get; set; }
        /// <summary>
        /// Mã phòng ban
        /// </summary>
        public string DepartmentCode { get; set; }
        /// <summary>
        /// Tên phòng ban
        /// </summary>
        public string DepartmentName { get; set; }  
        

    }
}
