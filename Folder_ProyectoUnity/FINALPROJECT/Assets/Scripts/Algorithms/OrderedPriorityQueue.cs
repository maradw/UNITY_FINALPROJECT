using System;
using UnityEngine;

public class OrderedPriorityQueue<T>
{
    class Node
    {
        public T Value { get; set; }
        public int Priority { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }
        public Node(T value, int priority)
        {
            this.Value = value;
            this.Priority = priority;
            Next = null;
            Previous = null;
        }
    }
    private Node Head { get; set; }
    private Node Tail { get; set; }
    private int length = 0;
    public void Enqueue(T value, int priority)
    {
        Node newNode = new Node(value, priority);
        if (Head == null)
        {
            Head = newNode;
            Tail = newNode;
            Head.Next = newNode;
            length++;

        }
        else if (priority < Head.Priority)
        {
            newNode.Next = Head;
            Head = newNode;
            length++;
        }
        else if (priority > Tail.Priority)
        {
            Tail.Next = newNode;
            Tail = newNode;
            Tail.Next = null;
            length++;
        }
        else
        {
            Node priorityNode = Head;

            Node previousNode = null;

            while (newNode.Priority > priorityNode.Priority)
            {
                previousNode = priorityNode;
                priorityNode = priorityNode.Next;
            }
            previousNode.Next = newNode;
            newNode.Next = priorityNode;

            length++;

        }
    }
    public void Dequeue()
    {
        if (Head == null)
        {
            throw new NullReferenceException("La cola está vacia");
        }
        else
        {
            Node oldHead = Head;
            Node newHead = Head.Next;
            Head.Next = null;
            newHead.Previous = null;
            Head = newHead;
            oldHead = null;
            length--;
        }
    }
    public void Print()
    {
        Node tmp = Head;
        while (tmp != Tail)
        {
            Console.Write(tmp.Value + "-" + tmp.Priority + "    ");
            //Console.WriteLine("\n length: " + length);
            tmp = tmp.Next;
        }
        Console.Write(Tail.Value + "-" + Tail.Priority + "    ");
        Console.WriteLine();
    }
}
class Program
{
    static void Main(string[] args)
    {

    }
}

