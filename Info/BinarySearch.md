# Binary Search

To be more specific, binary search begs the question
```
Given an ordered set of `n` numbers and only being able to check one number at a time:
What is the most number of checks you would have to do as a function of `n`?"
```
In other words:</br>
If we have an ordered set of numbers of length `n`, in the worst-case scenario how many numbers do we need to check to find a particular number?

Your first intuition might be that the answer would have to be `n`.</br>
Logically it makes sense, in the worst case the number we are looking for is the last number we search. Forcing us to search through all numbers in the set. 

While this is true for ***un**ordered* sets, the question is asking about *ordered* sets.
So give it some thought, does having an ordered set change our answer? Why?</br>
I think the best way to answer that is with a quick activity:</br>

Here is an ordered set of numbers, you are searching for the number `11`.
<table>
  <tr>
    <td>1</td>
    <td>3</td>
    <td>8</td>
    <td>10</td>
    <td>11</td>
    <td>14</td>
    <td>20</td>
  </tr>
</table>

However, there are some rules:</br>
- You may only check one number at a time.
- You can only *"see"* a number that you are checking.
  (You can only make decisions based on the current number you are checking)
Can you do it without checking every number?



The trick here is to divide by two.</br>
Start at the middle of the set (if the set length is even just pick one of the middle numbers)
If the number is lower than what you are searching for, 



