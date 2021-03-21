﻿using System;
using System.Collections.Generic;
public class Tree<T>
{
    public Tree(T value, params Tree<T>[] children)
    {
        Value = value;
        this.Children = new List<Tree<T>>();
        foreach (Tree<T> child in children)
        {
            this.Children.Add(child);
            child.Parent = this;
        }
    }

    public T Value { get; set; }
    public Tree<T> Parent { get; set; }
    public List<Tree<T>> Children { get; set; }
}


