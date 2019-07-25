using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _3._4.__DYNAMIC_ARRAY__HARDCORE_MODE_
{
    class MyDynamicArray<T> : IEnumerable<T>, IEnumerable, ICloneable<T>
    {
        public T[] Array { get; set; }

        public int Length { get; private set; } 

        public int Capacity { get; set; }
        //{
        //    get => Array.Length;

        //    set
        //    {
        //        if (value < Length)
        //        {
        //            throw new ArgumentOutOfRangeException("Exception! Capacity cannot be lower then Length of the array!");
        //        }
        //        else
        //        {
        //            var newArr = new T[Capacity];
        //            for (int i = 0; i < Array.Length; i++)
        //            {
        //                newArr[i] = Array[i];
        //            }
        //            Array = newArr;
        //        }
        //    }
        //}

        public int Count { get; set; }

        public MyDynamicArray() : this(capacity: 8)
        {
            Array = new T[Capacity];
            Length = 0;
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

        public T[] ToArray()
        {
            T[] newArr = new T[Length];
            for (int i = 0; i < Length; i++)
            {
                newArr[i] = Array[i];
            }
            return newArr;
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
                return index < 0 ? Array[Capacity + index] : Array[index];
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
                    Array[i] = Array[Capacity - 1];
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

        MyDynamicArray<T> ICloneable<T>.Clone()
        {
            return new MyDynamicArray<T>()
            {
                Array = Array.Clone() as T[]
            };
        }
    }
}

