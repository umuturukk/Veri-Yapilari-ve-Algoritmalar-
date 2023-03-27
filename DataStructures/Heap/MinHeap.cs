namespace DataStructures.Heap
{
    public class MinHeap<T> : BHeap<T>, IEnumerable<T>
        where T : IComparable
    {
        public MinHeap() : base()
        {

        }
        public MinHeap(int _size) : base(_size)
        {

        }
        public MinHeap(IEnumerable<T> collection) : base(collection)
        {

        }

        protected override void HeapifyDown()
        {
            int index = 0;
            while (HasLeftChild(index))
            {
                var smallerIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && GetRightChild(index).CompareTo(GetLeftChild(index)) < 0);               
                    smallerIndex = GetRightChildIndex(index);             
                if (Array[smallerIndex].CompareTo(Array[index]) >= 0)
                    break;     
                Swap(smallerIndex, index);
                index = smallerIndex;
            }
        }

        protected override void HeapifyUp()
        {
            var index = position - 1; // index değerimiz heap'e son eklenen değeri işaret edicek.
            while (!IsRoot(index) && Array[index].CompareTo(GetParent(index)) < 0) // Index değeri kökü işaret etmediği ve Arrayın index değerine karşılık gelen değeri parent'tan küçük olduğu sürece döngü devam etsin.
            {
                var parentIndex = GetParentIndex(index); // Parent'ın index değerini parentIndex adında bir değişkene atadık.
                Swap(parentIndex, index); // parentIndex ile vermiş olduğumuz index değerini takas et.
                index = parentIndex; // index değerini parentIndex'e eşitle. Kaldığımız yerden devam edelim.
            }
        }

    }
}
