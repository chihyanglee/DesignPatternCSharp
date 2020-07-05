# Memento Design Pattern #

---

Without Violating encapsulation, capture and externalize an object's internal state so that the object can be restored to this state later.

- Originator

  - creates a memento containing a snapshot of its current internal state.
  - uses the memento to restore its internal state.

- Caretaker

  - is responsible for eht memento's safekeeping
  - never operates on or examines the contents of a memento.

- Memento

  - stores internal state of the Originator object. The memento may store as much or as little of eht originator's internal state as nessary at its originator's discretion.
  - protect against access by objects of other than the originator. Mementos have effectively two interfaces. Caretaker sees a narrow interface to the Mementos -- it can only pass the memento to the other objects. Originator, in contrast, sees a wide interface, one that lets it access all the data necessary to restore itself to its previous state. Ideally, only originator that produces the memento would be permitted to access the memento's internal state.