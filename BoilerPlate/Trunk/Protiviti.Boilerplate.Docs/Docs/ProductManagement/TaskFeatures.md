Task Features
========================

Overview
-----------------
Task features are used to spec out the tasks
that should be performed as part of a sprint that 
do not result in some sort of documentation and do not 
result in some sort of working software.
They typically start with an action the key word 
(like "Grant") and are named
after an action that creates a 
specific desired end state.  Ex: Grant Team Members Access to 
the Source Control.  

Task scenarios are usually just two
steps the first of which identifies some precondition
and the second that specifies that task that should 
be performed.

    Scenario: Task Based Step Example
      Given I have some precondition
      Then I should perform some task --TASK


Step Types
-----------------
There is really only two steps for defining a task.  Both of
which are defined by adding "--TASK" to the end of the step.
The first is a standard step.
The second uses a table argument to define multiple steps.

* __Then XXX --TASK__
  
  Takes the string value before --TASK and looks up 
  a matching task defined in the tasks.json file
  located in the Features folder.  The json format for 
  adding a task to the file is:

        {
            "name": "I should perform some task",
            "status": "Complete"
        },

  * The step name should match the name property.
  * The status property tells the test framework 
    whether to mark the step as pending, passing, or failing.
  
  The following table is used for setting the result of the task
  in the step.

        | Status           | Test Result |
        | Missing          | Pending     |
        | "Not Started"    | Pending     |
        | "Complete"       | Passing     |
        | Anything Else... | Failing     |

* __Then XXX --TASK__ (with table Parameter)
  
  If a table parameter is provided to the step then the 
  step will only pass if matches to each table row are found
  and marked as complete.  To define a table task in the 
  tasks.json file you need the following structure:

        {
            "name": "I should perform some task",
            "table": [
                {
                    "arguments": [ "John", "Good" ],
                    "status": "Complete"
                },
                {
                    "arguments": [ "Jane", "Naughty" ],
                    "status": "Complete"
                }
            ]
        }

  The test step will look for an entry in the table array
  that matches the row in the table argument.  For example
  the following step and table argument will pass with the 
  tasks defied above.

        Then I should be able to do something --TASK
        | Name | Status  |
        | Joe  | Good    |
        | Jane | Naughty |


Examples
-----------------
To see examples of documentation features go to: 

      Protiviti.Boilerplate.Test
        Features
          ProductManagement
            BacklogManagement
              DefineTaskFeatures.feature

<p class="updated">Updated on 9/24/2014 by Stewart Armbrecht</p>
<p class="reviewed">Reviewed on 9/24/2014 by Stewart Armbrecht</p>
