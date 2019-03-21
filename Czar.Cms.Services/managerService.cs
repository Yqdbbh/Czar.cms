/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：复制自yilezhu                                            
*│　版    本：1.0    模板代码自动生成                                                
*│　创建时间：2019-03-13 22:12:48                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： Czar.Cms.Services                                  
*│　类    名： managerService                                    
*└──────────────────────────────────────────────────────────────┘
*/
using AutoMapper;
using Czar.Cms.Core.Extensions;
using Czar.Cms.IRepository;
using Czar.Cms.IServices;
using Czar.Cms.Models;
using Czar.Cms.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Czar.Cms.Services
{
    public class managerService: ImanagerService
    {
        private readonly ImanagerRepository _repository;

        private readonly ImanagerroleRepository _roleRepository;

        private readonly IMapper _mapper;

        private readonly ImanagerlogRepository _logRepository;

        public managerService(ImanagerRepository repository,ImanagerroleRepository roleRepository,IMapper mapper,ImanagerlogRepository logRepository)
        {
            _repository = repository;
            _roleRepository = roleRepository;
            _mapper = mapper;
            _logRepository = logRepository;
        }

        public BaseResult AddOrModify(ManagerAddOrModifyModel item)
        {
            var result = new BaseResult();
            manager manager;
            if (item.Id == 0)
            {
                //TODO  Add
                manager = _mapper.Map<manager>(item);
                manager.PASSWORD = "123456";
                manager.LOGINCOUNT = 0;
                manager.ADDMANAGERID = 1;
                manager.ISDELETE = false;
                manager.ADDTIME = DateTime.Now;
                if (_repository.Insert(manager) > 0)
                {
                    result.ResultCode = ResultCodeAddMsgKey.CommonObjectSuccessCode;
                    result.ResultMsg = ResultCodeAddMsgKey.CommonObjectSuccessMsg;
                }
                else
                {
                    result.ResultCode = ResultCodeAddMsgKey.CommonExceptionCode;
                    result.ResultMsg = ResultCodeAddMsgKey.CommonExceptionMsg;
                }
            }
            else
            {
                //TODO Modify
                manager = _repository.Get(item.Id);
                if(manager!=null)
                {
                    _mapper.Map(item, manager);
                    manager.MODIFYMANAGERID = 1;
                    manager.MODIFYTIME = DateTime.Now;
                    if (_repository.Update(manager) > 0)
                    {
                        result.ResultCode = ResultCodeAddMsgKey.CommonObjectSuccessCode;
                        result.ResultMsg = ResultCodeAddMsgKey.CommonObjectSuccessMsg;
                    }
                    else
                    {
                        result.ResultCode = ResultCodeAddMsgKey.CommonExceptionCode;
                        result.ResultMsg = ResultCodeAddMsgKey.CommonExceptionMsg;
                    }
                }
                else
                {
                    result.ResultCode = ResultCodeAddMsgKey.CommonFailNoDataCode;
                    result.ResultMsg = ResultCodeAddMsgKey.CommonFailNoDataMsg;
                }
            }
            return result;
        }

        public BaseResult ChangeLockStatus(ChangeStatusModel model)
        {
            var result = new BaseResult();
            var isLock = _repository.GetLockStatusById(model.Id);
            if (isLock != model.Status)
            {
                var count = _repository.ChangeLockStatusById(model.Id, model.Status);
                if (count > 0)
                {
                    result.ResultCode = ResultCodeAddMsgKey.CommonObjectSuccessCode;
                    result.ResultMsg = ResultCodeAddMsgKey.CommonObjectSuccessMsg;
                }
                else
                {
                    result.ResultCode = ResultCodeAddMsgKey.CommonExceptionCode;
                    result.ResultMsg = ResultCodeAddMsgKey.CommonExceptionMsg;
                }
            }
            else
            {
                result.ResultCode = ResultCodeAddMsgKey.CommonDataStatusChangeCode;
                result.ResultMsg = ResultCodeAddMsgKey.CommonDataStatusChangeMsg;
            }
            return result;
        }

        public BaseResult ChangePassword(ChangePasswordModel model)
        {
            BaseResult result = new BaseResult();
            string oldPwd = _repository.GetPasswordById(model.Id);
            if (oldPwd == "123456")
            {
                var count = _repository.ChangePasswordById(model.Id, "123456");
                if (count > 0)
                {
                    result.ResultCode = ResultCodeAddMsgKey.CommonObjectSuccessCode;
                    result.ResultMsg = ResultCodeAddMsgKey.CommonObjectSuccessMsg;
                }
                else
                {
                    result.ResultCode = ResultCodeAddMsgKey.CommonExceptionCode;
                    result.ResultMsg = ResultCodeAddMsgKey.CommonExceptionMsg;
                }
            }
            else
            {
                result.ResultCode = ResultCodeAddMsgKey.PasswordOldErrorCode;
                result.ResultMsg = ResultCodeAddMsgKey.PasswordOldErrorMsg;
            }
            return result;
        }

        public BaseResult DeleteIds(int[] Ids)
        {
            var result = new BaseResult();
            if (Ids.Count() == 0)
            {
                result.ResultCode = ResultCodeAddMsgKey.CommonModelStateInvalidCode;
                result.ResultMsg = ResultCodeAddMsgKey.CommonModelStateInvalidMsg;
            }
            else
            {
                var count = _repository.DeleteLogical(Ids);
                if (count > 0)
                {
                    result.ResultCode = ResultCodeAddMsgKey.CommonObjectSuccessCode;
                    result.ResultMsg = ResultCodeAddMsgKey.CommonObjectSuccessMsg;
                }
                else
                {
                    result.ResultCode = ResultCodeAddMsgKey.CommonExceptionCode;
                    result.ResultMsg = ResultCodeAddMsgKey.CommonExceptionMsg;
                }

            }
            return result;
        }

        public TableDataModel LoadData(ManagerRequestModel model)
        {
            string conditions = "where IsDelete=0 ";
            if (!model.Key.IsNullOrWhiteSpace())
            {
                conditions += $" and (username like '%@Key%' or NickName like '%@Key%' or Remark like '%@Key%' or Mobile like '%@Key%' or Email like '%@Key%')";
            }
            var list = _repository.GetListPaged(model.Page, model.Limit, conditions, " Id desc", model).ToList();
            var viewList = new List<ManagerListModel>();
            list.ForEach(x =>
            {
                var item = _mapper.Map<ManagerListModel>(x);
                item.RoleName = _roleRepository.GetNameById(x.ROLEID);
                viewList.Add(item);
            });
            return new TableDataModel
            {
                count = _repository.RecordCount(conditions),
                data = viewList
            };
        }

        public manager SignIn(LoginModel model)
        {
            model.Password = "123456";
            model.UserName = model.UserName.Trim();
            string condition = " where IsDelete=0 ";//未被删除的数据
            condition += $" and (UserName=@UserName or Mobile=@UserName or Email=@UserName ) and Password=@Password ";
            var manager = _repository.GetList(condition, model).FirstOrDefault();
            if (manager != null)
            {
                manager.LOGINLASTIP = model.Ip;
                manager.LOGINLASTTIME = DateTime.Now;
                manager.LOGINCOUNT += 1;
                _repository.Update(manager);
                _logRepository.Insert(new managerlog()
                {
                    ACTIONTYPE = CzarCmsEnums.ActionEnum.Sign.ToString(),
                    ADDMANAGEID = manager.Id,
                    ADDMANAGERNICKNAME = manager.NICKNAME,
                    ADDTIME = DateTime.Now,
                    ADDIP=model.Ip,
                    REMARK="用户登录"
                });
            }
            return manager;
        }
    }
}