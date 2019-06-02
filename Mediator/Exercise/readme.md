# Mediator Pattern Exercise

Our system has any number of instances of `Participant` classes. Each participant has a Value integer, initially zero.

A participant can `Say()` a particular value, which is broadcast to all other participants. At this point in time every
other participant is *obliged* to increase their Value by the value being broadcast.

Example:

- Two participants start with values 0 and 0 respectively.
- Participant 1 broadcast the value 3. We now have Participant 1 Value = 0, Participant 2 Value = 3;
- Participant 2 broadcast the value 2. We now have Participant 1 Value = 2, Participant 2 Value = 3;