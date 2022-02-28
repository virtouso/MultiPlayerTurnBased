namespace LeaderBoard.Mediator
{
    public interface ILeaderBoardMediator
    {
        bool UpdateLeaderBoardRecord(string leaderBoardName, string jwtToken, int score);

        int? GetLeaderBoardScore(string leaderBoardName, string jwtToken);

        List<(string, int)> GetLeaderBoard(string leaderBoardName, string jwtToken);




    }
}
