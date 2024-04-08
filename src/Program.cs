using System;

namespace FunctionChallenges
{
    class Program
    {
        static void Main(string[] args)
        {
            // Challenge 1: String and Number Processor
            Console.WriteLine("Challenge 1: String and Number Processor");
            StringNumberProcessor("Hello", 100, 200, "World"); // Expected outcome: "Hello World; 300"

            // Challenge 2: Object Swapper
            Console.WriteLine("\nChallenge 2: Object Swapper");
            object num1 = 25, num2 = 30;
            object num3 = 10, num4 = 30;
            object str1 = "HelloWorld", str2 = "Programming";
            object str3 = "Hi", str4 = "Programming";
            object bool1 = true, bool2 = false;

            SwapObjects(ref num1, ref num2); // Expected outcome: num1 = 30, num2 = 25
            SwapObjects(ref num3, ref num4); // Error: Value must be more than 18

            SwapObjects(ref str1, ref str2); // Expected outcome: str1 = "Programming", str2 = "HelloWorld"
            SwapObjects(ref str3, ref str4); // Error: Length must be more than 5

            SwapObjects(ref bool1, ref bool2); // Error: Unsupported data type
            SwapObjects(ref num1, ref str1); // Error: Objects must be of same types

            Console.WriteLine($"Numbers: {num1}, {num2}");
            Console.WriteLine($"Strings: {str1}, {str2}");

            // Challenge 3: Guessing Game
            Console.WriteLine("\nChallenge 3: Guessing Game");
            // Uncomment to test the GuessingGame method
            GuessingGame(); // Expected outcome: User input until the correct number is guessed or user inputs `Quit`

            // Challenge 4: Simple Word Reversal
            Console.WriteLine("\nChallenge 4: Simple Word Reversal");
            string sentence = "This is the original sentence!";
            string reversed = ReverseWords(sentence);
            Console.WriteLine(reversed); // Expected outcome: "sihT si eht lanigiro !ecnetnes"
        }

        public static void StringNumberProcessor(params object[] inputs)
        {
            string sentence = "";
            int sum = 0;
            foreach (object input in inputs)
            {
                switch (input)
                {
                    case string:
                        sentence += input + " ";
                        break;
                    case int:
                        sum += (int)input;
                        break;
                    default:
                        Console.WriteLine($"Error: {input} not allowed datatype");
                        break;
                }
            }
            Console.WriteLine($"{sentence.Trim()}; {sum}");
        }

        public static void SwapObjects(ref dynamic input1, ref dynamic input2)
        {
            try
            {
                if (input1.GetType() == input2.GetType())
                {
                    switch (input1)
                    {
                        case int:
                            if (input1 > 18 && input2 > 18)
                            {
                                (input1, input2) = (input2, input1);
                            }
                            else
                            {
                                throw new Exception("Error: Value must be more than 18");
                            }
                            break;
                        case string:
                            if (input1.Length > 5 && input2.Length > 5)
                            {
                                (input1, input2) = (input2, input1);
                            }
                            else
                            {
                                throw new Exception("Error: Length must be more than 5");
                            }
                            break;
                        default:
                            throw new Exception("Error: Unsupported data type");
                    }
                }
                else
                {
                    throw new Exception("Error: Objects must be of same types");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void GuessingGame()
        {
            Random randomNumber = new Random();
            int numberRandom = randomNumber.Next(1, 10);
            int numberGuess;
            // Console.WriteLine($"{numberRandom}");
            Console.WriteLine("Guess a number between (1,10) or write 'Quit' to exist");
            do
            {
                try
                {
                    string userInput = Console.ReadLine() ?? "";
                    if (userInput.ToLower() == "quit")
                    {
                        break;
                    }
                    if (
                        int.TryParse(userInput, out numberGuess)
                        && numberGuess <= 10
                        && numberGuess >= 1
                    )
                    {
                        if (numberGuess == numberRandom)
                        {
                            Console.WriteLine("You got it! GUESS correct :)");
                            break;
                        }
                        else
                        {
                            Console.WriteLine(
                                "Your GUESS not correct :( try again or write 'Quit' to exist"
                            );
                        }
                    }
                    else
                    {
                        throw new Exception("Error: You should enter a number between (1,10):( try again or write 'Quit' to exist"
                        );
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (true);
        }

        public static string ReverseWords(string sentence)
        {
            string reversSentence = "";
            char[] letters;
            try
            {
                if (string.IsNullOrWhiteSpace(sentence))
                {
                    throw new Exception("Error: you should enter a sentence ");
                }
                else
                {
                    string[] words = sentence.Split(" ");
                    foreach (string word in words)
                    {
                        letters = word.ToCharArray();
                        Array.Reverse(letters);
                        reversSentence += new string(letters) + " ";
                    }
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
            return reversSentence.Trim();
        }
    }
}
