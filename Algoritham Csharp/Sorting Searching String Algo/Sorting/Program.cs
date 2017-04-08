using System;
using System.Collections.Generic;

namespace Sorting
{
    class Program
    {
        static int[] array;

        static void Main()
        {
            array = new int[] { 43, 13, 12, 44, 53, 3, 42, 2, 0 };
            Print();
            HeapSort(ref array);
            Print();
        }

        //Algorithms with complexity n * n 
        static void BubbleSort()
        {
            int temp = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        static void CocktailSort()
        {
            bool isSorted = false;
            int temp = 0;
            for (int i = 0; i < array.Length / 2; i++)
            {
                isSorted = true;
                for (int j = i; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        isSorted = false;
                    }
                }

                for (int j = array.Length - 1 - i; j > 0; j--)
                {
                    if (array[j] < array[j - 1])
                    {
                        temp = array[j];
                        array[j] = array[j - 1];
                        array[j - 1] = temp;
                        isSorted = false;
                    }
                }

                if (isSorted)
                {
                    break;
                }
            }
        }

        static void ShellSort()
        {
            for (int gap = array.Length / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < array.Length; i++)
                {
                    int value = array[i];
                    int j;
                    for (j = i; j >= gap && array[j - gap].CompareTo(value) > 0; j -= gap)
                    {
                        array[j] = array[j - gap];
                    }

                    array[j] = value;
                }
            }

        }

        static void SelectionSort()
        {
            int temp = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[i] < array[j])
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        static void InsertionSort()
        {
            for (int i = 1; i < array.Length; i++)
            {
                int index = i;
                int value = array[index];
                while (index > 0 && value <= array[index - 1])
                {
                    array[index] = array[index - 1];
                    index--;
                }

                array[index] = value;
            }
        }

        //Algorithms with complexity n(log(n))
        static int[] QuickSort(int[] array, int left, int right)
        {
            int i = left;
            int j = right;
            int pivot = array[left + (right - left) / 2];

            while (i <= j)
            {
                while (array[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (array[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }

            if (left < j)
            {
                QuickSort(array, left, j);
            }

            if (i < right)
            {
                QuickSort(array, i, right);
            }

            return array;
        }

        static void HeapSort(ref int[] array)
        {
            int heapSize = array.Length;
            for (int p = (heapSize - 1) / 2; p >= 0; p--)
            {
                Heapify(ref array, heapSize, p);
            }

            for (int i = array.Length - 1; i > 0; i--)
            {
                int temp = array[i];
                array[i] = array[0];
                array[0] = temp;

                heapSize--;
                Heapify(ref array, heapSize, 0);
            }
        }

        static void Heapify(ref int[] data, int heapSize, int index)
        {
            int left = (index + 1) * 2 - 1;
            int right = (index + 1) * 2;
            int largest = 0;

            if (left < heapSize && data[left] > data[index])
            {
                largest = left;
            }
            else
            {
                largest = index;
            }

            if (right < heapSize && data[right] > data[largest])
            {
                largest = right;
            }

            if (largest != index)
            {
                int temp = data[index];
                data[index] = data[largest];
                data[largest] = temp;
                Heapify(ref data, heapSize, largest);
            }
        }

        static int[] MergeSort(int[] array)
        {
            if (array.Length == 1)
            {
                return array;
            }

            int middle = array.Length / 2;
            int[] leftArray = new int[middle];
            int[] rigthArray = new int[array.Length - middle];
            for (int i = 0; i < middle; i++)
            {
                leftArray[i] = array[i];
            }

            for (int i = middle, j = 0; i < array.Length; i++, j++)
            {
                rigthArray[j] = array[i];
            }

            leftArray = MergeSort(leftArray);
            rigthArray = MergeSort(rigthArray);
            return Merge(leftArray, rigthArray);
        }

        static int[] Merge(int[] left, int[] right)
        {
            int leftIncrease = 0;
            int rightIncrease = 0;
            int[] array = new int[left.Length + right.Length];
            for (int i = 0; i < array.Length; i++)
            {
                if (rightIncrease == right.Length ||
                    ((leftIncrease < left.Length) &&
                    (left[leftIncrease] <= right[rightIncrease])))
                {
                    array[i] = left[leftIncrease];
                    leftIncrease++;
                }
                else if (leftIncrease == left.Length ||
                    ((rightIncrease < right.Length) &&
                    (left[leftIncrease] >= right[rightIncrease])))
                {
                    array[i] = right[rightIncrease];
                    rightIncrease++;
                }
            }

            return array;
        }

        static void Print()
        {
            Console.WriteLine(string.Join(", ", array));
        }
    }
}