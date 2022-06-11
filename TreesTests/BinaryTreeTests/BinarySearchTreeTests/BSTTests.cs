using System.Collections.Generic;
using System.Linq;
using Trees.BinaryTree;
using Trees.BinaryTree.BinarySearchTree;
using Xunit;

namespace TreesTests.BinaryTreeTests.BinarySearchTreeTests
{
    public class BST_Tests
    {
        // Arrage
        BST<int> bst;
        public BST_Tests()
        {
            bst = new BST<int>();
        }

        [Fact]
        public void Add_Root_Test()
        {
            // Act
            bst.Add(15);

            // Assert
            Assert.Equal(15, bst.Root.Value);

        }

        [Fact]
        public void Adding_with_IEnumerable_Constructor_LevelOredr()
        {
            // Act
            var bst = new BST<int>(new List<int> { 15, 10, 40, 7, 3, 18, 0, 80, 99, 30, 40 });
            var list = BinaryTree<int>.LevelOredrTraverse(bst.Root);

            //              15 
            //           /      \
            //          10        40
            //         /        /     \
            //        7       18       80
            //       /          \     /  \
            //      3           30   40   99
            //     /
            //    0


            // Assert
            Assert.Collection(list,
                item => Assert.Equal(15, item.Value),
                item => Assert.Equal(10, item.Value),
                item => Assert.Equal(40, item.Value),
                item => Assert.Equal(7, item.Value),
                item => Assert.Equal(18, item.Value),
                item => Assert.Equal(80, item.Value),
                item => Assert.Equal(3, item.Value),
                item => Assert.Equal(30, item.Value),
                item => Assert.Equal(40, item.Value),
                item => Assert.Equal(99, item.Value),
                item => Assert.Equal(0, item.Value));
        }

        [Fact]
        public void Adding_with_IEnumerable_Constructor_InOrderIteration()
        {
            // Act
            var bst = new BST<int>(new List<int> { 23, 16, 44, 3, 22, 99, 37 });


            //      23 
            //      / \
            //    16    44
            //   / \    / \
            //  3  22  37 99

            var list = BinaryTree<int>.InOrderIterationTraverse(bst.Root);
            Assert.Collection(list,
                item => Assert.Equal(3, item),
                item => Assert.Equal(16, item),
                item => Assert.Equal(22, item),
                item => Assert.Equal(23, item),
                item => Assert.Equal(37, item),
                item => Assert.Equal(44, item),
                item => Assert.Equal(99, item));
        }

        [Fact]
        public void FindMin_Test()
        {
            // Act
            var bst = new BST<int>(new List<int> { 23, 16, 44, 3, 22, 99, 37 });

            //      23 
            //      / \
            //    16    44
            //   / \    / \
            //  3  22  37 99

            var min = bst.FindMin(bst.Root);

            // Assert
            Assert.Equal(3, min);
        }

        [Fact]
        public void FindMin_Test_without_Parameter()
        {
            // Act
            var bst = new BST<int>(new List<int> { 23, 16, 44, 3, 22, 99, 37 });

            //      23 
            //      / \
            //    16    44
            //   / \    / \
            //  3  22  37 99

            var min = bst.FindMin();

            // Assert
            Assert.Equal(3, min);
        }

        [Fact]
        public void Findmax_Test()
        {
            // Act
            var bst = new BST<int>(new List<int> { 23, 16, 44, 3, 22, 99, 37 });

            //      23 
            //      / \
            //    16    44
            //   / \    / \
            //  3  22  37 99

            var max = bst.FindMax();

            // Assert
            Assert.Equal(99, max);
        }

        [Fact]
        public void Find_Test()
        {
            // Act
            var bst = new BST<int>(new List<int> { 23, 16, 44, 3, 22, 99, 37 });

            //      23 
            //      / \
            //    16    44
            //   / \    / \
            //  3  22  37 99

            var node = bst.Find(22);

            // Assert
            Assert.Equal(node, bst.Root.Left.Right);
        }

        [Fact]
        public void Remove_A_Leaf()
        {
            // Act
            var bst = new BST<int>(new List<int> { 60, 40, 70, 20, 45, 65, 85 });

            //      60 
            //      / \
            //    40    70
            //   / \    / \
            // [20] 45  65 85

            //      60 
            //      / \
            //    40    70
            //     \    / \
            //     45  65 85

            var node = bst.Remove(bst.Root, 20);

            // Assert
            var list = BinaryTree<int>.InOrderIterationTraverse(bst.Root);
            Assert.Collection(list,
                item => Assert.Equal(40, item),
                item => Assert.Equal(45, item),
                item => Assert.Equal(60, item),
                item => Assert.Equal(65, item),
                item => Assert.Equal(70, item),
                item => Assert.Equal(85, item));
        }

        [Fact]
        public void Remove_A_Node_With_One_Child()
        {
            // Act
            var bst = new BST<int>(new List<int> { 60, 40, 70, 20, 45, 65, 85 });

            //      60 
            //      / \
            //    40    70
            //   / \    / \
            //  20 45  65 85

            //      60 
            //     /   \
            //  [40]    70
            //     \    / \
            //      45  65 85

            var node = bst.Remove(bst.Root, 20);
            node = bst.Remove(bst.Root, 40);

            //      60 
            //      / \
            //    45    70
            //          / \
            //         65 85



            // Assert
            var list = BinaryTree<int>.InOrderIterationTraverse(bst.Root);
            Assert.Collection(list,
                item => Assert.Equal(45, item),
                item => Assert.Equal(60, item),
                item => Assert.Equal(65, item),
                item => Assert.Equal(70, item),
                item => Assert.Equal(85, item));
        }

        [Fact]
        public void Remove_A_Node_With_Two_Child()
        {
            // Act
            var bst = new BST<int>(new List<int> { 60, 40, 70, 20, 45, 65, 85 });

            //      60 
            //      / \
            //    40    70
            //   / \    / \
            //  20 45  65 85

            //      60 
            //      / \
            //    40    70
            //     \    / \
            //      45  65 85

            var node = bst.Remove(bst.Root, 20);
            node = bst.Remove(bst.Root, 40);

            //      60 
            //      / \
            //    45    70
            //          / \
            //         65 85

            node = bst.Remove(bst.Root, 60);

            //      65 
            //      / \
            //    45    70
            //           \
            //            85

            // Assert
            var list = BinaryTree<int>.InOrderIterationTraverse(bst.Root);
            Assert.Collection(list,
                item => Assert.Equal(45, item),
                item => Assert.Equal(65, item),
                item => Assert.Equal(70, item),
                item => Assert.Equal(85, item));

            Assert.Equal(65, bst.Root.Value);
        }


    }
}
