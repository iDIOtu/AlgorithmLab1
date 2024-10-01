using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLab1_console_.Algorithms
{
    internal class CycleSort : Algorithm
    {
        public override void ExecuteAlgorithm(int[] arr)
        {
            // подсчет количества записей в память
            int writes = 0;

            // проходим по элементам массива и 
            // помещаем их на правильные места
            for (int cycle_start = 0; cycle_start <= arr.Length - 2; cycle_start++)
            {
                // инициализируем элемент как начальную точку
                int item = arr[cycle_start];

                // Находим позицию, куда мы поместим элемент. 
                // Мы фактически считаем все меньшие элементы 
                // справа от элемента.
                int pos = cycle_start;
                for (int i = cycle_start + 1; i < arr.Length; i++)
                    if (arr[i] < item)
                        pos++;

                // Если элемент уже на правильной позиции
                if (pos == cycle_start)
                    continue;

                // игнорируем все дубликаты
                while (item == arr[pos])
                    pos += 1;

                // помещаем элемент на его правильную позицию
                if (pos != cycle_start)
                {
                    int temp = item;
                    item = arr[pos];
                    arr[pos] = temp;
                    writes++;
                }

                // Поворачиваем оставшуюся часть цикла
                while (pos != cycle_start)
                {
                    pos = cycle_start;

                    // Находим позицию, куда мы поместим элемент
                    for (int i = cycle_start + 1; i < arr.Length; i++)
                        if (arr[i] < item)
                            pos += 1;

                    // игнорируем все дубликаты
                    while (item == arr[pos])
                        pos += 1;

                    // помещаем элемент на его правильную позицию
                    if (item != arr[pos])
                    {
                        int temp = item;
                        item = arr[pos];
                        arr[pos] = temp;
                        writes++;
                    }
                }
            }
        }
    }
}
