namespace LAB01
{
        internal class Program
        {
            static void Main(string[] args)
            {
                double a, b, c;
                Console.WriteLine("Nhap so a: ");
                a = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Nhap so b: ");
                b = Convert.ToDouble(Console.ReadLine());
                void Tong(double a, double b)
                {
                    c = a + b;
                    Console.WriteLine("Tong cua {0} va {1} la: {2}", a, b, c);
                }
                void Hieu(double a, double b)
                {
                    c = a - b;
                    Console.WriteLine("Hieu cua {0} va {1} la: {2}", a, b, c);
                }
                void Tich(double a, double b)
                {
                    c = a * b;
                    Console.WriteLine("Tich cua {0} va {1} la: {2}", a, b, c);
                }
                void Thuong(double a, double b)
                {
                    if (b != 0)
                    {
                        c = a / b;
                        Console.WriteLine("Thuong cua {0} va {1} la: {2}", a, b, c);
                    }
                    else
                    {
                        Console.WriteLine("Khong the chia cho 0");
                    }
                }
                int S;
                Console.WriteLine("Chon phep toan: \n1. Tong\n2. Hieu\n3. Tich\n4. Thuong");
                S = Convert.ToInt32(Console.ReadLine());
                switch (S)
                {
                    case 1:
                        Tong(a, b);
                        break;
                    case 2:
                        Hieu(a, b);
                        break;
                    case 3:
                        Tich(a, b);
                        break;
                    case 4:
                        Thuong(a, b);
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le");
                        break;
                }
            }
        }
    }
