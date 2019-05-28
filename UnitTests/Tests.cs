using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReverseLinkedList;

namespace UnitTests
{
    [TestClass]
    public class Tests
    {
        //[TestInitialize]
        //public void TestInitialize()
        //{ }


        [TestMethod]
        public void TestEmptyList()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestTwoValList()
        {
            var list = PopulateListFromValues(new List<int>() { 1, 2 });

            var newHead = Program.ReverseIt(list[0]);
            list.Reverse();
            var passed = CompareListWithNewHead(list, newHead);
            Assert.IsTrue(passed);
        }

        [TestMethod]
        public void TestNonConsecutiveValuesList()
        {
            var list = PopulateListFromValues(new List<int>() { 1, 3, 99, 101 });
            var newHead = Program.ReverseIt(list[0]);
            list.Reverse();
            var passed = CompareListWithNewHead(list, newHead);
            Assert.IsTrue(passed);
        }

        private bool CompareListWithNewHead(List<Node> list, Node head)
        {
            bool passed = true;
            Node node = head;
            foreach (Node n in list)
            {
                if (n.Val != node.Val )
                {
                    passed = false;
                    break;
                }

                node = node.Next;
            }

            return passed;
        }

        List<Node> PopulateListFromValues(List<int> vals)
        {
            List<Node> list = null;
            if (!vals.Any())
            {
                return list;
            }

            list = new List<Node>();
            var now = new Node(vals[0], null);
            list.Add(now);
            for (int i = 1; i < vals.Count; i++)
            {
                var soon = new Node(vals[i], null);
                now.Next = soon;
                now = soon;
                list.Add(now);
            }

            return list;
        }
    }
}