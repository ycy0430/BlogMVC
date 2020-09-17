using LitJson;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace db.bll
{
    /// <summary>
    /// 用户组织
    /// </summary>
    public class rbac_UserOrg
    {
        /// <summary>
        /// 判断用户是否能够登录该组织
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="orgCode"></param>
        /// <param name="dc"></param>
        /// <returns></returns>
        public static bool isCanLogin(string userCode,string orgCode,db.dbEntities dc) {
            efHelper ef = new efHelper(ref dc); 
            string sql = " SELECT rowID FROM rbac_UserOrg WHERE isLogin='是' AND userCode=@userCode AND orgCode=@orgCode ";
            return ef.ExecuteExist(sql, new { userCode, orgCode });
        }

        /// <summary>
        /// 添加用户组织关联
        /// </summary>
        /// <param name="rowID"></param>
        /// <param name="selected"></param>
        /// <param name="dc"></param>
        public static void addOrgs(string rowID, string selected, db.dbEntities dc)
        {
            efHelper ef = new efHelper(ref dc); 

            db.sbs_Empl emplEntry = dc.sbs_Empl.Single(a => a.rowID == rowID);
            List<string> list = rui.dbTools.getList(selected);
            foreach (string orgCode in list)
            {
                db.rbac_UserOrg entry = new db.rbac_UserOrg();
                entry.userCode = emplEntry.emplCode;
                entry.orgCode = orgCode;
                if (orgCode == emplEntry.orgCode)
                    entry.deptCode = emplEntry.deptCode;
                if (rui.typeHelper.isNullOrEmpty(entry.deptCode))
                    entry.isLogin = "否";
                else
                    entry.isLogin = "是";
                entry.isAllPrj = "否";
                dc.rbac_UserOrg.Add(entry);
            }
            dc.SaveChanges();
        }

        /// <summary>
        /// 删除用户组织关联
        /// </summary>
        /// <param name="rowID"></param>
        /// <param name="selected"></param>
        /// <param name="dc"></param>
        public static void deleteOrgs(string rowID, string selected, db.dbEntities dc)
        {
            efHelper ef = new efHelper(ref dc); 

            string userCode = db.bll.sbs_Empl.getCodeByRowID(rowID, dc);
            string sql = " delete from rbac_UserOrg where userCode=@userCode and orgCode in @orgCode ";
            ef.Execute(sql, new { userCode, orgCode = rui.dbTools.getDpList(selected) });
        }

        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="rowIDList"></param>
        /// <param name="deptCodeList"></param>
        /// <param name="isLoginList"></param>
        /// <param name="isAllPrjList"></param>
        /// <param name="dc"></param>
        public static void saveOrgs(List<string> rowIDList, List<string> deptCodeList, List<string> isLoginList, List<string> isAllPrjList, db.dbEntities dc)
        {
            efHelper ef = new efHelper(ref dc); 

            for (int i = 0; i < rowIDList.Count; i++)
            {
                string rowID = rui.typeHelper.toString(rowIDList[i]);
                db.rbac_UserOrg entry = dc.rbac_UserOrg.SingleOrDefault(a => a.rowID == rowID);
                if (entry != null)
                {
                    entry.deptCode = deptCodeList[i];
                    entry.isLogin = isLoginList[i];
                    entry.isAllPrj = isAllPrjList[i];
                }
            }
            dc.SaveChanges();
        }

        /// <summary>
        /// 下拉框绑定某一部门下的所有用户
        /// </summary>
        /// <param name="has请选择"></param>
        /// <param name="selectedValues"></param>
        /// <param name="deptCode"></param>
        /// <returns></returns>
        public static List<SelectListItem> bindDdl(bool has请选择 = false, string selectedValue = "", string deptCode = "")
        {
            efHelper ef = new efHelper();
            string sql = @" SELECT  rbac_User.userCode as code, rbac_User.userName as name
                            FROM rbac_User 
                            LEFT OUTER JOIN rbac_UserOrg ON rbac_User.userCode = rbac_UserOrg.userCode 
                            LEFT OUTER JOIN sbs_Dept ON rbac_UserOrg.deptCode = sbs_Dept.deptCode 
                            WHERE sbs_Dept.deptCode=@deptCode ";
            DataTable table = ef.ExecuteDataTable(sql, new { deptCode });
            List<SelectListItem> list = rui.listHelper.dataTableToDdlList(table, has请选择, selectedValue);
            return list;
        }

        /// <summary>
        /// 获取某个用户能够访问的组织列表
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="dc"></param>
        /// <returns></returns>
        public static string getOrgDdlJsonByUserCode(string userCode, db.dbEntities dc)
        {
            efHelper ef = new efHelper(ref dc); 

            string sql = @" SELECT sbs_Org.orgCode AS code,orgName AS name FROM rbac_UserOrg
                LEFT JOIN sbs_Org ON rbac_UserOrg.orgCode = sbs_Org.orgCode
                WHERE isLogin='是' and userCode=@userCode order by sbs_Org.orgCode desc ";
            DataTable table = ef.ExecuteDataTable(sql, new { userCode });

            return rui.jsonResult.dataTableToJsonStr(table);
        }
    }
}
