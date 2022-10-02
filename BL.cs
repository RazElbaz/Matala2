using System.Collections;
using System;
using System.Data;
using System.Diagnostics;//used for Stopwatch class
using BusinessEntities;

namespace BusinessLogic
{
    public class Logic
    {
        static string[] ice_cream = { "Normal cup", "special cup", "box","Chocolate",
         "Vanilla","Mekupelet", "Pistachio", "chewing gum", "Oreo", "strawberry","banana", "mango" , "lotus", 
         "Chocolate sauce", "maple sauce", "peanuts"};

        static int price = 0;
        public static int getprice() { return price; }

/////////////////////////// SQL /////////////////////////////////////////////////////
        public static void createTables(){
            MySqlAccess.MySqlAccess.createTables();
        }

        public static void fillINGREDIENT(int id, int more){
            Random r = new Random();
            int v = 0;

            if( id ==0 && more == 0){
                price = 7;
                v = 0;
            }

            if(id == 1 && more ==0){
                price = 9;
                v =1;
            }

            if(id == 2 && more ==0){
                price = 12;
                v =2;
            }

            if(v == 0 && more > 0){
                price = 7 + 6*more;
            }

            if(v == 1 && more > 0){
                price = 9 + 8*more;
            }

            if(v == 2 && more > 0){
                price = 12 + 11*more;
            }

            string name = ice_cream[id];
            Ingredients ice = new Ingredients(id,name, more);
            MySqlAccess.MySqlAccess.insertObject(ice);

            int order_id = 0; 

             //generate random values for order table
                //generate date string
                int rYear = r.Next(1990, 2020);
                int rMonth = r.Next(1, 13);
                int rDate = r.Next(1, 29);
                string orderDate = "" + rYear + "-" + rMonth + "-"+rDate;

                //generate date string               
                rDate = rDate + r.Next(1, 29);
                if (rDate > 29){
                    rDate = rDate % 29;
                    rMonth = rMonth + 1;
                }

                if (rMonth > 12){
                    rMonth = 1;
                    rYear = rYear + 1;
                }
                order_id= r.Next(0, 100);

                
                Order o = new Order(order_id,orderDate, price);
                MySqlAccess.MySqlAccess.insertObject(o);

                     //fiill the Recipe table
                int rIdRecipe = r.Next(0, 100);


                Recipe R = new Recipe(rIdRecipe, price, more, id,order_id);
                MySqlAccess.MySqlAccess.insertObject(R);
            
        }

        public static ArrayList getTableData(string tableName)
        {
            ArrayList all = MySqlAccess.MySqlAccess.readAll(tableName);
            ArrayList results = new ArrayList();

            if (tableName == "Order")
            {
                foreach (Object[] row in all)
                {
                    Order o = new Order((int)row[0],row[1].ToString(), (int)row[2]);
                    results.Add(o);
                }
            }

            if (tableName == "Ingredient")
            {
                foreach (Object[] row in all)
                {
                    Ingredients o = new Ingredients((int)row[0], (string)row[1], (int)row[2]);
                    results.Add(o);
                }
            }

            if (tableName == "Recipe")
            {
                foreach (Object[] row in all)
                {
                    Recipe o = new Recipe((int)row[0], (int)row[1], (int)row[2], (int)row[3], (int)row[4]);
                    results.Add(o);
                }
            }

            return results;
        }

/////////////////////////// mongo /////////////////////////////////////////////////////

        public static ArrayList getTableDataMongo()
        {
            ArrayList all = MongoAccess.MongoAccess.readAll();
            return all;
        }


        public static void fillCollection(int id, int more){
            Random r = new Random();
            MongoOrder tmpMongo;
            List<MongoOrder> data = new List<MongoOrder>(100);
            tmpMongo = new MongoOrder();
            int v = 0;

            if( id ==0 && more == 0){
                price = 7;
                v = 0;
            }

            if(id == 1 && more ==0){
                price = 9;
                v =1;
            }

            if(id == 2 && more ==0){
                price = 12;
                v =2;
            }

            if(v == 0 && more > 0){
                price = 7 + 6*more;
            }

            if(v == 1 && more > 0){
                price = 9 + 8*more;
            }

            if(v == 2 && more > 0){
                price = 12 + 11*more;
            }

            string name = ice_cream[id];
            Ingredients I = new Ingredients(id,name, more);
            tmpMongo.setIngredients(I);

            int order_id = 0; 

             //generate random values for order table
                //generate date string
                int rYear = r.Next(1990, 2020);
                int rMonth = r.Next(1, 13);
                int rDate = r.Next(1, 29);
                string orderDate = "" + rYear + "-" + rMonth + "-"+rDate;

                //generate date string               
                rDate = rDate + r.Next(1, 29);
                if (rDate > 29){
                    rDate = rDate % 29;
                    rMonth = rMonth + 1;
                }

                if (rMonth > 12){
                    rMonth = 1;
                    rYear = rYear + 1;
                }
                order_id= r.Next(0, 10);

                
                Order o = new Order(order_id,orderDate, price);
                tmpMongo.setOrder(o);

                     //fiill the Recipe table
                int rIdRecipe = r.Next(0, 10);


                Recipe R = new Recipe(rIdRecipe, price, more, id,order_id);
                tmpMongo.setRecipe(R);

                data.Add(tmpMongo);
                MongoAccess.MongoAccess.fillDocuments(data);

     
        }
}
}