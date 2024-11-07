
## Problem:

When we run the program, we get this output
``` 
Assignment8.virtual.QueueWithMistake.SentinelLockQueue     1      10,74 199999994

Exception: java.lang.OutOfMemoryError thrown from the UncaughtExceptionHandler in thread "Thread-2"
```

The problem arises when an item is removed from the queue using `get()`. You update head to `first.next`, but the first node is still holding the reference to the previous head node. THHIS means that it cannot be garbage collected. Head is updated, but the first node still holds a reference to the original head, and thus the old node remains in memory. 

## First step:
We added the line `first.next = null;` after the `head = first.next`-line. 

The updated code is 

```
public synchronized int get() {
    if (head.next == null)
      return -999;
    Node first = head;
    head = first.next;
    first.next = null;
    return head.item;
  } 
```

- We nullify the reference of the removed node (first) to allow it to be garbage collected. In that way, there are no references to the rest of the queue from `first`. 

- This lets us run the required amount of iterations, albeit very slowly. 

```
Assignment8.virtual.QueueWithMistake.SentinelLockQueue     1       4,25 199999994
Assignment8.virtual.QueueWithMistake.SentinelLockQueue     2      26,80 199999994
Assignment8.virtual.QueueWithMistake.SentinelLockQueue     3      44,34 199999994
Assignment8.virtual.QueueWithMistake.SentinelLockQueue     4      65,57 199999994
Assignment8.virtual.QueueWithMistake.SentinelLockQueue     5      77,01 199999994
Assignment8.virtual.QueueWithMistake.SentinelLockQueue     6      95,49 199999994
Assignment8.virtual.QueueWithMistake.SentinelLockQueue     7     119,52 199999994
Assignment8.virtual.QueueWithMistake.SentinelLockQueue     8     150,01 199999994
Assignment8.virtual.QueueWithMistake.SentinelLockQueue     9     144,79 199999994
Assignment8.virtual.QueueWithMistake.SentinelLockQueue    10     164,55 199999994
Assignment8.virtual.QueueWithMistake.SentinelLockQueue    11     174,43 199999994
Assignment8.virtual.QueueWithMistake.SentinelLockQueue    12     165,49 199999994
Assignment8.virtual.QueueWithMistake.SentinelLockQueue    13     197,77 199999994
Assignment8.virtual.QueueWithMistake.SentinelLockQueue    14     226,41 199999994
Assignment8.virtual.QueueWithMistake.SentinelLockQueue    15     203,82 199999994
Assignment8.virtual.QueueWithMistake.SentinelLockQueue    16     313,50 199999994
Assignment8.virtual.QueueWithMistake.SentinelLockQueue    17     301,08 199999994
Assignment8.virtual.QueueWithMistake.SentinelLockQueue    18     336,85 199999994
Assignment8.virtual.QueueWithMistake.SentinelLockQueue    19     301,60 199999994
``` 