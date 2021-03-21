namespace _02.Two_Three.Tests
{
    using System;
    using NUnit.Framework;
    using _02.Two_Three;

    public class TwoThreeTreeTests
    {
        [Test]
        public void TestInsertZero()
        {
            var tree = new TwoThreeTree<string>();
            Assert.AreEqual("", tree.ToString());
        }

        [Test]
        public void TestInsertSingle()
        {
            var tree = new TwoThreeTree<string>();
            tree.Insert("13");

            Assert.AreEqual("13 " + Environment.NewLine, tree.ToString());
        }

        [Test]
        public void TestInsertMany()
        {
            var tree = new TwoThreeTree<string>();
            tree.Insert("A");
            tree.Insert("B");
            tree.Insert("C");
            Assert.AreEqual("B " + Environment.NewLine +
                            "A " + Environment.NewLine +
                            "C " + Environment.NewLine, tree.ToString());
        }

        [Test]
        public void TestInsert13Elements()
        {
            var tree = new TwoThreeTree<string>();

            String[] arr = { "F", "C", "G", "A", "B", "D", "E", "K", "I", "G", "H", "J", "K" };
            for (int i = 0; i < 13; i++)
            {
                tree.Insert(arr[i]);
            }

            Assert.AreEqual("D G" + Environment.NewLine +
                            "B " + Environment.NewLine +
                            "A " + Environment.NewLine +
                            "C " + Environment.NewLine +
                            "F " + Environment.NewLine +
                            "E " + Environment.NewLine +
                            "G " + Environment.NewLine +
                            "I K" + Environment.NewLine +
                            "H " + Environment.NewLine +
                            "J " + Environment.NewLine +
                            "K " + Environment.NewLine, tree.ToString());
        }

        [Test]
        public void TestInsertNumbers()
        {
            var tree = new TwoThreeTree<string>();

            String[] arr = { "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34"};
            for (int i = 0; i < arr.Length; i++)
            {
                tree.Insert(arr[i]);
            }
        }
    }
}