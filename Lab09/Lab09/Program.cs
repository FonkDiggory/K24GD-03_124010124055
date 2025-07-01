using System.Dynamic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using Firebase.Database;
using Firebase.Database.Query;

namespace Lab09
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var taskLoadWeb = GetWebContent("https:gamevui.vn");
            string serverConfig = await client.GetStringAsync(url);
            List<Players> allPlayers;
            try
            {
                string json = await ClientCertificateOption.GetStringAsync("")
            }

        }
    }
}
