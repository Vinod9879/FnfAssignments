using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

namespace AssignmentFnf
{
    class UserMovie
    {
        private int _id;
        string _movieName;
        string _generic;
        double _rating;
        
        public int MovieId
        {
            get {  return _id; }
            set { _id = value; }
        }public string MovieName
        {
            get { return _movieName; }
            set { _movieName = value; }
        }public string Generic
        {
            get { return _generic; }
            set { _generic = value; }
        }
        public double Rating
        {
            get { return _rating; }
            set { _rating = value; }
        }
    }
    class MovieRepo
    {
        List<UserMovie> movies=new List<UserMovie>();
        public void AddMovie(UserMovie movie)
        {
            movies.Add(movie);
            Console.WriteLine($"Succesfully{movie.MovieName} movie added");
        }
        public UserMovie GetMovie(int movId)
        {
            return movies.Find(mov => mov.MovieId == movId);
        }
        public UserMovie[] GetAllMovie()
        {
            return movies.ToArray();
        }
        public void UpdateMovie(UserMovie mov) 
        {
                for(int i=0;i<movies.Count;i++)
                {
                    if (movies[i].MovieId == mov.MovieId)
                    {
                       
                       
                        movies[i].MovieName = mov.MovieName;
                        movies[i].Generic = mov.Generic;
                        movies[i].Rating = mov.Rating;
                        Console.WriteLine($"Movie updated{mov.MovieName} update successsfully");
                        return;


                    }
                }
                Console.WriteLine("No movie found to up[date");

        }
            public void DeleteMovie(int movId)
        {
            var records=movies.Find(mov=>mov.MovieId == movId);
            if (records == null)
            {
                Console.WriteLine($"No employye found with id{movId} to delete");
                return;
            }
            movies.Remove(records);
            Console.WriteLine($"Movie removed succesfully with id{movId}");
        }

    }
    internal class Assignment5
    {
        static MovieRepo movieRepo = new MovieRepo();
        static void Main(string[] args)
        {
            bool processing = true;
            do
            {
                Console.WriteLine("Enter Your  choice 1 to Add, 2 to Find ,3 to DisplayAll ,4 to Update,5 to Delete and ,6 to exit");
                int choice=Convert.ToInt32(Console.ReadLine());
                processing = processMenu(choice);

            } while (processing);


        }
        public static bool processMenu(int choice)
        {
            switch (choice)
            {
                case 1:addMovie();return true;
                case 2:findMovie();return true;
                case 3:displayAll(); return true;
                case 4:updateMovie(); return true;
                case 5:deleteMovie(); return true;
                case 6:return false;
                default:Console.WriteLine("Invalid Choice please Enter valid ");return true;

            }
        }
        private static void addMovie()

        {  UserMovie mov= new UserMovie();
            mov.MovieId = ConsoleUtil.GetInputInt("Enter the MovieID");
            mov.MovieName = ConsoleUtil.GetInputString("Enter the MovieName");
            mov.Generic = ConsoleUtil.GetInputString("Enter the Generic(action /Romance etc");
            mov.Rating = ConsoleUtil.GetInputDouble("Enter the Rating ");
            movieRepo.AddMovie(mov);


        }
        private static void findMovie()
        {
            Console.WriteLine("Enter the Movie id");
            int movieId=Convert.ToInt32(Console.ReadLine());
            UserMovie mov = movieRepo.GetMovie(movieId);
            if (mov!=null)
            {
                Console.WriteLine($"Movie Found : id={mov.MovieId},Name ={mov.MovieName} Gneric={mov.Generic},Rating={mov.Rating}");
            }
            else
            {
                Console.WriteLine($"No Movie is not Found with id{movieId}");
            }
       
        }
        private static void displayAll()
        {
            var records = movieRepo.GetAllMovie();
            foreach(UserMovie mov in records)
            {
                Console.WriteLine($"Movie Found : id={mov.MovieId},Name ={mov.MovieName} Gneric={mov.Generic},Rating={mov.Rating}");
            }
        }
        private static void updateMovie()
        {
            int choice;
            do
            {
                Console.WriteLine("Enter the number u want to update\n1. MovieName\n2.Generic\n3.Rating\n4.exit");
                choice = ConsoleUtil.GetInputInt("enter ur chocie");
                updatChoice(choice);
            } while (choice != 4); // Loop continues as long as the choice is not 4
        }

        public static void updatChoice(int choice)
        {
            if (choice == 4) // No need to process further if the user chose to exit
            {
                return;
            }

            int movieId = ConsoleUtil.GetInputInt("Enter the id u want to update");
            UserMovie existing = movieRepo.GetMovie(movieId);

            if (existing == null)
            {
                Console.WriteLine("no movie to update");
                return;
            }

            switch (choice)
            {
                case 1:
                    existing.MovieName = ConsoleUtil.GetInputString("Enter the new MovieName");
                    break;
                case 2:
                    string Generic = ConsoleUtil.GetInputString("Enter the Generic(action /Romance etc)");
                    existing.Generic = Generic;
                    break;
                case 3:
                    double Rating = ConsoleUtil.GetInputDouble("Enter the Rating");
                    existing.Rating = Rating;
                    break;
                default:
                    Console.WriteLine("invalid choice");
                    break;
            }
            movieRepo.UpdateMovie(existing);
        }


        private static void deleteMovie()
        {
            int movieId = ConsoleUtil.GetInputInt("Enter thr moie id you want to delete");
            movieRepo.DeleteMovie(movieId);

        }


    }
    static class ConsoleUtil
    {
        public static String GetInputString(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }
        public static int GetInputInt(string question)
        {
           while (true)
            {
                string input=GetInputString(question);
                if (int.TryParse(input, out int value))
                    return value;
                Console.WriteLine($"Invalid Input Pleasee enter valid interger between {int.MinValue} and {int.MaxValue}");
            }

        }
        public static double GetInputDouble(string question)
        {
            while (true)
            {
                string input= GetInputString(question);
                if (double.TryParse(input, out double value))
                    return value;
                Console.WriteLine($"Invalid Input Pleasee enter valid double between {double.MinValue} and {double.MaxValue}");
            }

        }
        public static long GetInputLong(string question)
        {
            while (true)
            {
                string input = GetInputString(question);
                if (long.TryParse(input, out long value))
                    return value;
                Console.WriteLine($"Invalid Input Pleasee enter valid double between {long.MinValue} and {long.MaxValue}");
            }

        }
    }
}
