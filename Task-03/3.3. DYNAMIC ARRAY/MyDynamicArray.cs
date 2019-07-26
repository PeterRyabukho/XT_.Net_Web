using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _3._3._DYNAMIC_ARRAY
{
    class MyDynamicArray<T> : IEnumerable<T>, IEnumerable
    {
        public T[] Array { get; private set; }

        public int Length { get; private set; } = 0;

        private int capacity = 8;
        public int Capacity
        {
            get => capacity;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Exception! Capacity cannot be lower then 0!");
                }
                if (capacity > value)
                {
                    var newArr = new T[value];
                    for (int i = 0; i < value; i++)
                    {
                        newArr[i] = Array[i];
                    }
                    Array = newArr;
                    Length = value;

                }
                capacity = value;
            }
        }

        public MyDynamicArray() : this(capacity: 8)
        {
            Array = new T[Capacity];
        }

        public MyDynamicArray(int capacity)
        {
            Capacity = capacity;
            Array = new T[capacity];
        }

        public MyDynamicArray(IEnumerable<T> someCollection)
        {
            int newCpacity = Capacity + GetLengthOfSomeCollection(someCollection);

            Array = new T[newCpacity];

            AddElementsInArray(someCollection, 0);
        }

        private void AddElementsInArray(IEnumerable<T> someCollection, int i)
        {
            foreach (var item in someCollection)
            {
                Array[i] = item;
                i++;
            }
        }

        private static int GetLengthOfSomeCollection(IEnumerable<T> someCollection)
        {
            int elements = 0;
            foreach (var item in someCollection)
            {
                elements++;
            }

            return elements;
        }

        public T this[int index]
        {
            get
            {
                if (IsOutOfRange(index))
                    throw new ArgumentOutOfRangeException("Exception! Index can not be negative or be longer than the length of the array!"); 
                else return Array[index]; 
            }
            set
            {
                if (IsOutOfRange(index))
                    throw new ArgumentOutOfRangeException("Exception! Index can not be negative or be longer than the length of the array!");
                else Array[index] = value; 
            }
        }

        private bool IsOutOfRange(int index)
        {
            if (index < 0 || index >= Length) return true;
            return false;
        }
        public void Add(T item)
        {
            if (Length >= Capacity)
                Array = new T[Capacity * 2];

            Array[Length] = item;
            Length++;
        }

        public void AddRange(IEnumerable<T> someCollection)
        {
            int collectionLength = GetLengthOfSomeCollection(someCollection);
            if (Length + collectionLength > Capacity)
            {
                int newCapacity = (Capacity + collectionLength) * 2;

                T[] arr = Array;
                Array = new T[newCapacity];
                Capacity = newCapacity;
                arr.CopyTo(Array, 0);
            }

            AddElementsInArray(someCollection, Length);
            Length += collectionLength;
        }

        public bool Insert(T item, int index)
        {
            if (IsOutOfRange(index))
            {
                throw new ArgumentOutOfRangeException("Exception! Index can not be negative or be longer than the length of the array!");
            }
            if (Length >= Capacity)
                Array = new T[Capacity * 2];
            Length++;
            for (int i = Length - 1; i > index; i--)
            {
                Array[i] = Array[i - 1];
            }
            Array[index] = item;
            return true;
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < Length; i++)
            {
                if (Array[i].Equals(item))
                {
                    Array[i] = Array[Capacity-1];
                    for (int j = i; j < Length - 1; j++)
                    {
                        Array[j] = Array[j + 1];

                    }
                    Array[Length - 1] = default;
                    Length--;

                    return true;
                }  
            }
            return false;
        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in Array)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
