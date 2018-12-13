using System;
using System.Linq;
using ConsoleApp.MySQL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.ExpressionTranslators.Internal;
using Newtonsoft.Json;

namespace ConsoleApp.MySQL
{
    /// <summary>
    /// https://dev.mysql.com/doc/connector-net/en/connector-net-entityframework-core.html
    /// http://www.cnblogs.com/crazylqy/p/4361406.html
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new Context())
            {
                CheckMigrations(ctx);
                var lst = ctx.DataLogs.ToList();
                //if (!ctx.DataLogs.Any())
                //{
                DataLog log = new DataLog();
                log.Type = "Event";
                log.Remark = $"{DateTime.Now.ToString("s")}";
                ctx.DataLogs.Add(log);
                ctx.SaveChanges();
                // }
                var ss = JsonConvert.SerializeObject(ctx.DataLogs.ToList());
                Console.WriteLine($"{ss}");
            }
            Console.ReadKey();
        }


        /// <summary>
        /// 检查迁移
        /// </summary>
        /// <param name="db"></param>
        static void CheckMigrations(Context db)
        {
            db.Database.EnsureCreated();
            Console.WriteLine("Check Migrations");    //判断是否有待迁移(Add-Migration Add_Col 不可少,Update-Database可以省略而已、。。、、。)
            if (db.Database.GetPendingMigrations().Any())
            {
                Console.WriteLine("Migrating...");        //执行迁移
                db.Database.Migrate();
                Console.WriteLine("Migrated");
            }
            Console.WriteLine("Check Migrations Coomplete!");
        }
    }
}
