﻿using System;
using UnityEngine;

/// <summary>
/// This class holds all data needed to create a DataLogDTO object.
/// Data includes a timestamp, milliseconds since the start of the trial, head movement,
/// cursor and gaze position on screen, and pupil data(if using the Pupil Labs eye-tracker).
/// A DataLog represents the smallest timestep in the simulation, and is created every update.
/// </summary>

public class DataLog {

    public string TimeStamp;
    public double MsProgress;
    public Vector2 CursorPosition;
    public Vector2 GazePosition;
    public float HeadMovement;
    public float? PupilDiameterLeft;
    public float? PupilDiameterRight;
    public float? PupilDiameter3DLeft;
    public float? PupilDiameter3DRight;
    public float? PupilConfidenceLeft;
    public float? PupilConfidenceRight;
    public float? PupilTimestampLeft;
    public float? PupilTimestampRight;
    public Vector2 NosePosition;
    public float? HmdPositionX;
    public float? HmdPositionY;
    public float? HmdPositionZ;
    public float? HmdRotationX;
    public float? HmdRotationY;
    public float? HmdRotationZ;
    /// <summary>
    /// DataLog constructor.
    /// </summary>
    /// <param name="msProgress"> Milliseconds since start of the trial.</param>
    /// <param name="cursorPosition"> Position on the canvas of the cursor.</param>
    /// <param name="gazePosition"> Position on the canvas of the gaze.</param>
    /// <param name="pupilDiameterLeft"> Pupil diameter of the left eye. (PupilLabs only)</param>
    /// <param name="pupilDiameterRight"> Pupil diameter of the right eye. (PupilLabs only)</param>
    /// <param name="pupilDiameter3DLeft"> 3d Pupil diameter of the left eye. (PupilLabs only)</param>
    /// <param name="pupilDiameter3DRight"> 3d Pupil diameter of the right eye. (PupilLabs only)</param>
    /// <param name="pupilConfidenceLeft"> Pupil confidence of the left eye. (PupilLabs only)</param>
    /// <param name="pupilConfidenceRight"> Pupil confidence of the right eye. (PupilLabs only)</param>
    /// <param name="pupilTimestampLeft"> Pupil timestamp of the left eye. (PupilLabs only)</param>
    /// <param name="pupilTimestampRight"> Pupil timestamp of the right eye. (PupilLabs only)</param>
    /// <param name="headMovement"> Sum of angular head movement up to this DataLog.</param>
    /// <param name="nosePosition"> Position on the canvas to which the center of the head (nose) is pointing.</param>
    /// <param name="hmdPositionX"> X coordinate position of the hmd.</param>
    /// <param name="hmdPositionY"> Y coordinate position of the hmd.</param>
    /// <param name="hmdPositionZ"> Z coordinate position of the hmd.</param>
    /// <param name="hmdRotationX"> X coordinate rotation of the hmd.</param>
    /// <param name="hmdRotationY"> Y coordinate rotation of the hmd.</param>
    /// <param name="hmdRotationZ"> Z coordinate rotation of the hmd.</param>
    public DataLog(double msProgress, Vector2 cursorPosition, Vector2 gazePosition, float? pupilDiameterLeft, float? pupilDiameterRight, 
        float? pupilDiameter3DLeft, float? pupilDiameter3DRight, float? pupilConfidenceLeft, float? pupilConfidenceRight, float? pupilTimestampLeft, float? pupilTimestampRight, 
        float headMovement, Vector2 nosePosition, float? hmdPositionX, float? hmdPositionY, float? hmdPositionZ, float? hmdRotationX, float? hmdRotationY, float? hmdRotationZ)
    {
        TimeStamp = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt");
        MsProgress = msProgress;
        CursorPosition = cursorPosition;
        GazePosition = gazePosition;
        PupilDiameterLeft = pupilDiameterLeft;
        PupilDiameterRight = pupilDiameterRight;
        PupilDiameter3DLeft = pupilDiameter3DLeft;
        PupilDiameter3DRight = pupilDiameter3DRight;
        PupilConfidenceLeft = pupilConfidenceLeft;
        PupilConfidenceRight = pupilConfidenceRight;
        PupilTimestampLeft = pupilTimestampLeft;
        PupilTimestampRight = pupilTimestampRight;
        HeadMovement = headMovement;
        NosePosition = nosePosition;
        HmdPositionX = hmdPositionX;
        HmdPositionY = hmdPositionY;
        HmdPositionZ = hmdPositionZ;
        HmdRotationX = hmdRotationX;
        HmdRotationY = hmdRotationY;
        HmdRotationZ = hmdRotationZ;
    }
    
    /// <summary>
    /// Create a new DataLogDTO.
    /// </summary>
    /// <param name="testTrialId"> The Id of the trial that this DTO is a part of.</param>
    /// <returns> The newly created DTO.</returns>
    public DataLogDTO CreateDTO(int testTrialId)
    {
        return new DataLogDTO(testTrialId, TimeStamp, MsProgress, CursorPosition.x, CursorPosition.y, GazePosition.x, GazePosition.y,
            PupilDiameterLeft, PupilDiameterRight, PupilDiameter3DLeft, PupilDiameter3DRight, PupilConfidenceLeft, PupilConfidenceRight, PupilTimestampLeft, PupilTimestampRight,
            HeadMovement, NosePosition.x, NosePosition.y, HmdPositionX, HmdPositionY, HmdPositionZ, HmdRotationX, HmdRotationY, HmdRotationZ);
    }
}
