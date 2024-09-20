using System.Collections;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

public class Program
{
    public static void Main()
    {
        // 594
        int[] array = { 1, 3, 2, 2, 5, 2, 3, 7 };
        //Console.WriteLine(LeetCode.FindLHS(array));

        // 441
        int num = 8;
        //Console.WriteLine(LeetCode.ArrangeCoins(num));

        // 20
        string s = "{}()[()[]{{}}[]]";
        //Console.WriteLine(LeetCode.IsValid(s));

        // 21
        // Define list1: 1 -> 2 -> 4
        ListNode list1 = new ListNode(1);
        list1.next = new ListNode(2);
        list1.next.next = new ListNode(4);
        list1.next.next.next = list1;

        // Define list2: 1 -> 3 -> 4
        ListNode list2 = new ListNode(1);
        list2.next = new ListNode(3);
        list2.next.next = new ListNode(4);

        // Print both lists before merging
        //Console.WriteLine("List 1:");
        //LeetCode.PrintList(list1);

        //Console.WriteLine("List 2:");
        //LeetCode.PrintList(list2);

        // Merge the two lists and print the result
        //ListNode mergedList = LeetCode.MergeTwoLists(list1, list2);
        //Console.WriteLine("Merged List:");
        //LeetCode.PrintList(mergedList);
        
        // 121
        int[] prices = { 7,6,5,4,3,1 };
        //Console.WriteLine(LeetCode.MaxProfit(prices));

        // 125
        s = "A man, a plan, a canal: Panama";
        //Console.WriteLine(Leetcode.IsPalindrome(s));

        // 226        
        // Manually creating nodes
        TreeNode root = new TreeNode(1);  // Root node with value 1
        root.left = new TreeNode(2);      // Left child of root with value 2
        root.right = new TreeNode(3);     // Right child of root with value 3
        root.left.left = new TreeNode(4); // Left child of node with value 2
        root.left.right = new TreeNode(5);// Right child of node with value 2
        root.right.right = new TreeNode(6); // Right child of node with value 3

        // Tree structure:
        //       1
        //      / \
        //     2   3
        //    / \   \
        //   4   5   6

        // Output the root value
        //Console.WriteLine("Root Node Value: " + root.val);
        //Console.WriteLine("Left Child of Root: " + root.left.val);
        //Console.WriteLine("Right Child of Root: " + root.right.val);
        //Console.WriteLine("Left Child of Node 2: " + root.left.left.val);
        //Console.WriteLine("Right Child of Node 2: " + root.left.right.val);
        //Console.WriteLine("Right Child of Node 3: " + root.right.right.val);
        //Console.WriteLine(LeetCode.InvertTree(root));


        //Console.WriteLine($"Start Tree Nodes: {Leetcode.PrintTreeNodes(root)}");
        //TreeNode result = Leetcode.InvertTree(root);
        //Console.WriteLine($"Inverted Tree Nodes: {Leetcode.PrintTreeNodes(result)}");


        // 242
        s = "anagram";
        string t = "nagaram";
        //Console.WriteLine($"Anagram test: {Leetcode.IsAnagram(s,t)}");

        // 704
        int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8 };
        int target = 1;
        //Console.WriteLine($"Binary Search: Target {target} was found at index {Leetcode.BinarySearch(nums, target)}");

        // 242
        nums = [1, 10, 11, 3, 31, 4, 32, 22, 43, 2];
        //Console.WriteLine($"Contains Duplicate: {Leetcode.ContainsDuplicate(nums)}");

        //Console.WriteLine(Leetcode.LowestCommonAncestor(root, root.left,root.right).val);

        //Console.WriteLine(Leetcode.IsBalanced(root));

        Console.WriteLine(Leetcode.HasCycle(list1));
    }
}




