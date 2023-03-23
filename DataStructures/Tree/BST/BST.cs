using DataStructures.Tree.BinaryTree;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataStructures.Tree.BST
{
    // IEnumerable kontratını ve T(generic ifade) IComparable kontratını kabul eden sınıf tasarımı.
    public class BST<T> : IEnumerable<T>
        where T: IComparable  // Düğümleri karşılaştırma imkanı veriyor.  
    {
        public Node<T> Root { get; set; } // Kök düğüm oluşturma işlemi.
        public BST()
        {

        } // Default constructor
        public BST(IEnumerable<T> collection) // Eğer bize bir collection geliyorsa, foreach ifadesiyle bu collection'un item'larını add metodu ile ağaca eklemiş olacağız. 
        // Bu constructor sayesinde henüz ağacın tanımlanma işlemi esnasında bir sayı dizisi vererek oluşturma işlemini gerçekleştirebiliriz.
        {
            foreach (var item in collection)            
                Add(item);       
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            return new BSTEnumerator<T>(Root);
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // Ağaca ekleme işlemini gerçekleştireceğimiz fonksiyon.
        public void Add(T value)
        {
            // Verilen değerin null olma durumunun kontrolü.
            if (value == null)
                throw new ArgumentNullException();
            // Node class'ından verdiğimiz değeri içinde taşıyan yeni bir düğüm oluşturma işlemi.
            var newNode = new Node<T>(value);
            // Kök düğümün null olma durumunun kontrolü.
            if (Root == null)      
                Root = newNode;  // Eğer kök düğüm null ise artık kök düğüm yeni düğüme eşit olmuş oluyor.
            // Kök düğüm null değil ise ekleyecek olduğumuz düğümün uygun konumunu bulmamız gerekli.
            else
            {
                var current = Root; // Mevcut durumda kök düğüm üzerindeyiz.
                Node<T> parent; // Parent'a bağlı olarak ilerletme işlemi gerçekleştirmek için parent düğümü oluşturduk.
                // Durma koşulu 
                while (true)
                {
                    parent = current;
                    // Sol alt ağaçtan mı ilerleyeceğiz?
                    if (value.CompareTo(current.Value) < 0) // CompareTo kontratına göre value değeri current value değerinden küçükse -1 döner.
                    // Yani 0'dan küçük ve bu şartı sağlıyor o halde eklemek istediğimiz değer current'ın solundan devam eder.
                    {
                        current = current.Left; // Current'a sol taraftan devam et demiş oluyoruz.
                        if (current == null) // Soldan devam ettiğimizde boş bir ifadeyle karşılaşırsak ekleme işlemini ancak gerçekleştirebiliriz.
                        {
                            parent.Left = newNode;
                            break; // İşlemi bitiriyoruz.
                        }
                    }
                    // Sağ alt ağaçtan mı ilerleyeceğiz?
                    else
                    {
                        current = current.Right; // Current'a sağ taraftan devam et demiş oluyoruz.
                        if (current == null)
                        {
                            parent.Right = newNode;
                            break;
                        }
                    }
                }
            }

            
        }

        // Minimum Elemanı Bulma
        public Node<T> FindMin(Node<T> root) // Geriye Node döndüren ve root düğümünü referans alarak minimum elemanı bulan metod.
        {
            var current = root;
            while (!(current.Left == null)) // current'ın solu null olana kadar devam et.
                current = current.Left; // current'ı her çevrimde current'ın solundaki düğüme eşitle.
            return current; // en son current zaten ağacımızın en küçük elemanı olacaktır.           
        }

        // Maximum Elemanı Bulma
        public Node<T> FindMax(Node<T> root)
        {
            var current = root;
            while (!(current.Right == null))
                current = current.Right;
            return current;
        }

        // Verilen spesifik bir değere özgü bulma işlemi.
        public Node<T> Find(Node<T> root, T key) // Verilen bir parametreye ait düğümün tutmuş olduğu değeri bulan metod.
        {
            var current = root;
            // key, current value'ya eşit olmadığı sürece döngüye devam et.
            while (key.CompareTo(current.Value) != 0) // Generic ifadelerde(T) metot üzerinden karşılaştırma yapılmalıdır.
            {
                if (key.CompareTo(current.Value) < 0) // Anahtar değer karşılaştırma yapılan değerden küçük mü?
                    current = current.Left; // key < current.value ise current artık current'ın sağındaki düğüme eşit olur.
                else
                    current = current.Right;
                if (current == null)
                    // throw new Exception("Could not found!");                          
                    return default(Node<T>);
            }
            return current;
        }

        // Silme İşlemi
        public Node<T> Remove(Node<T> root, T key) // Geriye Node<T> şeklinde generic bir ifade döndüren, referans olarak root düğümünü alan ve key olarak silinecek elemanı alan metod.
        {
            if (root == null) // Eğer root null bir değerse;   
                return root;

            // Rekürsif ilerle
            if (key.CompareTo(root.Value) < 0) // Eğer anahtar değeri ilgili current değerinden küçükse           
                root.Left = Remove(root.Left, key);
            
            else if(key.CompareTo(root.Value) > 0)           
                root.Right = Remove(root.Right, key);
            
            else
            {
                // Silme işlevini uygulayabiliriz. Çünkü küçüklük büyüklük durumunu üstteki if elif yapılarında ele almıştık.
                // Tek çocuklu veya çocuksuz ise
                if (root.Left == null)
                    return root.Right;
                else if (root.Right == null)                
                    return root.Left;

                // İki çocuk var ise
                root.Value = FindMin(root.Right).Value;
                root.Right = Remove(root.Right, root.Value);               
            }
            return root;

        }


    }
}
