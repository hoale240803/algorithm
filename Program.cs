using algorithm.BinarySearch;
using Tree;


TreeNode rootNode = new TreeNode(5);
rootNode.left = new TreeNode(4);

rootNode.right = new TreeNode(6);
rootNode.right.left = new TreeNode(3);
rootNode.right.right = new TreeNode(7);
rootNode.PrintBFS();

ValidBST b = new ValidBST();
Console.WriteLine(b.IsValidBST(rootNode));
















