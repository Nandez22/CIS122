# **BUBBLE SORT**
  ## **INTRO**
  Bubble sort is one of ***MANY*** sorting algorithms you will learn about as a programmer, it is also one of the first. Bubble Sort is considered to be one of the simplest algorithms, so it makes for a great start! While this is not an algotithms course, we don't want you to have a stroke when you get there, so it's best to dip your feet in now before you meet QuickSort.

Before explaning what Bubble Sort do, I need to get a few technical bits out of the way:
- Like most sorts, Bubble Sort can sort a list in either ascending or descending order
  - For the purposes of this _thing_ we will be doing the former
- Bubble Sort is an ***in place*** sort
  - This means that it does **not** create a new list or array, it simply modifies the one it's given
- Bubble Sort is **SLOW** with an emphesis on **SLOW**
  - I will explain why in the [Optimization](#OPTIMIZATION) section, along with some improvements we can make
    
## **WHAT DO?**
Bubble Sort gets it's name from the idea that larger values _"bubble"_ their way to the top of the list one at a time. This _"bubbling"_ happens with two loops, an [**Inner**](#Inner-Loop) and [**Outer**](#Outer-Loop). The shorthand explanation is that we keep swapping elements of the array to push the max(or min) value as far to one side(right) as possible. We repeat that process until the array(or list) is sorted.
  ### **Inner Loop**
  The inner loop is the meat and potatoes of the sort, all the logic and fun things happen here! The point of this loop is to bring the maximum value to the right side of the loop by swapping. That might be a little tough to mentally visualize, so here's an example:
  We want to sort the following array, we have called the BubbleSort function and are currently inside the inner loop. As mentioned the main and only goal of the inner loop is to bring the maximum value to the end of the list. This is all done with swapping.

  Starting state:
  |1|5|4|6|3|2|
  |-|-|-|-|-|-|

  The inner loop makes comparisons of index i to index i + 1. (If we are trying to move the greatest value to the rightmost position in the list, when would we want to swap the two values we are comparing?)

  <!-- Pain -->
  <table><tr>
      <td>$${\color{purple} 1}$$</td>
      <td>$${\color{purple} 5}$$</td>
      <td>4</td>
      <td>6</td>
      <td>3</td>
      <td>2</td>
    </tr>
  </table>
  
  Looking at the two values, since the greater value is already to the right, we don't need to do anything... on to the next.
  <table><tr>
      <td>1</td>
      <td>$${\color{purple} 5}$$</td>
      <td>$${\color{purple} 4}$$</td>
      <td>6</td>
      <td>3</td>
      <td>2</td>
    </tr>
  </table>
  
Here we can clearly see that 5 > 4 _(hint hint...)_ since the greater value is to the left, they need to be swapped.
  
  ### **Outer Loop**

## **CODE**
## **OPTIMIZATION**