
namespace Student_Database
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] studentNames = ["Penny","Howard","Leonard","Rajesh","Sheldon","Ashley","Leena"];
            string[] studentHometowns = ["Redlands", "Covina", "Pasadena", "San Diego", "Riverside", "Big Bear", "Moreno Valley"];
            string[] studentFavFoods = ["Pasta", "Pizza", "Sandwich", "Tater Tots", "Fries", "Burrito", "Shrimp"];

            do
            {
                DisplayMenu(); //Display menu options
                Console.WriteLine("Select an option to display");
                string userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "1":
                        int studentNum;
                        bool isValid = false;
                        

                        studentNum = GetStudentNumber(studentNames.Length) - 1; //Get valid student number to lookup
                        Console.WriteLine($"Student {studentNum+1} is {studentNames[studentNum]}. "); //Display student name
                        
                        do
                        {
                            //Get the category to display for student
                            Console.WriteLine($"What would you like to know about {studentNames[studentNum]}. Enter \"hometown\" or \"favorite food\":\r\n ");
                            string category = Console.ReadLine();

                            switch (category)
                            {
                                case string value when "hometown".Contains(category.ToLower()):
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($"{studentNames[studentNum]} is from {studentHometowns[studentNum]}");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    isValid = true;
                                    break;
                                case string value when "favorite food".Contains(category.ToLower()):
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($"{studentNames[studentNum]}'s favorite food is {studentFavFoods[studentNum]}");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    isValid = true;
                                    break;
                                default:
                                    Console.WriteLine("Invalid Category... Try Again!");
                                    isValid = false;
                                    break;
                            }                           
                            
                        } while (!isValid);

                        break;
                    case "2":
                        //display all student info
                        DisplayAllStudentsInfo(studentNames, studentHometowns, studentFavFoods);
                        break;
                    case "3":
                        Console.WriteLine("Enter the student name you want to search");
                        string name = Console.ReadLine();
                        int index = -1;
                        for(int counter = 0; counter < studentNames.Length; counter++)
                        {
                            if(studentNames[counter].ToLower() == name.ToLower())
                            {
                                index = counter;
                                break;
                            }
                        }

                        if(index != -1)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"{studentNames[index]} is from {studentHometowns[index]} and his/her favorite food is {studentFavFoods[index]}");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else
                        {
                            Console.WriteLine("No Student found with given name");
                        }
                        break;
                    case "0":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Option selected");
                        break;
                }
                Console.WriteLine("\nWould you like to learn about another student? (y/n)");
            } while (Console.ReadLine() == "y");       
            
        }

      
        public static void DisplayAllStudentsInfo(string[] studentNames, string[] studentHomeTowns, string[] studentFavFoods)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\tStudent Name\t\tHometown\t\tFavourite Food");
            Console.WriteLine("\t------------\t\t--------\t\t--------------");
            Console.ForegroundColor = ConsoleColor.Green;
            for (int index = 0; index < studentNames.Length; index++)
            {
                Console.WriteLine($"\t{studentNames[index],-10}\t\t{studentHomeTowns[index],-10}\t\t{studentFavFoods[index],-10} ");
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n************************************************************");
            Console.WriteLine("\t\t\tMenu");
            Console.WriteLine("************************************************************");
            Console.WriteLine("1. Display Student info");
            Console.WriteLine("2. Display All Student info");
            Console.WriteLine("3. Search by student name & display details");
            Console.WriteLine("0. Exit ");
            Console.WriteLine("\n************************************************************\n");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        //function to get valid Student Id
        public static int GetStudentNumber(int limit) 
        {
            int studentNum = -1;
            bool isValid = false;
            do
            {
                Console.WriteLine("Enter the student number you would like to display data.");

                isValid = int.TryParse(Console.ReadLine(), out studentNum); //Parse the input
                if (!isValid)
                {
                    Console.WriteLine("Invalid number");
                }
                else if (studentNum < 1 || studentNum > limit) //Input is number but is it valid?
                {
                    Console.WriteLine("Student number does not exists. Valid student number is from 0 to " + limit);
                    isValid = false;
                }
                
            } while (!isValid);
            return studentNum;
        }
    }
}
