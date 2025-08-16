// using System.Collections.Generic;
//
// namespace Tasks.ArrayTasks
// {
//     public class CopyLinkedListWithRandomPointer
//     {
//         public LinkedListNode<int> Copy(LinkedListNode<int> head)
//         {
//             var copy = new LinkedListNode<int>(head.Value, head.Next, head.Prev);
//             var dict = new Dictionary<int, LinkedListNode<int>>();
//             var temp = new LinkedListNode<int>(head.Next.Value);
//             copy.Next = temp;
//             
//             while (head.Next != null)
//             {
//                 dict.Add(head.Prev.Value, head.Prev);
//                 temp
//             }
//             
//         }
//     }
// }