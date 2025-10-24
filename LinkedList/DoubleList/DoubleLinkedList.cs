using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleList;

public class DoubleLinkedList<T>
{
    private DoubleNode<T>? _head;
    private DoubleNode<T>? _tail;

    public DoubleLinkedList()
    {
        _head = null;
        _tail = null;
    }

    public void OrderedInsert(T data)
    {
        var newNode = new DoubleNode<T>(data);
        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
            return;
        }
        var current = _head;
        while (current != null && Comparer<T>.Default.Compare(current.Data!, data) < 0)
        {
            current = current.Next;
        }
        if (current == _head)
        {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
        }
        else if (current == null)
        {
            newNode.Prev = _tail;
            _tail!.Next = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.Prev = current.Prev;
            newNode.Next = current;
            current.Prev!.Next = newNode;
            current.Prev = newNode;
        }
        SortAscending();
    }

    public string ShowForward()
    {
        var output = string.Empty;
        var current = _head;
        while (current != null)
        {
            output += $"{current.Data} <=> ";
            current = current.Next;
        }
        return output.Substring(0, output.Length - 5);
    }

    public string ShowBackward()
    {
        var output = string.Empty;
        var current = _tail;
        while (current != null)
        {
            output += $"{current.Data} <=> ";
            current = current.Prev;
        }
        return output.Substring(0, output.Length - 5);
    }

    public void RemoveFirstCoincidence(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                if (current.Prev != null)
                {
                    current.Prev.Next = current.Next;
                }
                else
                {
                    _head = current.Next;
                }

                if (current.Next != null)
                {
                    current.Next.Prev = current.Prev;
                }
                else
                {
                    _tail = current.Prev;
                }

                return;
            }
            current = current.Next;
        }
    }

    public void RemoveAllCoindicences(T data)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                if (current.Prev != null)
                {
                    current.Prev.Next = current.Next;
                }
                else
                {
                    _head = current.Next;
                }

                if (current.Next != null)
                {
                    current.Next.Prev = current.Prev;
                }
                else
                {
                    _tail = current.Prev;
                }
            }
            current = current.Next;
        }
    }

    public string Exists(T data)
    {
        var current = _head;
        var output = $"The value {data} does not exists in the list.";
        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                output = $"The value {data} exists in the list.";
            }
            current = current.Next;
        }
        return output;
    }

    public void SortDescending()
    {
        if (_head == null || _head.Next == null) return;

        bool swapped;
        do
        {
            swapped = false;
            var current = _head;

            while (current != null && current.Next != null)
            {
                var first = current;
                var second = current.Next;

                if (Comparer<T>.Default.Compare(first.Data, second.Data) < 0)
                {
                    var prevNode = first.Prev;
                    var nextNode = second.Next;

                    if (prevNode != null)
                        prevNode.Next = second;
                    second.Prev = prevNode;

                    if (nextNode != null)
                        nextNode.Prev = first;
                    first.Next = nextNode;

                    second.Next = first;
                    first.Prev = second;

                    if (second.Prev == null)
                        _head = second;
                    if (first.Next == null)
                        _tail = first;

                    swapped = true;

                    if (second.Prev != null)
                        current = second.Prev;
                    else
                        current = second;
                }
                else
                {
                    current = current.Next;
                }
            }
        } while (swapped);
    }

    public void SortAscending()
    {
        if (_head == null || _head.Next == null) return;

        bool swapped;
        do
        {
            swapped = false;
            var current = _head;

            while (current != null && current.Next != null)
            {
                var first = current;
                var second = current.Next;

                if (Comparer<T>.Default.Compare(first.Data, second.Data) > 0)
                {
                    var prevNode = first.Prev;
                    var nextNode = second.Next;

                    if (prevNode != null)
                        prevNode.Next = second;
                    second.Prev = prevNode;

                    if (nextNode != null)
                        nextNode.Prev = first;
                    first.Next = nextNode;

                    second.Next = first;
                    first.Prev = second;

                    if (second.Prev == null)
                        _head = second;
                    if (first.Next == null)
                        _tail = first;

                    swapped = true;

                    if (second.Prev != null)
                        current = second.Prev;
                    else
                        current = second;
                }
                else
                {
                    current = current.Next;
                }
            }
        } while (swapped);
    }

    public string ShowMode()
    {
        var current = _head;
        var repeated = new Dictionary<T, int>();
        var output = string.Empty;

        while (current != null)
        {
            if (repeated.ContainsKey(current.Data!))
            {
                current = current.Next;
                continue;
            }

            int maxCount = 1;
            var compare = current.Next;

            while (compare != null)
            {
                if (current.Data!.Equals(compare.Data))
                {
                    maxCount++;
                }
                compare = compare.Next;
            }

            repeated[current.Data!] = maxCount;
            current = current.Next;
        }

        foreach (var rep in repeated)
        {
            output += $"{rep.Key} tiene {rep.Value} repeticiones\n";
        }

        return output;
    }

    public string ShowGraphicMode()
    {
        var current = _head;
        var repeated = new Dictionary<T, string>();
        var output = string.Empty;

        while (current != null)
        {
            if (repeated.ContainsKey(current.Data!))
            {
                current = current.Next;
                continue;
            }

            string maxCount = "*";
            var compare = current.Next;

            while (compare != null)
            {
                if (current.Data!.Equals(compare.Data))
                {
                    maxCount+="*";
                }
                compare = compare.Next;
            }

            repeated[current.Data!] = maxCount;
            current = current.Next;
        }

        foreach (var rep in repeated)
        {
            output += $"{rep.Key} => {rep.Value}\n";
        }

        return output;
    }
}