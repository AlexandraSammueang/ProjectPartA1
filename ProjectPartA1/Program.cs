using System;

namespace ProjectPartA1
{
    class Program
    {
        struct Article
        {
            public string Name;
            public decimal Price;
        }
        const int maxArticles = 10;
        const decimal _vat = 0.25M;

        static Article[] articles = new Article[maxArticles];
        static int inputArticles; //needs to be static so can use in main

        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Project Part A");
            Console.WriteLine("Let's print a receipt");

            TryReadArticles(out inputArticles);

            ReadArticles();
            PrintReciept();

            bool ErrorHandling = TryReadArticles(out inputArticles);

        }

        private static void ReadArticles()
        {
            string[] UserInput; //Save the users input in a string
            int item = 0; 
            Article article = new Article();
            while (item < inputArticles)
            {
                try
                {
                    Console.WriteLine($"\nPlease enter name and price for article #{item + 1} in format Banana; 7,50");
                    UserInput = Console.ReadLine().Split(";"); //Split the input with name;price


                    if (!string.IsNullOrEmpty(UserInput[0]) || !string.IsNullOrWhiteSpace(UserInput[0]))

                    {
                        article.Name = UserInput[0];
                    }
                    else
                    {
                        Console.WriteLine("Name error!");
                        continue;
                    }

                    bool priceformat = decimal.TryParse(UserInput[1], out decimal price); //convert the price to a decimal
                    if (priceformat)
                    {
                        article.Price = price;
                    }
                    else
                    {
                        Console.WriteLine("Price error!");
                        continue;
                    }

                    articles[item] = article; // saves all in articles item
                }
                catch
                {
                    Console.WriteLine($"Wrong input, try again!");
                    continue;
                }
                item++;
                continue;
            }

        }
        private static void PrintReciept()
        {
            {

                Console.WriteLine("Purchased Articals:\n");
                DateTime dateTime = DateTime.Now;// Adding datetime for the day
                Console.WriteLine(dateTime.ToString("dddd,dd MMMM yyyy HH:mm:ss") + "\n"); // Write how i want it to print out in a string
                Console.WriteLine($"{"#"} {"Name:",-50} {"Price:",-50}"); // By adding -50 i move the text to where i like it to be
                decimal total = 0; // Making a decimal for my Totalprice
                for (int i = 0; i < inputArticles; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{i + 1} {articles[i].Name,-50} {articles[i].Price,-50:C2}"); //Make a decimal to reach all values in price (for print)

                    total += articles[i].Price; // Put the total of the users price in articals i
                }
                decimal TotalVat = _vat * total; // diveded my Vat decimal whith total price
                Console.WriteLine("-------------------------------------------------------------------------");
                Console.WriteLine($"\n{"Total purchased",-52} {total,-50:C2}"); // use C2 to get currency and 2 numers
                Console.WriteLine($"{"Includes VAT 25%",-52} {TotalVat,-60:C2}");

            }

        }
        private static bool TryReadArticles(out int nrArticles)

        {
            nrArticles = 0;
            string inputArticles;
            do
            {

                Console.WriteLine($"\nHow many articles do you want? (Between 1-10 or Q to quit)");
                inputArticles = Console.ReadLine(); //user put in article

                if (int.TryParse(inputArticles, out nrArticles) && nrArticles >= 1 && nrArticles <= maxArticles) //convert input from string to a number
                                                                                                                 // checks the condition 
                {
                    return true;
                }
                else if (inputArticles != "Q" && inputArticles != "q")
                {
                    Console.WriteLine("Wrong input, please try again.");
                }
            }
            while ((inputArticles != "Q" && inputArticles != "q"));
            return false;

        }
    }
}
