/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：管理员                                                    
*│　作    者：复制自yilezhu                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2019-03-12 16:31:15                            
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: Czar.Cms.Models                                  
*│　类    名：manager                                     
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Czar.Cms.Models
{
	/// <summary>
	/// 复制自yilezhu
	/// 2019-03-12 16:31:15
	/// 管理员
	/// </summary>
	[Table("manager")]
	public class manager
	{
		/// <summary>
		/// 添加人
		/// <summary>
		[Required]
		public Int32 ADDMANAGERID { get; set;}

		/// <summary>
		/// 添加时间
		/// <summary>
		[Required]
		public DateTime ADDTIME { get; set;}

		/// <summary>
		/// 头像
		/// <summary>
		[MaxLength(256)]
		public String AVATAR { get; set;}

		/// <summary>
		/// 邮箱地址
		/// <summary>
		[MaxLength(128)]
		public String EMAIL { get; set;}

		/// <summary>
		/// 主键
		/// <summary>
		[Key]
		public Int32 Id{ get; set;}

		/// <summary>
		/// 是否删除
		/// <summary>
		[Required]
		public Int64 ISDELETE { get; set;}

		/// <summary>
		/// 是否锁定
		/// <summary>
		[Required]
		public Int64 ISLOCK { get; set;}

		/// <summary>
		/// 登录次数
		/// <summary>
		public Int32? LOGINCOUNT { get; set;}

		/// <summary>
		/// 最后一次登录IP
		/// <summary>
		[MaxLength(64)]
		public String LOGINLASTIP { get; set;}

		/// <summary>
		/// 最后一次登录时间
		/// <summary>
		public DateTime? LOGINLASTTIME { get; set;}

		/// <summary>
		/// 手机号码
		/// <summary>
		[MaxLength(16)]
		public String MOBILE { get; set;}

		/// <summary>
		/// 修改人
		/// <summary>
		public Int32? MODIFYMANAGERID { get; set;}

		/// <summary>
		/// 修改时间
		/// <summary>
		public DateTime? MODIFYTIME { get; set;}

		/// <summary>
		/// 用户昵称
		/// <summary>
		[MaxLength(32)]
		public String NICKNAME { get; set;}

		/// <summary>
		/// 密码
		/// <summary>
		[Required]
		[MaxLength(128)]
		public String PASSWORD { get; set;}

		/// <summary>
		/// 备注
		/// <summary>
		[MaxLength(128)]
		public String REMARK { get; set;}

		/// <summary>
		/// 角色ID
		/// <summary>
		[Required]
		public Int32 ROLEID { get; set;}

		/// <summary>
		/// 用户名
		/// <summary>
		[Required]
		[MaxLength(32)]
		public String USERNAME { get; set;}


	}
}
