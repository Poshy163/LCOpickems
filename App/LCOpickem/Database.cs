using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
#pragma warning disable CS8600 
#pragma warning disable CS8602
#pragma warning disable CS0618
using BsonReader = Newtonsoft.Json.Bson.BsonReader;
using JsonConvert = Newtonsoft.Json.JsonConvert;

namespace LCOpickem
{
    internal class Database
    {

        public static bool TestPing()
        {
            try
            {
                MongoClient client = new MongoClient(Global.ConnectionString);
                IMongoDatabase database = client.GetDatabase("admin");
                Global.client = new MongoClient(Global.ConnectionString);
                return true;
            }
            catch
            {
                return false;
            }

        }

        #region Login/register
        public static bool SignupDatabase(User T_user)
        {
            try
            {
                BsonDocument? filter = new BsonDocument { { "Username", T_user.Username } };
                IMongoDatabase? database = Global.client.GetDatabase("UserInfo");
                IMongoCollection<BsonDocument>? collection = database.GetCollection<BsonDocument>("UserCredentials");
                System.Collections.Generic.List<BsonDocument>? documents = collection.Find(filter).ToList();
                dynamic jsonFile = JsonConvert.DeserializeObject(Functions.ToJson(documents[0]));
                return false;
            }
            catch
            {
                IMongoDatabase? database = Global.client.GetDatabase("UserInfo");
                IMongoCollection<BsonDocument>? collection = database.GetCollection<BsonDocument>("UserCredentials");

                BsonDocument? document = new BsonDocument
               {
                { "UserID", T_user.UserID },
                { "Username", T_user.Username },
                { "Password", T_user.Password },
                { "Email", T_user.Email },
                { "Date Registered", T_user.DateRegistered },
                { "Points", 0 },
                { "Glassball Pick", "" }
               };

                collection.InsertOne(document);
                return true;
            }

        }

