using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// This class contains a number of mathematical functions used by other classes with 
/// the purpose of calculating various variables related to Fitts' Law.
/// </summary>
class TestDataHelper {

    private const float LOG_TWO = 0.693147181f;
    private const float SQRT_2_PI_E = 4.132731354f;


    /// <summary>
    /// Calculate the throughput of the sequence.
    /// </summary>
    /// <param name="amplitudes"> Amplitude of the sequence.</param>
    /// <param name="deltaX"></param>
    /// <param name="times"> Mean completion time of the sequence of trials.</param>
    /// <returns> Returns the throughput for the sequence of trials.</returns>
    public static float CalculateThroughput(List<int> amplitudes, List<float> deltaX, List<double> times ) {
        float aeMean = Mean(amplitudes);
        float sdx = StandardDeviation(deltaX);
        float we = SQRT_2_PI_E * sdx;
        //float ide = (float)Math.Log(aeMean / we + 1f) / LOG_TWO; // bits
        float ide = (float)Math.Log(aeMean / we + 1f, 2); // bits
        float mtMean = Mean(times) / 1000f; // seconds
        return ide / mtMean; // bits per second
    }

    /// <summary>
    /// Calculate the effective width of the sequence.
    /// </summary>
    /// <param name="deltaX"></param>
    /// <returns> Returns the effective width.</returns>
    public static float CalculateEffectiveWidth(List<float> deltaX)
    {
        return SQRT_2_PI_E * StandardDeviation(deltaX);
    }

    /// <summary>
    /// Calculate the effective index of difficulty.
    /// </summary>
    /// <param name="amplitudes"></param>
    /// <param name="effectiveWidth"></param>
    /// <returns> Return the index of difficulty.</returns>
    public static float CalculateEffectiveDifficultyIndex(List<int> amplitudes, float effectiveWidth)
    {
        return (float)Math.Log(Mean(amplitudes) / effectiveWidth + 1f) / LOG_TWO; // bits
    }

    /// <summary>
    /// Calculate the default index of difficulty.
    /// </summary>
    /// <param name="amplitude"></param>
    /// <param name="width"></param>
    /// <returns>Return the index of difficulty.</returns>
    public static double CalculateIndexOfDifficulty(float amplitude, float width) {
        return Math.Log(amplitude / width + 1) / LOG_TWO;
    }
    
    /// <summary>
    /// Calculate the mean of the values in a list of floats. 
    /// </summary>
    /// <param name="n"> List of floats n.</param>
    /// <returns> Return the mean.</returns>
    public static float Mean(List<float> n )
    {
        float mean = 0;
        foreach (float val in n)
            mean += val;
        return mean / n.Count;
    }


    /// <summary>
    /// Convert a list of ints to a list of floats.
    /// </summary>
    /// <param name="n"> List of ints n.</param>
    /// <returns> Return the list.</returns>
    public static float Mean(List<int> n)
    {
        return Mean(new List<float>(n.ConvertAll(x => (float)x)));
    }

    /// <summary>
    /// Convert a list of doubles to a list of floats.
    /// </summary>
    /// <param name="n"> List of doubles n.</param>
    /// <returns> Return the list.</returns>
    public static float Mean(List<double> n) {
        return Mean(new List<float>(n.ConvertAll(x => (float)x)));
    }
    
    /// <summary>
    /// Calculates the hypotenuse of two numbers.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns> Return the hypotenuse.</returns>
    public static double Hypotenuse(float a, float b)
    {
        return Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
    }
    
    /// <summary>
    /// Calculate the standard deviation of values in a float array.
    /// </summary>
    /// <param name="n"> List of floats n.</param>
    /// <returns> Return the standard deviation.</returns>
    public static float StandardDeviation(List<float> n) {
        float m = Mean(n);
        float t = 0;
        foreach (float val in n)
            t += (m - val) * (m - val);

        return (float)Math.Sqrt(t / (n.Count - 1.0f));
    }

    /*
     * Convert list of Vector2 offsets to list of magnitude values
     */
    /// <summary>
    /// Convert list of Vector2 offsets to list of magnitude values.
    /// </summary>
    /// <param name="deltas"> List of Vector2 offsets.</param>
    /// <returns> Return the list of magnitudes.</returns>
    public static List<float> CalculateDeltaX(List<Vector2> deltas)
    {
        List<float> deltaX = new List<float>();
        foreach (Vector2 delta in deltas)
            deltaX.Add(delta.magnitude);
        return deltaX;
    }
}
