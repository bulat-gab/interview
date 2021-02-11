// using System;
// using System.Collections.Generic;
//
// namespace Solution
// {
//     public interface IDistributedService
//     {
//         bool IsUserRegistered(ulong puid);
//         IList<ulong> GetAllUsers();    
//     }
//     
//     public class Solution {
//         
//
//         public class User 
//         {
//             public string FirstName {get ; set;}
//             public string LastName {get; set;}
//         }
//         /*
//          aa rr
//          a arr
//         */
//
//         private static GetServices()
//         {
//             // Magic we are not interested in that exercise
//         }
//         
//         public static Dictionary<string, IDistributedService> DistributedServiceByName {get; set;} = GetServices();
//         
//         public static void Main(string[] args) {
//             
//             // Please compute the list of duplicate ids and in which DC they occur....
//             var duplicateIds = new Dictionary<long, List<string>>();
//             var dict = new Dictionary<string, List<long>>();
//
//             foreach(var (dcName, dc) in GetServices())
//             {
//                 dict[dcName] = dc.GetAllUsers();
//             }
//
//             foreach(var (dcName, users) in dict)
//             {
//                 foreach(var user in users)
//                 {
//                     var exists = duplicateIds.TryGetValue(user, out var list);
//                     if (exists)
//                     {
//                         duplicateIds[user].Add(dcName);
//                     }
//                     else
//                     {
//                         duplicateIds[user] = new List<string>() { user };
//                     }
//                 }
//             }
//
//
//             foreach(var (user, dcList) in duplicateIds)
//             {
//                 if (dcList.Length == 1)
//                     continue;
//
//                 Console.WriteLine($"{user} : {dcList}")
//             }
//         }
//     }
// }