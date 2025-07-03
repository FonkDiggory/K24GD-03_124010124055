using System;
using System.Collections.Generic;
using Firebase.Database;
using Firebase.Database.Query;
using System.Threading.Tasks;
using System.Data;
using Newtonsoft.Json;
using System.Net.Http;

namespace LAB12_FINAL
{
    internal class Program
    {
        static FirebaseClient firebase = new FirebaseClient("https://fir-ec8e9-default-rtdb.firebaseio.com/");
        static List<Player> players;
        public static async Task Main(string[] args)
        {
            string url = "https://raw.githubusercontent.com/NTH-VTC/OnlineDemoC-/refs/heads/main/lab12_players.json";
            HttpClient client = new HttpClient();
            string json = await client.GetStringAsync(url);
            players = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Player>>(json);
            await Bai1();
            await Bai2();
        }


        public static async Task Bai1()
        {
            DateTime now = new DateTime(2025, 06, 30, 0, 0, 0, DateTimeKind.Utc);
            int index = 1;
            var inActivePlayers = players
                    .Where(p => !p.IsActive || (now - p.LastLogin).TotalDays > 5)
                    .Select(p => new {p.Name, p.IsActive, p.LastLogin })
                    .ToList();

            foreach (var p in inActivePlayers)
            {
                
                Console.WriteLine($"#{index} | Name = {p.Name}, IsActive: {p.IsActive}, LastLogin: {p.LastLogin}");
                await firebase.Child("final_exam_bai1_inactive_players").Child(index.ToString).PutAsync(inActivePlayers);
                index++;
            }
            index = 1;
            var LowLvlPlayers = players
                    .Where(p => p.Level < 10)
                    .Select(p => new { p.Name, p.Level, p.Gold })
                    .ToList();
            foreach (var p in LowLvlPlayers)
            {
                Console.WriteLine($"#{index} | {p.Name}, Level: {p.Level}, CurrentGold: {p.Gold}");
                await firebase.Child("final_exam_bai1_low_level_players").Child(index.ToString).PutAsync(LowLvlPlayers);
                index++;
            }
        }
        public static async Task Bai2()
        {
            int index = 1;
            var Top3VipLvl = players
                    .Where(p => p.VipLevel > 0)
                    .OrderByDescending(p => p.VipLevel)
                    .Take(3)
                    .Select(p => new { p.Name, p.VipLevel, p.Gold, Bonus = index == 1 ? 2000 : index == 2 ? 1500 : 1000 })
                    .ToList();

            foreach (var p in Top3VipLvl)
            {
                Console.WriteLine($"#{index} | {p.Name}, VIP Level: {p.VipLevel}, Bonus: {p.Bonus}");
                await firebase.Child("final_exam_bai2_top3_vip_awards").Child(index.ToString).PutAsync(Top3VipLvl);
                index++;
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
}
    



