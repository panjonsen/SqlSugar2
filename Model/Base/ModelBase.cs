using SqlSugar;

namespace Model.Base
{
    public record class ModelBase
    {
        public string LogicId { get; set; }

        public DateTime CreateTime { get; set; }

        [SugarColumn(IsNullable = true)]
        public DateTime? UpdateTime { get; set; }

        public bool DeleteFlag { get; set; }

        public long CreateUserId { get; set; }

        public long UpdateUserId { get; set; }

        public long DeleteUserId { get; set; }
    }
}