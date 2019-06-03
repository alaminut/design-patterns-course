# Visitor Pattern Coding Exercise

You are asked to implement a double-dispatch visitor called `ExpressionPrinter` for printing different mathematical expressions. The range
of expressions cover addition and multiplication - please put round brackets around addition expressions (but not multiplication ones)! Also,
please avoid any blank spaces in output.

**Example**

* Input: `AdditionExpression(Literal(2), Literal(3))`
* Output: `(2+3)`