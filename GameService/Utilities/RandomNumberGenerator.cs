namespace QuizGame.Utilities;

public class RandomNumberGenerator : IRandomNumberGenerator
{
    public int GetRandomInteger(int lowerBound, int upperBound)
    {
        Random rand = new Random();
        return rand.Next(lowerBound, upperBound);
    }
}