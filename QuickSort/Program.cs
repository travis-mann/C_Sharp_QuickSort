////////////////////////////////////////////////////////////////////////////////////////////////////////
//FileName    : QuickSort.cs
//Author      : Travis Mann
//Date        : 06/26/2023
//Description : Quicksort sorting algorithm implementation
////////////////////////////////////////////////////////////////////////////////////////////////////////



namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            /// <summary>Run quick sort with an example.</summary>

            // example array
            int[] array = new int[] { 3, 8, 5, 4, 1, 6, 7, 2 };

            // print array before sorting
            Console.Write("Unsorted array: ");
            foreach (int arrayElement in array)
            {
                Console.Write(arrayElement + " ");
            }

            // sort array
            QuickSort(array, 0, array.Length);

            // print sorted array
            Console.Write("\nSorted array: ");
            foreach (int arrayElement in array)
            {
                Console.Write(arrayElement + " ");
            }
        }

        private static void QuickSort(int[] array, int leftIndex, int rightIndex)
        {
            /// <summary> QuickSort algoritm implementation</summary>
            /// <param name="array">Array to sort</param>
            /// <returns>
            /// <param name="sortedArray">Sorted input array</param>
            /// </returns>

            // base case: 1 element
            if (rightIndex - leftIndex == 0)
            {
                return;
            }

            // partition the array around a pivot
            int pivotIndex = Partition(array, leftIndex, rightIndex);

            // recursively sort subarrays around pivot
            QuickSort(array, leftIndex, pivotIndex);
            QuickSort(array, pivotIndex + 1, rightIndex);
        }

        private static int Partition(int[] array, int leftIndex, int rightIndex)
        {
            // get pivot
            int pivot = ChoosePivot(array, leftIndex, rightIndex);

            // track boundary between elements less than and greter than the pivot
            int pivotBoundaryIndex = leftIndex + 1;

            // iterate over all elements to action
            for (int actionedBoundaryIndex = leftIndex + 1;  // start w/ first element after the left most index
                actionedBoundaryIndex < rightIndex;          // iterate up to the right index
                actionedBoundaryIndex++)                     // inc by 1 to search all elements
            {
                // check if element is larger than the pivot
                if (array[actionedBoundaryIndex] < pivot)
                {
                    // swap current element with element at pivot boundary
                    int currentElement = array[actionedBoundaryIndex];
                    array[actionedBoundaryIndex] = array[pivotBoundaryIndex];
                    array[pivotBoundaryIndex] = currentElement;

                    // increment pivot boundary over swapped element
                    pivotBoundaryIndex++;
                }
            }

            // swap the pivot with last element lower than it
            array[leftIndex] = array[pivotBoundaryIndex - 1];
            array[pivotBoundaryIndex - 1] = pivot;

            // return pivot index
            return pivotBoundaryIndex - 1;
        }

        private static int ChoosePivot(int[] array, int leftIndex, int rightIndex)
        {
            /// <summary>Choose a pivot and swap it to the leftIndex</summary>
            /// <param name="array">Array to sort</param>
            /// <returns>
            /// <param name="pivotIndex">index of pivot to partition around</param>
            /// </returns> 

            // choose 1st element as the pivot
            return array[leftIndex];
        }

    }
}
