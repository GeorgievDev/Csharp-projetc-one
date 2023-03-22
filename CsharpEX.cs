namespace ADS_Homework1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Exercise1();
            Exercise2();
            Exercise3();
            Exercise4();
            Exercise5();
            Exercise6();
            Exercise7();
            Exercise8();
            Exercise9();
        }


        static string PringArray<T>(T[] array)
        {
            string str = "";
            str += "[" + array[0];
            for (int i = 0; i < array.Length; i++)
            {
                str += ", " + array[i];
            }

            str += "]";


            return str;
        }

        //EX.1

        static void Exercise1()
        {
            int n;
            Console.Write("Enter integer number n: ");
            do
            {
                n = int.Parse(Console.ReadLine());
            } while (n < 0 || n > 20);

            double[] array = new double[n];

            EnterArray(array);

            Console.WriteLine("Sum of first " + n + " elements: " + SumOfNElements(array, n));
        }

        static void EnterArray(double[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("Enter real number: ");
                array[i] = double.Parse(Console.ReadLine());
            }
        }

        static double SumOfNElements(double[] array, int n)
        {
            double sum = 0;

            for (int i = 0; i < n; i++)
            {
                sum += array[i];
            }

            return sum;
        }


        //EX.2 

        static void Exercise2()
        {
            Random random = new Random();

            Console.Write("Enter integer number n: ");
            int n = int.Parse(Console.ReadLine());

            int[] array = new int[n];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(10, 99);
            }


            Console.WriteLine(PringArray(array));


            int count = 1;
            int maxCount = 1;
            int maxNumber = array[0];

            for (int i = 0; i < array.Length; i++)
            {
                if (i == array.Length - 1)
                {
                    break;
                }

                count = 1;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] == array[j])
                    {
                        count++;
                    }
                }

                if (count > maxCount)
                {
                    maxCount = count;
                    maxNumber = array[i];
                }
            }
            if (maxCount == 1)
            {
                Console.WriteLine("Every number in the array is seen only 1 time");
            }
            else
            {
                Console.WriteLine("The most frequent number in the array is " + maxNumber + " and it has been seen " + maxCount + " number of times");
            }
        }


        //EX.3

        static void Exercise3()
        {
            int[,] square = new int[4, 4];

            for (int i = 0; i < square.GetLength(0); i++)
            {
                for (int j = 0; j < square.GetLength(1); j++)
                {
                    int number;
                    do
                    {
                        Console.Write("Enter square[" + i + ", " + j + "]: ");
                        number = int.Parse(Console.ReadLine());
                    } while (number < 1 || number > 20);
                    square[i, j] = number;

                }
            }

            bool flag = true;
            int previousSum = 0;
            int sum = 0;


            Console.WriteLine("\n\n");

            for (int i = 0; i < square.GetLength(0); i++)
            {
                sum = 0;
                for (int j = 0; j < square.GetLength(1); j++)
                {
                    sum += square[i, j];
                }
                if (sum != previousSum && previousSum != 0)
                {
                    flag = false;
                    break;
                }
                if (previousSum == 0)
                {
                    previousSum = sum;
                }

            }


            if (!flag)
            {
                Console.WriteLine("this is not a magic square!!!");
                return;
            }


            for (int i = 0; i < square.GetLength(1); i++)
            {
                sum = 0;
                for (int j = 0; j < square.GetLength(0); j++)
                {
                    sum += square[j, i];
                }
                if (sum != previousSum && previousSum != 0)
                {
                    flag = false;
                    break;
                }

            }


            if (!flag)
            {
                Console.WriteLine("this is not a magic square!!!");
                return;
            }


            sum = 0;

            for (int i = 0, j = 0; i < square.GetLength(0) && j < square.GetLength(1); i++, j++)
            {
                sum += square[i, j];
            }
            if (sum != previousSum)
            {
                flag = false;
            }


            if (!flag)
            {
                Console.WriteLine("This is not a magic square!!!");
                return;
            }


            for (int i = 0, j = square.GetLength(1) - 1; i < square.GetLength(0) && j >= 0; i++, j--)
            {
                sum += square[i, j];
            }
            if (sum != previousSum)
            {
                flag = false;
            }


            if (!flag)
            {
                Console.WriteLine("This is not a magic square!!!");
                return;
            }


            Console.WriteLine("This is a magic square!!!");
        }


        //EX.4

        static void Exercise4()
        {
            double[] array = new double[9];

            for (int i = 0; i < array.Length; i++)
            {
                double n;
                do
                {
                    Console.Write("Entere array[" + i + "]: ");
                    n = double.Parse(Console.ReadLine());

                } while (n < -99.99 || n > 99.99);
                array[i] = n;
            }

            bool flag = true;

            ReccursiveMonoton(array, 0, true);

            for (int i = 0; i < array.Length-1; i++)
            {
                if (array[i] > array[i+1])
                {
                    flag = false;
                    break;
                }
            }

            
        }

        static void ReccursiveMonoton(double[] array, int index, bool flag)
        {
            if (!flag)
            {
                Console.WriteLine("The entered sequence of numbers is not monotonically increasing");
                return;
            }
            if (index == array.Length - 1 && flag)
            {
                Console.WriteLine("The entered sequence of numbers is monotonically increasing");
                return;
            }
            if (array[index] > array[index + 1]) {
                flag = false;
            }
            ReccursiveMonoton(array, ++index, flag);

        }



        //EX.5


        static void Exercise5()
        {
            int n;
            do
            {
                Console.Write("Enter number between 10 and 100010: ");
                n = int.Parse(Console.ReadLine());
            } while (n < 10 || n > 100010);

            bool flag = true;

            for (int i = n + 1; true; i++)
            {
                flag = true;
                for (int j = 2; j < Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    Console.WriteLine(i + " is the closset prime number to " + n);
                    break;
                }
            }
        }



        //EX.6 

        static void Exercise6()
        {
            int n;
            do
            {
                Console.Write("Enter number between 10 to 100010: ");
                n = int.Parse(Console.ReadLine());
            } while (n < 10 || n > 100010);

            int sum = RecursiveSum(n);

            Console.WriteLine(sum);
        }

        static int RecursiveSum(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            int sum = 0;

            sum += n % 10;
            sum += RecursiveSum(n / 10);


            return sum;
        }


        //EX.7

        static void Exercise7()
        {
            List<int> list1 = new List<int>{ 1, 2, 3, 4, 7, 9 };
            List<int> list2 = new List<int> { 0, 2, 3, 4, 8, 10 };

            List<int> list3 = Section(list1, list2);
            List<int> list4 = Unification(list1, list2);


            Console.Write("[" + list3[0]);
            for (int i = 1; i < list3.Count ; i++)
            {
                Console.Write(", " + list3[i]);
            }
            Console.WriteLine("]");


            Console.WriteLine();


            Console.Write("[" + list4[0]);
            for (int i = 1; i < list4.Count; i++)
            {
                Console.Write(", " + list4[i]);
            }
            Console.WriteLine("]");
        }

        static List<int> Section(List<int> list1, List<int> list2)
        {
            List<int> sectoinList = new List<int>();

            for (int i = 0; i < list1.Count; i++)
            {
                for (int j = 0; j < list2.Count; j++)
                {
                    if (list1[i] == list2[j])
                    {
                        sectoinList.Add(list1[i]);
                    }
                }
            }


            return sectoinList;
        }

        static List<int> Unification(List<int> list1, List<int> list2)
        {
            List<int> unitedList = new List<int>();
            for (int i = 0; i < list1.Count; i++)
            {
                unitedList.Add(list1[i]);
            }
            for (int i = 0; i < list2.Count; i++)
            {
                unitedList.Add(list2[i]);
            }

            return unitedList;
        }


        //EX.8

        static void Exercise8()
        {
            List<int> list = new List<int> { 1, 1, 2, 2, 2, 3, 4, 5, 5, 6 };
            LongestSequence(list);
        }

        static void LongestSequence(List<int> list) 
        {
            int count = 1;
            int maxCount = 1;
            int maxNumber = 0;

            for (int i = 0; i < list.Count-1; i++)
            {
                if (list[i] == list[i + 1])
                {
                    count++;
                }
                else if (count > maxCount)
                {
                    maxCount = count;
                    count = 1;
                    maxNumber = list[i];
                }
            }

            List<int> numberList = new List<int>();

            for (int i = 0; i < maxCount; i++)
            {
                numberList.Add(maxNumber);
            }

            Console.Write("[" + numberList[0]);
            for (int i = 1; i < numberList.Count; i++)
            {
                Console.Write(", " + numberList[i]);
            }
            Console.WriteLine("]");

        }


        //EX.9


        static void Exercise9()
        {
            List<int> list = new List<int> { -1, 1, 4, -6, 7, -1, 6 };


            Console.Write("[" + list[0]);
            for (int i = 1; i < list.Count; i++)
            {
                Console.Write(", " + list[i]);
            }
            Console.WriteLine("]");




            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] < 0)
                {
                    list.RemoveAt(i);
                }
            }

            Console.WriteLine();


            Console.Write("[" + list[0]);
            for (int i = 1; i < list.Count; i++)
            {
                Console.Write(", " + list[i]);
            }
            Console.WriteLine("]");


        }
    }







    //EX.10
    class Node<T>
    {
        public T Element { get; set; }
        public Node<T> NextNode { get; set; }

        public Node<T> PreviousNode { get; set; }

        public Node(T Element)
        {

            this.Element = Element;
            this.NextNode = null;
            this.PreviousNode = null;
        }

    }

    internal class DoubleLinkedList<T>
    {
        private Node<T> Head;

        private int counter = 0;
        // Method for adding elements
        public virtual void AddElement(T Element)
        {

            Node<T> newNode = new Node<T>(Element);
            newNode.NextNode = Head;

            if (Head != null)
            {
                Head.PreviousNode = newNode;
            }
            Head = newNode;
            counter--;

        }
        // Method for removing elements
        public void RemoveElement(int index)
        {
            Node<T> removeNode = Head;
            if (Head == null)
            {
                Console.WriteLine("There is nothing to remove here");
            }
            else
            {
                for (int i = 0; i < index; i++)
                {
                    removeNode = removeNode.NextNode;
                }
                removeNode.NextNode = removeNode.NextNode.NextNode;
                counter--;
            }

        }
        // Method for searching for index
        public void SearchingIndex(int index)
        {

            if (index < 0 || index > counter)
                Console.WriteLine("There is nothing to search for.");

            for (int i = 0; i < index; i++)
            {
                Head = Head.NextNode;
            }
            Console.WriteLine(Head.Element);
        }
        // Method for adding element of given index
        public void AddElement(int index, T Element)
        {
            Node<T> Add = new Node<T>(Element);
            for (int i = 0; i < index; i++)
            {
                Head = Head.NextNode;
            }
            Head.NextNode = Add;
        }
        // Method witch returns element on given index
        public T GetElement(int index)
        {
            if (index < 0 || index > counter)
            {
                index++;
            }
            for (int i = 0; i < index; i++)
            {
                Head = Head.NextNode;
            }
            return Head.Element;
        }
        // Method witch returns array of the list's elements
        public T[] ToArray()
        {
            T[] arr = new T[counter];
            for (int i = 0; i < counter; i++)
            {
                arr[i] = Head.Element;
            }

            return arr;
        }

    }
}