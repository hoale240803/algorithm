using algorithm.BinarySearch;
using Tree;


TreeNode rootNode = new TreeNode(1);
rootNode.left = new TreeNode(2);
// rootNode.left.left = new TreeNode(4);
// rootNode.left.right = new TreeNode(5);

rootNode.right = new TreeNode(3);
// rootNode.right.left = new TreeNode(6);
// rootNode.right.right = new TreeNode(7);
rootNode.PrintBFS();

BinaryTreeRightSideView b = new BinaryTreeRightSideView();
var res = b.RightSideViewV2(rootNode);
rootNode.PrintRightSideView(res);
















