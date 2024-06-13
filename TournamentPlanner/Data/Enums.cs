namespace TournamentPlanner.Data
{
    public enum GameModeListType
    {
        WhiteList,
        BlackList
    }

    public enum BlockTeamListType
    {
        Input,
        Output
    }

    public enum BlockType
    {
        RoundRobin,
        SingleElimination,
        DoubleElimination,
        Split,
        Knockout

    }

    public enum ListManipulationType
    {
        MergeABAB,
        MergeAABB,
        KeepA,
        KeepB,
        Take4,
        Take8,
        Tail,
        Head,

    }
}
