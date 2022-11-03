namespace Interface
{
    public interface IMyActionResult
    {
        //返回码
        public string Code { get; set; }
        //返回消息
        public string Msg { get; set; }
        //返回数据
        public object Data { get; set; }
    }
}