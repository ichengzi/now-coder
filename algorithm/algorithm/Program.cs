using System;
using System.Collections.Generic;

namespace algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            //var tree = TreeHelper.GetTestTree();
            //var nodes = new TreePrinter().printTree(tree);
            //foreach (var item in nodes)
            //{
            //    foreach (var node in item)
            //    {
            //        Console.Write(node+"\t");
            //    }
            //    Console.WriteLine();
            //}

            //var res = new Rotation().ChkRotation("abcd",4,"bcda",4);

            Console.Read();
        }
    }
}

//-------------------------

class Rotation
{
    /*
     *如果对于一个字符串A，将A的前面任意一部分挪到后边去形成的字符串称为A的旋转词。
     * 比如A="12345",A的旋转词有"12345","23451","34512","45123"和"51234"。
     * 对于两个字符串A和B，请判断A和B是否互为旋转词。
     * 给定两个字符串A和B及他们的长度lena，lenb，请返回一个bool值，代表他们是否互为旋转词。 
     */
    public bool ChkRotation(string A, int lena, string B, int lenb)
    {
        if (lena != lenb)
            return false;

        var AA = string.Concat(A,A);
        for ( int i = 0; i < A.Length; i++)
        {
            if (A[i] == B[0])
            {
                for (int j = 1; j < B.Length; j++)
                {
                    if (AA[i + j] != B[j])
                        break;
                    else if (j == B.Length - 1)
                        return true;
                }
            }
        }

        return false;
    }
}

//--------------------------

class TreePrinter
{
    /*
     * 有一棵二叉树，请设计一个算法，按照层次打印这棵二叉树。
     * 给定二叉树的根结点root，请返回打印结果，结果按照每一层一个数组进行储存，
     * 所有数组的顺序按照层数从上往下，且每一层的数组内元素按照从左往右排列。保证结点数小于等于500。
     */
    public int[][] printTree(TreeNode root)
    {
        if (root == null)
            return null;

        List<int> row = new List<int>();
        List<int[]> rows = new List<int[]>();
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        TreeNode last = root,nlast = null;

        while (queue.Count != 0)
        {
            TreeNode tmp = queue.Dequeue();
            row.Add(tmp.val);
            if (tmp.left != null)
            {
                queue.Enqueue(tmp.left);
                nlast = tmp.left;
            }
            if (tmp.right != null)
            {
                queue.Enqueue(tmp.right);
                nlast = tmp.right;
            }
            if (last.Equals(tmp))
            {
                var arr = row.ToArray();
                rows.Add(arr);
                row.Clear();
                last = nlast;
            }
        }

        int[][] res = new int[rows.Count][];
        for (int i = 0; i < rows.Count; i++)
        {
            res[i] = rows[i];
        }
        return res;
    }
}

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x)
    {
        val = x;
    }
}

public class TreeHelper
{
    public static TreeNode GetTestTree()
    {
        /*
         *      1
         *     / \
         *   2     3
         *  /     / \  
         * 4     5   6
         *      /\
         *     7  8  
        */

        var n1 = new TreeNode(1);
        var n2 = new TreeNode(2);
        var n3 = new TreeNode(3);
        var n4 = new TreeNode(4);
        var n5 = new TreeNode(5);
        var n6 = new TreeNode(6);
        var n7 = new TreeNode(7);
        var n8 = new TreeNode(8);

        n1.left = n2;
        n1.right = n3;

        n2.left = n4;

        n3.left = n5;
        n3.right = n6;

        n5.left = n7;
        n5.right = n8;

        return n1;
    }
}