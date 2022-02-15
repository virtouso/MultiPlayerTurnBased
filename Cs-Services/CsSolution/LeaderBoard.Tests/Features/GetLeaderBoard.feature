Feature: GetLeaderBoard

Player Asks For A LeaderBoard Then Server Checks Config On Server About Number of Players Should Be returned And Sends It Back To Client


Scenario: Current Players On Leaderboard Is Equal Or Bigger Than Config Top LeaderboardPlayers
	Given Count Of Selected Top Players Is Any Number Bigger Than Zero
	Given Config Of Count Of Returning Players Is Less or Equal Than Current Players On Leaderboard 
	When Get List Of Top LeaderBoard Players
	Then Return Json Record Of Top Players With Server Config Count With Their DisplayId & Score 




Scenario: Current Players On Leaderboard Is Less Than Config Top LeaderboardPlayers
	Given Count Of Selected Top Players Is Any Number Bigger Than Zero
	Given Config Of Count Of Returning Players Is Bigger Current Players On Leaderboard 
	When Get List Of Top LeaderBoard Players
	Then Return Json Record Of Top Players With All Players On Leaderboard Count With Their DisplayId & Score 
