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
*│　类    名：article                                     
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
	[Table("article")]
	public class article
	{
		/// <summary>
		/// 主键
		/// <summary>
		[Key]
		public Int32 Id{ get; set;}

		/// <summary>
		/// 分类ID
		/// <summary>
		[Required]
		public int CATEGORYID { get; set;}

		/// <summary>
		/// 文章标题
		/// <summary>
		[Required]
		[MaxLength(128)]
		public varchar TITLE { get; set;}

		/// <summary>
		/// 图片地址
		/// <summary>
		[MaxLength(128)]
		public varchar? IMAGEURL { get; set;}

		/// <summary>
		/// 文章内容
		/// <summary>
		[MaxLength(65535)]
		public text? CONTENT { get; set;}

		/// <summary>
		/// 浏览次数
		/// <summary>
		[Required]
		public int VIEWCOUNT { get; set;}

		/// <summary>
		/// 排序
		/// <summary>
		[Required]
		public int SORT { get; set;}

		/// <summary>
		/// 作者
		/// <summary>
		[MaxLength(64)]
		public varchar? AUTHOR { get; set;}

		/// <summary>
		/// 来源
		/// <summary>
		[MaxLength(128)]
		public varchar? SOURCE { get; set;}

		/// <summary>
		/// SEO标题
		/// <summary>
		[MaxLength(128)]
		public varchar? SEOTITLE { get; set;}

		/// <summary>
		/// SEO关键字
		/// <summary>
		[MaxLength(256)]
		public varchar? SEOKEYWORD { get; set;}

		/// <summary>
		/// SEO描述
		/// <summary>
		[MaxLength(512)]
		public varchar? SEODESCRIPTION { get; set;}

		/// <summary>
		/// 添加人ID
		/// <summary>
		[Required]
		public int ADDMANAGERID { get; set;}

		/// <summary>
		/// 添加时间
		/// <summary>
		[Required]
		public datetime ADDTIME { get; set;}

		/// <summary>
		/// 修改人ID
		/// <summary>
		public int? MODIFYMANAGERID { get; set;}

		/// <summary>
		/// 修改时间
		/// <summary>
		public datetime? MODIFYTIME { get; set;}

		/// <summary>
		/// 是否置顶
		/// <summary>
		[Required]
		public bit ISTOP { get; set;}

		/// <summary>
		/// 是否轮播显示
		/// <summary>
		[Required]
		public bit ISSLIDE { get; set;}

		/// <summary>
		/// 是否热门
		/// <summary>
		[Required]
		public bit ISRED { get; set;}

		/// <summary>
		/// 是否发布
		/// <summary>
		[Required]
		public bit ISPUBLISH { get; set;}

		/// <summary>
		/// 是否删除
		/// <summary>
		[Required]
		public bit ISDELETED { get; set;}


	}
}
