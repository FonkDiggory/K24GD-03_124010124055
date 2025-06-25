using System;
using System.Collections.Generic;
using Firebase.Database;
using Firebase.Database.Query;
using System.Threading.Tasks;
using System.Data;

namespace SEMI_FINAL
{
    internal class Program
    {
        static FirebaseClient firebase = new FirebaseClient("https://fir-ec8e9-default-rtdb.firebaseio.com/");
        public static async Task Main(string[] args)
        {
            List<Players> players = new List<Players>();
            while (true)
            {
                Console.WriteLine("\n--- MENU ---");
                Console.WriteLine("1. Nhap 10 nguoi choi vao danh sach");
                Console.WriteLine("2. Hien thi danh sach");
                Console.WriteLine("3. Cap nhat vang/diem");
                Console.WriteLine("4. Xoa nguoi choi");
                Console.WriteLine("5. Them nguoi choi moi");
                Console.WriteLine("6. Hien thi Top 5 nguoi choi co so vang cao nhat");
                Console.WriteLine("7. Hien thi Top 5 nguoi choi co so diem cao nhat");
                Console.WriteLine("0. Thoat");
                Console.Write("Chon: ");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1": await Add10Players(); break;
                    case "2": await HienThiDanhSach(); break;
                    case "3": await CapNhatThongTin(); break;
                    case "4": await XoaPlayer(); break;
                    case "5": await AddPlayer(); break;
                    case "6": await HienThiTopGold(); break;
                    case "7": await HienThiTopScore(); break;
                    case "0": return;
                    default: Console.WriteLine("Lua chon khong hop le"); break;
                }
            }
        }
        public class Players
        {
            public string PlayerID { get; set; }
            public string Name { get; set; }
            public int Gold { get; set; }
            public int Score { get; set; }
        }
        public static async Task HienThiDanhSach()
        {
            var data = await firebase.Child("Players").OnceAsync<Players>();
            Console.WriteLine("\nDanh sach nguoi choi");

            foreach (var item in data)
            {
                var p = item.Object;
                Console.WriteLine($"ID: {p.PlayerID}, Ten: {p.Name}, Vang: {p.Gold}, Điem: {p.Score}");
            }
        }
        public static async Task AddPlayer()
        {
            Players player = new Players();
            Console.Write("Nhap ID nguoi choi: ");
            player.PlayerID = Console.ReadLine();
            Console.Write("Nhap ten nguoi choi: ");
            player.Name = Console.ReadLine();
            Console.Write("Nhap so vang: ");
            player.Gold = int.Parse(Console.ReadLine());
            Console.Write("Nhap so diem: ");
            player.Score = int.Parse(Console.ReadLine());
            await firebase.Child("Players").Child(player.PlayerID).PutAsync(player);
            Console.WriteLine($"Da them nguoi choi: {player.Name}");

        }
        public static async Task Add10Players()
        {
            List<Players> players = new List<Players>
                {
                    new Players { PlayerID = "P001", Name = "Alice", Gold = 100, Score = 110 },
                    new Players { PlayerID = "P002", Name = "Bob", Gold = 200, Score = 220 },
                    new Players { PlayerID = "P003", Name = "Charlie", Gold = 300, Score = 330 },
                    new Players { PlayerID = "P004", Name = "Daisy", Gold = 400, Score = 440 },
                    new Players { PlayerID = "P005", Name = "Ethan", Gold = 500, Score = 550 },
                    new Players { PlayerID = "P006", Name = "Fiona", Gold = 600, Score = 660 },
                    new Players { PlayerID = "P007", Name = "George", Gold = 700, Score = 770 },
                    new Players { PlayerID = "P008", Name = "Hana", Gold = 800, Score = 880 },
                    new Players { PlayerID = "P009", Name = "Ivan", Gold = 900, Score = 990 },
                    new Players { PlayerID = "P010", Name = "Jenny", Gold = 1000, Score = 1100 }
                };

            foreach (var player in players)
            {
                await firebase
                    .Child("Players")
                    .Child(player.PlayerID)
                    .PutAsync(player);
                Console.WriteLine($"Đa themm: {player.Name}");
            }
        }
        static async Task CapNhatThongTin()
        {
            Console.Write("Nhap ID nguoi choi moi can cap nhat: ");
            var id = Console.ReadLine();

            var p = await firebase.Child("Players").Child(id).OnceSingleAsync<Players>();
            if (p == null)
            {
                Console.WriteLine("Khong tim thay nguoi choi");
                return;
            }

            Console.WriteLine("1. Cap nhat vang\n2. Cap nhat diem");
            var opt = Console.ReadLine();

            if (opt == "1")
            {
                Console.Write("Nhap so vang moi: ");
                p.Gold = int.Parse(Console.ReadLine());
            }
            else if (opt == "2")
            {
                Console.Write("Nhap so diem moi: ");
                p.Score = int.Parse(Console.ReadLine());
            }

            await firebase.Child("Players").Child(id).PutAsync(p);
            Console.WriteLine("Da cap nhat");
        }
        static async Task XoaPlayer()
        {
            Console.Write("Nhap ID nguoi choi can xoa: ");
            var id = Console.ReadLine();
            await firebase.Child("Players").Child(id).DeleteAsync();
            Console.WriteLine("Da xoa");
        }
        
        public static async Task HienThiTopGold()
        {
            var data = await firebase
                .Child("Players")
                .OnceAsync<Players>();

            if (data == null || data.Count == 0)
            {
                Console.WriteLine("Khong co du lieu de xu ly");
                return;
            }

            var top5 = data
                .Select(p => p.Object)
                .OrderByDescending(p => p.Gold)
                .Take(5)
                .Select((player, index) => new
                {
                    index = index + 1,
                    id = player.PlayerID,
                    name = player.Name,
                    gold = player.Gold
                }).ToList();
            foreach (var p in top5)
            {
                Console.WriteLine($"#{p.index} | ID: {p.id}, Ten: {p.name}, Vang: {p.gold}");

                await firebase
                    .Child("TopGold")
                    .Child(p.index.ToString())
                    .PutAsync(new
                    {
                        index = p.index,
                        id = p.id,
                        name = p.name,
                        gold = p.gold
                    });
            }
        }

        public static async Task HienThiTopScore()
        {
            var data = await firebase
                .Child("Players")
                .OnceAsync<Players>();

            if (data == null || data.Count == 0)
            {
                Console.WriteLine("Khong co du lieu de xu ly");
                return;
            }

            var top5 = data
                .Select(p => p.Object)
                .OrderByDescending(p => p.Score)
                .Take(5)
                .Select((player, index) => new
                {
                    index = index + 1,
                    id = player.PlayerID,
                    name = player.Name,
                    score = player.Score
                }).ToList();
            foreach (var p in top5)
            {
                Console.WriteLine($"#{p.index} | ID: {p.id}, Ten: {p.name}, Diem: {p.score}");

                await firebase
                    .Child("TopScore")
                    .Child(p.index.ToString())
                    .PutAsync(new
                    {
                        index = p.index,
                        id = p.id,
                        name = p.name,
                        gold = p.score
                    });
            }
        }
    }
}