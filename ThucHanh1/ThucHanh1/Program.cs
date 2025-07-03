using System;
using System.Collections.Generic;
using Firebase.Database;
using Firebase.Database.Query;
using System.Threading.Tasks;
using System.Data;
using Newtonsoft.Json;
using System.Net.Http;

namespace ThucHanh1
{
    internal class Program
    {
        static FirebaseClient firebase = new FirebaseClient("https://fir-ec8e9-default-rtdb.firebaseio.com/");
        static List<Player> players;
        public static async Task Main(string[] args)
        {
            string url = "https://raw.githubusercontent.com/NTH-VTC/OnlineDemoC-/refs/heads/main/simple_players.json";
            HttpClient client = new HttpClient();
            string json = await client.GetStringAsync(url);
            players = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Player>>(json);
            //List<Players> players = new List<Players>();
            while (true)
            {
                Console.WriteLine("\n---MENU---");
                Console.WriteLine("1. Thuc hien bai 1");
                Console.WriteLine("2. Thuc hien bai 2");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "1": await Bai1(); break;
                    case "2": await Bai2(); break;
                    case "0": return;
                    default: Console.WriteLine("Lua chon khong hop le!"); break;
                }
            }
        }


        public static async Task Bai1()
        {
            var richPlayers = players
                    .Where(p => p.Gold > 1000 && p.Coins > 100)
                    .OrderByDescending(p => p.Gold)
                    .Select(p => new { p.Name, p.Gold, p.Coins })
                    .ToList();

            foreach (var p in richPlayers)
                Console.WriteLine($"{p.Name} - Gold: {p.Gold}, Coins: {p.Coins}");
            await firebase.Child("quiz_bai1_richPlayers").PutAsync(richPlayers);

        }
        public static async Task Bai2()
        {
            DateTime now = new DateTime(2025, 06, 30, 0, 0, 0);
            var totalVips = players
                    .Where(p => p.IsActive && p.VipLevel > 0)
                    .Select(p => new { p.Name, p.VipLevel})
                    .ToList();

            Console.WriteLine($"Total vip player: {totalVips.Count}");

            var activePlayers = players
                    .Where(p => p.IsActive && p.VipLevel > 0 && (now - p.LastLogin).TotalDays <= 2)
                    .Select(p => new {p.Name, p.VipLevel, p.Region })
                    .ToList();
                
            foreach (var p in activePlayers)
                Console.WriteLine($"{p.Name} - VIP Level: {p.VipLevel}, Region: {p.Region}");
            await firebase.Child("quiz_bai2_activePlayers").PutAsync(activePlayers);

        }
    }

    public class Player
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int Gold { get; set; }
        public int Coins { get; set; }
        public bool IsActive { get; set; }
        public int VipLevel { get; set; }
        public string Region { get; set; }
        public DateTime LastLogin { get; set; }

    }
}
    

