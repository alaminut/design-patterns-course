# Template Method Coding Exercise

Imagine a typical collectible card game which has cards representing creatures. Each creature has two values Attack and Health.
Creatures can fight each other dealing their attack damage, thereby reducing their opponent's health.

The class `CardGame` implements the logic for two creatures fighting one another. However, the exact mechanics of how damage is
dealt is different.

* `TemporaryCardDamage`: In some games, unless the creature has been killed, its health returns to the original value at the
end of combat.
* `PermanentCardDamage`: In other games, health damage persists.

You are asked to implement aforementioned classes that would allow us to simulate combat between creatures.

**Some Examples**

* With temporary damage, creatures 1/2 and 1/3 can never kill one another. With permanent damage second creature will win after
two rounds of combat.
* With either temporary or permanent damage, two 2/2 creatures kill one another.