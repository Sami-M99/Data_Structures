using System;
using System.Collections.Generic;
using Trees.BinaryTree;
using Xunit;

namespace TreesTests.BinaryTreeTests
{
    public class Deletion_Tests
    {

        [Fact]
        public void Delete_Test()
        {
            /***  Complete Binary Tree  ***/

            // Act
            var bst = new BinaryTree<int>(new List<int> { 60, 40, 70, 20, 45, 65, 85 });

            //      60 
            //      / \
            //    40    70
            //   / \    / \
            //  20 45  65 85

            //      60 
            //      / \
            //    40    70
            //   / \    / \
            //  20 45  65 

            var node = bst.Delete();
            Assert.Equal(85, node);

            // Assert
            var list = BinaryTree<int>.LevelOredrTraverse(bst.Root);
            Assert.Collection(list,
                item => Assert.Equal(60, item.Value),
                item => Assert.Equal(40, item.Value),
                item => Assert.Equal(70, item.Value),
                item => Assert.Equal(20, item.Value),
                item => Assert.Equal(45, item.Value),
                item => Assert.Equal(65, item.Value));
        }

        [Fact]
        public void Remove_A_Leaf()
        {
            // Act
            var bst = new BinaryTree<int>(new List<int> { 60, 40, 70, 20, 45, 65, 85 });

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

            var node = bst.Delete(20);
            Assert.Equal(20, node);
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
            var bst = new BinaryTree<int>(new List<int> { 60, 40, 70, 20, 45, 65, 85 });

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

            int node = bst.Delete(20);  // bst.Root.Left.Left
            node = bst.Delete(bst.Root.Left); // 40

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
            var bst = new BinaryTree<int>(new List<int> { 60, 40, 70, 20, 45, 65, 85 });

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

            var node = bst.Delete(bst.Root, 20);
            node = bst.Delete(bst.Root, 40);

            //      60 
            //      / \
            //    45    70
            //          / \
            //         65 85

            node = bst.Delete(bst.Root, 60);

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
