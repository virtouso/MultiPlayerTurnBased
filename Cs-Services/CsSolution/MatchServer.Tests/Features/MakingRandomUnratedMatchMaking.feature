Feature: MakingRandomUnratedMatchMaking

A Player Joins Match Server And Asks For A Match


Scenario: New Player Joined The Server And There Is No Player Waiting For New Match
	Given There Is No Waiting Player
	When New Player has Joined The Unrated Lobby
	Then Add Player To The Waitning List
    Then  Send The Player To Wait For Certain Time
	
Scenario:  New Player Joined The Server And There Is At Least One Player In Lobby
   Given There Is At Least One Waiting Player
   When New Player Has Joined The Unrated Lobby
   Then Make A Group,
   Then Send The Group Id To Both Players
   Then Remove Both Players From Lobby List






