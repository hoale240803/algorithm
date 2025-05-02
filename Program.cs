using Algorithm.BinarySearch;
using Algorithm.SlideWindow;
using Algorithm.LinkedList;
using LinkedList;
using BinarySearch;
using Tree;

// Input: p = [1,2,3], q = [1,2,3]
// Output: true
SameBinaryTree sameBinaryTree = new SameBinaryTree();
TreeNode p = new TreeNode(1);
TreeNode p1 = new TreeNode(2);
TreeNode p2 = new TreeNode(3);
p.left = p1;
p.right = p2;
Console.WriteLine(sameBinaryTree.IsSameTree(p, p));

// Input: p = [4,7], q = [4,null,7]
// Output: false
TreeNode q = new TreeNode(4);
TreeNode q1 = new TreeNode(7);
q.left = q1;
Console.WriteLine(sameBinaryTree.IsSameTree(p, q));





























