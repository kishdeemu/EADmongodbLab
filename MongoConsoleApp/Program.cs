using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace MongoConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MongoClient dbClient = new MongoClient("mongodb://localhost:27017");
            var dbName = dbClient.GetDatabase("mongo_lab");
            var dbCollection = dbName.GetCollection<PersonModel>("Person");

            var bill = new PersonModel { firstName = "Bill", lastName = "Gates" };
            var mark = new PersonModel { firstName = "Mark", lastName = "Zukergurg" };
            var larrie = new PersonModel { firstName = "Larrie", lastName = "Eliison" };

            //CRUD Operations (Create, Read, Update, Delete)
            // Create
            //dbCollection.InsertOne(bill);
            //dbCollection.InsertOne(mark);
            //dbCollection.InsertOne(larrie);

            // Read
            // query using lambda function
            var selectQuery = dbCollection.Find(x => x.firstName == "Mark").ToList();

            Console.WriteLine(selectQuery[0].lastName);
            Console.WriteLine(selectQuery[0].id);
            Console.ReadLine();

            // Delete
            //dbCollection.DeleteOne(x=> x.firstName == "Bill");

            //Update
            //var filter = Builders<PersonModel>.Filter.Eq("firstName", "Mark");
            //var update = Builders<PersonModel>.Update.Set("Updated", DateTime.Now);

            //dbCollection.UpdateOne(filter, update);

        }
    }
}
