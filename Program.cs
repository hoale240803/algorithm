using Algorithm.BinarySearch;
using Algorithm.SlideWindow;
using Algorithm.LinkedList;
using LinkedList;
using BinarySearch;
using Tree;

// Input: root = [1,2,3,null,null,4]
// Output: true

BalancedBinaryTree balancedBinaryTree = new BalancedBinaryTree();
TreeNode node1 = new TreeNode(1);
TreeNode node2 = new TreeNode(2);
TreeNode node3 = new TreeNode(3);
TreeNode node4 = new TreeNode(4);
node1.left = node2;
node1.right = node3;
node3.left = node4;
Console.WriteLine(balancedBinaryTree.IsBalanced(node1));


// Input: root = [1,2,3,null,null,4,null,5]
// Output: false

BalancedBinaryTree balancedBinaryTree2 = new BalancedBinaryTree();
TreeNode root2 = new TreeNode(1, new TreeNode(2, null, null), new TreeNode(3, new TreeNode(4, null, null), new TreeNode(5, null, null)));
Console.WriteLine(balancedBinaryTree2.IsBalanced(root2));





































