Feature: PlayerAskedToContinueAsPermanentUser
         Player Has Sent GooglePlay Id. Make A New Permanent Token.   


Scenario: Player Has Sent GooglePlay Id And Has Previous Record
	Given Previous Record Is Not Null 
	Given GooglePlay Is Not Null
	When Ask The Player To Select Which Progress
	Then AskPlayer Flag Is True
	Then Temp Record Is Not Null
	Then Permanent Record Is Not Null