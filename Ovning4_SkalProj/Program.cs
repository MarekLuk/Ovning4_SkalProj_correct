using System;


namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        // check how it works
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n5. Examine Recursion"
                    + "\n6. Examine Iteration"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    case '5':
                        RecursiveEvenCaller();
                        break;
                    case '6':
                        IterationEvenCaller();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }

            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            List<string> theList = new List<string>();
            Console.WriteLine($"Type \"+input\" to add e.g +Adam and \"Adam\" would be added to the list \nType \"-input\" to remove e.g -Adam and \"Adam\" would be removed from the list \nType x to exit");


            while (true)
            {

                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Incorrect input");
                    continue;
                }

                if (input.ToLower() == "x")
                {
                    break;
                }


                char nav = input[0];
                string value = input.Substring(1).Trim();

                switch (nav)
                {
                    case '+':
                        if (theList.Contains(value))
                        {
                            Console.WriteLine($"List already contain {value}");
                        }
                        else
                        {
                            theList.Add(value);
                            Console.WriteLine($"You added {value}");
                        }
                        break;
                    case '-':
                        if (theList.Contains(value))
                        {
                            theList.Remove(value);
                            Console.WriteLine($"You removed {value}");
                        }
                        else
                        {
                            Console.WriteLine($"You can not remove {value} because does not exist in list");
                        }
                        break;
                    default:
                        Console.WriteLine($"Use only + or -");
                        break;
                }
                Console.WriteLine($"Count: {theList.Count} Capacity: {theList.Capacity}");
            }

            //2.När ökar listans kapacitet? (Alltså den underliggande arrayens storlek) 
            //3.Med hur mycket ökar kapaciteten? 
            //List capacity increase when numbers of elements exceed list capacity
            // count 0 capacity 4
            // count 1 capacity 4
            // count 2 capacity 4
            // count 3 capacity 4
            // count 4 capacity 4
            // count 5 capacity 8
            // count 6 capacity 8
            // count 7 capacity 8
            // count 8 capacity 8
            // count 9 capacity 16
            // decrease
            // count 8 capacity 16
            // count 7 capacity 16
            // count 6 capacity 16
            // count 5 capacity 16 
            // count 4 capacity 16 
            // count 3 capacity 16 
            // count 2 capacity 16 
            // count 1 capacity 16 
            // count 0 capacity 16 

            // according to this solution capacity doubling current capacity

            //4.Varför ökar inte listans kapacitet i samma takt som element läggs till
            //I think that will be ineffective way because it will require rewrite list every single time and it takes extra resources

            //5.Minskar kapaciteten när element tas bort ur listan? 
            //No. 

            //6. När är det då fördelaktigt att använda en egendefinierad array istället för en lista?
            //When we have fixed length of data.

        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */


            Queue<string> theQueue = new Queue<string>();
            Console.WriteLine($"Type: \ne<ITEM> to enqueue item\nd to dequeue \nx to exit");


            while (true)
            {

                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Incorrect input");
                    continue;
                }

                if (input.ToLower() == "x")
                {
                    break;
                }



                char nav = input[0];
                string value = input.Substring(1).Trim();

                switch (nav)
                {
                    case 'e':
                        theQueue.Enqueue(value);
                        break;
                    case 'd':
                        if (theQueue.Count > 0)
                        {
                            theQueue.Dequeue();
                        }
                        else
                        {
                            Console.WriteLine($"Queue is empty");
                        }
                        break;
                    default:
                        Console.WriteLine($"Use only e or d");
                        break;


                }
                Console.WriteLine("Queue: ");
                foreach (string item in theQueue)
                {
                    Console.WriteLine($"{item} ");
                }
                Console.WriteLine($"{theQueue.Count} persons in the queue\n ");
            }
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {

            //1. Simulera ännu en gång ICA-kön på papper. Denna gång med en stack. Varför är det 
            //inte så smart att använda en stack i det här fallet ?
            // To use a stack in the ICA queue is not a good idea because the last person joined the queue will be served first.
            // People who have been waiting the longest will be served last.
            //2


            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
            Stack<string> theStack = new Stack<string>();
            Stack<char> reversedStack = new Stack<char>();
            Console.WriteLine($"Type: \np<ITEM> to push item\nd to remove item from top of the stack \nx to exit");



            while (true)
            {

                string input = Console.ReadLine();


                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Incorrect input");
                    continue;
                }

                if (input.ToLower() == "x")
                {
                    break;
                }



                char nav = input[0];
                string value = input.Substring(1).Trim();

                switch (nav)
                {
                    case 'p':
                        theStack.Push(value);
                        break;
                    case 'd':
                        if (theStack.Count > 0)
                        {
                            theStack.Pop();
                        }
                        else
                        {
                            Console.WriteLine($"Stack is empty");
                        }
                        break;
                    case 'r':
                        for (int i = 0; i < value.Length; i++)
                        {
                            reversedStack.Push(value[i]);
                        }
                        string reversedText = "";

                        for (int i = reversedStack.Count; i > 0; i--)
                        {
                            reversedText = reversedText + reversedStack.Pop();
                        }

                        Console.WriteLine($"reserved text is {reversedText}");
                        break;

                    default:
                        Console.WriteLine($"use only p or d");
                        break;
                }

                Console.WriteLine("Stack: ");
                foreach (string item in theStack)
                {
                    Console.WriteLine($"{item} ");
                }
                Console.WriteLine($"{theStack.Count} persons in the stack\n ");



            }
        }


        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */


            // I am using Stack datastructure

            Console.WriteLine("Type parentheses:      or tap x to exit");


            while (true)
            {

                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Incorrect input");
                    continue;
                }

                if (input.ToLower() == "x")
                {
                    break;
                }

                bool isCorrect = true;
                Stack<char> checkStack = new Stack<char>();


                foreach (var item in input)
                {
                    if (item == '(')
                    {
                        checkStack.Push(')');
                    }

                    else if (item == '{')
                    {
                        checkStack.Push('}');

                    }
                    else if (item == '[')
                    {
                        checkStack.Push(']');
                    }

                    else if (item == ')' || item == '}' || item == ']')
                    {
                        if (checkStack.Count == 0 || checkStack.Pop() != item)
                        {
                            isCorrect = false;
                            break;
                        }

                    }

                }


                if (isCorrect && checkStack.Count == 0)
                {
                    Console.WriteLine("Example is correct");


                }
                else
                {
                    Console.WriteLine("Example is incorrect");

                }

                checkStack.Clear();
                Console.WriteLine("Type another set of parentheses or tap x to exit:");


            }
        }




        //Rekursion 

        static void RecursiveEvenCaller()
        {

            Console.WriteLine("Type: \ne<INT> Calcualte nth even number\nf<INT> Calculate numbers in the fibonnaci sequence \nx to exit");
            while (true)
            {
                string input = Console.ReadLine();


                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Incorrect input");
                    continue;
                }

                if (input.ToLower() == "x")
                {
                    break;
                }





                char nav = input[0];
                int value = int.Parse(input.Substring(1).Trim());

                switch (nav)
                {
                    case 'e':
                        int result = RecursiveEven(value);
                        Console.WriteLine($"{value}th even number is {result}");
                        break;

                    case 'f':
                        int resultFibonacci = FibonacciSequence(value);
                        Console.WriteLine($"{value}th Fibonacci number is {resultFibonacci}");
                        break;


                    default:
                        Console.WriteLine($"use only e or f");
                        break;
                }

            }
        }

        static int RecursiveEven(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            return (2 + RecursiveEven(n - 1));
        }


        static int FibonacciSequence(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            else if (n == 1)
            {
                return 1;
            }

            return (FibonacciSequence(n - 1) + (FibonacciSequence(n - 2)));
        }


        //Iteration

        //Recusrion using more memory then iteration.
        //Reason for that is because each recursive call adds a new layer to the call stack


        static void IterationEvenCaller()
        {

            Console.WriteLine("Type: \ne<INT> Calcualte nth even number\nf<INT> Calculate numbers in the fibonnaci sequence \nx to exit");
            while (true)
            {
                string input = Console.ReadLine();


                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Incorrect input");
                    continue;
                }

                if (input.ToLower() == "x")
                {
                    break;
                }





                char nav = input[0];
                int value = int.Parse(input.Substring(1).Trim());

                switch (nav)
                {
                    case 'e':
                        int result = IterationEven(value);
                        Console.WriteLine($"{value}th even number is {result}");
                        break;

                    case 'f':
                        int resultFibonacci = IterationFibonacciSequence(value);
                        Console.WriteLine($"{value}th Fibonacci number is {resultFibonacci}");
                        break;


                    default:
                        Console.WriteLine($"use only e or f");
                        break;
                }

            }
        }

        static int IterationEven(int n)
        {

            int result = 0;

            for (int i = 0; i < n ; i++)
            {
                result += 2;
            }
            return result;


        }

        static int IterationFibonacciSequence(int n)
        {

            if (n == 0)
            {
                return 0;
            }

            else if (n == 1)
            {
                return 1;
            }
            int a = 0;
            int b = 1;
            int c = 0;
            for (int i = 2; i <= n; i++)
            {
                c = a + b;
                a = b;
                b = c;


            }
            return b;



        }

    }
}