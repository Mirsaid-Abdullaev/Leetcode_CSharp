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
        public static bool IsValid(string s)
        {
            if (s.Length == 0 || s.Length % 2 == 1)
            {
                return false;
            }

            Stack BracketStack = new Stack();
            Dictionary<char, char> Brackets = new Dictionary<char, char>
            {
                { '{', '}' },
                { '[', ']' },
                { '(', ')' }
            };

            for (int i = 0; i < s.Length; i++)
            {
                if (BracketStack.Count > 0 && Brackets.ContainsKey((char)BracketStack.Peek()) && Brackets[(char)BracketStack.Peek()] == s[i])
                {
                    BracketStack.Pop();
                    continue;
                }
                BracketStack.Push(s[i]);
            }
            return BracketStack.Count == 0;
        }
        /// <summary>
        /// LeetCode problem #69
        /// </summary>
        public static int MySqrt(int x)
        {
            if (x <= 0)
            {
                return 0;
            }
            long l = 1;
            long r = x;
            long m = ((l + r) % 2 == 0) ? (l + r) / 2 : (l + r - 1) / 2;

            while (!(m == l && m == r))
            {
                long temp = m * m - x; // m^2 - x

                if (temp == 0)
                {
                    return (int)m;
                }
                else if (temp > 0)
                {
                    if (m != l)
                    {
                        r = m - 1;
                    }
                    else
                    {
                        r--;
                    }
                }
                else
                {
                    if (-temp < (m + 1) * (m + 1) - x)
                    {
                        return (int)m;
                    }
                    if (m != r)
                    {
                        l = m + 1;
                    }
                    else
                    {
                        l++;
                    }
                }
                m = ((l + r) % 2 == 0) ? (l + r) / 2 : (l + r - 1) / 2;
            }
            if (m * m > x)
            {
                return (int)(m - 1);
            }
            else
            {
                return (int)m;
            }
        }
        /// <summary>
        /// LeetCode problem #2423
        /// </summary>
        public static bool EqualFrequency(string word)
        {
            Dictionary<char, int> Occurrences = new Dictionary<char, int>();
            Dictionary<int, int> SameOccurrences = new Dictionary<int, int>();
            foreach(char letter in word)
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

            foreach (int val in Occurrences.Values)
            {
                if (SameOccurrences.ContainsKey(val))
                {
                    SameOccurrences[val]++;
                }
                else if (SameOccurrences.Keys.Count > 2)
                {
                    return false;
                }
                else
                {
                    SameOccurrences.Add(val, 1);
                }
            }

            if (SameOccurrences.Count == 1 && (SameOccurrences.Keys.ElementAt(0) == 1 || SameOccurrences.Values.ElementAt(0) == 1)) //all chars in the string occur once, or one char occurs multiple times
            {
                return true;
            }
            else if (SameOccurrences.Count == 2) //there are two frequencies of letters
            {
                if (SameOccurrences.ContainsKey(1) && SameOccurrences[1] == 1 || 
                    (SameOccurrences.Keys.ElementAt(0) == SameOccurrences.Keys.ElementAt(1) + 1 && SameOccurrences.Values.ElementAt(0) == 1) ||
                    (SameOccurrences.Keys.ElementAt(1) == SameOccurrences.Keys.ElementAt(0) + 1 && SameOccurrences.Values.ElementAt(1) == 1))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else //there are more than two frequencies in the word, not possible to do this
            {
                return false;
            }
        }
        /// <summary>
        /// LeetCode problem #2591
        /// </summary>
        public static int DistMoney(int money, int children)
        {
            if (children <= 0 || children > money)
            {
                return -1;
            }
            if (children == 1)
            {
                if (money != 8)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            //children > 1 at this point
            int eights = money / 8;
            int rem = money % 8;

            if (eights == children) //number of lots of eight are the same as the children, with some remainder (< 8) that can be added to some other child, so no one has 4 moneys
            {
                if (rem > 0)
                {
                    return eights - 1;
                }
                else
                {
                    return eights;
                }
            }
            else if (eights > children) //more lots of eight than children - e.g. 20 moneys, 2 children
            {
                return children - 1;
            }
            else //less lots of eight than children, e.g. 20 moneys, but 3 kids
            {
                if (rem == 0)
                {
                    eights--;
                    rem = 8;
                }
                int rem_child = children - eights;
                while (rem < rem_child)
                {
                    rem += 8;
                    eights--;
                    rem_child++;
                }
                if (rem == 4 && rem_child == 1)
                {
                    return eights - 1;
                }
                if (rem_child > rem)
                {
                    return 0;
                }
                //at this point, eights holds max number of eights that we can give out
                return eights;
            }
        }
    }
}
