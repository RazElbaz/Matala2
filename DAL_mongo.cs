
using MongoDB.Driver;
using MongoDB.Bson;

using BusinessEntities;
using BusinessLogic;
using System.Collections;

namespace MongoAccess
{
    class MongoAccess
    {

        public static void fillDocuments (List<MongoOrder> orders) 
        {

             List<BsonDocument> documents = new List<BsonDocument>();

            //build list of all documents
            foreach (var mongoOrderd in orders) {
                var document = new BsonDocument { 
                    { "order", new BsonDocument 
                        { 
                            {"order_ID", mongoOrderd.GetOrder().getID() },
                            {"date",mongoOrderd.GetOrder().getDate()},
                            {"price",mongoOrderd.GetOrder().getPrice()}
                        }
                    }, 
                    { "Ingredient", new BsonDocument 
                        { 
                            { "Ingredient_ID", mongoOrderd.GetIngredients().getIngredient_ID() },
                            { "Ingredient_name" , mongoOrderd.GetIngredients().getIngredient_name() },
                            { "More?", mongoOrderd.GetIngredients().gethowmuch() } 
                        }
                    }, 
                    { "Recipe", new BsonDocument 
                        { 
                            { "Recipe_ID", mongoOrderd.GetRecipe().getRecipe_ID() },
                            { "Order_ID", mongoOrderd.GetRecipe().getID_Order() },
                            { "Ingredient_ID", mongoOrderd.GetRecipe().getID_ingredint() },
                            { "Quantity" , mongoOrderd.GetRecipe().getQuantity() },
                            { "Cost", mongoOrderd.GetRecipe().getCost() } 
                        }
                    }                
                };

                documents.Add(document);
            }

            Console.WriteLine("list is ok");

            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://galc:galcohen3161@gal.0znrmyf.mongodb.net/test");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("ice_Cream");
            var collection = database.GetCollection<BsonDocument> ("orders");

           
            collection.InsertMany(documents);
        }

        
        // read all the data from collection
        public static ArrayList readAll()
        {
            ArrayList all = new ArrayList();

            try
            {
              
                var settings = MongoClientSettings.FromConnectionString("mongodb+srv://galc:galcohen3161@gal.0znrmyf.mongodb.net/test");
                settings.ServerApi = new ServerApi(ServerApiVersion.V1);
                var client = new MongoClient(settings);
                var database = client.GetDatabase("ice_Cream");
                var collection = database.GetCollection<BsonDocument> ("orders");
                var documents = collection.Find(new BsonDocument()).ToList();
               foreach (BsonDocument doc in documents){
                Console.WriteLine(doc.ToString());}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return all;
        }
    }

}