using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Sample05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            test_insert();
            test_mult_insert();
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
    }
}
