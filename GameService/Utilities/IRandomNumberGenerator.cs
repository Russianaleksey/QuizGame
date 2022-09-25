namespace QuizGame.Utilities;

public interface IRandomNumberGenerator
{
    /// <summary>
    /// Gets a random integer between the lower bound (inclusive) and upper bound (exclusive)
    /// </summary>
    /// <param name="lowerBound">Inclusive lower bound on the random integer</param>
    /// <param name="upperBound">Exclusive upper bound on the random integer</param>
    /// <returns>A random integer</returns>
    int GetRandomInteger(int lowerBound, int upperBound);
}