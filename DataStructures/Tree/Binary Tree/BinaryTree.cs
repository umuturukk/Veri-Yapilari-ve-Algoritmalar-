﻿using DataStructures.Tree.BinaryTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataStructures.Tree.Binary_Tree
{
    public class BinaryTree<T> where T: IComparable // IComparable kontratını kabul eden ikili ağaç sınıfı oluşturduk.
    {
        public List<Node<T>> list { get; private set; }// Node listesi oluşturduk.
        public BinaryTree() // Default constructor.
        {
            list = new List<Node<T>>();
        }

        public List<Node<T>> InOrder(Node<T> root) // InOrder (Left-Data-Right) dolaşma işlemini gerçekleştirecek olan fonksiyon.
        {
            if (!(root == null)) // Root ifadesi null olmadığı sürece dolaş.
            {
                InOrder(root.Left); // Rekürsif bir çağrı yaptık.
                list.Add(root); // Listeye ekleme işlemi.
                InOrder(root.Right);
            }
            return list;
        }
        public List<Node<T>> InOrderNonRecursiveTraversal(Node<T> root) // İteratif yöntemle InOrder
        {
            var list = new List<Node<T>>(); // İçerisinde düğümleri tutacak bir liste tanımı yapıldı.
            var S = new Stack<Node<T>>(); // Stack tanımı yapıldı.
            Node<T> currentNode = root; // Node<T> sınıfından currentNode nesnesi root olarak atandı.
            bool done = false; // done şeklinde boolean bir değişken oluşturuldu.
            while (!done)
            {
                if (currentNode != null) // Eğer üzerinde bulunduğumuz düğüm null değil ise;
                {
                    S.Push(currentNode); // Current node'u stack'e ekle.
                    currentNode = currentNode.Left; // Yeni current node'umuz eski current node'umuzun solunda kalan node oluyor.
                }
                else
                {
                    if (S.Count == 0) // Stack'teki eleman sıfır ise;
                    {
                        done = true; // Döngüyü kır.
                    }
                    else
                    {
                        currentNode = S.Pop(); // Yığından bir eleman çıkar ve o çıkarılan eleman yeni current node olsun.
                        list.Add(currentNode);
                        currentNode = currentNode.Right; // Daha sonra current node'un sağından devam et.  
                    }
                }
            }
            return list;
        }
        public List<Node<T>> PreOrder(Node<T> root) // PreOrder (Data-Left-Right) dolaşma işlemini gerçekleştirecek olan fonksiyon.
        {
            if (!(root == null)) // Root ifadesi null olmadığı sürece dolaşmaya devam et.
            {
                list.Add(root);
                PreOrder(root.Left);
                PreOrder(root.Right);
            }
            return list;
        }
        public List<Node<T>> PostOrder(Node<T> root) // PostOrder (Left-Right-Data) dolaşma işlemini gerçekleştirecek olan fonksiyon.
        {
            if(!(root == null))
            {
                PostOrder(root.Left);
                PostOrder(root.Right);
                list.Add(root);
            }
            return list;
        }
        public void ClearList() => list.Clear();

    }
}
