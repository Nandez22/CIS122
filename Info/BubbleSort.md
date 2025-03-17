# **BUBBLE SORT**
  ## **INTRO**
Bubble Sort is one of the ***MANY*** sorting algorithms you will learn about as a programmer, and also one of the first. Bubble Sort is considered one of the simplest algorithms, making it a great start for new programmers! While this is not an algorithms course, we don't want you to have a stroke when you get there, so it's best to dip your feet in now before you meet QuickSort.

Before explaining what Bubble Sort does, I need to get a few bits out of the way:
- Like most sorts, Bubble Sort can sort a list in either ascending or descending order
  - For this _thing_ we will be doing the former
- Bubble Sort is an ***in place*** sort
  - This means that it does **not** create a new list or array, it simply modifies the one it's given
- Bubble Sort is **SLOW** with an emphasis on **SLOW**
  - I will explain why in the [Optimization](#OPTIMIZATION) section, along with some improvements we can make!
    
## **WHAT DO?**
Bubble Sort gets its name from the idea that larger values _"bubble"_ their way to the top of the list one at a time. This _"bubbling"_ happens with two loops, an [**Inner**](#Inner-Loop) and [**Outer**](#Outer-Loop) loop. The shorthand explanation is that we keep swapping elements of the array to push the max(or min) value as far to one side as possible. We repeat that process until the list/array is sorted.

### **Inner Loop**
The inner loop is the meat and potatoes of the sort, all the logic and fun things happen here! The point of this loop is to bring the maximum value to the right side of the loop by swapping. 

_Swapping occurs as a result of comparing the current index `arr[i]` to the next index of the array `arr[i+1]`. If the larger of the two is on the left, they need to swap._

That might be a little tough to  visualize, so here's an example:
We want to sort the following array:

  Starting state:
  |1|5|4|6|3|2|
  |-|-|-|-|-|-|
  </br>

Let's start by checking index 0 and 1:</br>
Looking at the two values, since the greater value is already to the right, we don't need to do anything... on to the next.
  <!-- Pain -->
  <table><tr>
      <td>$${\color{purple} 1}$$</td>
      <td>$${\color{purple} 5}$$</td>
      <td>4</td>
      <td>6</td>
      <td>3</td>
      <td>2</td>
    </tr></table></br>
  
Here we can see that 5 > 4 _(hint hint...)_ since the greater value is to the left, they need to be swapped. So:
<!-- Wow I didn't think it could get worse! -->
<!-- this whole table thing is horrible, the fact that GitHub scrapes html SO violently makes this annoying, and the fact that Mermaid (a platform made for representing data BY PROGRAMMERS) has no good way to represent arrays is insane -->
<table><tr><td><table><tr>
      <td>1</td>
      <td>$${\color{red} 5}$$</td>
      <td>$${\color{red} 4}$$</td>
      <td>6</td>
      <td>3</td>
      <td>2</td>
    </tr></table></td>
  <td>--></td>
  <td><table><tr>
      <td>1</td>
      <td>$${\color{purple} 4}$$</td>
      <td>$${\color{purple} 5}$$</td>
      <td>6</td>
      <td>3</td>
      <td>2</td>
    </tr></table></td></tr></table></br>

I'll give you a guess what happens next...</br>
If you said nothing you not only got the question correct, but you also predicted what you get for doing so!
<table><tr>
      <td>1</td>
      <td>4</td>
      <td>$${\color{purple} 5}$$</td>
      <td>$${\color{purple} 6}$$</td>
      <td>3</td>
      <td>2</td>
    </tr></table></br>

Moving forward we take a look at indices 3 and 4.
<table><tr><td><table><tr>
      <td>1</td>
      <td>4</td>
      <td>5</td>
      <td>$${\color{red} 6}$$</td>
      <td>$${\color{red} 3}$$</td>
      <td>2</td>
    </tr></table></td>

<td>--></td>  

  <td><table><tr>
      <td>1</td>
      <td>4</td>
      <td>5</td>
      <td>$${\color{purple} 3}$$</td>
      <td>$${\color{purple} 6}$$</td>
      <td>2</td>
    </tr></table></td></tr></table></br>

Finally, for the last iteration of our inner loop, we look at indices 4 and 5. They need to be swapped, after doing so you may notice that we marked 6 green. This is because we know it is in the correct place. Think about it for a minute, is it possible for the max number of an array to not end up to the right using this method?
<table><tr><td><table><tr>
      <td>1</td>
      <td>4</td>
      <td>5</td>
      <td>3</td>
      <td>$${\color{red} 6}$$</td>
      <td>$${\color{red} 2}$$</td>
    </tr></table></td>

<td>--></td>  

  <td><table><tr>
      <td>1</td>
      <td>4</td>
      <td>5</td>
      <td>3</td>
      <td>$${\color{purple} 2}$$</td>
      <td>$${\color{green} 6}$$</td>
    </tr></table></td></tr></table></br>

So, I think it's fair that I summarize what's going on here. We loop through the array, and at each index `i` we compare its value `arr[i]` to the index ahead of it `arr[i+1]`. If the former is greater (i.e. `arr[i] > arr[i+1]`), that means the bigger value is to the left. Remember we want larger values to the right, so we swap them.
If `arr[i] < arr[i+1]`, then nothing needs to happen because the greater value is already to the right.</br>
Notice that when we move to a new index > 0, the highest value we've seen up to that point is always at `i`, unless we run into a greater number. So if you think about it, we are dragging the biggest value we can find along to the end, if we come across a larger value on the way, we grab that instead. The result of this is that we always end up with the largest value to the right.</br>
That is the entire purpose of the inner loop.

### **Outer Loop**
The outer loop is a little less grand, and only serves one purpose, to repeat the inner loop. As discussed in the [Inner Loop](#Inner-Loop) section, the inner loop puts the greatest value at the very end of the array. In our example we walked through a full run of the loop, resulting in the following:</br>

<table><tr>
      <td>1</td>
      <td>5</td>
      <td>4</td>
      <td>6</td>
      <td>3</td>
      <td>2</td>
    </tr></table>
And ended with:
  <table><tr>
      <td>1</td>
      <td>4</td>
      <td>5</td>
      <td>3</td>
      <td>2</td>
      <td>$${\color{green} 6}$$</td>
    </tr></table>

 Looking at our result, and the steps in the [Inner Loop](#inner-loop) section, can you guess what another iteration would yield? _I'm serious, draw it out._</br>
 We will walk through the inner loop again, and I want to see if you catch a pattern starting to form...
<!-- i = 0 -->
<table><tr>
      <td>$${\color{purple} 1}$$</td>
      <td>$${\color{purple} 4}$$</td>
      <td>5</td>
      <td>3</td>
      <td>2</td>
      <td>$${\color{green} 6}$$</td>
    </tr></table>

<!-- i = 1 -->
<table><tr>
      <td>1</td>
      <td>$${\color{purple} 4}$$</td>
      <td>$${\color{purple} 5}$$</td>
      <td>3</td>
      <td>2</td>
      <td>$${\color{green} 6}$$</td>
    </tr></table>

<!-- i = 2 -->
<table><tr><td><table><tr>
      <td>1</td>
      <td>4</td>
      <td>$${\color{red} 5}$$</td>
      <td>$${\color{red} 3}$$</td>
      <td>2</td>
      <td>$${\color{green} 6}$$</td>
    </tr></table></td>
<td>--></td>  
  <td><table><tr>
      <td>1</td>
      <td>4</td>
      <td>$${\color{purple} 3}$$</td>
      <td>$${\color{purple} 5}$$</td>
      <td>2</td>
      <td>$${\color{green} 6}$$</td>
    </tr></table></td></tr></table>

<!-- i = 3 -->
<table><tr><td><table><tr>
      <td>1</td>
      <td>4</td>
      <td>3</td>
      <td>$${\color{red} 5}$$</td>
      <td>$${\color{red} 2}$$</td>
      <td>$${\color{green} 6}$$</td>
    </tr></table></td>
<td>--></td>  
  <td><table><tr>
      <td>1</td>
      <td>4</td>
      <td>3</td>
      <td>$${\color{purple} 2}$$</td>
      <td>$${\color{green} 5}$$</td>
      <td>$${\color{green} 6}$$</td>
    </tr></table></td></tr></table></br>

So, running the inner loop for a 2nd time, brought the 2nd max, to the 2nd rightmost position. Are you seeing the pattern here? Notice that the first run of the inner loop took 5 iterations while the second run took 4. This is because we are using the fact that every time the inner loop runs we know for sure that one number is placed correctly. Since we know _where_ they are (filled to the right), we can confidently stop comparing those numbers because we know they are bigger than the rest. Like our example, our first iteration brought 6 to the right because it was the biggest in the array. At the end of the second iteration, we didn't compare 5 and 6 because we knew that something bigger than 5 was at the end of the array. We can make the same assumption for every iteration from here on out:

<!-- k = 2 -->
<table><tr><td><table><tr>
      <td>1</td>
      <td>4</td>
      <td>3</td>
      <td>2</td>
      <td>$${\color{green} 5}$$</td>
      <td>$${\color{green} 6}$$</td>
    </tr></table></td>
<td>--></td>  
  <td><table><tr>
      <td>1</td>
      <td>3</td>
      <td>2</td>
      <td>$${\color{green} 4}$$</td>
      <td>$${\color{green} 5}$$</td>
      <td>$${\color{green} 6}$$</td>
    </tr></table></td></tr></table>

<!-- k = 3 -->
<table><tr><td><table><tr>
      <td>1</td>
      <td>3</td>
      <td>2</td>
      <td>$${\color{green} 4}$$</td>
      <td>$${\color{green} 5}$$</td>
      <td>$${\color{green} 6}$$</td>
    </tr></table></td>
<td>--></td>  
  <td><table><tr>
      <td>1</td>
      <td>2</td>
      <td>$${\color{green} 3}$$</td>
      <td>$${\color{green} 4}$$</td>
      <td>$${\color{green} 5}$$</td>
      <td>$${\color{green} 6}$$</td>
    </tr></table></td></tr></table>
    
<!-- k = 4 -->
<table><tr><td><table><tr>
      <td>1</td>
      <td>2</td>
      <td>$${\color{green} 3}$$</td>
      <td>$${\color{green} 4}$$</td>
      <td>$${\color{green} 5}$$</td>
      <td>$${\color{green} 6}$$</td>
    </tr></table></td>
<td>--></td>  
  <td><table><tr>
      <td>1</td>
      <td>$${\color{green} 2}$$</td>
      <td>$${\color{green} 3}$$</td>
      <td>$${\color{green} 4}$$</td>
      <td>$${\color{green} 5}$$</td>
      <td>$${\color{green} 6}$$</td>
    </tr></table></td></tr></table>
    
<!-- k = 5 -->
<table><tr><td><table><tr>
      <td>1</td>
      <td>$${\color{green} 2}$$</td>
      <td>$${\color{green} 3}$$</td>
      <td>$${\color{green} 4}$$</td>
      <td>$${\color{green} 5}$$</td>
      <td>$${\color{green} 6}$$</td>
    </tr></table></td>
<td>--></td>  
  <td><table><tr>
      <td>$${\color{green} 1}$$</td>
      <td>$${\color{green} 2}$$</td>
      <td>$${\color{green} 3}$$</td>
      <td>$${\color{green} 4}$$</td>
      <td>$${\color{green} 5}$$</td>
      <td>$${\color{green} 6}$$</td>
    </tr></table></td></tr></table></br>

The result of the outer loop is a sorted array! While there is not much more to address in this section, I want to leave you with another question that will be answered in the [Optimization](#OPTIMIZATION) section.</br>
If we are given an array of length 5, how many times will the outer loop run? How about the inner loop>

## **CODE**
While algorithms can seem a bit daunting at first (yes even the simple ones), usually their implementation is quite elegant, so don't feel bad if you don't know how to code a bubble sort after reading about it. While the previous section was more open-ended and much less technical, this one will be much more direct. 

So without further ado, how do we code Bubble Sort, or any algorithm for that matter?

The best way to go about solving these 'bigger' problems is to break them into their most granular parts. In this case, the smallest problem we need to solve is swapping two array items. 

In some languages (like Python), swapping is trivial. Unfortunately using the best programming language comes with some downsides _(even saints sin)_, and swapping tends to throw off new programmers.

Most people immediately jump to something like:
```cs
int a = 5;
int b = 6;

a = b;
b = a;
```

But think for a minute, what would the output of this be?</br>
It turns out that both `a = 6` and `b = 6`.
It's like giving two apples to two people and having them swap apples without ever holding two at the same time. It cannot be done. Instead, you need a third person:
```cs
int temp;
int a = 5;
int b = 6;

temp = a;
a = b;
b = temp;
```
Now our program properly makes `a = 6` and `b = 5`! With that, the core of our problem is solved, but we only have a program that can swap two numbers...
Think back to the [Inner Loop](#Inner-Loop) segment of this doc, we only wanted to swap two items in the array if a particular condition was true.

This is our next problem, we only want to run the code we wrote if and only if a swap is needed. As discussed before we only swap two values if the current value is greater than the next:
```cs
public int[] BubbleSort(int[] arr){
    int temp;

    if(arr[i] > arr[i+1]){
        temp = arr[i];
        arr[i] = arr[i+1];
        arr[i+1] = temp;
    }
}
```
This problem sounded simple because it is. It only required a single if statement to solve, but you may have noticed some additional changes to our code. Most notably, we have replaced `a` and `b` with `arr[i]` and `arr[i+1]` respectivly. If you recall from the [Innter Loop](#inner-loop) section, we discussed that we are comparing each value to the next.

So now we have a code block that will swap two items in an array if and only if the current `i`th element is greater than the next `i+1`th. This brings us to the natural question of where does `i` come from? The answer to that is a loop...</br>

Now that we have our swapping logic done, we need to repeat it across the array. As mentioned previously the goal of the inner loop is to bring the largest value to the rightmost position by repeatedly swapping larger values to the right.

Since we have the swapping logic, the remainder is the 'repeating' component.

> [!TIP]
> Different programmers prefer different loops, click on the drop-down for the loop you prefer to see its code and any relevant notes!

<details>
<summary> For Loop </summary>

```cs
public int[] BubbleSort(int[] arr){
    int temp;

    for(int i = 0; i < arr.Length - 1; i++) {
        if(arr[i] > arr[i+1]) {
            temp = arr[i];
            arr[i] = arr[i+1];
            arr[i+1] = temp;
        }
    }
}
```

</details>

<details>
<summary> While Loop</summary>

```cs
public int[] BubbleSort(int[] arr){
    int temp;
    int i = 0;

    while(i < arr.Length - 1){
        if(arr[i] > arr[i+1]) {
            temp = arr[i];
            arr[i] = arr[i+1];
            arr[i+1] = temp;
        }
    }
    i++;
}
```

</details></br>

This loop implementation is pretty standard, nothing too fancy going on. The only additional bit I want to touch on is the `i < arr.Length - 1` condition. When looping through the array, we are checking the value at index `i`, but we are also checking the value at `i+1`. If our condition were `i < arr.Length`, `i` would increase to `arr.Length - 1` in value. While that is not bad on its own, we need to remember we are checking `i+1`. If `i` = `arr.Length - 1`, then `i+1` == `arr.Length`. If you recall, the maximum index of an array is always 1 less than its length (because indices start at 0). This means that if our condition were `i < arr.Length`, checking `arr[i+1]` would go out of bounds and crash the program. The `-1` keeps it in bounds.</br>

Ok, now for the outer loop, if you recall this is the simpler of the two since its only goal is to repeat the inner loop. The main question is how many times?
In the [Outer Loop](#outer-loop) section I mentioned that for every run of the inner loop, we knew as a fact that 1 additional element was sorted. If we sort 1 element every time the inner loop completes, then pretty clearly the loop needs to be run once for every item in arr:

<details>
<summary> For Loop </summary>

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

</details>

<details>
<summary> While Loop </summary>

```cs
public int[] BubbleSort(int[] arr) {
    int k = 0;
    int i = 0;

    int temp;
     
    while(k < arr.Length) {
        while(i < arr.Length - 1) {
            if(arr[i] > arr[i+1]) {
                temp = arr[i];
                arr[i] = arr[i+1];
                arr[i+1] = temp;
            }
            i++;
        }
        i = 0;
        k++;
    }

    return arr;
}
```

A quick note: we have to reset `i` to zero after each full run of the inner loop. Just another thing we have to think about if we are using while loops.

</details></br>

Here is yet another standard-looking loop. If you notice, `k` is not being used for other comparisons, which is usually a hallmark of these double-loop algorithms. You will also notice if you run this code, it will sort the array! However, it won't do that as fast as it could, that is what we will discuss in the [Optimization](#optimization) section below.

> [!NOTE]
> You may have noticed that we are still returning the array even though we are editing it in place. If you are thinking to yourself _"That seems redundant?"_, that would be because it is. This is very dependent on the application, in reality with in-place sorts you can return _anything_...

## **OPTIMIZATION**
Optimizing code is a massive rabbit hole, and even the result of this section won't scratch the surface of "well-optimized" code. The main idea is to show how to reduce redundant operations. Looking at Bubble Sort, it has a time complexity of $`O(n^2)`$, and a space complexity of $`O(1)`$, if you don't know what that means, check out the [Time Complexity](Info/TimeComplexity.md) page. 

For those of you who do, you would know that means bubble sort is **slow**. So, let's take a look at how we can try and speed it up.
One of the first and most common optimizations for bubble sort is to change the constraint of the inner loop.
I will now look something like this:

```cs
i < arr.Length - k - 1
```

This is a product of an observation made in the [Outer Loop](#outer-loop) section. Recall that each time the inner loop is run, another value is considered to be sorted. Since we are pushing the `k`th largest item to the `k`th rightmost position, we can assert that for every completion of the inner loop, we can traverse one less index in the next.

For Example:
<table>
    <tr>
    <td>Start</td>
    <td>
        <table><tr>
            <td>1</td>
            <td>5</td>
            <td>4</td>
            <td>6</td>
            <td>3</td>
            <td>2</td>
        </tr></table>
    </td>
    </tr><tr>
    <td>k = 0</td>
    <td>
        <table><tr>
            <td>1</td>
            <td>4</td>
            <td>5</td>
            <td>3</td>
            <td>2</td>
            <td>$${\color{green} 6}$$</td>
        </tr></table>
    </td>
    </tr><tr>
    <td>k = 1</td>
    <td>
        <table><tr>
            <td>1</td>
            <td>4</td>
            <td>3</td>
            <td>2</td>
            <td>$${\color{green} 5}$$</td>
            <td>$${\color{green} 6}$$</td>
        </tr></table>
    </td>
    </tr><tr>
    <td>k = 2</td>
    <td>
        <table><tr>
            <td>1</td>
            <td>3</td>
            <td>2</td>
            <td>$${\color{green} 4}$$</td>
            <td>$${\color{green} 5}$$</td>
            <td>$${\color{green} 6}$$</td>
        </tr></table>
    </td>
    </tr><tr>
    <td>k = 3</td>
    <td>
        <table><tr>
            <td>1</td>
            <td>2</td>
            <td>$${\color{green} 3}$$</td>
            <td>$${\color{green} 4}$$</td>
            <td>$${\color{green} 5}$$</td>
            <td>$${\color{green} 6}$$</td>
        </tr></table>
    </td>
    </tr><tr>
    <td>k = 4</td>
    <td>
        <table><tr>
            <td>1</td>
            <td>$${\color{green} 2}$$</td>
            <td>$${\color{green} 3}$$</td>
            <td>$${\color{green} 4}$$</td>
            <td>$${\color{green} 5}$$</td>
            <td>$${\color{green} 6}$$</td>
        </tr></table>
    </td>
    </tr><tr>
    <td>k = 5</td>
    <td>
        <table><tr>
            <td>$${\color{green} 1}$$</td>
            <td>$${\color{green} 2}$$</td>
            <td>$${\color{green} 3}$$</td>
            <td>$${\color{green} 4}$$</td>
            <td>$${\color{green} 5}$$</td>
            <td>$${\color{green} 6}$$</td>
        </tr></table>
    </td>
    </tr>
</table>

Notice that for every time k increases, so does the number of sorted values. So, if we subtract `k` from the maximum of `i`, we will only visit unsorted indices, making our algorithm much more efficient.

While that is good, do you notice something else about the last iterations of the outer loop? Starting at `k = 3`, the array is sorted, while on paper it seems obvious that we should stop there, but the computer needs to be told to do so. Right now our code just runs the inner loop `n` times (where `n` is the number of items in `arr`). While it might seem sensible to change the loop, we need to remember that there are cases where we may have to sort `n` times.

This raises the question, when do we stop sorting? Well, the answer seems kinda redundant, but it's _when the array is sorted_. So let's make a bool to track that.

```cs
bool sorted = true;
```

Right now we are assuming that `arr` is already sorted, this is because of our swap condition. Think about it for a moment, if we give the sort a pre-sorted array, will the swap function ever execute? No, it won't because it only triggers if two values are out of order. So, if we just set `sorted` to false whenever the swap function is activated, then we will have an accurate track of weather our array is sorted or not. (_For the first iteration_).

```cs
if(a > b) {
    temp = a;
    a = b;
    b = temp;
    sorted = false;
}
```

As the sort goes along, it would look something like this:

<table>
    <tr>
    <td>Start</td>
    <td>
        <table><tr>
            <td>1</td>
            <td>5</td>
            <td>4</td>
            <td>6</td>
            <td>3</td>
            <td>2</td>
        </tr></table>
    </td>
    </tr><tr>
    <td>k = 0</td>
    <td>
        <table><tr>
            <td>1</td>
            <td>4</td>
            <td>5</td>
            <td>3</td>
            <td>2</td>
            <td>$${\color{green} 6}$$</td>
        </tr></table>
    </td>
    <td>${\color{red} false}$</td>
    </tr><tr>
    <td>k = 1</td>
    <td>
        <table><tr>
            <td>1</td>
            <td>4</td>
            <td>3</td>
            <td>2</td>
            <td>$${\color{green} 5}$$</td>
            <td>$${\color{green} 6}$$</td>
        </tr></table>
    </td>
    <td>${\color{red} false}$</td>
    </tr><tr>
    <td>k = 2</td>
    <td>
        <table><tr>
            <td>1</td>
            <td>3</td>
            <td>2</td>
            <td>$${\color{green} 4}$$</td>
            <td>$${\color{green} 5}$$</td>
            <td>$${\color{green} 6}$$</td>
        </tr></table>
    </td>
    <td>${\color{red} false}$</td>
    </tr><tr>
    <td>k = 3</td>
    <td>
        <table><tr>
            <td>1</td>
            <td>2</td>
            <td>$${\color{green} 3}$$</td>
            <td>$${\color{green} 4}$$</td>
            <td>$${\color{green} 5}$$</td>
            <td>$${\color{green} 6}$$</td>
        </tr></table>
    </td>
    <td>${\color{red} false}$</td>
    </tr><tr>
    <td>k = 4</td>
    <td>
        <table><tr>
            <td>1</td>
            <td>$${\color{green} 2}$$</td>
            <td>$${\color{green} 3}$$</td>
            <td>$${\color{green} 4}$$</td>
            <td>$${\color{green} 5}$$</td>
            <td>$${\color{green} 6}$$</td>
        </tr></table>
    </td>
    <td>${\color{red} false}$</td>
    </tr><tr>
    <td>k = 5</td>
    <td>
        <table><tr>
            <td>$${\color{green} 1}$$</td>
            <td>$${\color{green} 2}$$</td>
            <td>$${\color{green} 3}$$</td>
            <td>$${\color{green} 4}$$</td>
            <td>$${\color{green} 5}$$</td>
            <td>$${\color{green} 6}$$</td>
        </tr></table>
    </td>
    <td>${\color{red} false}$</td>
    </tr>
</table>

If you look at the rightmost column (which holds the value of `sorted` after each iteration of `k`) you might see an issue. Even when we get to `k = 3`, where `sorted` should be true, we get false. This is because we never reset `sorted`. That assumption that the `arr` is sorted needs to be made for every iteration of `k`. 
So, we reset it:

```cs
int temp;
bool sorted = true;

for(int k = 0; k < arr.Length; k++){
    for(int i = 0; i < arr.Length - k - 1; i++){
        if(arr[i] > arr[i+1]) {
            temp = arr[i];
            arr[i] = arr[i+1];
            arr[i+1] = temp;
            sorted = false;
        }
    }
    sorted = true;
}
```

Running it we see:

<table>
    <tr>
    <td>Start</td>
    <td>
        <table><tr>
            <td>1</td>
            <td>5</td>
            <td>4</td>
            <td>6</td>
            <td>3</td>
            <td>2</td>
        </tr></table>
    </td>
    </tr><tr>
    <td>k = 0</td>
    <td>
        <table><tr>
            <td>1</td>
            <td>4</td>
            <td>5</td>
            <td>3</td>
            <td>2</td>
            <td>$${\color{green} 6}$$</td>
        </tr></table>
    </td>
    <td>${\color{red} false}$</td>
    </tr><tr>
    <td>k = 1</td>
    <td>
        <table><tr>
            <td>1</td>
            <td>4</td>
            <td>3</td>
            <td>2</td>
            <td>$${\color{green} 5}$$</td>
            <td>$${\color{green} 6}$$</td>
        </tr></table>
    </td>
    <td>${\color{red} false}$</td>
    </tr><tr>
    <td>k = 2</td>
    <td>
        <table><tr>
            <td>1</td>
            <td>3</td>
            <td>2</td>
            <td>$${\color{green} 4}$$</td>
            <td>$${\color{green} 5}$$</td>
            <td>$${\color{green} 6}$$</td>
        </tr></table>
    </td>
    <td>${\color{red} false}$</td>
    </tr><tr>
    <td>k = 3</td>
    <td>
        <table><tr>
            <td>1</td>
            <td>2</td>
            <td>$${\color{green} 3}$$</td>
            <td>$${\color{green} 4}$$</td>
            <td>$${\color{green} 5}$$</td>
            <td>$${\color{green} 6}$$</td>
        </tr></table>
    </td>
    <td>${\color{green} true}$</td>
    </tr><tr>
    <td>k = 4</td>
    <td>
        <table><tr>
            <td>1</td>
            <td>$${\color{green} 2}$$</td>
            <td>$${\color{green} 3}$$</td>
            <td>$${\color{green} 4}$$</td>
            <td>$${\color{green} 5}$$</td>
            <td>$${\color{green} 6}$$</td>
        </tr></table>
    </td>
    <td>${\color{green} true}$</td>
    </tr><tr>
    <td>k = 5</td>
    <td>
        <table><tr>
            <td>$${\color{green} 1}$$</td>
            <td>$${\color{green} 2}$$</td>
            <td>$${\color{green} 3}$$</td>
            <td>$${\color{green} 4}$$</td>
            <td>$${\color{green} 5}$$</td>
            <td>$${\color{green} 6}$$</td>
        </tr></table>
    </td>
    <td>${\color{green} true}$</td>
    </tr>
</table>

Now we have a bool that tracks whether or not the array is sorted. However, we don't stop sorting even when we know it is, for that all we need to add is one line:

```cs
if(sorted){ break; }
```

Give it some thought, where should this line go?

<details>
<summary> Check Here</summary>

```cs
public int[] BubbleSort(int[] arr) {
    int k = 0;
    int i = 0;

    int temp;
     
    while(k < arr.Length) {
        while(i < arr.Length - 1) {
            if(arr[i] > arr[i+1]) {
                temp = arr[i];
                arr[i] = arr[i+1];
                arr[i+1] = temp;
            }
            i++;
        }
        i = 0;
        k++;
    }

    return arr;
}
```
</details></br>

Now we have a sort that will stop when the array is sorted! If you are wondering what this looks like with while loops, I'd encourage you to try and do it yourself, but in good faith, here's that too:

<details>
<summary> While Loop Implementation </summary>

```cs
public int[] BubbleSort(int[] arr) {
    int k = 0;
    int i = 0;
    bool sorted = true;

    int temp;
     
    while(k < arr.Length) {
        while(i < arr.Length - 1) {
            if(arr[i] > arr[i+1]) {
                temp = arr[i];
                arr[i] = arr[i+1];
                arr[i+1] = temp;
            }
            i++;
        }
        if(sorted){ break; }
        sorted = true;
        i = 0;
        k++;
    }

    return arr;
}
```
</details></br>

The final optimization we can make is to move variable declarations outside of loops.
When you declare a variable, the computer allocates memory for said variable. Anything declared in a local space will have memory allocated to it, and then will have that memory deallocated when the local space is closed. 

A loop is a local space, so at the start of each iteration memory will be allocated for all declared variables. At the end of each iteration, all of that memory will be freed. While this is _"memory safe"_, it still takes time and resources to do so.

The way to avoid this is to declare all variables that you can as global. Keeping in mind that variables declared inside loops are also local, using while loops makes a lot of sense here since we would be effectively turning our for loops into while loops.

>[!IMPORTANT]
>I want to stress that we are now outside the realm of "this applies to all code", there are cases where you want local variables.

```cs
public int[] BubbleSort(int[] arr){
    int i = 0;
    int k = 0;
    bool sorted = true;

    int a;
    int b;
    int temp;

    while(k < arr.Length){
        while(i < arr.Length - k - 1){
            a = arr[i];
            b = arr[i+1];

            if(a > b){
                temp = a;
                a = b;
                b = temp;
                sorted = false;
            }
            i++;
        }
        if(sorted){ break; }
        sorted = true;
        i = 0;
        k++
    }
    
    return arr;
}
```

You will also notice the addition of variables `a` and `b`. These are also an optimization. Indexing is not as simple as getting a value from a variable. Without getting too complex, indexing takes the address of the array and adds `i` times the size of the array type. (This also is why arrays are zero-indexed)

This is why we want to access array indices as little as possible. This is yet another very small optimization, and far beyond what you would be expected to know at this point.

Finally, if you are familiar with big-O notation you may have noticed that despite our optimizations our sort remains $`O(n^2)`$. Generally speaking, changing the time complexity of an algorithm changes the algorithm itself. So bubble sort with a better O notation is most likely not a bubble sort.

So, that concludes bubble sort, thank you for reading (or not). Hopefully, this helps, if you have any further questions or suggestions, feel free to reach out or leave an issue on this repo. Thanks <3
