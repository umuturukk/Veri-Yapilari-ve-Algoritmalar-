﻿using System;
using System.Collections.Generic;
using System.Collections;
using DataStructures.Tree.BST;
using DataStructures.Tree.Binary_Tree;
using DataStructures.Tree.BinaryTree;

namespace Apps
{
    class Program
    {
        static void Main(string[] args)
        {
            var heap = new DataStructures.Heap.BinaryHeap<int>(DataStructures.Shared.SortDirection.Ascending, new int[] { 54, 45, 36, 27, 29, 18, 21, 99 });

            foreach (var item in heap)
            {
                Console.Write(item + " ");
            }


            Console.ReadKey();
        }

        private static void BSTCalisma()
        {
            var BST = new DataStructures.Tree.BST.BST<int>(new int[] { 60, 40, 70, 20, 45, 65, 85 });

            var bt = new BinaryTree<int>();

            bt.InOrder(BST.Root)
                .ForEach(node => Console.Write($"{node,-3} "));

            BST.Remove(BST.Root, 20);
            BST.Remove(BST.Root, 40);
            BST.Remove(BST.Root, 60);
            Console.WriteLine();

            bt.ClearList();
            bt.InOrder(BST.Root)
                .ForEach(node => Console.Write($"{node,-3} "));

            /*
            Console.WriteLine("Level Order Traversal\n");
            bt.LevelOrderNonRecursiveTraversal(BST.Root).
                ForEach(node => Console.Write($"{node,-3} "));
            */
            /*
            Console.WriteLine("\nMinimum Maksimum Elemanlar\n");
            Console.WriteLine($"Minimum value: {BST.FindMin(BST.Root)}");
            Console.WriteLine($"Maximum value: {BST.FindMax(BST.Root)}");
            
            var keyNode = BST.Find(BST.Root, 100);
            Console.WriteLine($"{keyNode.Value} - Left: {keyNode.Left.Value} - Right: {keyNode.Right.Value}");
            */
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