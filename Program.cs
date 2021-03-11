using System;
using System.Collections.Generic;

namespace Day12
{
    class Program
    {
        static void Main(string[] args)
        {
            var ls = new List<string> { "Ant", "Bat", "Cat", "Dog" };
            int k = 2;
            KGroupAssignmentsEmpty(ls, k);
        }

        static void GroupAssignments(List<string> ls)
        {
            var groups = new List<List<string>>();
            GroupAssignments(ls, 0, groups);
        }

        static void GroupAssignments(List<string> ls, int idx, List<List<string>> groups)
        {
            if (ls.Count == idx)
            {
                PrintGroups(groups);
                return;
            }
            // Add the current element to each existing group
            for (int i = 0; i < groups.Count; i++)
            {
                groups[i].Add(ls[idx]);
                GroupAssignments(ls, idx + 1, groups);
                groups[i].Remove(ls[idx]);
            }
            // Add the current element to a new group
            groups.Add(new List<string>());
            groups[groups.Count - 1].Add(ls[idx]);
            GroupAssignments(ls, idx + 1, groups);
            groups.RemoveAt(groups.Count - 1);
        }

        static void PrintGroups(List<List<string>> groups)
        {
            foreach (List<string> group in groups)
            {
                Console.Write("| ");
                foreach (string s in group)
                {
                    Console.Write(s + " ");
                }
            }
            Console.WriteLine("|");
        }

        static void KGroupAssignments(List<string> ls, int k)
        {
            var groups = new List<List<string>>();
            KGroupAssignments(ls, 0, groups, k);
        }

        static void KGroupAssignments(List<string> ls, int idx, List<List<string>> groups, int k)
        {
            if (ls.Count == idx)
            {
                if (groups.Count == k) PrintGroups(groups);
                return;
            }
            // Add the current element to each existing group
            for (int i = 0; i < groups.Count; i++)
            {
                groups[i].Add(ls[idx]);
                KGroupAssignments(ls, idx + 1, groups, k);
                groups[i].Remove(ls[idx]);
            }
            // Add the current element to a new group
            groups.Add(new List<string>());
            groups[groups.Count - 1].Add(ls[idx]);
            KGroupAssignments(ls, idx + 1, groups, k);
            groups.RemoveAt(groups.Count - 1);
        }
        
        static void KGroupAssignmentsEmpty(List<string> ls, int k)
        {
            var groups = new List<List<string>>();
            KGroupAssignmentsEmpty(ls, 0, groups, k);
        }

        static void KGroupAssignmentsEmpty(List<string> ls, int idx, List<List<string>> groups, int k)
        {
            if (ls.Count == idx)
            {
                if (groups.Count <= k) 
                {
                    PrintGroupsEmpty(groups, k);
                }
                return;
            }
            // Add the current element to each existing group
            for (int i = 0; i < groups.Count; i++)
            {
                groups[i].Add(ls[idx]);
                KGroupAssignmentsEmpty(ls, idx + 1, groups, k);
                groups[i].Remove(ls[idx]);
            }
            // Add the current element to a new group
            groups.Add(new List<string>());
            groups[groups.Count - 1].Add(ls[idx]);
            KGroupAssignmentsEmpty(ls, idx + 1, groups, k);
            groups.RemoveAt(groups.Count - 1);
        }

        static void PrintGroupsEmpty(List<List<string>> groups, int k)
        {
            foreach (List<string> group in groups)
            {
                Console.Write("| ");
                foreach (string s in group)
                {
                    Console.Write(s + " ");
                }                
            }
            Console.Write("|");

            if (groups.Count < k)
            {
                for (int i = 0; i < k - groups.Count; i++)
                {
                    Console.Write(" |");
                }
            }
            Console.WriteLine();
        }

    }

}
