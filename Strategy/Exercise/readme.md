# Strategy Coding Exercise

Consider the quadratic equation and it's canonical solution:

![](https://i.udemycdn.com/redactor/raw/2017-07-25_13-02-23-6d1ea227c732e9ec42ca34d020236894.png)

The part b^2 - 4ac is called the *discriminant*. Suppose we want to provide an api with two different strategies for calculating the
discriminant:

1. In `OrdinaryDiscriminantStrategy`, if the discriminant is negative, we return it as-is. This is OK since our main API returns `Complex`
numbers anyway.
2. In `RealDiscriminantStrategy`, if the discriminant is negative, we return NaN (Not a Number), NaN propagates throughout the calculation, so the
equation solver gives two NaN values.

With regards the + and - value in the formulae, please return the + result as the first element, - as the second.