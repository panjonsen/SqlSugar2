using Interface;

namespace DTOModel.ActionResultDTO
{
    public class MyHttpActionResult : IMyActionResult
    {
        public string Code { get; set; }

        public string Msg { get; set; }

        public object Data { get; set; }

        public object Custom { get; set; }
    }
}