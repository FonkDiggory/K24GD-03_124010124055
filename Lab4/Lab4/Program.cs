using System.Collections;
using static Lab4.Program;
using System.Collections.Generic;

namespace Lab4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                {
                    Console.Write("\nNhap ma mat hang: ");
                    int maMH = int.Parse(Console.ReadLine());

                    Console.Write("Nhap ten mat hang: ");
                    string tenMH = Console.ReadLine();

                    Console.Write("Nhap so luong: ");
                    int soLuong = int.Parse(Console.ReadLine());

                    Console.Write("Nhap don gia: ");
                    double donGia = double.Parse(Console.ReadLine());

                    ThemMatHang(new MatHang(maMH, tenMH, soLuong, donGia));

                    Console.Write("Tiep tuc nhap? \n(y/n): ");
                    if (Console.ReadLine().ToLower() != "y") break;
                }
            }
                XuatDanhSach();

                Console.Write("\nNhap ma mat hang can tim: ");
                int maTim = int.Parse(Console.ReadLine());

                if (TimMatHang(maTim, out MatHang matHang))
                {
                    Console.WriteLine("Mat hang tim thay: " + matHang);
                    Console.Write("Ban co muon xoa mat hang khong? (y/n): ");
                    if (Console.ReadLine().ToLower() == "y")
                    {
                        XoaMatHang(maTim);
                        Console.WriteLine("\nDanh sach sau khi xoa:");
                        XuatDanhSach();
                    }
                }
                else
                {
                    Console.WriteLine("Khong tim thay mat hang");
                }
        }

    class MatHang
    {
        public int MaMH { get; set; }
        public string TenMH { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }

        public MatHang(int maMH, string tenMH, int soLuong, double donGia)
        {
            MaMH = maMH;
            TenMH = tenMH;
            SoLuong = soLuong;
            DonGia = donGia;
        }

        public double ThanhTien()
        {
            return SoLuong * DonGia;
        }

        public override string ToString()
        {
            return $"Ma: {MaMH}, Ten: {TenMH}, So luong: {SoLuong}, Don gia: {DonGia}, Thanh tien: {ThanhTien()}";
        }
    }

        static List<MatHang> danhSachMatHang = new List<MatHang>();

        static void ThemMatHang(MatHang mh)
        {
            danhSachMatHang.Add(mh);
        }

        static bool TimMatHang(int maMH, out MatHang matHang)
        {
            matHang = danhSachMatHang.Find(mh => mh.MaMH == maMH);
            return matHang != null;
        }

        static void XuatDanhSach()
        {
            Console.WriteLine("\nDanh sach mat hang:");
            foreach (var mh in danhSachMatHang)
            {
                Console.WriteLine(mh);
            }
        }

        static void XoaMatHang(int maMH)
        {
            danhSachMatHang.RemoveAll(mh => mh.MaMH == maMH);
        }
    }
}

    //    Console.WriteLine("=== List<Student> ===");
    //    List<Student> students = new List<Student>
    //    {
    //        new Student(1, "Alice"),
    //        new Student(2, "Bob"),
    //        new Student(3, "Charlie")
    //    };
    //    students.Add(new Student(4, "David"));
    //}
    //public class Student
    //{
    //    public string Name { get; set; }
    //    public int ID { get; set; }

//    public Student(int id, string name)
//    {
//        Name = name;
//        ID = id;
//    }
//    public override string ToString()
//    {
//        return $"Student Name={Name},ID = {ID}";
//    }
//}

//static void QueueExample()
//{
//    Queue<string> tasks = new Queue<string>();
//    tasks.Enqueue("Download file");
//    tasks.Enqueue("scan file");
//    Console.WriteLine("Next task: " + tasks.Peek);
//    Console.WriteLine("Processing: " + tasks.Dequeue());
//    foreach (var task in tasks)
//    {
//        Console.WriteLine(task);
//    }
//}

//static void ListExample()
//{
//    List<string> fruits = new List<string>();
//    fruits.Add("Apple");
//    fruits.Add("Banana");
//    fruits.Add("Cherry");
//    fruits.Insert(1, "Blueberry");
//    Console.WriteLine("Contains Banana? " + fruits.Contains("banana"));
//}
//static void StackExample()
//{
//    Stack<string> books = new Stack<string>();
//    books.Push("C# Programming");
//    books.Push("Data Structures");
//    Console.WriteLine("Top book: " + books.Peek());
//    Console.WriteLine("Removing: " + books.Pop());
//    foreach (var book in books)
//    {
//        Console.WriteLine(book);
//    }
//}
//static void SortedExample()
//{
//    SortedList<int, string> students = new SortedList<int, string>();
//    students.Add(102, "Lan");
//    students.Add(101, "Nam");
//    students.Add(105, "Hoa");
//    students[102] = "Linh";

//    if (students.ContainsKey(105))
//    {
//        Console.WriteLine("Student ID 105: " + students[105]);
//        students.Remove(101);
//    }
//    foreach (var s in students)
//        Console.WriteLine($"{s.Key}, {s.Value}");
//}




//    struct MatHang
//        {
//            public int MaMH;
//            public string tenMH;
//            public int SoLuong;
//            public float DonGia;
//            public MatHang(int maMH, string tenMH, int soLuong, float donGia)
//            {
//                this.MaMH = maMH;
//                this.tenMH = tenMH;
//                this.SoLuong = soLuong;
//                this.DonGia = donGia;
//            }
//            public float ThanhTien()
//            {
//                return SoLuong * DonGia;
//            }

//        static void ThemMatHang(Hashtable danhsach, MatHang m)
//        {
//            danhsach.Add(m.MaMH, m);
//        }
//        static bool TimMatHang(Hashtable danhsach, int maMH, out MatHang m)
//        {
//            if (danhsach.ContainsKey(maMH))
//            {
//                m = (MatHang)danhsach[maMH];
//                return true;
//            }
//            else
//            {
//                m = new MatHang();
//                return false;
//            }
//        }
//    }
//}




//static void vd1_lab4()
//{
//    SortedList mySL = new SortedList();
//    mySL.Add("Third", "!");
//    mySL.Add("Second", "World");
//    mySL.Add("First", "Hello");
//    Console.WriteLine("mySl");
//    Console.WriteLine("Count: {0}", mySL.Count);
//    Console.WriteLine("capcity: {0}", mySL.Capacity);
//    Console.WriteLine("Keys:");
//    foreach (string key in mySL.Keys)
//    {
//        Console.WriteLine(key);
//    }
//}


