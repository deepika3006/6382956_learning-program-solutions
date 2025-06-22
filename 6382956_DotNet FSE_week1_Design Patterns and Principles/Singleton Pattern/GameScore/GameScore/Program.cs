using System;

class GameScore
{
    public static readonly GameScore ScoreManager = new GameScore();
        private int highScore;
    private GameScore()
    {
        Console.WriteLine("Score Manager Ready!");
        highScore = 0;
    }
    public void UpdateScore(int score)
    {
        if (score > highScore)
        {
            highScore = score;
            Console.WriteLine("New High Score: " + highScore);
        }
        else
        {
            Console.WriteLine("Score " + score + " is less than current high score.");
        }
    }
    public void ShowHighScore()
    {
        Console.WriteLine("Current High Score: " + highScore);
    }
}

class Program
{
    static void Main(string[] args)
    {
        GameScore player1 = GameScore.ScoreManager;
        player1.UpdateScore(50);
        GameScore player2 = GameScore.ScoreManager;
        player2.UpdateScore(40);
        GameScore player3 = GameScore.ScoreManager;
        player3.UpdateScore(70);
        GameScore.ScoreManager.ShowHighScore();
        if (player1 == player2 && player2 == player3)
        {
            Console.WriteLine("All players used the same Score Manager. Singleton works!");
        }
    }
}
