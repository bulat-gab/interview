namespace Tasks.ArrayTasks
{
    public class LinkedListNode<T>
    {
        public T Value { get; set; }
        public LinkedListNode<T> Next { get; set; }
        public LinkedListNode<T> Prev { get; set; }

        public LinkedListNode(T value, LinkedListNode<T> next = null, LinkedListNode<T> prev = null)
        {
            Value = value;
            Next = next;
            Prev = prev;
        }
    }
}