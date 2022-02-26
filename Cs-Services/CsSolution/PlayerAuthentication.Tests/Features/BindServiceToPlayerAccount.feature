Feature: BindServiceToPlayerAccount
      Player Has Signed As A Guest Or Didnt Loged In With One Or More Services Then Player Attempts To Add Service Or Change Account To Permanent



Scenario: Player Is Guest And Decides To Turn Account To Permanent
	Given New Service Id Is Not Null
	Given There is No Other Services
	Given Player Is Guest
	Given There Is No Other Service
	When Select higher Progress And Remove Old Lower Progress and Unify The Records
	Then IsGuest Is False And Related Service Id And Email  Not Null



Scenario: Player Is Not Guest And Wants To Bind A New Service To Account
	Given New Service Id Is Not Null
	Given There is No Other Services
	Given Player Is Not Guest
	Given There Is At Least One Service To Player Account
	When Bind New Account To Player
	Then IsGuest Is False And New Services Account Include New service




