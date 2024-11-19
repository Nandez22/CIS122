### Time Complexity
Time complexity is a measure of how many operations an algorithm performs as a function of its input size. In simpler terms, given an input of size n, time complexity estimates how the algorithm's performance grows relative to n. One of the main purposes of time complexity is to compare different algorithms. While it might seem straightforward to measure execution time directly, real-world factors like hardware and background processes can influence runtime significantly. To avoid these inconsistencies, we use time complexity as an abstract, platform-independent measure.

Time complexity is typically categorized into three cases: Best Case, Average Case, and Worst Case. While all are important, Worst Case is emphasized most because it tells us the maximum time an algorithm could take, ensuring reliability under all conditions.

For example, which of the following horses would be the safer bet?

400m race
|Horse|Best Case|Worst Case|
|-|-|-|
|A|25 Sec| 1 Min|
|B|30 Sec|35 Sec|

Horse A may seem promising in the best case, but Horse B is more consistent in the worst case. Similarly, worst-case complexity provides the most reliable metric for comparing algorithms.

Worst-Case Time Complexity (denoted as O, pronounced "big-O") describes the upper limit on the number of operations an algorithm may perform for an input of size n. The exact "something" in O(something) is determined through an analysis of the algorithm.

Mathematically:</br>
A function $`f(x)`$ is in $`O(g(x))`$ (denoted as $`f(x) \in O(g(x))`$) if and only if there exists positive constants $`c`$ and $`x_{0}`$ such that:</br>
$`|f(x)| \leq c * |g(x)|`$ for all $`x \geq x_{0}`$

While this may look intimidating, it essentially means that $`f(x)`$ grows at the same rate or slower than $`g(x)`$ as $`x`$ becomes large. For example, if an algorithm is $`O(n^2)`$ it means the number of operations grows no faster than $`n^2`$ for a large n.

I chose $`n^2`$ for the example because bubble sort has a time complexity of $`O(n^2)`$. This means that in the worst-case scenario, given an array of length 10, it will take _about_ 100 operations to complete. We say _about_ because time complexity is not a measure of exactly how many operations an algorithm will take, but rather just a statement on how fast the number of operations will grow. 

So how do we know the time complexity of bubble sort? 


```cs
public int[] BubbleSort(int[] arr) {
    int temp;

    for(int k = 0; k < arr.Length; k++) {
        for(int i = 0; i < arr.Length - 1; i++) {
            if(arr[i] > arr[i+1]) {
                temp = arr[i];
                arr[i] = arr[i+1];
                arr[i+1] = temp;
            }
        }
    }

    return arr;
}
```
_we are using the version with for loops, but the logic applies the same to while loops_
