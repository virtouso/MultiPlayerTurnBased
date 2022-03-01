namespace LeaderBoard.Mediator
{
    public class LeaderBoardMediator : ILeaderBoardMediator
    {
        public List<(string, int)> GetLeaderBoard(string leaderBoardName, string jwtToken)
        {
            throw new NotImplementedException();
        }

        public int? GetLeaderBoardScore(string leaderBoardName, string jwtToken)
        {
            throw new NotImplementedException();
        }

        public bool UpdateLeaderBoardRecord(string leaderBoardName, string jwtToken, int score)
        {
            throw new NotImplementedException();
        }
    }
}
