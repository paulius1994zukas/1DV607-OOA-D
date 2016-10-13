#Sequence diagram:
* I'm missing the interaction with the user input in both diagrams. Especially in CreateMember. This makes the diagrams small and easier to understand but also less useful.
* In CompactList, the notation for the loop could be a bit clearer. Because it is such a small diagram it's clear implicitly but could show that the loop is looping over all members. Also missing correct notation for return messages inside the loop [1, Chapter 15, Figure 15.8]. The naming of messages make it clear anyway but in a bigger diagram it could help quickly understand it.

#Class diagram:
* The association names doesn't always match the implementation. F.ex. Member to Boat is "+boat" but in code it's "boats". Usually it's not a big thing but "member" implies only one instance and "members" imply a collection. If the reader doesn't know that a member should be able to have more than one boat then it will be confusing.
* I feel like the diagram could show more of the architechural desicions. F.ex. that boats are created in the member class or a member is created in the crud class. To give the viewer a better understanding of what class does what.


#Code:
Quality of code looks good. Good naming of functions and variables.

#Design/Architechture:
* Consider changing name of class CRUD. The name doesn't convey the responsibilities of the class and create a high representational gap (which is bad) between domain model and design.
* Consider renaming classes ErrorHandling and ConsoleErrorHandling as they do validation and do not handle errors.
* The model doesn't depend on the view which is good.

#Runnable version:
Works good. Took some time to get up and running and I had to install Java compiler.

#Conclusion:
The diagrams are fairly lightweight which make them easy to understand but also reduce the value they provide. I would prefer if they were a bit more fleshed out.


#References:
1. Larman C., Applying UML and Patterns 3rd Ed, 2005, ISBN: 0131489062