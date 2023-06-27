# Quicksort C#
Purpose: Quick Sort Implementation in C# with randomly selected pivots

Advantages over MergeSort:
- More memory efficient as it sorts an array in-place
- More efficient for smaller datasets in memory

**Average Run Time:** O(nlogn)

## Average Run Time Proof:

**Identify Random Variable of Interest**

1. Let $σ$ be a set of pivot choices such that $σ ⊆ Ω$, where $Ω$ is the set of all possible pivot choices
2. Let $Z_i$ be the ith smallest element in $A$, where $A$ is the given array to sort
3. Let $X_{ij}$ be the number of times $Z_i$ and $Z_j$ are compared where $i < j$
4. Quicksort runtime is dominated by the number of comparisons between distinct elements denoted by the random variable: $C(σ)$
5. It follows that the total number of comparisons is composed of the sum of all singular comparisons
6. Therefore, $$∀σ,\ C(σ) = \sum_{i=1}^{n-1} \sum_{j=i}^{n} X_{ij}$$
7. Additionally, $X_{ij}$ is an indicator random variable (can only take on the values 0, or 1) because any 2 distinct elements can only be compared at most 1 time:  
    a. For every recursive call, only the chosen pivot element is compared with each other element  
    b. There is only ever one pivot for each recursive call  
    c. The pivot does not continue on to further recursive calls  
    d. Therefore, one of the 3 following possibilies occur which only return a value of 1 or 0.    
>1. $i$ or $j$ are chosen as the pivot, compared once and the other is sent to further recursive calls alone. 
>2. Neither is chosen as the pivot and they continue together to the next recursive call uncompared or 
>3. Neither is chosen as the pivot, they are send to separate recursive calls and never compared.  

**Simplify the Decomposition**

1. In order to determine the average runtime for all comparisons, the expectation for this random variable is: $$E[C(σ)] = E[\sum_{i=1}^{n-1} \sum_{j=i}^{n} X_{ij}]$$
2. Using [linearity of expectation](https://brilliant.org/wiki/linearity-of-expectation/#:~:text=Linearity%20of%20expectation%20is%20the,weighted%20average%20of%20possible%20outcomes.): $$E[C(σ)] = \sum_{i=1}^{n-1} \sum_{j=i}^{n} E[X_{ij}]$$
3. Simplifying the inner expectation:  
$$E[X_{ij}] = Pr[X_{ij}=0]*0 + Pr[X_{ij}=1]*1 = Pr[X_{ij}=1]$$
$$Pr[X_{ij}=1] = r[Z_i\ and\ Z_j\ are\ compared]$$
$$∴ E[C(σ)] = \sum_{i=1}^{n-1} \sum_{j=i}^{n} Pr[Z_i\ and\ Z_j\ are\ compared]$$

**Precise Probability of Comparison**

1. Next, we will derive a precise expression for the probability of comparing 2 elements.
2. Consider the set $Z_i, Z_{i+1}, ..., Z_{j-1}, Z_j$
3. By induction, as long as none are chosen as the pivot, they must all be passed to the same recursive call
4. KEY INSIGHT: If $Z_i$ or $Z_j$ is chosen as the pivot before any other element in this set, then they will be compared (because the pivot is compared with every other element in the current subarray). Otherwise, if any other element in the set is chosen then $Z_i$ and $Z_j$ will be sent to separate recursive calls and never compared.
5. The probability of comparison between any two elements is the ratio between the number of possibilities which lead to a comparison divided by the total number of overall pivot choices:

$$∀i < j,\ Pr[Z_i\ and\ Z_j\ are\ compared] = {2\over(j-i+1)}$$
6. NOTE: This is only true in the case that pivots are chosen randomly and thus all have an equal likelihood of being selected as the pivot

**Final Calculations**

1. Plugging the precise probability back into the original expectation expression:
$$E[C(σ)] = \sum_{i=1}^{n-1} \sum_{j=i}^{n} {2\over(j-i+1)} = 2 * \sum_{i=1}^{n-1} \sum_{j=i}^{n} {1\over(j-i+1)}$$

2. The 1st sum adds the inner portion of this equation (n-1) times, thus the equation can be rewriten as such:

$$E[C(σ)] = 2 * (n-1) * \sum_{j=i}^{n} {1\over(j-1+1)}$$

3. For each fixed i, the inner sum is:

$$\sum_{j=i+1}^{n} {1\over(j-i+1)} = {1\over2}+{1\over3}+{1\over4}+...+{1\over(n-i+1)}$$

4. Since this sum is always limited to at most (n - (i+1)) terms, we can create an upper bound with a change of variables:

$$\sum_{j=i+1}^{n} {1\over(j-i+1)} \le \sum_{k=2}^{n} {1\over k}$$

5. Therefore,

$$E[C(σ)] = 2 * (n-1) * \sum_{k=2}^{n} {1\over k}$$

6. Since, the area under the function $1\over x$ always covers more area than a discrete sum for it, another top bound can be formed:

$$\sum_{k=2}^{n} {1\over k} \le \int_{1}^{n} {1\over x}$$

7. Solving the integral gives a precise top bound:

$$\int_{1}^{n} {1\over x} = ln(x)|_{1}^{n}$$
$$= ln(n) - ln(1)$$
$$= ln(n) - 0$$
$$= ln(n)$$

8. Therefore,

$$E[C(σ)] \le 2 * (n-1) * ln(n)$$

9. Using big O notation: E[C(σ)] = O(nlogn)

QED!