using System.Collections;
using System;
using System.Data;
using System.Diagnostics;//used for Stopwatch class

using MySql.Data;
using MySql.Data.MySqlClient;

using MySqlAccess;

namespace BusinessEntities
{
    public class Order
    {
        int ID_Order;
        string Date;
        int Price;

        public Order(int order_id, string date, int price)
        {
            this.ID_Order = order_id;
            this.Date = date;
            this.Price = price;
        }

        public int getID() { return ID_Order; }
        public string getDate() { return Date; }
        public int getPrice() { return Price; }

        public override string ToString()
        {
            return base.ToString() + ": " + ID_Order + " , "+Date+" , "+Price;
        }
    }

    public class Ingredients
    {
        int ID_Ingredient;
        string Name_Ingredient;
        int howmuch; // 0 - no more, 1 - yes more

        public Ingredients(int id,string name, int b){

            this.ID_Ingredient = id;
            this.Name_Ingredient = name;
            this.howmuch = b;
        }

        public int getIngredient_ID() { return ID_Ingredient; }
        public string getIngredient_name() { return Name_Ingredient; }
        public int gethowmuch() { return howmuch; }


        public override string ToString()
        {
            return base.ToString() + ": " + ID_Ingredient + " , " + Name_Ingredient;
        }
    }


    public class Recipe
    {
        int cost;
        int Quantity;
        int ID_ingredint;
        int ID_Order;
        int Recipe_ID;
        
        public Recipe(int Recipe_ID ,int cost, int Quantity, int ID_ingredint, int ID_Order)
        {
            this.Recipe_ID = Recipe_ID;
            this.Quantity = Quantity;
            this.ID_ingredint = ID_ingredint;
            this.ID_Order = ID_Order;
            this.cost = cost;
        }

        public int getQuantity() { return Quantity; }
        public int getID_ingredint() { return ID_ingredint; }
        public int getCost() { return cost; }
        public int getID_Order() { return ID_Order; }
        public int getRecipe_ID() { return Recipe_ID; }


        public override string ToString()
        {
            return base.ToString() + ": " + Recipe_ID + " , " + ID_Order + " , "+ ID_ingredint+" , "+ cost + "," + Quantity;
        }
    }

/////////////////////////////// MONGO CLASS //////////////////////////////////
    public class MongoOrder
    {
        Order order;
        Ingredients ingredients;
        Recipe recipe;

        string orderDate;
 

        public void setStatus(string orderDate)
        {
            this.orderDate = orderDate;
   
        }

        public void setOrder(Order o){
            order = o;
        }

        public void setIngredients(Ingredients ing){
            ingredients = ing;
        }

        public void setRecipe(Recipe rec){
            recipe = rec;
        }

        public Order GetOrder(){
            return order;
        }

        public Ingredients GetIngredients(){
            return ingredients;
        }

        public Recipe GetRecipe(){
            return recipe;
        }

        public string getOrderDate() { return orderDate; }


    }
}
