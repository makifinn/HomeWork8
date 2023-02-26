bool IsWork = true;

while (IsWork)

{
    Console.WriteLine();
    Console.WriteLine("Выберите программу:");
    Console.WriteLine("1 - Программа упорядочивает по убыванию элементы каждой строки двумерного массива");
    Console.WriteLine("2 - Программа находит строку с наименьшей суммой элементов");
    Console.WriteLine("3 - Программа находит произведение двух матриц");
    Console.WriteLine("-1 - Для завершения работы");
    Console.Write("Выберите программу: ");

    int ReadInt(string argument)
    {
        Console.Write($"{argument}");
        int number;

        while (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.WriteLine("вы ввели не число");
        }

        return number;
    }

    int[,] CreateRandomTwoDimensionIntArray(int m, int n)
    {
        int[,] result = new int[m, n];
        Random rnd = new Random();

        for (int i = 0; i < result.GetLength(0); i++)
        {
            for (int j = 0; j < result.GetLength(1); j++)
            {
                result[i, j] = rnd.Next(1, 10);
            }
        }
        return result;
    }

    string PrintTwoDimensionIntArray(int[,] array)
    {
        string result = string.Empty;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                result += $"{array[i, j]} ";
            }
            result += Environment.NewLine;
        }

        return result;
    }

    if (int.TryParse(Console.ReadLine(), out int i))
    {
        switch (i)
        {
            case 1:
                {
                    Task_1();

                    void Task_1()
                    {
                        Console.WriteLine();
                        Console.WriteLine("Создайте массив:");
                        int[,] array = CreateRandomTwoDimensionIntArray(ReadInt("Задайте количество строк: "), ReadInt("Задайте количество столбцов: "));
                        Console.WriteLine();
                        Console.WriteLine(PrintTwoDimensionIntArray(array));

                        SortArrayDes(array);

                        void SortArrayDes(int[,] array)
                        {
                            for (int i = 0; i < array.GetLength(0); i++)
                            {
                                for (int j = 0; j < array.GetLength(1) - 1; j++)
                                {
                                    for (int k = j + 1; k < array.GetLength(1); k++)
                                    {
                                        if (array[i, j] < array[i, k])
                                        {
                                            int temp = array[i, j];
                                            array[i, j] = array[i, k];
                                            array[i, k] = temp;
                                        }
                                    }
                                }
                            }

                            Console.WriteLine(PrintTwoDimensionIntArray(array));
                        }
                    }

                    break;
                }
            case 2:
                {
                    Task_2();

                    void Task_2()
                    {
                        Console.WriteLine();
                        int[,] array = CreateRandomTwoDimensionIntArray(ReadInt("Укажите количество строк: "), ReadInt("Укажите количество столбцов: "));
                        Console.WriteLine();
                        Console.WriteLine(PrintTwoDimensionIntArray(array));

                        FindRowWithLowestSum(array);

                        void FindRowWithLowestSum(int[,] array)
                        {
                            int sumOfRow = 0;
                            int checkLowest = 100000000;
                            int lowestSumRowNum = 0;
                            for (int i = 0; i < array.GetLength(0); i++)
                            {
                                for (int j = 0; j < array.GetLength(1); j++)
                                {
                                    sumOfRow += array[i, j];
                                }

                                Console.WriteLine($"сумма элементов в строке: {i + 1} = {sumOfRow}");

                                if (checkLowest > sumOfRow)
                                {
                                    checkLowest = sumOfRow;
                                    lowestSumRowNum = i + 1;
                                }
                                sumOfRow = 0;
                            }

                            Console.WriteLine();
                            Console.WriteLine($"строка с наименьшей суммой элементов: {lowestSumRowNum}");
                        }
                    }

                    break;
                }
            case 3:
                {
                    Task_3();

                    void Task_3()
                    {
                        int[,] matrix1 = CreateRandomTwoDimensionIntArray(ReadInt("Укажите количество строк первой матрицы: "), ReadInt("Укажите количество столбцов первой матрицы: "));
                        int[,] matrix2 = CreateRandomTwoDimensionIntArray(ReadInt("Укажите количество строк второй матрицы: "), ReadInt("Укажите количество столбцов второй матрицы: "));
                        Console.WriteLine();
                        Console.WriteLine("Первая матрица:");
                        Console.WriteLine(PrintTwoDimensionIntArray(matrix1));
                        Console.WriteLine("Вторая матрица:");
                        Console.WriteLine(PrintTwoDimensionIntArray(matrix2));
                        Console.WriteLine("Результирующая матрица:");
                        Console.WriteLine(PrintTwoDimensionIntArray(MultMatrix(matrix1, matrix2)));

                        bool CheckMatrixSize(int[,] firstMatrix, int[,] secondMatrix)
                        {
                            if (firstMatrix.GetLength(1) != secondMatrix.GetLength(0))
                            {
                                Console.WriteLine($"Число столбцов первой матрицы должно ровняться числу строк второй матрицы");
                            }

                            return true;
                        }

                        int[,] MultMatrix(int[,] firstMatrix, int[,] secondMatrix)
                        {
                            CheckMatrixSize(matrix1, matrix2);

                            int[,] multipliedMatrix = new int[firstMatrix.GetLength(0), secondMatrix.GetLength(1)];
                            int mult = 0;

                            for (int i = 0; i < multipliedMatrix.GetLength(1); i++)
                            {
                                for (int j = 0; j < firstMatrix.GetLength(0); j++)
                                {
                                    for (int k = 0; k < secondMatrix.GetLength(1); k++)
                                    {
                                        mult += firstMatrix[i, k] * secondMatrix[k, j];
                                    }
                                    multipliedMatrix[i, j] = mult;
                                    mult = 0;
                                }
                            }

                            return multipliedMatrix;
                        }
                    }

                    break;
                }

            case -1: IsWork = false; break;
        }
    }
}