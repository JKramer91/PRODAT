
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

- This lets us run for quite a lot of iterations, but very slowly. We only ran it up to 11, and then we stopped, because we didn't have the time to wait around:

```
Assignment8.virtual.QueueWithMistake.SentinelLockQueue     1       4,25 199999994
Assignment8.virtual.QueueWithMistake.SentinelLockQueue     2      26,80 199999994
Assignment8.virtual.QueueWithMistake.SentinelLockQueue     3      44,34 199999994
...                                                        11     160,40 199999994

```