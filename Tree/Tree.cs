using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Transactions;

public class Node
{
    public int data;
    public Node? left;
    public Node? right;

    public Node(int d)
    {
        data = d;
        left = null;
        right = null;
    }
    
    public Node(int d, Node l, Node r)
    {
        data = d;
        left = l;
        right = r;
    }
}

public class Tree
{
    public Node? root;

    public void Add(int data)
    {
        Node node = new Node(data);
        Node? current = root;

        if (current == null)
        {
            root = node;
            return;
        }

        while (current != null)
        {
            if (node.data >= current.data)
            {
                if (current.right == null)
                {
                    current.right = node;
                    return;
                }

                current = current.right;
            }
            else
            {
                if (current.left == null)
                {
                    current.left = node;
                    return;
                }

                current = current.left;
            }
        }
    }

    public void Remove(int data)
    {
        if (root == null) return;
        else
        {
            if (root.data == data)
            {
                RemoveNode(root, null);
                return;
            }
        }

        Node? current = root;

        while (current != null)
        {
            if (data < current.data)
            {
                if (current.left == null) return;
                else
                {
                    if (current.left.data == data)
                    {
                        RemoveNode(current.left, current);
                    }
                    current = current.left;
                }
            }
            else
            {
                if (current.right == null) return;
                else
                {
                    if (current.right.data == data)
                    {
                        RemoveNode(current.right, current);
                    }
                    current = current.right;
                }
            }
        }

        return;
    }

    public void RemoveNode(Node target, Node? parent)
    {
        // 1. left and right == null
        if (target.left == null && target.right == null)
        {
            if (parent == null)
            {
                root = null;
                return;
            }
            else
            {
                if (parent.data > target.data) parent.left = null;
                else parent.right = null;

                return;
            }
        }
        // 2. left and right != null
        else if (target.left != null && target.right != null)
        {
            Node current = target.right;
            Node before = target;
            bool chk = false;

            while (true)
            {
                if (current.left == null)
                {
                    target.data = current.data;

                    if (chk) before.left = null;
                    else before.right = null;

                    return;
                }
                else
                {
                    before = current;
                    current = current.left;
                    chk = true;
                }
            }
        }
        // 3. left or right == null
        else
        {
            if (parent == null)
            {
                if (target.left == null) root = target.right;
                else root = target.left;
            }
            else
            {
                if (target.left == null) parent.right = target.right;
                else if (target.right == null) parent.left = target.left;
            }

            return;            
        }
    }

    public bool Contains(int data)
    {
        Node? current = root;

        if (current == null) return false;


        while (current != null)
        {
            if (data == current.data)
            {
                return true;
            }

            else if (data < current.data)
            {
                if (current.left == null) return false;
                current = current.left;
            }
            else
            {
                if (current.right == null) return false;
                current = current.right;
            }
        }

        return false;
    }

    public Node? Find(int data)
    {
        Node? current = root;

        if (current == null) return null;


        while (current != null)
        {
            if (data == current.data)
            {
                return current;
            }

            else if (data < current.data)
            {
                if (current.left == null) return null;
                current = current.left;
            }
            else
            {
                if (current.right == null) return null;
                current = current.right;
            }
        }

        return null;
    }

    public void Print()
    {
        if (root != null)
        {
            Console.Write(" ");

            Queue<(Node?, int)> q = new Queue<(Node?, int)>();
            int cl = -1;
            bool chk = false;

            q.Enqueue((root, 0));

            while (q.Count > 0)
            {
                (Node? n, int l) = q.Dequeue();

                
                if (l != cl)
                {
                    Console.WriteLine();

                    for (int i = 0; i < 10 - cl * 2; i++) Console.Write(" ");
                    cl = l;
                }

                if (cl == 1 && chk) Console.Write("  ");

                if (n != null) Console.Write($" {n.data} ");
                else Console.Write("   ");

                if (cl == 1 && !chk) chk = true;

                if (n != null)
                {
                    q.Enqueue((n.left, l + 1));
                    q.Enqueue((n.right, l + 1));
                }
            }
            Console.WriteLine();

            Console.Write("PreOrder - ");
            PreOrder(root);
            Console.Write("\nInOrder - ");
            InOrder(root);
            Console.Write("\nPostOrder - ");
            PostOrder(root);
            Console.Write("\nLevelOrder - ");
            LevelOrder(root);
        }
        Console.WriteLine();
    }



    public void PreOrder(Node node)
    {
        // data - left - right
        Console.Write($"{node.data} ");

        if (node.left != null) PreOrder(node.left);
        if (node.right != null) PreOrder(node.right);
    }

    public void InOrder(Node node)
    {
        // left - data - right
        if (node.left != null) InOrder(node.left);
        Console.Write($"{node.data} ");
        if (node.right != null) InOrder(node.right);
    }

    public void PostOrder(Node node)
    {
        // left - right - data
        if (node.left != null) PostOrder(node.left);
        if (node.right != null) PostOrder(node.right);
        Console.Write($"{node.data} ");
    }

    public void LevelOrder(Node node)
    {
        // level1 - level2 - ...
        Queue<Node?> q = new Queue<Node?>();

        q.Enqueue(node);

        while (q.Count > 0)
        {
            Node? n = q.Dequeue();

            if (n != null)
            {
                Console.Write($"{n.data} ");

                q.Enqueue(n.left);
                q.Enqueue(n.right);
            }
        }
    }
}