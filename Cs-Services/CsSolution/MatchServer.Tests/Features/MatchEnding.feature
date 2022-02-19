Feature: MatchEnding
Match Has Ended And Both Players Should Return Result Of Their Match



Scenario: Both Players Has Sent The Result Of Their Match And Their Both Results Are Valid
	Given The Result They Have Sent Are The Same
	When Both Player Have Send The Match Result
	Then Log Needed Results
	Then Update Database Related Valued
	Then Send Both Players The Match Results
	Then Remove The Match Group
