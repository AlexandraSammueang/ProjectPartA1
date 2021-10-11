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
        const decimal VAT = 0.25M;
        const int MaxArticals = 10;

        static Article[] articles = new Article[MaxArticals];
        static int nrArticles;
        static void Main(string[] args)
        {
            {
                ReadArticles();
                PrintReciept(articles); // create a constructor to save and print out
            }

            static void ReadArticles()

            {
                Console.WriteLine("Welcome to project part A!");
                Console.WriteLine("Let´s print a recipt!");
                Console.WriteLine();
                Console.WriteLine("How many articals do you want (between 1 to 10)?"); //Ask how many articels user want

                try

                {

                    nrArticles = Convert.ToInt32(Console.ReadLine()); // convert the  useres input string to a number
                    if (nrArticles <= MaxArticals && nrArticles >= 1) //User can put max 10 artical minimun or same as one 
                    {
                        Console.WriteLine($"You want to write in {nrArticles}  articles");//print out how many articels the user put in
                        for (int i = 0; i < nrArticles; i++) // as many times as the user wants articals...
                        {
                            //ask the user for name and price
                            int iteam = i;
                            Console.WriteLine($"Please enter a name and price for article #{iteam + 1} in format name; price"); //+1 to make it start on 1
                            var NamePrice = Console.ReadLine().Split(';'); //(var is a string array)split the name; price and save valu in the string
                            decimal price;                                         // index 0 is name , price is index 1

                            if (string.IsNullOrEmpty(NamePrice[0]))

                            {
                                Console.WriteLine("Wrong name!");
                            }
                            else if (!decimal.TryParse(NamePrice[1], out price)) //Convert my string to a decimal 
                            {
                                Console.WriteLine("Wrong price");
                            }
                            else
                            {
                                articles[i] = new Article
                                {
                                    Name = NamePrice[0],// initsierar my articel array with name
                                    Price = price  // put my price array in price
                                };

                            }


                        }
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }


            }
        }
        static void PrintReciept(Article[] articles) // Need to be the same parameter as i use in the begining
        {
            try
            {


                Console.WriteLine("Purchased Articals:\n");
                DateTime dateTime = DateTime.Now;// Adding datetime for the day
                Console.WriteLine(dateTime.ToString("dddd,dd MMMM yyyy HH:mm:ss") + "\n"); // Write how i want it to print out in a string
                Console.WriteLine($" {"Name:",-50} {"Price:",-50}"); // By adding -50 i move the text to where i like it to be
                decimal total = 0; // Making a decimal for my Totalprice
                for (int i = 0; i < nrArticles; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine($"#{i + 1} {articles[i].Name,-50} {articles[i].Price,-50:C2}"); //Make a decimal to reach all values in price (for print)

                    total += articles[i].Price; // Put the total of the users price in articals i
                }
                decimal TotalVat = VAT * total; // diveded my Vat decimal whith total price
                Console.WriteLine($"{"Total purchased",-50} {total,-54:C2}"); // use C2 to get currency
                Console.WriteLine($"{"Includes VAT 25%",-50} {TotalVat,-54:C2}");

            }


            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}



