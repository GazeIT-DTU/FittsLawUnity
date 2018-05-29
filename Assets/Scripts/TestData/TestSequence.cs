using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// This class collects all data needed to create a TestSequenceDTO. Data includes the 
/// targets' base and effective amplitude, width and index of difficulty, start time, 
/// the block that the sequence is a part of, number of repeats, number and percentage of errors,
/// mean movement time and throughput.A lot of this data is computed through helper functions,
/// some in this class and others in the TestDataHelper class.
/// A TestSequence is represented by one ring of targets in the experiment.
/// </summary>
public class TestSequence {
    // Sequence parameters.
    public int SequenceNumber;
    public int TargetAmplitude;
    public float TargetWidth;
    public List<TestTrial> Trials;

    // Test Result Data.
    public DateTime StartTime;
    public double IndexOfDifficulty;
    public float EffectiveAmplitude;
    public float EffectiveTargetWidth;
    public float EffecttiveIndexOfDifficulty;
    public int SequenceOfRepeats;
    public int Errors;
    public float MovementTime;
    public float ErrorRate;
    public float Throughput;

    /// <summary>
    /// TestSequence constructor. 
    /// </summary>
    /// <param name="sequenceNumber"> Number of the specific sequence (out of a number of sequences that a block makes up).</param>
    /// <param name="targetAmplitude"> The amplitude that all trial targets will use.</param>
    /// <param name="targetWidth"> The width that all trial targets will use.</param>
    /// <param name="numberOfTrials"> Number of trials in the entire sequence.</param>
    public TestSequence(int sequenceNumber, int targetAmplitude, float targetWidth, int numberOfTrials)
    {
        SequenceNumber = sequenceNumber;
        TargetAmplitude = targetAmplitude;
        TargetWidth = targetWidth;

        IndexOfDifficulty = TestDataHelper.CalculateIndexOfDifficulty(targetAmplitude, targetWidth);
        Trials = GenerateTestSteps(numberOfTrials);
    }

    /// <summary>
    /// Generates TestTrials and gives them a temporary angle.
    /// 90 degrees are added here as we want the targets to start spawning 
    /// straight up from the center of the screen at a distance of TargetAmplitude.
    /// </summary>
    /// <param name="amountOfTargets"></param>
    /// <returns></returns>
    private List<TestTrial> GenerateTestSteps(int amountOfTargets) {
        float deltaAngle = 360f / amountOfTargets;
        List<TestTrial> steps = new List<TestTrial>();
        for (int i = 0; i < amountOfTargets; i++) {
            float angle = i * deltaAngle;
            steps.Add(new TestTrial(angle + 90));
        }
        return steps;
    }
    
    /// <summary>
    /// Calculate the mean effective amplitude. 
    /// </summary>
    public void CalculateEffectiveAmplitude()
    {
        List<double> effectiveAmplitudes = new List<double>();
        for (int i = 0; i < Trials.Count; i++)
        {
            Vector2 from = Vector2.zero;
            if (i > 0)
                from = TestController.GetTargetSpawnPosition(TargetAmplitude, Trials[i-1].TargetAngle);
            Vector2 to = TestController.GetTargetSpawnPosition(TargetAmplitude, Trials[i].TargetAngle);
            effectiveAmplitudes.Add(Trials[i].CalculateTrialAe(from, to, to + Trials[i].TargetCenterError));
        }
        EffectiveAmplitude = TestDataHelper.Mean(effectiveAmplitudes);
    }
    
    /// <summary>
    ///  Center error is the distance from the center of the target in x and y coordinates when the target is activated.
    /// </summary>
    /// <returns> Returns a list of center errors for all trials.</returns>
    public List<Vector2> GetTrialCenterError()
    {
        return Trials.Select(trial => trial.TargetCenterError).ToList();
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns> Returns a list of the times to activate each target.</returns>
    public List<double> GetMovementTimes()
    {
        return Trials.Select(trial => trial.TimeToActivate).ToList();
    }

    /// <summary>
    /// Calculates the mean movement time for the sequence.
    /// </summary>
    public void CalculateMeanMovementTime()
    {
        MovementTime = TestDataHelper.Mean(Trials.Select(trial => trial.TimeToActivate).ToList());
    }

    /// <summary>
    /// Calculate the error rate percentage for the sequence.
    /// </summary>
    public void CalculateErrorRate()
    {
        ErrorRate = ((float) Errors / (float) Trials.Count) * 100;
    }

    /// <summary>
    /// The Fitts' Law Experiment requires targets to spawn by alternating positions around a circle.
    /// This function updates the angle for each target after spawning.
    /// </summary>
    public void UpdateAnglesBeforeLogging()
    {
        float deltaAngle = 360f / Trials.Count;
        for (int i = 0; i < Trials.Count; i++)
        {
            if (i % 2 == 0)
            {
                Trials[i].UpdateTrialAngleForLogging(Mathf.FloorToInt(i / 2) * deltaAngle);
            }
            else
            {
                Trials[i].UpdateTrialAngleForLogging((Mathf.CeilToInt(Trials.Count / 2) + Mathf.CeilToInt(i / 2) + 1) * deltaAngle);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="testBlockId"> The Id of the block that this sequence is a part of.</param>
    /// <returns> Returns a TestSequenceDTO.</returns>
    public TestSequenceDTO CreateDTO(int testBlockId)
    {
        return new TestSequenceDTO(SequenceNumber, testBlockId, StartTime, TargetAmplitude, TargetWidth, IndexOfDifficulty,
            EffectiveAmplitude, EffectiveTargetWidth, EffecttiveIndexOfDifficulty, SequenceOfRepeats, Errors, MovementTime, ErrorRate, Throughput);
    }
}
