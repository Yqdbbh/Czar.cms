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
using Czar.Cms.IRepository;
using Czar.Cms.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Czar.Cms.Services
{
    public class managerroleService: ImanagerroleService
    {
        private readonly ImanagerroleRepository _repository;

        public managerroleService(ImanagerroleRepository repository)
        {
            _repository = repository;
        }
    }
}