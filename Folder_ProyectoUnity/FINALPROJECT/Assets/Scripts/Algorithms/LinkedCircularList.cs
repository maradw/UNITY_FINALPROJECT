using System;
using UnityEngine;

public class LinkedCircularList<T>
{
    class Node
    {
        public T Value { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }
        public Node(T value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }

    }
    private Node head;
    public int length;

    private Node GetLastNode()
    {
        Node lastNode = head;
        while (lastNode.Next != head)
        {
            lastNode = lastNode.Next;
        }
        return lastNode;
    }
    public void InsertNodeAtStart(T value)
    {
        if (head == null)
        {
            Node newNode = new Node(value);
            head = newNode;
            newNode.Next = head;
            newNode.Previous = head;
            length++;
        }
        else
        {
            Node lastNode = GetLastNode();
            Node newNode = new Node(value);
            newNode.Next = head;
            newNode.Previous = lastNode;
            lastNode.Next = newNode;
            head.Previous = newNode;
            head = newNode;
            length++;
        }
    }

    public void InsertNodeAtEnd(T value)
    {
        if (head == null)
        {
            InsertNodeAtStart(value);
        }
        else
        {
            Node lastNode = GetLastNode();
            Node newNode = new Node(value);
            lastNode.Next = newNode;
            newNode.Next = head;
            head.Previous = newNode;
            newNode.Previous = lastNode;
            length++;
        }
    }
    public void InsertNodeAtPosition(T value, int position)
    {
        if (position == 0)
        {
            InsertNodeAtStart(value);
        }
        else if (position == length - 1)
        {
            InsertNodeAtEnd(value);
        }
        else if (position >= length)
        {
            throw new IndexOutOfRangeException(" posición no válida");
        }
        else
        {
            Node nodePosition = head;
            int iterator = 0;
            while (iterator < position)
            {
                nodePosition = nodePosition.Next;
                iterator = iterator + 1;
            }
            Node newNode = new Node(value);
            Node previousNode = nodePosition.Previous;
            previousNode.Next = newNode;
            newNode.Next = nodePosition;
            newNode.Previous = previousNode;
            nodePosition.Previous = newNode;
            length++;
        }
    }
    public void ModifyAtStart(T value)
    {
        if (head == null)
        {
            throw new NullReferenceException(" la lista está vacia");
        }
        else
        {
            head.Value = value;
        }
    }
    public void ModifyAtEnd(T value)
    {
        if (head == null)
        {
            ModifyAtStart(value);
        }
        else
        {
            Node lastNode = GetLastNode();
            lastNode.Value = value;
        }
    }
    public void ModifyAtPosition(T value, int position)
    {
        if (position == 0)
        {
            ModifyAtStart(value);
        }
        else if (position == length - 1)
        {
            ModifyAtEnd(value);
        }
        else if (position >= length)
        {
            throw new IndexOutOfRangeException(" posición no válida");
        }
        else
        {
            Node tmp = head;
            int iterator = 0;
            while (iterator < position)
            {
                tmp = tmp.Next;
                iterator = iterator + 1;
            }
            tmp.Value = value;
        }
    }
    public T GetNodeAtStart()
    {
        if (head == null)
        {
            return default(T);
        }
        else
        {
            return head.Value;
        }
    }
    public T GetNodeAtEnd()
    {
        if (head == null)
        {
            return GetNodeAtStart();
        }
        else
        {
            Node lastNode = GetLastNode();
            return lastNode.Value;
        }
    }
    public T GetNodeAtPosition(int position)
    {
        if (position == 0)
        {
            return GetNodeAtStart();
        }
        else if (position == length - 1)
        {
            return GetNodeAtEnd();
        }
        else if (position >= length || position < 0)
        {
            return default(T);
        }
        else
        {
            Node tmp = head;
            int iterator = 0;
            while (iterator < position)
            {
                tmp = tmp.Next;
                iterator = iterator + 1;
            }
            return tmp.Value;
        }
    }
    public void DeleteNodeAtStart()
    {
        if (head == null)
        {
            throw new NullReferenceException(" la lista está vacia");
        }
        else
        {
            Node oldHead = head;
            Node lastNode = GetLastNode();
            Node newHead = head.Next;
            lastNode.Next = newHead;
            newHead.Previous = lastNode;
            oldHead.Next = null;
            oldHead.Previous = null;
            head = newHead;
            oldHead = null;
            length--;
        }
    }
    public void DeleteNodeAtEnd()
    {
        if (head == null)
        {
            DeleteNodeAtStart();
        }
        else
        {
            Node lastNode = GetLastNode();
            Node previousLastNode = lastNode.Previous;
            previousLastNode.Next = head;
            head.Previous = previousLastNode;
            lastNode.Previous = null;
            lastNode.Next = null;
            lastNode = null;
            length--;
        }
    }
    public void DeleteNodeAtPosition(int position)
    {
        if (position == 0)
        {
            DeleteNodeAtStart();
        }
        else if (position == length - 1)
        {
            DeleteNodeAtEnd();
        }
        else if (position >= length || position < 0)
        {
            throw new IndexOutOfRangeException(" posición no válida");
        }
        else
        {
            Node nodePosition = head;
            int iterator = 0;
            while (iterator < position)
            {
                nodePosition = nodePosition.Next;
                iterator = iterator + 1;
            }
            Node previousPositionNode = nodePosition.Previous;
            Node nextPositionNode = nodePosition.Next;
            previousPositionNode.Next = nextPositionNode;
            nextPositionNode.Previous = previousPositionNode;
            nodePosition.Previous = null;
            nodePosition.Next = null;
            nodePosition = null;
            length--;
        }
    }


    public void PrintAllNodes()
    {
        Node tmp = head;
        while (tmp.Next != head)
        {
            Console.Write(tmp.Value + " ");
            tmp = tmp.Next;
        }
        Console.Write(tmp.Value + " ");
        Console.WriteLine();
    }
    public void PrintReversedNodes()
    {
        Node tmp = GetLastNode();
        Node firstNode = head;
        while (tmp.Previous != head)
        {
            Console.Write(tmp.Value + " ");
            tmp = tmp.Previous;
        }
        Console.Write(tmp.Value + " ");
        Console.Write(firstNode.Value + " ");
        Console.WriteLine();
    }
    public void GetLength()
    {
        if (length > 0)
        {
            Console.WriteLine(" capacidad de la lista: " + length);
        }
        else
        {
            Console.WriteLine(" la lista está vacia ");
        }
    }
}


