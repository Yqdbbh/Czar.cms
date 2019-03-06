using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Linq;

namespace Sample05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //test_insert();
            //test_mult_insert();
            //test_delete();
            //test_mult_del();
            //test_update();
            //test_mult_update();
            //test_select();
            test_select_content_with_comment();
            Console.ReadKey();
        }

        /// <summary>
        /// 插入一条数据
        /// </summary>
        static void test_insert()
        {
            var content = new Content
            {
                title = "标题1",
                content = "这是内容",
            };
            using (var conn = new MySqlConnection("server=127.0.0.1;user=root;password=admin; database=coretest;"))
            {
                string sql_insert = @"insert into content(title,content,status,add_time,modify_time) values(@title,@content,@status,@add_time,@modify_time)";
                var result = conn.Execute(sql_insert, content);
                Console.WriteLine($"test_insert:插入了{result}条数据");
            }
        }

        static void test_mult_insert()
        {
            List<Content> contents = new List<Content>() {
                   new Content
                {
                    title = "批量插入标题1",
                    content = "批量插入内容1",

                },
                   new Content
                {
                    title = "批量插入标题2",
                    content = "批量插入内容2",

                },
            };

            using (var conn = new MySqlConnection("server=127.0.0.1;user=root;password=admin; database=coretest;"))
            {
                string sql_insert = @"insert into content(title,content,status,add_time,modify_time) values(@title,@content,@status,@add_time,@modify_time)";
                var result = conn.Execute(sql_insert, contents);
                Console.WriteLine($"test_mult_insert：插入了{result}条数据！");
            }
        }

        /// <summary>
        /// 测试删除数据
        /// </summary>
        static void test_delete()
        {
            var content = new Content { id = 2 };
            using (var conn = new MySqlConnection("server=localhost;user=root;password=admin;database=coretest"))
            {
                string sql_del = "Delete from content where (id = @id)";
                var result = conn.Execute(sql_del, content);
                Console.WriteLine($"test_del:删除了{result}条数据");
            }
            
        }

        /// <summary>
        /// 批量删除操作
        /// </summary>
        static void test_mult_del() {
            List<Content> contents = new List<Content> { new Content { id = 3 }, new Content { id = 1 } };
            using (var conn = new MySqlConnection("server=localhost;user=root;password=admin;database=coretest"))
            {
                string sql_del = "Delete from content where (id = @id)";
                var result = conn.Execute(sql_del, contents);
                Console.WriteLine($"test_mult_del:删除了{result}条数据");
            }
        }

        /// <summary>
        /// 测试修改单条数据
        /// </summary>
        static void test_update()
        {
            var content = new Content() { id = 4, title = "这是修改之后的标题", content = "内容4" };
            using (var conn = new MySqlConnection("server=localhost;user=root;password=admin;database=coretest"))
            {
                string sql_up = "update content set title=@title,content=@content,modify_time=sysdate() where (id =@id)";
                var result = conn.Execute(sql_up, content);
                Console.WriteLine($"test_update:更新了{result}条数据");
            }
        }

        /// <summary>
        /// 测试修改多数据
        /// </summary>
        static void test_mult_update()
        {
            List<Content> contents = new List<Content> {
                new Content { id = 5,title="批量修改1",content="内容不能为空1" },
                new Content { id = 6,title="批量修改2",content="内容不能为空1" } };
            using (var conn = new MySqlConnection("server=localhost;user=root;password=admin;database=coretest"))
            {
                string sql_up = "update content set title=@title,content=@content,modify_time=sysdate() where (id =@id)";
                var result = conn.Execute(sql_up, contents);
                Console.WriteLine($"test_mult_update:更新了{result}条数据");
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        static void test_select()
        {
            using (var conn = new MySqlConnection("server=localhost;user=root;password=admin;database=coretest"))
            {
                string sql1 = "select * from content where id=@id";
                var result1 = conn.QueryFirstOrDefault<Content>(sql1, new { id = 5 });
                Console.WriteLine($"test_select:查询到了");
                string sql2 = "select * from content where id in @ids";
                var result2 = conn.Query<Content>(sql2, new { ids = new int[] { 4, 6 } });
                Console.WriteLine($"test_select:查询到了");
            }
        }

        /// <summary>
        /// 测试关联查询
        /// </summary>
        static void test_select_content_with_comment()
        {
            using (var conn = new MySqlConnection("server=localhost;user=root;password=admin;database=coretest"))
            {
                string sql_sel = "select * from content where id=@id;select * from comment where content_id=@id";
                using (var result = conn.QueryMultiple(sql_sel, new { id = 5 })) {
                    var content = result.ReadFirstOrDefault<ContentWithComment>();
                    content.comments = result.Read<Comment>();
                    Console.WriteLine($"评论数量:{content.comments.Count()}");

                }

            }
        }
    }
}
