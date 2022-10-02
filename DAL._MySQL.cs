using MySql.Data;
using MySql.Data.MySqlClient;

using BusinessEntities;
using BusinessLogic;
using System.Collections;

namespace MySqlAccess
{
    class MySqlAccess
    {

        static string connStr = "server=localhost;user=root;port=3306;password=gal3161"; //need to change to your MySQL

        /*
        this call will represent CRUD operation
        CRUD stands for Create,Read,Update,Delete
        */
        public static void createTables()
        {

            try
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();


                string sql = "DROP DATABASE IF EXISTS ICE_CREAM_SHOP;";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                // create ICE_CREAM_SHOP
                sql = "CREATE DATABASE ICE_CREAM_SHOP;";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                // create Order
                sql = "CREATE TABLE `ICE_CREAM_SHOP`.`Order` (" +
                    "`Order_ID` INT NOT NULL AUTO_INCREMENT, " +
                    "`Date` DATETIME DEFAULT NOW()," +
                    "`Price` INT NOT NULL DEFAULT 0," +
                    "PRIMARY KEY (`Order_ID`));";

                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                // create Ingredient
                sql = "CREATE TABLE `ICE_CREAM_SHOP`.`Ingredient` (" +
                    "`Ingredient_ID` INT NOT NULL AUTO_INCREMENT, " +
                    "`Name` VARCHAR(45) NOT NULL," +
                    "`More` INT NOT NULL DEFAULT 0," +
                    "PRIMARY KEY (`Ingredient_ID`));";

                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                // create connection task - Recipe
                sql = "CREATE TABLE `ICE_CREAM_SHOP`.`Recipe` (" +
                    "`Recipe_id` INT NOT NULL AUTO_INCREMENT, " +
                    "`Ingredient_ID` INT NOT NULL," +
                    "`Order_ID` INT NOT NULL," +
                    "`Quantity` INT NOT NULL DEFAULT 0," +
                    "`Cost` INT NOT NULL DEFAULT 0," +
                    "PRIMARY KEY (`Recipe_id`)," +
                    "FOREIGN KEY (Ingredient_ID) REFERENCES Ingredient(Ingredient_ID)); ";
                    // "FOREIGN KEY (Order_ID) REFERENCES Order(Order_ID));" ;

                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                conn.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void insertObject(Object obj)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = null;

                if (obj is Order)
                {
                    Order Order = (Order)obj;
                    sql = "INSERT INTO `ICE_CREAM_SHOP`.`Order` (`Order_ID`, `Date`, `Price`) " +
                    "VALUES ('" + Order.getID() + "', '" + Order.getDate() + "', '" + BusinessLogic.Logic.getprice() + "');";
                }

                if (obj is Ingredients)
                {
                    Ingredients Ingredients = (Ingredients)obj;
                    sql = "INSERT INTO `ICE_CREAM_SHOP`.`Ingredient` (`Ingredient_ID`, `Name`, `More`) " +
                    "VALUES ('" + Ingredients.getIngredient_ID() + "', '" + Ingredients.getIngredient_name() + "', '" + Ingredients.gethowmuch() + "');";
                }

                if (obj is Recipe)
                {
                    Recipe Recipe = (Recipe)obj;
                    sql = "INSERT INTO `ICE_CREAM_SHOP`.`Recipe` (`Recipe_ID`, `Order_ID`, `Ingredient_ID`, `Quantity` , `Cost`) " +
                    "VALUES ('" + Recipe.getRecipe_ID() + "', '" + Recipe.getID_Order() + "', '" + Recipe.getID_ingredint() +
                    "', '" +Recipe.getQuantity() + "', '" + Recipe.getCost() + "');";
                }

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        //select all the data from the table that choosen
        public static ArrayList readAll(string tableName)
        {
            ArrayList all = new ArrayList();

            try
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = "SELECT * FROM `ICE_CREAM_SHOP`."+tableName;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Object[] numb = new Object[rdr.FieldCount];
                    rdr.GetValues(numb);
                    all.Add(numb);
                }
                rdr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return all;
        }
    }

}