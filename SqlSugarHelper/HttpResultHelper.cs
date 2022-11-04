using DTOModel.ActionResultDTO;
using Newtonsoft.Json;

namespace Helper
{
    public static class HttpResultHelper
    {
        public static Dictionary<string, string> errorCodes = new Dictionary<string, string>();

        static HttpResultHelper()
        {
            errorCodes.Add("000000", "成功");
            errorCodes.Add("000001", "路由异常");
            errorCodes.Add("000003", "参数异常");
        }

        private static string GetCode(string code)
        {
            if (errorCodes.ContainsKey(code))
            {
                return errorCodes[code];
            }
            return null;
        }

        public static string Ok()
        {
            MyHttpActionResult myHttpActionResult = new MyHttpActionResult();
            myHttpActionResult.Code = "000000";
            myHttpActionResult.Msg = GetCode(myHttpActionResult.Code);
            return JsonConvert.SerializeObject(myHttpActionResult);
        }

  
        public static string OkByD(object data)
        {
            MyHttpActionResult myHttpActionResult = new MyHttpActionResult();
            myHttpActionResult.Code = "000000";
            myHttpActionResult.Msg = GetCode(myHttpActionResult.Code);
            myHttpActionResult.Data = data;
            return JsonConvert.SerializeObject(myHttpActionResult);
        }
      
        public static string OkByC(string code)
        {
            MyHttpActionResult myHttpActionResult = new MyHttpActionResult();
            myHttpActionResult.Code = code;
            myHttpActionResult.Msg = GetCode(myHttpActionResult.Code);
            return JsonConvert.SerializeObject(myHttpActionResult);
        }

        public static string OkByCM(string code, string msg)
        {
            MyHttpActionResult myHttpActionResult = new MyHttpActionResult();
            myHttpActionResult.Code = code;
            myHttpActionResult.Msg = msg;
            return JsonConvert.SerializeObject(myHttpActionResult);
        }

        public static string OkByCD(string code, string data)
        {
            MyHttpActionResult myHttpActionResult = new MyHttpActionResult();
            myHttpActionResult.Code = code;
            myHttpActionResult.Msg = GetCode(myHttpActionResult.Code);
            myHttpActionResult.Data = data;
            return JsonConvert.SerializeObject(myHttpActionResult);
        }

        public static string OkByCMD(string code, string msg, string data)
        {
            MyHttpActionResult myHttpActionResult = new MyHttpActionResult();
            myHttpActionResult.Code = code;
            myHttpActionResult.Msg = msg;
            myHttpActionResult.Data = data;

            return JsonConvert.SerializeObject(myHttpActionResult);
        }

        public static string Error()
        {
            MyHttpActionResult myHttpActionResult = new MyHttpActionResult();
            myHttpActionResult.Code = "000003";
            myHttpActionResult.Msg = GetCode(myHttpActionResult.Code);
            return JsonConvert.SerializeObject(myHttpActionResult);
        }

        public static string ErrorByC(string code)
        {
            MyHttpActionResult myHttpActionResult = new MyHttpActionResult();
            myHttpActionResult.Code = code;
            myHttpActionResult.Msg = GetCode(myHttpActionResult.Code);
            return JsonConvert.SerializeObject(myHttpActionResult);
        }

        public static string ErrorByCD(string code, object data)
        {
            MyHttpActionResult myHttpActionResult = new MyHttpActionResult();
            myHttpActionResult.Code = code;
            myHttpActionResult.Msg = GetCode(myHttpActionResult.Code);
            myHttpActionResult.Data = data;
            return JsonConvert.SerializeObject(myHttpActionResult);
        }

        public static string ErrorByCMD(string code, string msg, object data)
        {
            MyHttpActionResult myHttpActionResult = new MyHttpActionResult();
            myHttpActionResult.Code = code;
            myHttpActionResult.Msg = msg;
            myHttpActionResult.Data = data;
            return JsonConvert.SerializeObject(myHttpActionResult);
        }
    }
}