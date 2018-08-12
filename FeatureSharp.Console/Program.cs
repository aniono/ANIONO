using System;
using FeatureSharp.Models;
using FeatureSharp.Data;

namespace FeatureSharp.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new FeatureSharpDbContext())
            {
                UserDataService userDataService = new UserDataService(context);
                UserPersistence persistent = new UserPersistence(userDataService);
                UserRepository userRepository = new UserRepository(persistent);           
            }
        }
    }
}
