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
*│　类    名：managerlog                                     
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
	[Table("managerlog")]
	public class managerlog
	{
		/// <summary>
		/// 主键
		/// <summary>
		[Key]
		public Int32 Id{ get; set;}

		/// <summary>
		/// 操作类型
		/// <summary>
		[MaxLength(32)]
		public varchar? ACTIONTYPE { get; set;}

		/// <summary>
		/// 操作人ID
		/// <summary>
		[Required]
		public int ADDMANAGEID { get; set;}

		/// <summary>
		/// 操作人名称
		/// <summary>
		[MaxLength(64)]
		public varchar? ADDMANAGERNICKNAME { get; set;}

		/// <summary>
		/// 操作时间
		/// <summary>
		[Required]
		public datetime ADDTIME { get; set;}

		/// <summary>
		/// 操作IP
		/// <summary>
		[MaxLength(64)]
		public varchar? ADDIP { get; set;}

		/// <summary>
		/// 备注
		/// <summary>
		[MaxLength(256)]
		public varchar? REMARK { get; set;}


	}
}
