using Algorithm.BinarySearch;
using Algorithm.SlideWindow;
using Algorithm.LinkedList;
using LinkedList;
using Algorithm.Tree;
using Tree;


// todo: output = 3
// todo: input = [1,null,2,3,4,5]

DiameterOfBinaryTreeClass diameterOfBinaryTreeClass = new DiameterOfBinaryTreeClass();
// var node1 = new TreeNode(1);
// var node2 = new TreeNode(2);
// var node3 = new TreeNode(3);
// var node4 = new TreeNode(4);
// var node5 = new TreeNode(5);
// node1.right = node2;
// node2.left = node3;
// node2.right = node4;
// node3.right = node5;

// var tree = node1;
// var result = diameterOfBinaryTreeClass.DiameterOfBinaryTree(tree);
// Console.WriteLine(result);




// todo: output = 2
// todo: input = [1,2,3]

var node1 = new TreeNode(1);
var node2 = new TreeNode(2);
node1.left = node2;

var tree = node1;
var result = diameterOfBinaryTreeClass.DiameterOfBinaryTree(tree);
Console.WriteLine(result);





































