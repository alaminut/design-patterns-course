#State Pattern Exercise

A combination lock is a lock that opens after the right digits have been entered. A lock is pre-programmed
with a combination and the user is expected to enter this combination to unlock the lock.

The lock has a Status field that indicates the state of the lock. The rules are:

- If the lock has just been locked (or at startup), the status is LOCKED
- If a digit has been entered, that digit is shown on the screen. As the user enter more digits they are added to status
- If the user has entered the correct sequence of digits, the lock status changes to OPEN
- If the user enters an incorrect sequence of digits, the lock status changes to ERROR

Please implement the `CombinationLock` class to enable this behavior.