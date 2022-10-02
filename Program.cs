using System;
using System.Data;
using System.Diagnostics;//used for Stopwatch class

using MySql.Data;
using MySql.Data.MySqlClient;

using MySqlAccess;
using BusinessLogic;
using System.Collections;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Welcome to our ice cream shop!");
Console.WriteLine("The current time is " + DateTime.Now);

Stopwatch stopwatch = new Stopwatch();

int userInput = 0;
int input = 0;
int var = 0;
int ind = -1;
do{
    Console.WriteLine("_____________________");
    Console.WriteLine("Please chose a DB:");
    Console.WriteLine("1- SQL");
    Console.WriteLine("2- Mongo");
    Console.WriteLine("(-1) - for exit");

    userInput = Int32.Parse(Console.ReadLine());
        
    if (userInput == 1){
        do{
            Console.WriteLine("1- create empty tables");
            Console.WriteLine("2 - Choose a cup");
            Console.WriteLine("3 - Choose an ice cream");
            Console.WriteLine("4 - Choose a toping");
            Console.WriteLine("5 - print values of a table");
            Console.WriteLine("(-1) - Return to the previous menu");

            input = Int32.Parse(Console.ReadLine());
            switch (input){
                case 1:
                    BusinessLogic.Logic.createTables();
                    break;
                case 5:
                    Console.WriteLine("Enter table name (Order/Ingredient/Recipe)");
                    string tableName = Console.ReadLine();
                    ArrayList results = BusinessLogic.Logic.getTableData(tableName);
                    foreach (Object obj in results)
                        Console.WriteLine("   {0}", obj);
                    Console.WriteLine();
                    break;

                case 2:
                    Console.WriteLine("Enter num of cup:  0 - Normal cup\n"+ 
                                                            "1 - special cup\n" +
                                                            "2 - box\n");
                    ind = Int32.Parse(Console.ReadLine());
                    BusinessLogic.Logic.fillINGREDIENT(ind, var);
                    break;

                case 3:
                    Console.WriteLine("Enter num of ice cream:   3 - Chocolate\n"+ 
                                                                "4 - Vanilla\n" +
                                                                "5 - Mekupelet\n" +
                                                                "6 - Pistachio\n" +
                                                                "7 - chewing gum\n" +
                                                                "8 - Oreo\n" +
                                                                "9 - strawberry\n" + 
                                                                "10 - banana\n" + 
                                                                "11 - mango\n" + 
                                                                "12 - lotus\n");
                    ind = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Do you want more balls? : 0 - no , 1 - yes");
                    int more = Int32.Parse(Console.ReadLine());

                    if ( more == 1 ){
                        var++;
                        Console.WriteLine("Enter num of ice cream: 3 - Chocolate\n"+ 
                                                                "4 - Vanilla\n" +
                                                                "5 - Mekupelet\n" +
                                                                "6 - Pistachio\n" +
                                                                "7 - chewing gum\n" +
                                                                "8 - Oreo\n" +
                                                                "9 - strawberry\n" + 
                                                                "10 - banana\n" + 
                                                                "11 - mango\n" + 
                                                                "12 - lotus\n");
                        ind = Int32.Parse(Console.ReadLine());
                        BusinessLogic.Logic.fillINGREDIENT(ind, var);
                    }
                    else{
                        BusinessLogic.Logic.fillINGREDIENT(ind, var);

                    }

                    break;

                case 4:
                    if (var == 1 && ind == 0){
                            Console.WriteLine("You can not choose toping with normal cup and with one boll");
                            break;
                    }
                    
                    Console.WriteLine("Enter num of cup:  13 - Chocolate sauce\n"+ 
                                                        "14 - maple sauce\n" +
                                                        "15 - peanuts\n");
                    int n = Int32.Parse(Console.ReadLine());
                    if(ind == 4 && n == 14){
                        Console.WriteLine("You can not choose toping maple sauce with Vanilla ball!");
                        break;
                    }
                    if(ind == 3 && ind == 5 && n == 13){
                        Console.WriteLine("You can not choose toping Chocolate sauce with chocolate ball and Mekupelet ball!");
                        break;
                    }
                    BusinessLogic.Logic.fillINGREDIENT(n, 0);
                    break;
            }  
        }while (input != -1);
    }
    if (userInput == 2){
        do{
            Console.WriteLine("1 - Choose a cup");
            Console.WriteLine("2 - Choose an ice cream");
            Console.WriteLine("3 - Choose a toping");
            Console.WriteLine("4 - print all the data");
            Console.WriteLine("(-1) - Return to the previous menu");

            input = Int32.Parse(Console.ReadLine());
            switch (input){
                case 1:
                    Console.WriteLine("Enter num of cup:  0 - Normal cup\n"+ 
                                                            "1 - special cup\n" +
                                                            "2 - box\n");
                    ind = Int32.Parse(Console.ReadLine());
                    BusinessLogic.Logic.fillCollection(ind, var);
                    break;

                case 2:
                    Console.WriteLine("Enter num of ice cream:   3 - Chocolate\n"+ 
                                                                "4 - Vanilla\n" +
                                                                "5 - Mekupelet\n" +
                                                                "6 - Pistachio\n" +
                                                                "7 - chewing gum\n" +
                                                                "8 - Oreo\n" +
                                                                "9 - strawberry\n" + 
                                                                "10 - banana\n" + 
                                                                "11 - mango\n" + 
                                                                "12 - lotus\n");
                    ind = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Do you want more balls? : 0 - no , 1 - yes");
                    int more = Int32.Parse(Console.ReadLine());

                    if ( more == 1 ){
                        var++;
                        Console.WriteLine("Enter num of ice cream: 3 - Chocolate\n"+ 
                                                                "4 - Vanilla\n" +
                                                                "5 - Mekupelet\n" +
                                                                "6 - Pistachio\n" +
                                                                "7 - chewing gum\n" +
                                                                "8 - Oreo\n" +
                                                                "9 - strawberry\n" + 
                                                                "10 - banana\n" + 
                                                                "11 - mango\n" + 
                                                                "12 - lotus\n");
                        ind = Int32.Parse(Console.ReadLine());
                        BusinessLogic.Logic.fillCollection(ind, var);
                    }
                    else{
                        BusinessLogic.Logic.fillCollection(ind, var);

                    }

                    break;

                case 3:
                    if (var == 1 && ind == 0){
                            Console.WriteLine("You can not choose toping with normal cup and with one boll");
                            break;
                    }
                    
                    Console.WriteLine("Enter num of cup:  13 - Chocolate sauce\n"+ 
                                                        "14 - maple sauce\n" +
                                                        "15 - peanuts\n");
                    int n = Int32.Parse(Console.ReadLine());
                    if(ind == 4 && n == 14){
                        Console.WriteLine("You can not choose toping maple sauce with Vanilla ball!");
                        break;
                    }
                    if(ind == 3 && ind == 5 && n == 13){
                        Console.WriteLine("You can not choose toping Chocolate sauce with chocolate ball and Mekupelet ball!");
                        break;
                    }
                    BusinessLogic.Logic.fillCollection(n, 0);
                    break;
                
                case 4:
                    ArrayList results = BusinessLogic.Logic.getTableDataMongo();
                    foreach (Object obj in results)
                        Console.WriteLine("   {0}", obj);
                    Console.WriteLine();
                    break;

            }
        }while (input != -1);
    }         
}while (userInput != -1);

Console.WriteLine("Thank you for your time");
