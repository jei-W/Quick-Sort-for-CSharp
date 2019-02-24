using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithm
{
    class QuickSort
    {
        public static void AscendingSort( int[] arg )
        {
            AscendingSort(arg, 0, arg.Length);
        }

        /// <summary>
        /// 퀵정렬, 오름차순 정렬을 한다.
        /// </summary>
        /// <param name="arg">정렬할 배열</param>
        /// <param name="startIndex">정렬을 시작할 범위의 처음 인덱스</param>
        /// <param name="endIndex">정렬을 시작할 범위의 마지막 인덱스</param>
        public static void AscendingSort( int[] arg, int startIndex, int endIndex )
        {
            //정렬은 arg의 크키가 2 이상일 때에만 실행된다
            if( endIndex - startIndex < 1 )
            {
                return;
            }

            //피봇은 구간의 첫번째 인자이다
            int pivotIndex = startIndex;
            int pivot = arg[pivotIndex];

            int leftIndex = startIndex + 1;
            int rightIndex = endIndex;

            //입력된 배열의 특정 구간을 피봇과 비교해 좌우로 나눈다
            do
            {
                if( arg[leftIndex] <= pivot && arg[rightIndex] <= pivot )
                {
                    leftIndex++;
                }
                else if( arg[leftIndex] > pivot && arg[rightIndex] > pivot )
                {
                    rightIndex--;
                }
                else if( arg[leftIndex] > arg[rightIndex] )
                {
                    Swap(ref arg[leftIndex], ref arg[rightIndex]);
                    leftIndex++;
                    rightIndex--;
                }
                else if( arg[leftIndex] < arg[rightIndex] )
                {
                    leftIndex++;
                    rightIndex--;
                }
            } while( leftIndex < rightIndex );

            //피봇을 올바른 위치로 스왑한다
            if( leftIndex == rightIndex )
            {
                if( pivot < arg[leftIndex] )
                {
                    Swap(ref arg[pivotIndex], ref arg[leftIndex - 1]);
                    pivotIndex = leftIndex - 1;
                }
                else
                {
                    Swap(ref arg[pivotIndex], ref arg[leftIndex]);
                    pivotIndex = leftIndex;
                }
            }
            else if( leftIndex > rightIndex )
            {
                Swap(ref arg[pivotIndex], ref arg[rightIndex]);
                pivotIndex = rightIndex;
            }

            // 왼쪽
            AscendingSort(arg, startIndex, pivotIndex - 1);
            
            // 오른쪽
            AscendingSort(arg, pivotIndex + 1, endIndex);
        }

         
        
        static void Swap( ref int a, ref int b )
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
