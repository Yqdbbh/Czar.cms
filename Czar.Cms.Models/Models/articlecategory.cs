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
*│　类    名：articlecategory                                     
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
	[Table("articlecategory")]
	public class articlecategory
	{
		/// <summary>
		/// 主键
		/// <summary>
		[Key]
		public Int32 Id{ get; set;}

		/// <summary>
		/// 分类标题
		/// <summary>
		[Required]
		[MaxLength(128)]
		public varchar TITLE { get; set;}

		/// <summary>
		/// 父分类ID
		/// <summary>
		[Required]
		public int PARENTID { get; set;}

		/// <summary>
		/// 类别ID列表(逗号分隔开)
		/// <summary>
		[MaxLength(128)]
		public varchar? CLASSLIST { get; set;}

		/// <summary>
		/// 类别深度
		/// <summary>
		public int? CLASSLAYER { get; set;}

		/// <summary>
		/// 排序
		/// <summary>
		[Required]
		public int SORT { get; set;}

		/// <summary>
		/// 分类图标
		/// <summary>
		[MaxLength(128)]
		public varchar? IMAGEURL { get; set;}

		/// <summary>
		/// 分类SEO标题
		/// <summary>
		[MaxLength(128)]
		public varchar? SEOTITLE { get; set;}

		/// <summary>
		/// 分类SEO关键字
		/// <summary>
		[MaxLength(256)]
		public varchar? SEOKEYWORDS { get; set;}

		/// <summary>
		/// 分类SEO描述
		/// <summary>
		[MaxLength(512)]
		public varchar? SEODESCRIPTION { get; set;}

		/// <summary>
		/// 是否删除
		/// <summary>
		[Required]
		public bit ISDELETED { get; set;}


	}
}
