using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using MyMVC;
using System.Reflection;
using Mumu.Frameworks.Entity;
using Mumu.Frameworks.LogicalOperation;

namespace Mumu.Frameworks.AjaxController.Ajax
{
    /// <summary>
    /// 
    /// </summary>
    public class AjaxGroup
    {
        /// <summary>
        /// 添加组信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        [Action]
        public object AddGroupInfo(string name, string description)
        {
            try
            {
                GroupInfo info = GroupOperation.GetGroupInfoByName(name);
                if (null == info)
                {
                    GroupInfo obj = new GroupInfo()
                    {
                        id = Guid.NewGuid(),
                        name = name,
                        description = description,
                        status = 1,
                        updatetime = DateTime.Now
                    };
                    GroupOperation.AddOrUpdateGroupInfo(obj, EnumAddOrUpdate.Add);
                    return string.Format("添加组【{0}】信息成功！", name);
                }
                else
                    return string.Format("系统已存在组【{0}】信息!", name);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        /// <summary>
        /// 修改组信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="description"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [Action]
        public object UpdateGroupInfo(string id,string description, int status)
        {
            try
            {
                GroupInfo info = GroupOperation.GetGroupInfoById(new Guid(id));
                if (null != info)
                {
                    info.description = description;
                    info.status = status;
                    info.updatetime = DateTime.Now;
                    GroupOperation.AddOrUpdateGroupInfo(info, EnumAddOrUpdate.Update);
                    return string.Format("更新组【{0}】信息成功！", info.name);
                }
                else
                    return string.Format("修改失败，系统不存在编号【{0}】组信息！", id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        /// <summary>
        /// 根据id删除组信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Action]
        public object DeleteGroupInfoById(string id)
        {
            try
            {
                GroupInfo info = GroupOperation.GetGroupInfoById(new Guid(id));
                if (null != info)
                {
                    GroupOperation.DeleteGroupInfo(new Guid(id));
                    return string.Format("删除组【{0}】信息成功！", info.name);
                }
                else
                    return string.Format("删除失败，系统不存在编号【{0}】组信息！", id);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        /// <summary>
        /// 查询组信息列表
        /// </summary> 
        /// <param name="fields"></param>
        /// <param name="key"></param>
        /// <param name="order"></param>
        /// <param name="ascOrdesc"></param>
        /// <param name="page"></param>
        /// <param name="rows"></param>
        /// <returns></returns>
        [Action]
        public object GetGroupInfoList(string fields, string key, string order, string ascOrdesc, int page, int rows)
        {
            try
            {

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
