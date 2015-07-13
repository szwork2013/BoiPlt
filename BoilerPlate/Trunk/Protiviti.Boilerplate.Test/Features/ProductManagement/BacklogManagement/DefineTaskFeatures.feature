@Sprint0 @StewartArmbrecht
Feature: Define Task Features
	In order to ensure that certain activities are performed by a team
	As a team member
	I want to be able to define a set of features that specify certain activities that must be performed

Scenario Outline: Create Task Based Step
  Given I have access to the solution
  And the solution has a Features/tasks.json file
  And the file has the following format for a task
  """
  [{
    "name": "I should be able to do something",
    "status": "<Status>"
  }]
  """
  When I define a step like this
  """
  Then I should be able to do something --TASK
  """
  And I end the step with --TASK
  And I specify a status of <Status> in the task list
  And I run the step
  Then the step should return a value of <Result>

  Examples: 
  | Status      | Result  |
  | Not Started | Pending |
  | In Progress | Failed  |
  | Complete    | Passed  |

Scenario: Task Based Step Example
  Given I have some precondition
  Then I should perform some task --TASK

Scenario Outline: Create Task Based Step With Table Parameter
  Given I have access to the solution
  And the solution has a Features/tasks.json file
  And the file has the following format for a task
  """
  [{
    "name": "I should be able to do something",
    "tableArgs" : { "values": ["Joe", "Good"], "status": "<Status>"}
  }]
  """
  When I define a step like this
  """
  Then I should be able to do something --TASK
  | Name | Status  |
  | Joe  | Good    |
  | Jane | Naughty |
  """
  And I end the step with --TASK
  And I specify a status of <Status> in the task list
  And I run the step
  Then the step should return a value of <Result>

  Examples: 
  | Status      | Result  |
  | Not Started | Pending |
  | In Progress | Failed  |
  | Complete    | Passed  |

Scenario: Task Based Step With Table Parameter Example
  Given I have some precondition
  Then I should perform some task --TASK
  | Person | Status  |
  | John   | Good    |
  | Jane   | Naughty |

