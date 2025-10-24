namespace DoubleList;

public class DoubleNode<T>
{
    public DoubleNode(T data)
    {
        Data = data;
        Next = null;
        Prev = null;
    }

    public T? Data { get; set; }
    public DoubleNode<T>? Next { get; set; }
    public DoubleNode<T>? Prev { get; set; }
}