using System.Linq;
using Trees.BinaryTree;
using Xunit;

namespace TreesTests.BinaryTreeTests
{
    public class Insert_Tests
    {
        // Arrange
        BinaryTree<int> tree;
        public Insert_Tests()
        {
            tree = new BinaryTree<int>();
        }

        [Fact]
        public void Insert_Create_Root()
        {
            //  Act
            tree.Insert(1);

            // Assert
            Assert.Equal(1, tree.Root.Value);

        }

        [Fact]
        public void Insert_Check_Left_Node()
        {
            //  Act
            tree.Insert(1);
            tree.Insert(2);

            //    1
            //   /
            //  2

            // Assert
            Assert.Equal(1, tree.Root.Value);
            Assert.Equal(2, tree.Root.Left.Value);
        }

        [Fact]
        public void Insert_Check_Right_Node()
        {

            // Act
            this.tree.Insert(1);
            tree.Insert(2);
            tree.Insert(3);

            //    1
            //   / \
            //  2   3

            // Assert
            Assert.Equal(1, tree.Root.Value);
            Assert.Equal(2, tree.Root.Left.Value);
            Assert.Equal(3, tree.Root.Right.Value);
        }

        [Fact]
        public void Multiple_Insertion_Check()
        {
            // Act
            new int[] { 1, 2, 3, 4, 5, 6, 7, 8, }
                .ToList()
                .ForEach(x => tree.Insert(x));

            //           1
            //         /    \
            //        2      3
            //      /  \    /  \ 
            //     4    5  6    7
            //    /
            //   8


            // Assert
            Assert.Equal(1, tree.Root.Value);
            Assert.Equal(2, tree.Root.Left.Value);
            Assert.Equal(3, tree.Root.Right.Value);
            Assert.Equal(4, tree.Root.Left.Left.Value);
            Assert.Equal(5, tree.Root.Left.Right.Value);
            Assert.Equal(6, tree.Root.Right.Left.Value);
            Assert.Equal(7, tree.Root.Right.Right.Value);
            Assert.Equal(8, tree.Root.Left.Left.Left.Value);



        }

        [Fact]
        public void Count_Check()
        {

            // Act
            new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }
            .Where(x => x % 2 == 0)
            .ToList()
            .ForEach(x => tree.Insert(x));

            //      2
            //     / \
            //    4   6   
            //   / \  
            //  8  10

            // Assert
            Assert.Equal(2, tree.Root.Value);
            Assert.Equal(4, tree.Root.Left.Value);
            Assert.Equal(6, tree.Root.Right.Value);
            Assert.Equal(8, tree.Root.Left.Left.Value);
            Assert.Equal(10, tree.Root.Left.Right.Value);

            Assert.Equal(5, tree.Count);
        }

        [Fact]
        public void Level_Order_Traverse_Test()
        {
            // Act
            new int[] { 1, 2, 3, 4, 5, 6, 7, 8, }
                .ToList()
                .ForEach((x) => tree.Insert(x));

            var list = BinaryTree<int>.LevelOredrTraverse(tree.Root);

            // Assert
            Assert.Collection(list,
               item => Assert.Equal(tree.Root.Value, item.Value),
               item => Assert.Equal(tree.Root.Left.Value, item.Value),
               item => Assert.Equal(3, item.Value),
               item => Assert.Equal(4, item.Value),
               item => Assert.Equal(5, item.Value),
               item => Assert.Equal(6, item.Value),
               item => Assert.Equal(7, item.Value),
               item => Assert.Equal(8, item.Value));

            Assert.Equal(8, tree.Count);

        }

        [Fact]
        public void GetEnumerator_Test()
        {

            // Act
            new int[] { 1, 2, 3, 4, 5, 6, 7 }
            .ToList()
            .ForEach(x => tree.Insert(x));

            var list = BinaryTree<int>.LevelOredrTraverse(tree.Root);
            // Assert
            Assert.Collection(list,
                item => Assert.Equal(tree.Root.Value, item.Value),
                item => Assert.Equal(2, item.Value),
                item => Assert.Equal(3, item.Value),
                item => Assert.Equal(4, item.Value),
                item => Assert.Equal(5, item.Value),
                item => Assert.Equal(6, item.Value),
                item => Assert.Equal(7, item.Value));

            Assert.Equal(7, tree.Count);

        }

        [Fact]
        public void Constractor_Test()
        {
            // Arrange & Act
            var tree = new BinaryTree<int>(new int[] { 1, 2, 3, 4, 5 });
            var list = BinaryTree<int>.LevelOredrTraverse(tree.Root);

            // Assert
            Assert.Collection(list,
                item => Assert.Equal(tree.Root.Value, item.Value),
                item => Assert.Equal(2, item.Value),
                item => Assert.Equal(3, item.Value),
                item => Assert.Equal(4, item.Value),
                item => Assert.Equal(5, item.Value)
                );

        }

        [Fact]
        public void IsLeaf_Test()
        {
            // Act
            new int[] { 1, 2, 3, 4, 5, 6, 7 }
            .ToList()
            .ForEach(x => tree.Insert(x));

            // Assert

            //       1
            //      / \
            //    2    3
            //   / \   / \ 
            //  4   5  6  7


            Assert.True(BinaryTree<int>.IsLeaf(tree.Root.Left.Left));

        }

        [Fact]
        public void IsNotLeaf_Test()
        {
            // Act
            new int[] { 1, 2, 3, 4, 5, 6, 7 }
            .ToList()
            .ForEach(x => tree.Insert(x));

            // Assert

            //       1
            //      / \
            //    2    3
            //   / \   / \ 
            //  4   5  6  7

            Assert.False(BinaryTree<int>.IsLeaf(tree.Root.Right));
        }

        [Fact]
        public void Is_Binary_Tree_InOrder()
        {
            // In Order Binary Tree

            new int[] { 10, 5, 12, 3, 8 }
            .ToList()
            .ForEach(x => tree.Insert(x));

            //      10
            //     /  \
            //    5    12   
            //   / \  
            //  3   8

            Assert.True(tree.IsInOrder(tree.Root));

        }

        [Fact]
        public void Is_Binary_Tree_OutOfOrder()
        {
            // Out of Order Binary Tree
            new int[] { 1, 2, 3, 4, 5, 6, 7, 8, }
            .ToList()
            .ForEach(x => tree.Insert(x));

            //           1
            //         /    \
            //        2      3
            //      /  \    /  \ 
            //     4    5  6    7
            //    /
            //   8

            Assert.False(tree.IsInOrder(tree.Root));
        }

    }

}
