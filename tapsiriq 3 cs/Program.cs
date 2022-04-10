using System;
class Program
{
    static void Shuffle(string[] wordArray)
    {
        Random random = new Random();
        for (int i = wordArray.Length - 1; i > 0; i--)
        {
            int swapIndex = random.Next(i + 1);
            string temp = wordArray[i];
            wordArray[i] = wordArray[swapIndex];
            wordArray[swapIndex] = temp;
        }
    }


    static int getAnswer(int answerCount, string question, string[] answers)
    {
        int choice = default;

        do
        {
            Console.Clear();
            int questionIndex = default;

            Console.WriteLine(question);

            foreach (var answer in answers)
                Console.WriteLine($"{++questionIndex}) {answer}");

            Console.Write("\nEnter choice Index: ");
            int.TryParse(Console.ReadLine(), out choice);

        } while (choice < 1 || choice > answerCount);

        return choice;
    }

    static void checkAnswer(string selectedAnswer, string correctAnswer, ref int score)
    {
        Console.Write("You have selected ");

        if (correctAnswer == selectedAnswer)
        {
            score += 10;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("TRUE");
        }
        else
        {
            score -= (score == 0) ? 0 : 10;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("False");
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(" answer.");
    }

    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        const int questionCount = 5;
        const int answerCount = 3;
        int score = default;

        string[] questions = {
            "CLR nə deməkdir?",
            "C# nə zaman çıxıb?",
            ".Net nədir?",
            "C# son versiyası nədir?",
            "Qrupumuzun nömrəsi nədir?"
        };
        string[][] answers = new string[questionCount][] {
            new string[answerCount]{ "Common Language RunTime", "CSharp Language Runtime", "CLI"},
            new string[answerCount]{ "2000", "1999", "1998"},
            new string[answerCount]{ "Envoirement", "Language", "IDE"},
            new string[answerCount]{ "10", "7", "8"},
            new string[answerCount]{ "FBAS 22-14", "TBAS 42-24", "TTMS 22-19" }
        };


        for (int i = 0; i < questionCount; i++)
        {
            var correctAnswer = answers[i][0];
            Shuffle(answers[i]);

            int choice = getAnswer(answerCount, questions[i], answers[i]);

            checkAnswer(answers[i][choice - 1], correctAnswer, ref score);

            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }

        Console.Clear();
        Console.WriteLine($"Result is: {score}");
    }
}