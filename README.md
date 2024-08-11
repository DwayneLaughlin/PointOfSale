# PointOfSale
A Backend Point of Sale emulator using .NET 6.0

The process works in 2 parts, an Order phase and a Transaction phase.

Order:
The Order() class allows for users to submit an order. They are able to add several food items and condiments to their order. Each item has it's own class. Currently the food items have a size, a price, and a type. Their prices are based on an initial price for the small size and constant upgrades for larger sizes. The medium size is .50 more than a small. Large is 1.00 more than a small. Condiments do not have a size and only have a single price. There is a maximum of 3 of the same condiments per order. You can have 3 mustards and 3 ketchups, but you cannot have 4 mustards or ketchups in the same order. When adding food items, users will be prompted for the item as well as the desired size. The desired size is assigned to the class and the list of generated classes of items is saved. 

Transaction:
The Transaction() class takes the lost generated in the passed in Order() class and uses that to calcuate a total using the CalculateOrderTotal method. Users are allowed to submit payments and attempt to charge the amount for the order total. If sufficient funds are available for the order, the list of ordered items is generated and the change owed where applicable. If there are not sufficient funds the user will receive a notification that there were not sifficient funds and will be prompted to add more money. The system does not throw an error for insufficient funds because funds can be added to supplement a transaction attempt if needed. 
