using System;
using System.Collections.Generic;

public class Tree<T>
{
    public T Value { get; set; }

    public IList<Tree<T>> Children { get; private set; }
    public Tree(T value, params Tree<T>[] children)
    {
        this.Value = value;
        this.Children = new List<Tree<T>>();

        foreach (Tree<T> child in children)
        {
            this.Children.Add(child);
        }
    }

    public void Print(int indent = 0)
    {
        Console.WriteLine($"{new string(' ', 2 * indent)}{this.Value}");
        foreach (Tree<T> child in this.Children)
        {
           child.Print(indent + 1);
        }
    }

    public void Each(Action<T> action)
    {
        action(this.Value);
        foreach (Tree<T> child in this.Children)
        {
            child.Each(action);
        }
    }

    public IEnumerable<T> OrderDFS()
    {
        List<T> result = new List<T>();

        this.DFS(this, result);

        return result;
    }

    private void DFS(Tree<T> tree, List<T> result)
    {
        foreach (Tree<T> child in tree.Children)
        {
            this.DFS(child, result);
        }
        result.Add(tree.Value);
    }

    public IEnumerable<T> OrderBFS()
    {
        List<T> list = new List<T>();
        Queue<Tree<T>> queue = new Queue<Tree<T>>();
        queue.Enqueue(this);

        while (queue.Count > 0)
        {
            Tree<T> node = queue.Dequeue();
            list.Add(node.Value);
            foreach (Tree<T> child in node.Children)
            {
                queue.Enqueue(child);
            }
        }
        return list;
    }
}
