using MongoDB.Driver;

namespace LCOpickem
{
    internal class Global
    {
        public static void GetData()
        {
            ConnectionString = DatabaseInfo.ConnectionString;
        }


        public static MongoClient? client;
        public static string? ConnectionString;
        public static User? currentUser;
        public static string SourceString = @"images/teams/";
        public static int Playday = 1;
        public static int Week = 1;
    }
}
