using DataStructures.LinkedList.SinglyLinkedList;
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


            Console.ReadKey();
        }


        private static void SinglyLinkedListApp02()
        {
            // Language Integrated Query - LINQ
            var rnd = new Random();
            var initial = Enumerable.Range(1, 10).OrderBy(x => rnd.Next()).ToList();
            var linkedlist = new SinglyLinkedList<int>(initial);

            var q = from item in linkedlist
                    where item % 2 == 1
                    select item;

            foreach (var item in q)
            {
                Console.WriteLine(item);
            }

            linkedlist.Where(x => x > 5).ToList().ForEach(x => Console.Write(x + " "));
        }
        private static void SinglyLinkedListApp01()
        {
            var linkedlist = new SinglyLinkedList<int>();
            linkedlist.AddFirst(1);
            linkedlist.AddFirst(2);
            linkedlist.AddFirst(3);
            // 3 2 1   O(1)

            linkedlist.AddLast(4);
            linkedlist.AddLast(5);
            // 3 2 1 4 5   O(n)

            linkedlist.AddAfter(linkedlist.Head.Next, 32);
            linkedlist.AddAfter(linkedlist.Head.Next.Next, 33);
            // 3 2 32 33 1 4 5   O(n)

            foreach (var item in linkedlist)
            {
                Console.WriteLine(item);
            }
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
            var arrChar = new char[] { 'b', 't', 'k' };
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