using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static Dictionary<int, Tree<int>> tree = new Dictionary<int, Tree<int>>();
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        ReadTree(n);
        Tree<int> root = GetRootNode();

        //01. Root Node
        //Console.WriteLine($"Root node: {root.Value}");

        //02. Print Tree;
        //PrintTree(root);

        //03. Leaf Nodes
        //List<Tree<int>> leafs = GetAllLeafNodesIncreacingOrder();
        //string leafTxt = "Leaf nodes: ";
        //PrintNodes(leafTxt, leafs);

        //04. Middle Nodes
        //List<Tree<int>> middleNodes = GetAllMiddleNodesIncreacingOrder();
        //string middleTxt = "Middle nodes: ";
        //PrintNodes(middleTxt, middleNodes);

        //05. Deepest Node
        //if (tree.Count != 0)
        //{
        //    Tree<int> deepestNode = GetDeepestNode();
        //    Console.WriteLine($"Deepest node: {deepestNode.Value}");
        //}

        //06. Longest Path
        //List<Tree<int>> list = GetLongestPath();
        //string text = "Longest path: ";
        //PrintNodes(text, list);

        //07. Paths With Given Sum
        //int sum = int.Parse(Console.ReadLine());
        //Console.WriteLine($"Paths of sum {sum}:");
        //FindAllPaths(root, sum);

        //08. Subtrees With Given Sum
        //int sum = int.Parse(Console.ReadLine());
        //Console.WriteLine($"Subtrees of sum {sum}:");
        //SubtreeOfGivenSum(root, sum);
    }

    private static int SubtreeOfGivenSum(Tree<int> node, int targetSum)
    {
        int currentSum = node.Value;
        foreach (var child in node.Children)
        {
            currentSum += SubtreeOfGivenSum(child, targetSum);
        }

        if (currentSum == targetSum)
        {
            List<int> subtree = new List<int>();
            GetNodes(node, subtree);
            Console.WriteLine(string.Join(" ", subtree));
        }
        return currentSum;
    }

    private static IEnumerable<int> GetNodes(Tree<int> node, List<int> result)
    {
        result.Add(node.Value);
        foreach (var child in node.Children)
        {
            GetNodes(child, result);
        }
        return result;
    }

    private static void FindAllPaths(Tree<int> node, int targetSum, int sum = 0)
    {
        sum += node.Value;
        if (sum == targetSum)
        {
            PrintPath(node);
        }

        foreach (var child in node.Children)
        {
            FindAllPaths(child, targetSum, sum);
        }
    }

    private static void PrintPath(Tree<int> node)
    {
        Stack<int> stack = new Stack<int>();
        stack.Push(node.Value);
        while (node.Parent != null)
        {
            node = node.Parent;
            stack.Push(node.Value);
        }
        Console.WriteLine(string.Join(" ", stack));
    }

    private static List<Tree<int>> GetLongestPath()
    {
        Stack<Tree<int>> stack = new Stack<Tree<int>>(); 
        Tree<int> current = GetDeepestNode();

        while (current != null)
        {
            stack.Push(current);
            current = current.Parent;
        }
        return stack.ToList();
    }

    private static Tree<int> GetDeepestNode()
    {
        int biggestDepth = 0;
        Tree<int> deepestNode = null;
        FindDeepest(GetRootNode(), 0, ref biggestDepth, ref deepestNode);
        return deepestNode;
    }

    private static void FindDeepest(Tree<int> currentNode, int currentDepth, ref int biggestDepth, ref Tree<int> deepestNode)
    {
        if (biggestDepth < currentDepth)
        {
            biggestDepth = currentDepth;
            deepestNode = currentNode;
        }

        foreach (var child in currentNode.Children)
        {
            FindDeepest(child, currentDepth + 1, ref biggestDepth, ref deepestNode);
        }
    }

    private static List<Tree<int>> GetAllMiddleNodesIncreacingOrder()
    {
        return tree
           .Values
           .Where(l => l.Children.Count > 0 && l.Parent != null)
           .OrderBy(l => l.Value)
           .ToList();
    }

    private static void PrintNodes(string text, List<Tree<int>> nodes)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var node in nodes)
        {
            sb.Append(node.Value + " ");
        }
        Console.WriteLine($"{text}{sb.ToString().TrimEnd()}");
    }

    private static List<Tree<int>> GetAllLeafNodesIncreacingOrder()
    {
        return tree
            .Values
            .Where(l => l.Children.Count == 0)
            .OrderBy(l => l.Value)
            .ToList();
    }

    private static void PrintTree(Tree<int> node, int indent = 0)
    {
        Console.WriteLine($"{new string(' ', indent)}{node.Value}");
        foreach (var child in node.Children)
        {
            PrintTree(child, indent + 2);
        }
    }

    private static Tree<int> GetRootNode()
    {
        return tree
            .Values
            .FirstOrDefault(x => x.Parent == null);
    }

    private static void ReadTree(int n)
    {
        for (int i = 0; i < n - 1; i++)
        {
            int[] input = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int parent = input[0];
            int child = input[1];

            if (!tree.ContainsKey(parent))
            {
                tree.Add(parent, new Tree<int>(parent));
            }

            if (!tree.ContainsKey(child))
            {
                tree.Add(child, new Tree<int>(child));
            }

            Tree<int> parentNode = tree[parent];
            Tree<int> childNode = tree[child];

            parentNode.Children.Add(childNode);
            childNode.Parent = parentNode;
        }
    }
}
