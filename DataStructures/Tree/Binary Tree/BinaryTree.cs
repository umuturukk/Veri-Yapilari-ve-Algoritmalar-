using DataStructures.Tree.BinaryTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
