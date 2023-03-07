using System;
using System.Collections.Generic;
using System.Collections;
using System.Net.WebSockets;

namespace Apps
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Esinimi çok seviyorum.");

            Console.ReadKey();
        }


       
        private static void GenericDiziIslemleri()
        {
            var arr = new DataStructures.Array.Array<int>();
            for (int i = 0; i < 8; i++)
            {
                arr.Add(i + 1);
                Console.WriteLine($"{i + 1} has been added to array.");
                Console.WriteLine($"{arr.Count} / {arr.Capacity}");
            }
            Console.WriteLine("*****************");
            for (int i = arr.Count; i >= 1; i--)
            {
                Console.WriteLine($"{arr.Remove()} has been removed from the array.");
                Console.WriteLine($"{arr.Count} / {arr.Capacity}");
            }
            Console.WriteLine("*****************");
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }
        private static void İlkCalisma()
        {
            // Array (Sabit boyutlu olduğundan ekleme çıkarma gibi işlemler yapamıyoruz.)
            var arrChar = new char[] { 'a', 'b', 'c' };
            Console.WriteLine(arrChar.Length);

            // ArrayList - Type-safe yok 
            // 10-> boxing -> object (boxing)
            // b -> boxing -> object (boxing)
            // object -> int (unboxing) 
            // Kutulama ve kutudan çıkarma işlemleri performans kaybına neden olurlar.
            var arrObj = new ArrayList();
            arrObj.Add(10);
            arrObj.Add('b');
            Console.WriteLine(arrObj.Count);

            // List<T> (Tip güvenliği sağladığından ötürü farklı türde verileri saklayamazsınız.)
            var arrInt = new List<int>() { 1, 2, 3 };
            Console.WriteLine(arrInt.Count);
            // arrInt.Add("umut"); // Bu işlemin hata vermesinin sebebi dizimizin integer türde verileri tutmak için tanımlanmış olmasıdır.
            foreach (var item in arrInt)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}