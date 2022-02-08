Feature: InitializeGuestPlayer
  Initialize New User As Guest. Give It A Guest Token And Set Temp Flag True
  


Scenario: Player Only Has Started Using Device Id And No More Unique Data
	Given Device Id Is Not Null
	Given GooglePlay ID Is Null
	When Player Initial Model Submitted
	Then Temp Flag Is True And Temp Token Is Not Null
