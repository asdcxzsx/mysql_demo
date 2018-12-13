using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using MySql.Data.EntityFrameworkCore.DataAnnotations;

namespace ConsoleApp.MySQL.Models
{
    public abstract class BaseModel<TKey> : IEquatable<BaseModel<TKey>>
    {
        protected BaseModel()
        {
            CreateTime = DateTime.Parse(DateTime.Now.ToString("s"));
        }

        #region *************************************属性区域************************************************************************

        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TKey Id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 是否禁用
        /// </summary>
        [Column(TypeName = "bit")]
        public bool IsDisable { get; set; }

        #endregion

        /// <summary>
        /// 比较器
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(BaseModel<TKey> other)
        {
            if (other != null)
            {
                return Id.Equals(other.Id);
            }

            return false;
        }
    }

    [Table("DataLog")]
    [MySqlCharset("utf8")]
    public class DataLog : BaseModel<Guid>
    {
        public DataLog()
        {
            Id = Guid.NewGuid();
        }
        [MaxLength(20)]
        public string Type { get; set; }

        public string Remark { get; set; }

        public string Action { get; set; } = $"Action{DateTime.Now.ToShortTimeString()}";

    }

}
