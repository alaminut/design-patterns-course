# Observer Pattern Exercise

Imagine a game where one or more rats can attack a player. Each individual rat has an attack value of 1. However, rats attack
as a swarm, so each rat's attack value is equal to the total number of rats in play.

Given that a rat enters play through the constructor and leaves play (dies) via its `Dispose()` method, please implement the `Game` and `Rat` classes so that, at any point in the game, the `Attack` value of a rat is always consistent.

The exercise has two simple rules:

- The `Game` class can not have properties or fields. It can only contain events and methods.
- The `Rat` class' `Attack` field is strictly a field not a property.