public static class Leetcode
{
    //141. Linked List Cycle
    public static bool HasCycle(ListNode head)
    {
        // store nodes as visited
        // if revisiting, then return false

        ListNode slow = head;
        ListNode fast = head;

        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;

            if (slow == fast)
                return true;
        }
        return false;
    }

    //110. Balanced Binary Tree
    public static bool IsBalanced(TreeNode root)
    {
        return CheckHeight(root) != -1;
    }
    public static int CheckHeight(TreeNode node)
    {
        if (node == null)
            return 0;

        // Recursively check the height of the left subtree
        int left = CheckHeight(node.left);
        if (left == -1) return -1; // Left subtree is unbalanced

        // Recursively check the height of the right subtree
        int right = CheckHeight(node.right);
        if (right == -1) return -1; // Right subtree is unbalanced

        // If the difference in height is more than 1, it;s unbalanced
        if (Math.Abs(left - right) > 1) return -1;

        // Return the height of the current node
        return Math.Max(left, right) + 1;
    }

    //235. Lowest Common Ancestor of a Binary Search Tree
    public static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root == null || root == p || root == q) 
            return root;

        // Recurse on left and right subtrees
        TreeNode left = LowestCommonAncestor(root.left, p, q);
        TreeNode right = LowestCommonAncestor(root.right, p, q);

        // If both left and right are non-null, current node is the LCA
        if (left != null && right != null)
            return root;

        // Otherwise, return the non-null child (either left or right)
        return left != null ? left: right;
    }

    //733. Flood Fill -- **
    public static int[][] FloodFill(int[][] image, int sr, int sc, int color)
    {
     

        return null;
    }

    //217. Contains Duplicate
    public static bool ContainsDuplicate(int[] nums)
    {
        Dictionary<int, int> occurances = new Dictionary<int, int>();

        foreach (var n in nums)
        {
            if (occurances.ContainsKey(n))
                return true;
            else
                occurances[n] = 1;
        }

        return false;
    }

    //704. Binary Search
    public static int BinarySearch(int[] nums, int target)
    {
        int l = 0;
        int r = nums.Length - 1;

        while (l <= r)
        {
            int mid = (l + r) / 2;

            if (nums[mid] == target)
                return mid;
            else if (nums[mid] < target)
                l = mid + 1;
            else
                r = mid - 1;
        }

        return -1;
    }

    //242. Valid Anagram
    public static bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length) return false;
        // Option 1. Sort both strings and compare char by char in a while loop

        // Char array inorder to sort
        //Array ss = s.ToCharArray();
        //Array tt = t.ToCharArray();

        //// Sort Array 
        //Array.Sort(ss);
        //Array.Sort(tt);



        // Option 2. Loop through a string, store char as a key and the occurance as a value
        //           Then loop through the comparable string and remove the values from the dictionary
        //           If dictionary is not empty, then return false
        //Dictionary<char, int> occurances = new Dictionary<char, int>();

        //foreach (char c in s)
        //{
        //    if (occurances.ContainsKey(c))
        //        occurances[c]++;
        //    else
        //        occurances[c] = 1;
        //}

        //foreach (char c in t)
        //{
        //    if (occurances.ContainsKey(c))
        //    {
        //        if (occurances[c] == 1)
        //            occurances.Remove(c);
        //        else
        //            occurances[c]--;
        //    }
        //    else
        //        return false;
        //}

        //if (occurances.Count == 0)
        //    return true;

        //return false;
        var symbolFrequency = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++)
        {
            symbolFrequency.TryAdd(s[i], 0);
            symbolFrequency.TryAdd(t[i], 0);

            symbolFrequency[s[i]]++;
            symbolFrequency[t[i]]--;
        }

        return symbolFrequency.Values.All(frequence => frequence == 0);
    }

    //226. Invert Binary Tree
    public static TreeNode InvertTree(TreeNode root)
    {
        if (root == null)
            return null;

        // Recursively invert the left and right subtrees
        TreeNode left = InvertTree(root.left);
        TreeNode right = InvertTree(root.right);

        // Swap the left and right nodes
        root.left = root.right;
        root.right = left;

        return root;
    }

    //125. Valid Palindrome
    public static bool IsPalindrome(string s)
    {
        // initialize left and right pointers at start and end of string length
        // compare l and r indices until l and r = eachother
        // if l and r are different return false
        // Regular expression pattern to match non-alphanumeric characters and spaces
        string pattern = "[^a-zA-Z0-9]";
        
        // Remove non-alphanumeric characters (including spaces)
        string result = Regex.Replace(s.ToLower(), pattern, "");

        int l = 0;
        int r = result.Length-1;

        while (l < r)
        {
            // return false if not = 
            if (result[l] != result[r])
                return false;
            else
            {
                l++;
                r--;
            }
        }

        return true;
    }

    //121. Best Time to Buy and Sell Stock
    public static int MaxProfit(int[] prices)
    {
        // Need to store the min as we iterate through
        // compare min value with the max value 
        // calculated 

        int min = prices[0];
        int profit = 0;

        foreach (int price in prices)
        {
            profit = Math.Max(profit, price - min);
            min = Math.Min(min, price);
        }

        return profit;
    }

    //21. Merge Two Sorted Lists
    public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        // need to use pointers where they both start on the head of list1 and list2
        // compare the values of both lists
        // set the current.next as the list with the lower value
        // update current to next and repeat
        // upon while loop completion, pass the remaining lists to the current.next
        // return result.next 

        ListNode result = new ListNode(0);
        ListNode current = result;

        while (list1 != null && list2 != null)
        {
            // list 1 has lower value
            if (list1.val <= list2.val)
            {
                // set next as list 1 
                current.next = list1;

                // update list1 to next node 
                list1 = list1.next;
            }
            else
            {
                current.next = list2;
                list2 = list2.next;
            }

            current = current.next;
        }

        // add remaining list into current if the other list is complete
        if (list1 != null)
            current.next = list1;
        else
            current.next = list2;

        return result.next;
    }

    //20. Valid Parenthesis
    public static bool IsValid(string s)
    {
        // create a stack
        Stack<char> stack = new Stack<char>();
        Dictionary<char, char> matchingPairs = new Dictionary<char, char>
        {
            { ')','('},
            { '}','{'},
            { ']','['},
        };

        // loop through each character
        foreach (char c in s)
        {
            // store the char in the stack only if the char is an opening bracket
            if (matchingPairs.ContainsValue(c))
                stack.Push(c);
            // if closing bracket, check if stack is empty or if the closing bracket doesn't contain a match is the stack, return false
            else if (matchingPairs.ContainsKey(c))
                if (stack.Count == 0 || stack.Pop() != matchingPairs[c])
                    return false;
        }

        // if stack is not empty, return false
        return stack.Count == 0; 
    }

    //441. Arranging Coins
    public static int ArrangeCoins(int n)
    {
        int i = 1;
        while (n - i >= 0)
        {
            n -= i;
            i++;
        }
        return i - 1;
    }

    //594. Longest Harmonious Subsequence
    public static int FindLHS(int[] nums)
    {
        Dictionary<int, int> occuranceMapper = new Dictionary<int, int>();

        foreach (int num in nums)
        {
            if (occuranceMapper.ContainsKey(num))
                occuranceMapper[num]++;
            else
                occuranceMapper[num] = 1;
        }

        int longest = 0;
        foreach (var kvp in occuranceMapper)
        {
            if (occuranceMapper.ContainsKey(kvp.Key + 1))
                longest = Math.Max(longest, kvp.Value + occuranceMapper[kvp.Key + 1]);
        }

        return longest;
    }

    #region Helper Methods
    // Helpers
    public static void PrintLinkedList(ListNode head)
    {
        ListNode current = head;
        while (current != null)
        {
            Console.Write(current.val + " -> ");
            current = current.next;
        }
        Console.WriteLine("null");
    }

    public static string PrintBinaryTree(TreeNode root)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(TraverseTree(root));

        return sb.ToString();
    }

    public static string TraverseTree(TreeNode node)
    {
        if (node == null)
            return string.Empty;

        StringBuilder sb = new StringBuilder();
        // Inorder Traversal: Left -> Root -> Right
        //sb.Append(TraverseTree(node.left));
        //sb.Append(node.val + " ");
        //sb.Append(TraverseTree(node.right));

        // Postorder Traversal: Left -> Right -> Root
        //sb.Append(TraverseTree(node.left));
        //sb.Append(TraverseTree(node.right));
        //sb.Append(node.val + " ");

        // Preorder Traversal: Root -> Left -> Right
        sb.Append(node.val + " ");
        sb.Append(TraverseTree(node.left));
        sb.Append(TraverseTree(node.right));

        return sb.ToString();
    }

    #endregion
}

//Definition for a linked list node.
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

//Definition for a binary tree node.
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}