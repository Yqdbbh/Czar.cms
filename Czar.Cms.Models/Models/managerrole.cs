////////////////////////////////////////////////////////////////////
//                          _ooOoo_                               //
//                         o8888888o                              //
//                         88" . "88                              //
//                         (| ^_^ |)                              //
//                         O\  =  /O                              //
//                      ____/`---'\____                           //
//                    .'  \\|     |//  `.                         //
//                   /  \\|||  :  |||//  \                        //
//                  /  _||||| -:- |||||-  \                       //
//                  |   | \\\  -  /// |   |                       //
//                  | \_|  ''\---/''  |   |                       //
//                  \  .-\__  `-`  ___/-. /                       //
//                ___`. .'  /--.--\  `. . ___                     //
//              ."" '<  `.___\_<|>_/___.'  >'"".                  //
//            | | :  `- \`.;`\ _ /`;.`/ - ` : | |                 //
//            \  \ `-.   \_ __\ /__ _/   .-` /  /                 //
//      ========`-.____`-.___\_____/___.-`____.-'========         //
//                           `=---='                              //
//      ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^        //
//                   佛祖保佑       永不宕机     永无BUG          //
////////////////////////////////////////////////////////////////////

/**
*┌──────────────────────────────────────────────────────────────┐
*│　描    述：                                                    
*│　作    者：复制自yilezhu                                              
*│　版    本：1.0   模板代码自动生成                                              
*│　创建时间：2019-03-10 20:09:52                            
*└──────────────────────────────────────────────────────────────┘
*┌──────────────────────────────────────────────────────────────┐
*│　命名空间: Czar.Cms.Models                                  
*│　类    名：managerrole                                     
*└──────────────────────────────────────────────────────────────┘
*/
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Czar.Cms.Models
{
	/// <summary>
	/// 复制自yilezhu
	/// 2019-03-10 20:09:52
	/// 
	/// </summary>
	[Table("managerrole")]
	public class managerrole
	{
		/// <summary>
		/// 主键
		/// <summary>
		[Key]
		public Int32 Id{ get; set;}

		/// <summary>
		/// 角色名称
		/// <summary>
		[Required]
		[MaxLength(64)]
		public varchar ROLENAME { get; set;}

		/// <summary>
		/// 角色类型1超管2系管
		/// <summary>
		[Required]
		public int ROLETYPE { get; set;}

		/// <summary>
		/// 是否系统默认
		/// <summary>
		[Required]
		public bit ISSYSTEM { get; set;}

		/// <summary>
		/// 添加人
		/// <summary>
		[Required]
		public int ADDMANAGERID { get; set;}

		/// <summary>
		/// 添加时间
		/// <summary>
		[Required]
		public datetime ADDTIME { get; set;}

		/// <summary>
		/// 修改人
		/// <summary>
		public int? MODIFYMANAGERID { get; set;}

		/// <summary>
		/// 修改时间
		/// <summary>
		public datetime? MODIFYTIME { get; set;}

		/// <summary>
		/// 是否删除
		/// <summary>
		[Required]
		public bit ISDELETE { get; set;}

		/// <summary>
		/// 备注
		/// <summary>
		[MaxLength(128)]
		public varchar? REMARK { get; set;}


	}
}
