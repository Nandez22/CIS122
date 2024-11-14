# **BUBBLE SORT**
  ## **INTRO**
  Bubble sort is one of ***MANY*** sorting algorithms you will learn about as a programmer, it is also one of the first. Bubble Sort is considered to be one of the simplest algorithms, so it makes for a great start! While this is not an algorithms course, we don't want you to have a stroke when you get there, so it's best to dip your feet in now before you meet QuickSort.

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
The inner loop is the meat and potatoes of the sort, all the logic and fun things happen here! The point of this loop is to bring the maximum value to the right side of the loop by swapping. That might be a little tough to mentally visualize, so here's an example:
We want to sort the following array, we have called the BubbleSort function and are currently inside the inner loop. As mentioned, the main and only function of the inner loop is to bring the maximum value to the end array. This is all done with swapping.

  Starting state:
  |1|5|4|6|3|2|
  |-|-|-|-|-|-|
  </br>

  _Swapping occurs as a result of comparing the current index `arr[i]` to the next index of the array `arr[i+1]`. If the larger of the two is on the left, they need to swap._

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
<!-- this whole table thing is horrible, the fact github scrapes html SO violently makes this annoying, and the fact that Mermaid (a platform made for representing data BY PROGRAMMERS) has no good way to represent arrays is insane -->
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

I'll just give you a guess what happens next...</br>
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

Finally, for the last iteration of our inner loop, we take a look at indices 4 and 5. They need to be swapped, after doing so you may notice that we marked 6 green. This is because we know for a fact it is in the correct place. Think about it for a minute, is it possible for the max number of an array to not end up to the right using this method?
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
The outer loop is a little less grand, and only serves one purpose, to repeat the inner loop. As we discussed in the [Inner Loop](#Inner-Loop) section, the inner loop puts the greatest value at the very end of the array. In our example we walked through a full run of the loop, resulting in the following array:</br>

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

  Looking at our result, and the steps found in the [Inner Loop](#Inner-Loop) section, can you guess what running the loop again would yield? _I'm serious, draw it out._</br>
  We will walk through the inner loop once more, and I want to see if you catch a pattern starting to form...
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

So, running the inner loop for a 2nd time, brought the 2nd max, to the 2nd rightmost position. Are you seeing the pattern here? Notice that the first run of the inner loop took 5 iterations while the second run took 4. This is because we are using the fact that every time the inner loop runs we know for sure that one number is placed correctly. Since we know _where_ they are (filled to the right), we can confidently stop comparing those numbers because we know they are bigger than the rest. Like in our example, our first iteration brought 6 to the right because it was the biggest in the array. At the end of the second iteration, we didn't compare 5 and 6 because we knew that something bigger than 5 was at the end of the array. We can make the same assumption for the next iteration, and the next, and the next...

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



## **CODE**
explanation...

<details>
  <summary>Using For Loops</summary>
  
```cs
public int[] BubbleSort(int[] arr) {
    int temp;

    for(int k = 0; k < arr.Length; k++) {
        for(int i = 0; i < arr.Length - k - 1; i++) {
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
  <summary>Using While Loops</summary>
  
```cs
public int[] BubbleSort(int[] arr) {
    int k = 0;
    int i = 0;

    int temp;
     
    while(k < arr.Length) {
        while(i < arr.Length - k - 1) {
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
</details>


## **OPTIMIZATION**
This is the ballerest one, the T is a generic type, which is constrained to be a number (hence the `where T : INumber<T>`). Don't worry about that too much
```cs
public static T[] BubbleSort<T>(T[] arr) where T : INumber<T> {
    bool sorted = true;
    T a;
    T b;

    T temp;

    for(int k = 0; k < arr.Length; k++) {
        for(int i = 0; i < arr.Length - k - 1; i++) {
            a = arr[i];
            b = arr[i + 1];

            if(a > b) {
                temp = a;
                a = b;
                b = temp;
                sorted = false;
            }
        }
        if(sorted) { break; }
        sorted = true;
    }

    return arr;
```

