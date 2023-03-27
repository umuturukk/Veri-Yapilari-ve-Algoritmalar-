﻿using DataStructures.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Heap
{
    public class BinaryHeap<T> : IEnumerable<T> where T : IComparable
    {
        public T[] Array { get; private set; }
        private int position; // position prop'ı tanımlandı.
        public int Count { get; private set; } // Count prop'ı tanımlandı.

        private readonly IComparer<T> comparer;
        private readonly bool isMax;

        public BinaryHeap() // Default constructor oluşturuldu.
        {
            Count = 0; // Başlangıçta eleman sayısı 0.
            Array = new T[128]; // 128 elemanlı bir dizi oluşturuyoruz.
            position = 0; // Başlangıçta pozisyon 0.
        }
        public BinaryHeap(int _size) // Ctor aşırı yükleme(dizi boyutunu dışardan girme.)
        {
            Count = 0;
            Array = new T[_size];
            position = 0;
        }
        public BinaryHeap(IEnumerable<T> collection)
        {
            Count = 0;
            Array = new T[collection.ToArray().Length];
            position = 0;
            foreach (var item in collection)
            {
                Add(item);
            }
        }
        public BinaryHeap(SortDirection sortDirection = SortDirection.Ascending)
            : this(sortDirection, null, null)
        {

        }
        public BinaryHeap(SortDirection sortDirection, IEnumerable<T> initial)     
            : this(sortDirection, initial, null)
        {

        }
        public BinaryHeap(SortDirection sortDirection, IComparer<T> comparer)
            : this(sortDirection, null, comparer)
        {

        }
        public BinaryHeap(SortDirection sortDirection, IEnumerable<T> initial, IComparer<T> comparer)
        {
            position = 0;
            Count = 0;
            this.isMax = sortDirection == SortDirection.Descending;
            if (comparer != null)            
                this.comparer = new CustomComparer<T>(sortDirection, comparer);         
            else      
                this.comparer = new CustomComparer<T>(sortDirection, Comparer<T>.Default);
            if (initial != null)
            {
                var items = initial as T[] ?? initial.ToArray();
                Array = new T[items.Count()];
                foreach (var item in items)
                {
                    Add(item);
                }
            }
            else
            {
                Array = new T[128]; 
            }
        }

        private int GetLeftChildIndex(int i) => 2 * i + 1;
        private int GetRightChildIndex(int i) => 2 * i + 2;
        private int GetParentIndex(int i) => (i - 1) / 2;

        private bool HasLeftChild(int i) => GetLeftChildIndex(i) < position;
        private bool HasRightChild(int i) => GetLeftChildIndex(i) < position;
        private bool IsRoot(int i) => i == 0;

        private T GetLeftChild(int i) => Array[GetLeftChildIndex(i)];
        private T GetRightChild(int i) => Array[GetRightChildIndex(i)];
        private T GetParent(int i) => Array[GetParentIndex(i)];

        public bool IsEmpty() => position == 0;
        public T Peek()
        {
            if (IsEmpty())
            {
                throw new Exception("Empty Heap!");
            }
            return Array[0];
        }

        public void Swap(int first, int second)
        {
            var temp = Array[first];
            Array[first] = Array[second];
            Array[second] = temp;
        }
        public void Add(T value)
        {
            if (position == Array.Length)
                throw new IndexOutOfRangeException("Overflow!");
            Array[position] = value;
            position++;
            Count++;
            HeapifyUp();
        }
        public T DeleteMinMax()
        {
            if (position == 0)
                throw new IndexOutOfRangeException("Underflow!");
            var temp = Array[0];
            Array[0] = Array[position - 1];
            position--;
            Count--;
            HeapifyDown();
            return temp;
        }

        protected void HeapifyUp() { }
        protected void HeapifyDown() { }

        public IEnumerator<T> GetEnumerator()
        {
            return Array.Take(position).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}