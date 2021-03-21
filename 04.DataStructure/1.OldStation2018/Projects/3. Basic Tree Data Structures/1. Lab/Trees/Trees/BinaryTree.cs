using System;

public class BinaryTree<T>
{
    public T Value { get; set; }

    public BinaryTree<T> LeftChild { get; set; }
    public BinaryTree<T> RightChild { get; set; }
    public BinaryTree(T value, BinaryTree<T> leftChild = null, BinaryTree<T> rightChild = null)
    {
        this.Value = value;
        this.LeftChild = leftChild;
        this.RightChild = rightChild;
    }

    public void PrintIndentedPreOrder(int indent = 0)
    {
        this.PreOrder(this, indent);
    }

    private void PreOrder(BinaryTree<T> node, int indent)
    {
        if (node == null)
        {
            return;
        }

       Console.WriteLine($"{new string(' ', indent)}{node.Value}");
       this.PreOrder(node.LeftChild, indent + 2);
       this.PreOrder(node.RightChild, indent + 2);
    }

    public void EachInOrder(Action<T> action)
    {
        this.InOrder(this, action);
    }

    private void InOrder(BinaryTree<T> node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }

        this.InOrder(node.LeftChild, action);
        action(node.Value);
        this.InOrder(node.RightChild, action);
    }

    public void EachPostOrder(Action<T> action)
    {
        this.PostOrder(this, action);
    }

    private void PostOrder(BinaryTree<T> node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }

        this.PostOrder(node.LeftChild, action);
        this.PostOrder(node.RightChild, action);
        action(node.Value);
    }
}
