using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puti_v_grafe
{
    class Graf
    {
        int num = 0;
        int[,] scalesMatrix;

        public Graf()
        {
        }

        public void shortByFord(int startVertex, int endVertex)
        {
            startVertex--;
            endVertex--;
            const int INF = 1000000000;
            int[] vertexScales = new int[num];
            List<int> changedScaleNumber = new List<int>();
            Console.WriteLine("Метод Форда-Беллмана");
            //Шаг 1
            for (int i = 0; i < num; i++)
            {
                if (i == startVertex)
                    vertexScales[i] = 0;
                else
                    vertexScales[i] = INF;
            }
            Console.Write("шаг 1: ");
            for (int i = 0; i < num; i++)
            {
                if (vertexScales[i] != INF)
                    Console.Write(vertexScales[i] + " ");
                else
                    Console.Write("~ ");
            }
            Console.WriteLine();

            //Шаг 2
            for (int i = 0; i < num; i++)
            {
                if (scalesMatrix[startVertex, i] != 0)
                {
                    vertexScales[i] = scalesMatrix[startVertex, i];
                    changedScaleNumber.Add(i);
                }
            }
            Console.Write("шаг 2: ");
            for (int i = 0; i < num; i++)
            {
                if (vertexScales[i] != INF)
                    Console.Write(vertexScales[i] + " ");
                else
                    Console.Write("~ ");
            }
            Console.WriteLine();
  

            //Последующие шаги
            int counter = 3;
            while (changedScaleNumber.Count > 0)
            {
                List<int> newChanged = new List<int>();
                for (int i = 0; i < changedScaleNumber.Count; i++)
                {
                    for (int j = 0; j < num; j++)
                    {
                        if (scalesMatrix[changedScaleNumber[i], j] != 0)
                        {
                            if (vertexScales[j] > vertexScales[changedScaleNumber[i]] + scalesMatrix[changedScaleNumber[i], j]) {
                                vertexScales[j] = vertexScales[changedScaleNumber[i]] + scalesMatrix[changedScaleNumber[i], j];
                                newChanged.Add(j);
                            }
                        }
                    }
                }
                Console.Write(String.Format("шаг {0}: ", counter));
                for (int i = 0; i < num; i++)
                {
                    if (vertexScales[i] != INF)
                        Console.Write(vertexScales[i] + " ");
                    else
                        Console.Write("~ ");
                }
                Console.WriteLine();
                counter++;
                changedScaleNumber = newChanged;
            }
            Console.WriteLine(String.Format("Длина наикратчайшего пути от S-{0} до S-{1} равна {2}", startVertex+1, endVertex+1, vertexScales[endVertex]));

        }

        public void Load()
        {
            num = Convert.ToInt32(Console.ReadLine());
            scalesMatrix = new int[num, num];
            for (int i = 0; i < num; i++)
            {
                string str_line = Console.ReadLine();
                string[] strArray = str_line.Split(' ');
                for (int j = 0; j < num; j++)
                {
                    scalesMatrix[i, j] = Convert.ToInt32(strArray[j]);
                }
            }
        }

        public void Info()
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Дана матрица весов:");
            for (int i = 0; i < num; i++)
            {
                for (int j = 0; j < num; j++)
                {
                    Console.Write(scalesMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("----------------------------------\n");
        }
    }
}
