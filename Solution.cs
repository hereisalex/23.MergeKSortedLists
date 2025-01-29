 using System.Collections.Concurrent;
 using System.Threading.Tasks;
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode MergeKLists(ListNode[] lists) 
    {
        if (lists.Length == 0)
        {
            return null;
        }
        ConcurrentBag<int> tempList = new();

        Parallel.ForEach(lists, list =>
        {
            var current = list;
            while (current != null)
            {
                tempList.Add(current.val);
                current = current.next;
            }
        });
        if (tempList.Count == 0)
        {
            return null;
        }
        if (tempList.Count == 1)
        {
            return new ListNode(tempList.First());
        }
        var sortedList = tempList.OrderByDescending(c => c).ToArray();
        var mergedList = new ListNode(sortedList[0]);
        for (var i = 1; i < sortedList.Length; i++)
        {
            mergedList = new ListNode(sortedList[i], mergedList);
        }
        return mergedList;
    }
}
