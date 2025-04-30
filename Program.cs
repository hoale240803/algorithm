using Algorithm.BinarySearch;
using Algorithm.SlideWindow;
using Algorithm.LinkedList;
using LinkedList;
using Algorithm.Tree;


InvertBinaryTree invertBinaryTree = new InvertBinaryTree();
var tree = new TreeNode(1, new TreeNode(2, new TreeNode(4), new TreeNode(5)), new TreeNode(3, new TreeNode(6), new TreeNode(7)));
tree.PrintTree();
var result = invertBinaryTree.InvertTree(tree);
result.PrintTree();




























