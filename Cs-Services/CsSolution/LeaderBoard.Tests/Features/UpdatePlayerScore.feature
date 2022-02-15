Feature: UpdatePlayerScore
After Match Ending The Game Updates Players Score



Scenario: Update Player Score With Incremental Score
	Given Player Score is Empty
	When Player Score Is Sent
	Then Player Score Is The Initiated Value



Scenario: Update Player Score With Decremental Score And Current Score Is Bigger Than Apllying Score
	Given Player Score Is Bigger Than Applying
	When Applying Score Is Negative
	Then Player Score Is New Positive Value


Scenario: Update Player Score With Decremental Score And Current Score Is Less Than Apllying Score
	Given Player Score Is Less Than Applying
	When Applying Score Is Negative
	Then Player Score Is 0 And Not Negative
