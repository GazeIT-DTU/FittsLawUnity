﻿using System;
using System.Collections;
using System.Collections.Generic;
using SQLite4Unity3d;
using UnityEngine;

/// <summary>
/// This is a DTO class with no business logic, used solely for moving data to the database.
/// </summary>
[Table("DataLogs")]
public class DataLogDTO
{
    [PrimaryKey, AutoIncrement]
    public int DataLogId { get; set; }
    public int TestTrialId { get; set; }
    public string TimeStamp { get; set; }
    public double MsProgress { get; set; }
    public float CursorPositionX { get; set; }
    public float CursorPositionY { get; set; }
    public float GazePositionX { get; set; }
    public float GazePositionY { get; set; }
    public float? PupilDiameterLeft { get; set; }
    public float? PupilDiameter3DLeft { get; set; }
    public float? PupilDiameter3DRight { get; set; }
    public float? PupilDiameterRight { get; set; }
    public float? PupilConfidenceLeft{ get; set; }
    public float? PupilConfidenceRight { get; set; }
    public float? PupilTimestampLeft { get; set; }
    public float? PupilTimestampRight { get; set; }
    public float HeadMovement { get; set; }
    public float NosePositionX { get; set; }
    public float NosePositionY { get; set; }
    public float? HmdPositionX { get; set; }
    public float? HmdPositionY { get; set; }
    public float? HmdPositionZ { get; set; }
    public float? HmdRotationX { get; set; }
    public float? HmdRotationY { get; set; }
    public float? HmdRotationZ { get; set; }
    /// <summary>
    /// DataLogDTO constructor.
    /// </summary>
    /// <param name="testTrialId"> Id of the trial this data log is a part of.</param>
    /// <param name="timeStamp"> Timestamp in "MM/dd/yyyy hh:mm:ss.fff tt" format.</param>
    /// <param name="msProgress"> Milliseconds since start of trial.</param>
    /// <param name="cursorPositionX"> X coordinate of the cursor position.</param>
    /// <param name="cursorPositionY"> Y coordinate of the cursor position.</param>
    /// <param name="gazePositionX"> X coordinate of the gaze position.</param>
    /// <param name="gazePositionY"> Y coordinate of the gaze position.</param>
    /// <param name="pupilDiameterLeft"> Pupil diameter of the left eye. (PupilLabs only)</param>
    /// <param name="pupilDiameterRight"> Pupil diameter of the right eye. (PupilLabs only)</param>
    /// <param name="pupilDiameter3DLeft"> 3d Pupil diameter of the left eye. (PupilLabs only)</param>
    /// <param name="pupilDiameter3DRight"> 3d Pupil diameter of the right eye. (PupilLabs only)</param>
    /// <param name="pupilConfidenceLeft"> Pupil confidence of the left eye. (PupilLabs only)</param>
    /// <param name="pupilConfidenceRight"> Pupil confidence of the right eye. (PupilLabs only)</param>
    /// <param name="pupilTimestampLeft"> Pupil timestamp of the left eye.</param>
    /// <param name="pupilTimestampRight"> Pupil timestamp of the right eye.</param>
    /// <param name="headMovement"> Sum of angular head movement up to this DataLog.</param>
    /// <param name="nosePositionX"> X coordinate on the canvas to which the center of the head (nose) is pointing.</param>
    /// <param name="nosePositionY"> Y coordinate on the canvas to which the center of the head (nose) is pointing.</param>
    /// <param name="hmdPositionX"> X coordinate position of the hmd.</param>
    /// <param name="hmdPositionY"> Y coordinate position of the hmd.</param>
    /// <param name="hmdPositionZ"> Z coordinate position of the hmd.</param>
    /// <param name="hmdRotationX"> X coordinate rotation of the hmd.</param>
    /// <param name="hmdRotationY"> Y coordinate rotation of the hmd.</param>
    /// <param name="hmdRotationZ"> Z coordinate rotation of the hmd.</param>
    public DataLogDTO(int testTrialId, string timeStamp,
        double msProgress, float cursorPositionX, float cursorPositionY, float gazePositionX, float gazePositionY, float? pupilDiameterLeft, float? pupilDiameterRight,
        float? pupilDiameter3DLeft, float? pupilDiameter3DRight, float? pupilConfidenceLeft, float? pupilConfidenceRight, float? pupilTimestampLeft, float? pupilTimestampRight,
        float headMovement, float nosePositionX, float nosePositionY, float? hmdPositionX, float? hmdPositionY, float? hmdPositionZ, float? hmdRotationX, float? hmdRotationY, float? hmdRotationZ) {
        TestTrialId = testTrialId;
        TimeStamp = timeStamp;
        MsProgress = msProgress;
        CursorPositionX = cursorPositionX;
        CursorPositionY = cursorPositionY;
        GazePositionX = gazePositionX;
        GazePositionY = gazePositionY;
        PupilDiameterLeft = pupilDiameterLeft;
        PupilDiameterRight = pupilDiameterRight;
        PupilDiameter3DLeft = pupilDiameter3DLeft;
        PupilDiameter3DRight = pupilDiameter3DRight;
        PupilConfidenceLeft = pupilConfidenceLeft;
        PupilConfidenceRight = pupilConfidenceRight;
        PupilTimestampLeft = pupilTimestampLeft;
        PupilTimestampRight = pupilTimestampRight;
        HeadMovement = headMovement;
        NosePositionX = nosePositionX;
        NosePositionY = nosePositionY;
        HmdPositionX = hmdPositionX;
        HmdPositionY = hmdPositionY;
        HmdPositionZ = hmdPositionZ;
        HmdRotationX = hmdRotationX;
        HmdRotationY = hmdRotationY;
        HmdRotationZ = hmdRotationZ;
    }
}
