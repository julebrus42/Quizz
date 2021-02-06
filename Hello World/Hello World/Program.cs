using System;
using System.Collections.Generic;
namespace Hello_World
{
    class Program
    {

        public class Questions
        {
            public string question;
            public string answer;

            public Questions(string q, string a)
            {
                question = q;
                answer = a;
            }

            public void display()
            {
                Console.WriteLine(question + " " + answer);
            }
        }


        static void Main(string[] args)
        {
            bool run = true;
            

            while (run)
            {
                int score = 0;
                bool points = false;
                bool ownQuiz = false;

                List<Questions> questions = new List<Questions>();

                Console.WriteLine("");
                Console.WriteLine("Do you want to create your own quiz? [y/n]");
                string ownQuizAnswer = Console.ReadLine().ToLower();
                Console.WriteLine("");

                if (ownQuizAnswer.Equals("y"))
                {
                    ownQuiz = true;
                }

                if (ownQuiz)
                {
                    questions = createQuestionsForQuiz();

                } else
                {
                    questions.Add(new Questions("What is Daniel's name?", "daniel"));
                    questions.Add(new Questions("How old is he", "21"));
                    questions.Add(new Questions("Where does he live", "ålesund"));
                    questions.Add(new Questions("What is his favorite food", "taco"));
                
                }


                Console.WriteLine("Welcome to the Quizzzzz");
                Console.WriteLine("----------------");

                Console.WriteLine("Do you want to collect points? [y/n]");
                string pointscollect = Console.ReadLine().ToLower();
                Console.WriteLine("");

                if (pointscollect.Equals("y"))
                {
                    points = true;
                }

                for (int i = 0; i < questions.Count; i++)
                {
                    bool correct = false;
                    
                    while (correct == false)
                    {
                        Console.WriteLine(questions[i].question);
                        string userAnswer = Console.ReadLine().ToLower();
                        if (userAnswer.Equals(questions[i].answer))
                        {
                            if (!points)
                            {
                                Console.WriteLine("Correct", Console.ForegroundColor = ConsoleColor.Green);
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            
                            Console.WriteLine("");

                            if (points)
                            {
                                score++;
                            }
                            correct = true;

                        } else if (!points)
                        {
                            Console.WriteLine("Wrong", Console.ForegroundColor = ConsoleColor.Red);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("");
                        } else
                        {
                            correct = true;
                            Console.WriteLine("");
                        }
                    }

                }

                if (points)
                {
                    Console.WriteLine("You collected: " + score + " points");
                    Console.WriteLine("");
                }

                Console.WriteLine("Do you want to restart the  Quizzzzz? [y/n]");
                string answer = Console.ReadLine().ToLower();
                Console.WriteLine("");

                if (answer.Equals("n")) {
                    run = false;
                }
            }
        }

        public static List<Questions> createQuestionsForQuiz()
        {

            bool finished = false;

            List<Questions> questions = new List<Questions>();

            Console.WriteLine("Write 'done' when you are finished creating questions! Remember to have ? at the end of the question!", Console.ForegroundColor = ConsoleColor.Green);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");

            while(!finished)
            {
                Console.WriteLine("Question:");
                string questionCreate = Console.ReadLine().ToLower();

                if (questionCreate != "done")
                {
                    Console.WriteLine("");

                    Console.WriteLine("Answer:");
                    string answerCreate = Console.ReadLine().ToLower();

                    questions.Add(new Questions(questionCreate, answerCreate));
                    Console.WriteLine("");
                } else
                {
                    Console.WriteLine("");
                    finished = true;
                }

            }

            return questions;
        }
    }
}
