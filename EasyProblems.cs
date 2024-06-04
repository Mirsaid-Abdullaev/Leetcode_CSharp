using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leetcode
{
    internal static class EasyProblems
    {
        /// <summary>
        /// LeetCode problem #344
        /// </summary>
        /// <param name="s"></param>
        public static void ReverseString(char[] s)
        {
            int n = s.Length;
            for (int i = 0; i < n / 2; i++)
            {
                char temp = s[i];
                s[i] = s[n - i - 1];
                s[n - 1 - i] = temp;
            }
            return;
        }
        /// <summary>
        /// LeetCode problem #1
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> Map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (Map.ContainsKey(target - nums[i]))
                {
                    return new int[] { i, Map[target - nums[i]] };
                }
                if (!Map.ContainsKey(nums[i]))
                {
                    Map.Add(nums[i], i);
                }
            }
            return null;
        }
        /// <summary>
        /// LeetCode problem #2
        /// </summary>
        // Definition for singly-linked list.
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
        /// <summary>
        /// LeetCode problem #2 solution
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            int carry = 0;
            ListNode result = new ListNode();
            ListNode temp = result;
            while (l1 != null && l2 != null)
            {
                temp.val = (l1.val + l2.val + carry) % 10;
                carry = (l1.val + l2.val + carry) / 10;
                l1 = l1.next;
                l2 = l2.next;
                temp.next = new ListNode();
                temp = temp.next;
            }
            if (l1 == null && l2 == null && carry > 0)
            {
                temp.val = carry;
            }
            else if (l1 == null)
            {
                while (l2 != null)
                {
                    temp.val = (l2.val + carry) % 10;
                    carry = (l2.val + carry) / 10;
                    l2 = l2.next;
                    temp.next = new ListNode();
                    temp = temp.next;
                    if (carry > 0 && l2 == null)
                    {
                        l2 = new ListNode();
                        continue;
                    }
                }
            }
            else if (l2 == null)
            {
                while (l1 != null)
                {
                    temp.val = (l1.val + carry) % 10;
                    carry = (l1.val + carry) / 10;
                    l1 = l1.next;
                    temp.next = new ListNode();
                    temp = temp.next;
                    if (carry > 0 && l1 == null)
                    {
                        l1 = new ListNode();
                        continue;
                    }
                }
            }

            temp = result;
            while (temp.next.next != null)
            {
                temp = temp.next;
            }
            if (temp.next.val == 0)
            {
                temp.next = null;
            }
            return result;
        }
        /// <summary>
        /// LeetCode problem # 409
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int LongestPalindrome(string s)
        {
            Dictionary<char, int> Occurrences = new Dictionary<char, int>();
            int total = 0;
            foreach (char letter in s)
            {
                if (letter != (char)32)
                {
                    if (Occurrences.ContainsKey(letter))
                    {
                        Occurrences[letter]++;
                    }
                    else
                    {
                        Occurrences.Add(letter, 1);
                    }
                }
            }
            int num_odd = 0;
            foreach (int val in Occurrences.Values)
            {
                if (val % 2 == 0)
                {
                    total += val;
                }
                else
                {
                    num_odd++;
                    total += val - 1;
                }
            }
            if (num_odd > 0)
            {
                return total + 1;
            }
            else
            {
                return total;
            }
        }
        /// <summary>
        /// LeetCode problem #9
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static bool IsPalindrome(int x)
        {
            if (x < 10 && x > -1)
            {
                return true;
            }
            if (x % 10 == 0 || x < 0)
            {
                return false;
            }
            int tempx = x;
            int reversed = 0;
            int pow = (int)Math.Floor(Math.Log10(x));
            for (int i = 0; i <= pow; i++)
            {
                reversed += (tempx % 10) * (int)Math.Pow(10, pow - i);
                tempx /= 10;
            }
            return reversed == x;
        }
        /// <summary>
        /// LeetCode problem #20
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsValid(string s)
        {
            Stack BracketStack = new Stack();
            Dictionary<char, char> Brackets = new Dictionary<char, char>
            {
                { '{', '}' },
                { '[', ']' },
                { '(', ')' }
            };

            for (int i = 0; i < s.Length; i++)
            {
                if (BracketStack.Count > 0)
                {
                    if (Brackets.ContainsKey((char)BracketStack.Peek()) && Brackets[(char)BracketStack.Peek()] == s[i])
                    {
                        BracketStack.Pop();
                        continue;
                    }
                }
                BracketStack.Push(s[i]);
            }
            return BracketStack.Count == 0;
        }

    }
}
