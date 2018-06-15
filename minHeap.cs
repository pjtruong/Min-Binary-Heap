using System;


public class Program

{

                public static void Main()

                {

                                MinHeap mh = new MinHeap(7);

                                mh.Insert(8);

                                mh.Insert(5);

                                mh.Insert(10);

                                mh.Insert(3);

                                mh.Insert(1);

                                mh.Insert(7);

                                mh.Insert(20);

                                mh.DisplayHeap();

                               

                                mh.Remove(20);

                                mh.DisplayHeap();

               

                }

}

 

public class MinHeap

{

                int[] heapArray;

                int arraySize;

                int heapSize;

                public MinHeap(int size)

                {

                                this.arraySize = size;

                                this.heapSize = 0;

                                this.heapArray = new int[size];

                }

 

                public void Insert(int value)

                {

                                heapArray[heapSize] = value;

                                SiftUp(heapSize);

                                heapSize++;

                }

 

                public int GetMin()

                {

                                if (heapSize == 0)

                                                throw new Exception("heap is empty");

                                return heapArray[0];

                }

 

                public int ExtractMin()

                {

                                int result = heapArray[0];

                                heapArray[0] = heapArray[heapSize - 1];

                                heapSize--;

                                SiftDown(0);

                                return result;

                }

               

                public void Remove(int value){

               

                               

                               

                                for(int i = 0; i < heapSize; i++){

                                                if(heapArray[i] == value){

                                                                heapArray[i] = int.MinValue;

                                                SiftUp(i);

                                                ExtractMin();

                                                }

                                }

               

               

                }

 

                public void SiftUp(int index)

                {

                                if (index != 0)

                                {

                                                while (heapArray[GetParentIndex(index)] > heapArray[index])

                                                {

                                                                Swap(GetParentIndex(index), index);

                                                                index = GetParentIndex(index);

                                                }

                                }

                }

 

                public void SiftDown(int index)

                {

                                int targetIndex;

                                if (GetRightIndex(index) >= heapSize)

                                {

                                                if (GetLeftIndex(index) >= heapSize)

                                                {

                                                                return;

                                                }

                                                else

                                                {

                                                                targetIndex = GetLeftIndex(index);

                                                }

                                }

                                else

                                {

                                                if (heapArray[GetLeftIndex(index)] < heapArray[GetRightIndex(index)])

                                                {

                                                                targetIndex = GetLeftIndex(index);

                                                }

                                                else

                                                {

                                                                targetIndex = GetRightIndex(index);

                                                }

                                }

 

                                if (heapArray[index] > heapArray[targetIndex])

                                {

                                                Swap(targetIndex, index);

                                                index = targetIndex;

                                                SiftDown(index);

                                }

                }

 

                public int GetParentIndex(int index)

                {

                                return (index - 1) / 2;

                }

 

                public int GetLeftIndex(int index)

                {

                                return (index * 2) + 1;

                }

 

                public int GetRightIndex(int index)

                {

                                return (index * 2) + 2;

                }

 

                public void Swap(int i, int j)

                {

                                int temp = heapArray[i];

                                heapArray[i] = heapArray[j];

                                heapArray[j] = temp;

                }

 

                public void DisplayHeap()

                {

                                Console.WriteLine("Elements of the heap:");

                                for(int i = 0; i < heapSize; i++)

                                {

                                                Console.Write(heapArray[i] + " ");

                                }

 

                                Console.WriteLine();

                }

}