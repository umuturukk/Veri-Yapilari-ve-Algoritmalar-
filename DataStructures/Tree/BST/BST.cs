using DataStructures.Tree.BinaryTree;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
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



    }
}
