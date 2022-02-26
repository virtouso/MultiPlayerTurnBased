Feature: InitializePlayer

Initialize Player On Different Conditions


Scenario: Player Has Auth Token And Is Not Valid
	Given Auth Token Not Exist
	Given Auth Token Is Expired
	When Ask To  Initialize Player Data
	Then Return 401 To The Player



Scenario: Player Has Token And Is Valid
	Given Auth Token Exist
	Given Auth Token Is Not Expired
	When Ask TO Intialize Player Data
	Then Return 200 To The Player



Scenario: Player Has Not Token And Has Not Any Service Id
	Given Auth Token Is Null
	Given No Service Id Is Sent
	When Ask To Initialize Player Data As Guest and Set New Record To Database
	Then  IsGuest Is True And Return 200 And Player Auth Token



Scenario: Player Has Not Token But Has A Service Id
	Given  Auth Token Is Null
	Given Service Id Is Not Null
	When Try Find Player Record With Id Otherwise Assign New Record For The Player
	Then Is Guest Is False Return 200 To Player And Return Auth Token





 


