Feature: PlayerAskedToContinueAsPermanentUser
         Player Has Sent GooglePlay Id. Make A New Permanent Token.   


Scenario: Player Has Sent GooglePlay Id And Has Previous Record
	Given Previous Record Is Not Null 
	Given GooglePlay Is Not Null
	When Ask The Player To Select Which Progress
	Then AskPlayer Flag Is True
	Then Temp Record Is Not Null
	Then Permanent Record Is Not Null


Scenario: Player Has Sent GooglePlay Id And Has No Previous Record
   Given Previous Record Is Null
   Given GooglePlay Id Is Not Null
   When Inset Temp Into Permanent And Clear Temp
   Then AskPlayer Flag Is False
   Then Token Is Not Null
   Then Temp Record Is False
   Then Temp Flag Is False



Scenario: Player Has Selected Progress
   Given Selection Enum Value Is Not None
   When Inset Temp Into Permanent And Clear Temp
   Then AskPlayer Flag Is False
   Then Token Is Not Null
   Then Temp Record Is False
   Then Temp Flag Is False
