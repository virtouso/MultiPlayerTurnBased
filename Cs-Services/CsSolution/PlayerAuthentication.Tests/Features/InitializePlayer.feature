Feature: InitializePlayer

Initialize Player On Different Conditions


Scenario: Player Has Auth Token And Is Not Valid
	Given Auth Token Is Not Null
	Given Auth Token Not Exist
	Given Auth Token Is Expired
	When Ask To  Initialize Player Data
	Then Return 401 To The Player





