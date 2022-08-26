using Newtonsoft.Json;

namespace Dojo.Bakery.BuildingBlocks.WebCommons.Models
{
    public class Response
    {
        public object Data { get; set; }
        public string Message { get; set; }
        public ResponseType Type { get; set; }

        public enum ResponseType
        {
            Success = 1,
            Error = 2
        }

        public Response() { }
        public Response(ResponseType type, string msg, object data)
        {
            Type = type;
            Message = msg;
            Data = data;
        }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
