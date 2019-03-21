/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：复制自yilezhu                                            
*│　版    本：1.0    模板代码自动生成                                                
*│　创建时间：2019-03-13 22:12:48                             
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间： Czar.Cms.Services                                  
*│　类    名： managerroleService                                    
*└──────────────────────────────────────────────────────────────┘
*/
using AutoMapper;
using Czar.Cms.IRepository;
using Czar.Cms.IServices;
using Czar.Cms.Models;
using Czar.Cms.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Czar.Cms.Services
{
    public class managerroleService: ImanagerroleService
    {
        private readonly ImanagerroleRepository _repository;
        private readonly IMapper _mapper;
        public managerroleService(ImanagerroleRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public BaseResult AddOrModify(ManagerRoleAddOrModifyModel item)
        {
            throw new NotImplementedException();
        }

        public BaseResult DeleteIds(string[] ids)
        {
            throw new NotImplementedException();
        }

        public List<managerrole> GetListByCondition(ManagerRoleRequestModel model)
        {
            throw new NotImplementedException();
        }

        public List<MenuNavView> GetMenusByRoleId(int roleId)
        {
            throw new NotImplementedException();
        }

        public TableDataModel LoadData(ManagerRoleRequestModel model)
        {
            throw new NotImplementedException();
        }
    }
}