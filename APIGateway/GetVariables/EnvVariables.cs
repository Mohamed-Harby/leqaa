using Newtonsoft.Json;

namespace APIGateway.GetVariables
{
    public class EnvVariables
    {

        public string DownstreamHost { get; set; } = "";
        public string BaseUrl { get; set; } = "";
        public string DownstreamPort { get; set; } = "";
        public string DOWNSTREAM_SCHEME { get; set; } = "";
        }

    }