        public static bool GlassBall(string pick)
        {
            try
            {
                IMongoDatabase? database = Global.client.GetDatabase("UserInfo");
                IMongoCollection<BsonDocument>? collection = database.GetCollection<BsonDocument>("Glassball");
                BsonDocument? document = new BsonDocument
                {
                 { "Username", Global.currentUser.Username },
                 { "Glassball Pick", pick }
                };
                collection.InsertOne(document);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion Login/register

        #region Pickems

        public static string[]? GetTeamsPlaying(int Week, int Playday)
        {
            IMongoDatabase? database = Global.client.GetDatabase("Pickem");
            IMongoCollection<BsonDocument>? collection = database.GetCollection<BsonDocument>("Schedule");
            BsonDocument? filter = new BsonDocument { { "Playday", Playday }, { "Week", Week } };
            System.Collections.Generic.List<BsonDocument>? documents = collection.Find(filter).ToList();
            dynamic jsonFile = JsonConvert.DeserializeObject(Functions.ToJson(documents[0]));
            string tempS = jsonFile["Schedule"] + "";
            if (jsonFile == null)
            {
                return null;
            }
            string[] games = tempS.Split('|');
            return games;
        }




        public static void LockUserPicks(int week, int playday, string ONE, string TWO, string THREE, string FOUR)
        {
            IMongoDatabase? database = Global.client.GetDatabase("UserPicks");
            if (!Functions.CollectionExists(database, Global.currentUser.Username))
            {
                database.CreateCollection(Global.currentUser.Username);
            }
            IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>(Global.currentUser.Username);
            BsonDocument? filter = new BsonDocument { { "Playday", Global.Playday }, { "Week", Global.Week } };
            List<BsonDocument>? documents = collection.Find(filter).ToList();
            BsonDocument? document = new BsonDocument
            {
                {"Week", week },
                {"Playday", playday},
                { "MATCH 1", ONE },
                { "MATCH 2", TWO },
                { "MATCH 3", THREE },
                { "MATCH 4", FOUR },
            };


            try
            {
                dynamic jsonFile = JsonConvert.DeserializeObject(Functions.ToJson(documents[0]));
                collection.FindOneAndUpdate(filter, document);
            }
            catch
            {
                collection.InsertOne(document);
            }


        }

        public static string[] LoadedPreselection()
        {
            try
            {
                IMongoDatabase? database = Global.client.GetDatabase("UserPicks");
                BsonDocument? filter = new BsonDocument { { "Playday", Global.Playday }, { "Week", Global.Week } };
                IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>(Global.currentUser.Username);
                System.Collections.Generic.List<BsonDocument>? documents = collection.Find(filter).ToList();
                dynamic jsonFile = JsonConvert.DeserializeObject(Functions.ToJson(documents[0]));
                return new string[] { jsonFile["MATCH 1"], jsonFile["MATCH 2"], jsonFile["MATCH 3"], jsonFile["MATCH 4"] };
            }
            catch
            {
                return new string[] { "", "", "", "" };
            }

        }
        public static bool IsMatchOver(int week, int playday)
        {
            IMongoDatabase? database = Global.client.GetDatabase("Pickem");
            BsonDocument? filter = new BsonDocument { { "Playday", playday }, { "Week", week } };
            IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>("Schedule");
            System.Collections.Generic.List<BsonDocument>? documents = collection.Find(filter).ToList();
            dynamic jsonFile = JsonConvert.DeserializeObject(Functions.ToJson(documents[0]));
            return jsonFile["Finished"];
        }


        public static string[] GetMatchWinners(int week, int playday)
        {
            IMongoDatabase? database = Global.client.GetDatabase("Pickem");
            BsonDocument? filter = new BsonDocument { { "Playday", playday }, { "Week", week } };
            IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>("Schedule");
            System.Collections.Generic.List<BsonDocument>? documents = collection.Find(filter).ToList();
            dynamic jsonFile = JsonConvert.DeserializeObject(Functions.ToJson(documents[0]));
            string temp = jsonFile["Result"] + "";
            return temp.Split('|');
        }
        #endregion Pickems

        #region Profile 

        public static void AddPoints() // THIS ADDS POINTS OK
        {
            IMongoDatabase? database = Global.client.GetDatabase("UserInfo");
            IMongoCollection<BsonDocument>? collection = database.GetCollection<BsonDocument>("UserCredentials");
            BsonDocument? filter = new BsonDocument { { "Username", "Poshy" } };
            UpdateDefinition<BsonDocument>? Update = Builders<BsonDocument>.Update.Set("Points", 2);
            collection.UpdateOne(filter, Update);
        }
        #endregion Profile
    }



    internal class User
    {

        public string Username;
        public string UserID;
        public string Email;
        public string Password = "";
        public string DateRegistered;

        public User(string T_name, string T_email, string T_password = "", bool Register = false, string T_DateRegistered = "", string T_UserID = "")
        {
            Username = T_name;
            Email = T_email;
            if (Register)
            {
                Password = Functions.ComputeSha256Hash(T_password);
                UserID = Functions.ComputeSha256Hash(T_name + T_email + DateTime.Now.ToString("MM/dd/yyyy h:mm tt"));
                DateRegistered = DateTime.Now.ToString("ddd, dd MMM yyy HH’:’mm’:’ss ‘GMT’");
            }
            else
            {
                DateRegistered = T_DateRegistered;
                UserID = T_UserID;
            }
        }

    }


    internal class Functions
    {
        public static string ComputeSha256Hash(string rawData)
        {
            using SHA256 sha256Hash = SHA256.Create();
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }

        public static string ToJson(BsonDocument bson)
        {
            MemoryStream? stream = new MemoryStream();
            using (BsonBinaryWriter? writer = new BsonBinaryWriter(stream))
            {
                BsonSerializer.Serialize(writer, typeof(BsonDocument), bson);
            }

            stream.Seek(0, SeekOrigin.Begin);
            BsonReader reader = new BsonReader(stream);
            StringBuilder? sb = new StringBuilder();
            StringWriter? sw = new StringWriter(sb);
            using (JsonTextWriter? jWriter = new JsonTextWriter(sw))
            {
                jWriter.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                jWriter.WriteToken(reader);
            }

            return sb.ToString();
        }



        public static bool CollectionExists(IMongoDatabase database, string collectionName)
        {
            BsonDocument? filter = new BsonDocument("name", collectionName);
            ListCollectionNamesOptions? options = new ListCollectionNamesOptions { Filter = filter };

            return database.ListCollectionNames(options).Any();
        }
    }
}