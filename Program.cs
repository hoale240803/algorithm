using algorithm.BinarySearch;
using Tree;


TreeNode rootNode = new TreeNode(5);
rootNode.left = new TreeNode(3);
rootNode.left.left = new TreeNode(1);
rootNode.left.right = new TreeNode(4);
rootNode.left.left.left = null;
rootNode.left.left.right = new TreeNode(2);

rootNode.right = new TreeNode(8);
rootNode.right.left = new TreeNode(7);
rootNode.right.right = new TreeNode(9);
rootNode.PrintBFS();

var temp = LowestCommonAncestorBinarySearchTree.LowestCommonAncestor(rootNode, rootNode.left, rootNode.right);
Console.WriteLine(temp.val);

var tem2 = LowestCommonAncestorBinarySearchTree.LowestCommonAncestor(rootNode, rootNode.left, rootNode.left.right);
Console.WriteLine(tem2.val);















