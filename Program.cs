using algorithm.BinarySearch;
using Tree;


TreeNode rootNode = new TreeNode(1);
rootNode.left = new TreeNode(2);
rootNode.left.left = new TreeNode(3);
rootNode.left.right = new TreeNode(4);

rootNode.right = new TreeNode(-1);
// rootNode.right.left = new TreeNode(6);
// rootNode.right.right = new TreeNode(7);
rootNode.PrintBFS();

CountGoodNodesBinaryTree b = new CountGoodNodesBinaryTree();
Console.WriteLine(b.GoodNodes(rootNode));
















