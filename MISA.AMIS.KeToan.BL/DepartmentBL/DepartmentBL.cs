using MISA.AMIS.KeToan.Common;
using MISA.AMIS.KeToan.DL;
using MISA.AMIS.KeToan.DL.DepartmentDL;


namespace MISA.AMIS.KeToan.BL.DepartmentBL
{

    public class DepartmentBL : BaseBL<Department>,  IDepartmentBL
    {
        #region Field
        private IDepartmentDL _departmentDL;
        #endregion 

        #region Constructor
        public DepartmentBL(IDepartmentDL departmentDL) : base(departmentDL)
        {
            _departmentDL = departmentDL;
        }
        #endregion
        //#region Field
        //private IDepartmentDL _departmentDL;
        //#endregion
        //#region Constructor
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="departmentDL"></param>
        //public DepartmentBL(IDepartmentDL departmentDL)
        //{
        //    _departmentDL = departmentDL;
        //}
        //#endregion
        //public IEnumerable<dynamic> GetAllDepartment()
        //{
        //    return _departmentDL.GetAllDepartment();
        //}

        //public Department GetDepartmentByID(Guid departmentID)
        //{
        //    return _departmentDL.GetDepartmentByID(departmentID);
        //}

        //public int InsertDepartment(Department department)
        //{
        //    return _departmentDL.InsertDepartment(department);
        //}

        //public int UpdateDepartmentByID(Guid departmentID, Department department)
        //{
        //    return _departmentDL.UpdateDepartmentByID(departmentID, department);
        //}
    }
}
