Feature: UpdatePlayerScore
After Match Ending The Game Updates Players Score



Scenario: Update Player Score With Incremental Score
	Given Player Score is Empty
	When Player Score Is Sent
	Then Player Score Is The Initiated Value



Scenario: Update Player Score With Decremental Score And Current Score Is Bigger Than Apllying Score
	Given Player Score Is 50
	When Applying Score Is -20
	Then Player Score Is 30


Scenario: Update Player Score With Decremental Score And Current Score Is Less Than Apllying Score
	Given Player Score Is 10
	When Applying Score Is -20
	Then Player Score Is 0 And Not Negative
