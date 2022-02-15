Feature: GetPlayerScore

Player Sends Token And Asks For Current Score On Certain Leaderboard

@tag1
Scenario: Player Asking For Leaderboard Score With Token. Server Should Find Player Id With Token And Find The Score With Player Id
	Given Player Token & Player Id
	When Asking For Player score
	Then Return Score To The Player
