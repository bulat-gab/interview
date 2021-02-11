// using System;
//
// namespace Solution
// {
//     public class Solution {
//         private HashSet<string> _words;
//
//
//         public static void Main(string[] args) {
//             // you can write to stdout for debugging purposes, e.g.
//             Console.WriteLine("This is a debug message");         
//         }
//
//         bool AreAnagrams(string s1, string s2){
//             if (s1 == null || s2 == null)
//                 return false;
//
//             if (s1.Length != s2.Length)
//                 return false;
//
//             var sorted1 = Array.sort(s1);
//             var sorted2 = Array.sort(s2);
//
//             if (sorted1 == sorted2)
//                 return true;
//             
//             return false;
//         }
//
//         bool AreAnagrams2(string s1, string s2){
//             if (s1 == null || s2 == null)
//                 return false;
//
//             if (s1.Length != s2.Length)
//                 return false;
//
//             var dict = new Dictionary<char, int>();
//             foreach(var ch : s1){
//                 var value = dict.GetValueOrDefault(ch, 0);
//                 dict[ch] = value + 1;
//             }
//
//             foreach(var ch : s2){
//                 if (dict.TryGetValue(ch, out var value)) {
//                     value--;
//                     if (value < 0)
//                     {
//                         return false;
//                     }
//                     dict[ch] = value;
//                 }
//             }
//
//             return true;
//         }
//
//         public void LoadWords(IList<string> words){
//             if (_words == null){
//                 _words = words;
//                 return;
//             }
//
//             _words.AddRange(words);
//
//             var length = _words.Length;
//             for (var i = 0; i < length; i++){
//                 for (var j = i; < length; j++){
//                     if (AreAnagrams(_words[i], _words[j])){
//                         _words.RemoveAt(j);
//                         length--;
//                     }
//                 }
//             }
//
//             _words.Add(words);
//         }
//
//         // O(knLog(n))
//         public bool HasAnagram(string word){
//             foreach(string learnedWord : _words){
//                 if (AreAnagrams(word, learnedWord))
//                     return true;
//             }
//
//             return false;
//         }
//     }
// }
