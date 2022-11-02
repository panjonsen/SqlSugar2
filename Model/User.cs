using Model.Base;
using SqlSugar;

namespace Model
{
    public record class User : ModelBase
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long UserId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        [SugarColumn(IsNullable = true)]
        public DateTime? LastLoginTime { get; set; }
    }
}