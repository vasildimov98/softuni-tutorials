namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TreeFactory
    {
        private readonly Dictionary<int, Tree<int>> nodesByKeys;

        public TreeFactory()
        {
            this.nodesByKeys = new Dictionary<int, Tree<int>>();
        }

        public Tree<int> CreateTreeFromStrings(string[] input)
        {
            foreach (var line in input)
            {
                var nodesArg = line
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                var parentKey = nodesArg[0];
                var childKey = nodesArg[1];

                this.AddEdge(parentKey, childKey);
            }

            return this.GetRoot();
        }

        public Tree<int> CreateNodeByKey(int key)
        {
            if (!nodesByKeys.ContainsKey(key))
            {
                this.nodesByKeys[key] = new Tree<int>(key);
            }

            return this.nodesByKeys[key];
        }

        public void AddEdge(int parent, int child)
        {
            var parentNode = this.CreateNodeByKey(parent);
            var childNode = this.CreateNodeByKey(child);

            parentNode.AddChild(childNode);
            childNode.AddParent(parentNode);
        }

        private Tree<int> GetRoot()
        {
            foreach (var nodeByKey in this.nodesByKeys)
            {
                if (nodeByKey.Value.Parent == null)
                {
                    return nodeByKey.Value;
                }
            }

            return null;
        }
    }
}
