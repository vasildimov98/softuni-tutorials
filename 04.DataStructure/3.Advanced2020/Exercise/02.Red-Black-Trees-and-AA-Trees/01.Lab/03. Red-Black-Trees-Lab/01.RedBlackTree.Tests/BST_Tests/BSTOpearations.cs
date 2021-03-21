namespace _01.BSTOpearations.Tests
{
    using System;
    using System.Text;
    using System.Linq;
    using NUnit.Framework;
    using System.Collections.Generic;

    using _01.RedBlackTree;

    public class BSTOpearations
    {
        private IBinarySearchTree<int> _bst;

        [SetUp]
        public void InitializeBST()
        {
            this._bst = new RedBlackTree<int>();
            this._bst.Insert(12);
            this._bst.Insert(21);
            this._bst.Insert(5);
            this._bst.Insert(1);
            this._bst.Insert(8);
            this._bst.Insert(18);
            this._bst.Insert(23);
        }

        [Test]
        public void TestContainsCheckReturnedTrue()
        {
            Assert.IsTrue(this._bst.Contains(5));
        }

        [Test]
        public void TestContainsCheckReturnedFalse()
        {
            Assert.IsFalse(this._bst.Contains(77));
        }

        [Test]
        public void TestEachInOrderWorksCorrectly()
        {
            StringBuilder result = new StringBuilder();
            this._bst.EachInOrder((el) => result.Append($"{el}, "));

            StringAssert.AreEqualIgnoringCase("1, 5, 8, 12, 18, 21, 23, ", result.ToString());
        }

        [Test]
        public void TestRangeWorksCorrectlyWithElements()
        {
            int[] expected = { 1, 5, 8, 12, 18 };
            List<int> actual = this._bst.Range(1, 18)
                .OrderBy(el => el)
                .ToList();

            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [Test]
        public void TestRangeWorksCorrectlyWithNoElementsFound()
        {
            var actual = this._bst.Range(25, 70);

            Assert.IsEmpty(actual);
        }

        [Test]
        public void TestDeleteMinWorksCorrectlyWithOne()
        {
            this._bst.DeleteMin();

            Assert.IsFalse(this._bst.Contains(1));
        }

        [Test]
        public void TestDeleteMinWorksCorrectlyWithTwoDeletions()
        {
            this._bst.DeleteMin();
            this._bst.DeleteMin();

            Assert.IsFalse(this._bst.Contains(1));
            Assert.IsFalse(this._bst.Contains(5));
        }

        [Test]
        public void TestDeleteMinThrowsExceptionOnEmptyCollection()
        {
            var myBst = new RedBlackTree<int>();

            Assert.Throws<InvalidOperationException>(() => myBst.DeleteMin());
        }

        [Test]
        public void TestDeleteMaxWorksCorrectlyWithOne()
        {
            this._bst.DeleteMax();

            Assert.IsFalse(this._bst.Contains(23));
        }

        [Test]
        public void TestDeleteMaxWorksCorrectlyWithTwoDeletions()
        {
            this._bst.DeleteMax();
            this._bst.DeleteMax();

            Assert.IsFalse(this._bst.Contains(23));
            Assert.IsFalse(this._bst.Contains(21));
        }

        [Test]
        public void TestDeleteMaxThrowsExceptionOnEmptyCollection()
        {
            var myBst = new RedBlackTree<int>();

            Assert.Throws<InvalidOperationException>(() => myBst.DeleteMax());
        }

        [Test]
        public void TestCountWorksCorreclyAfterInsert()
        {
            Assert.AreEqual(7, this._bst.Count());
        }

        [Test]
        public void TestCountWorksCorreclyAfterDeleteMin()
        {
            this._bst.DeleteMin();

            Assert.AreEqual(6, this._bst.Count());
        }

        [Test]
        public void TestCountWorksCorreclyAfterDeleteMax()
        {
            this._bst.DeleteMax();

            Assert.AreEqual(6, this._bst.Count());
        }

        [Test]
        public void TestDeleteThrowsExceptionOnEmptyCollection()
        {
            var myBst = new RedBlackTree<int>();

            Assert.Throws<InvalidOperationException>(() => myBst.Delete(2));
        }

        [Test]
        public void TestCountWorksCorreclyAfterDelete()
        {
            this._bst.Delete(18);

            Assert.AreEqual(6, this._bst.Count());
        }

        [Test]
        public void TestDeleteWorksCorrectlyLeafNode()
        {
            this._bst.Delete(18);
            this._bst.Delete(18);

            Assert.IsFalse(this._bst.Contains(18));
            Assert.AreEqual(6, this._bst.Count());
        }

        [Test]
        public void TestDeleteWorksCorrectlyNodeWithOnlyRightSubtree()
        {
            this._bst.Delete(18);
            this._bst.Delete(21);

            Assert.IsFalse(this._bst.Contains(18));
            Assert.IsFalse(this._bst.Contains(21));
            Assert.AreEqual(5, this._bst.Count());
        }

        [Test]
        public void TestDeleteWorksCorrectlyNodeWithOnlyLeftSubtree()
        {
            this._bst.Delete(8);
            this._bst.Delete(5);

            Assert.IsFalse(this._bst.Contains(5));
            Assert.IsFalse(this._bst.Contains(8));
            Assert.AreEqual(5, this._bst.Count());
        }

        [Test]
        public void TestDeleteWorksCorrectlyNodeWithTwoChildren()
        {
            this._bst.Delete(21);

            Assert.AreEqual(6, this._bst.Count());
            Assert.IsFalse(this._bst.Contains(21));
        }

        [Test]
        public void TestDeleteWorksCorrectlyRootWithOnlyLeftSubtree()
        {
            var bst = new RedBlackTree<int>();
            bst.Insert(12);
            bst.Insert(5);
            bst.Insert(1);
            bst.Insert(8);

            bst.Delete(12);

            Assert.AreEqual(3, bst.Count());
            Assert.IsFalse(bst.Contains(12));
        }

        [Test]
        public void TestDeleteWorksCorrectlyRootWithOnlyRightSubtree()
        {
            var bst = new RedBlackTree<int>();
            bst.Insert(12);
            bst.Insert(21);
            bst.Insert(18);
            bst.Insert(23);

            bst.Delete(12);

            Assert.AreEqual(3, bst.Count());
            Assert.IsFalse(bst.Contains(12));
        }

        [Test]
        public void TestDeleteWorksCorrectlyRootWithTwoChildren()
        {
            this._bst.Delete(12);

            Assert.AreEqual(6, this._bst.Count());
            Assert.IsFalse(this._bst.Contains(12));
        }

        [Test]
        public void TestRankShouldReturnZero()
        {
            int actualRank = this._bst.Rank(1);

            Assert.AreEqual(0, actualRank);
        }

        [Test]
        public void TestRankShouldReturnCorrectValueElementIsInTheLeftSubtree()
        {
            int actualRank = this._bst.Rank(5);

            Assert.AreEqual(1, actualRank);
        }

        [Test]
        public void TestRankShouldReturnCorrectValueIfElementIsInTheRightSubtree()
        {
            int actualRank = this._bst.Rank(23);

            Assert.AreEqual(6, actualRank);
        }

        [Test]
        public void TestRankShouldReturnValueEqualToTheCountOfTreeIfValueIsGreaterThanEveryElementInTheTree()
        {
            int actualRank = this._bst.Rank(300);

            Assert.AreEqual(this._bst.Count(), actualRank);
        }

        [Test]
        public void TestCeilingOfNodeShouldThrowExceptionIfThereIsNoSuchNode()
        {
            Assert.That(() => this._bst.Ceiling(23),
                Throws.
                InvalidOperationException.
                With.Message.
                EqualTo("Tree does't contain such node"));
        }

        [Test]
        public void TestCeilingOfNodeShouldBeTheSmallesValueWhichIsGreaterThanSearchedOne()
        {
            var actualCeiling = this._bst.Ceiling(18);

            Assert.AreEqual(21, actualCeiling);
        }

        [Test]
        public void TestFloorMethodShouldThrowExceptionIfThereIsNoSuchNode()
        {
            Assert.That(() => this._bst.Floor(1),
                Throws.
                InvalidOperationException.
                With.Message.
                EqualTo("Tree does't contain such node"));
        }

        [Test]
        public void TestFloorMethodShouldReturnTheGreatestValueWhichIsSmallerThanTheSearchedOne()
        {
            var actualCeiling = this._bst.Floor(18);

            Assert.AreEqual(12, actualCeiling);
        }
    }
}