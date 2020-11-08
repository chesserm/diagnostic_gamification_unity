using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PatientData
{
    #region DataProperties
    // 12 values in initial presentation data
    public List<string> InitialData { get; set; }

    // General Exam information
    public List<String> GeneralExamData { get; set; }

    // Head Exam Information
    public String HeadData { get; set; }

    // Neck Exam Information
    public String NeckData { get; set; }

    // Lung Exam Information
    public String LungData { get; set; }

    // Extremities Exam Information
    public String ExtremitiesData { get; set; }

    // Skin Exam Information
    public String SkinData { get; set; }

    // Abdomen Exam Information
    public String AbdomenData { get; set; }

    // Oxygen Exam Information (2 values)
    public List<String> OxygenData { get; set; }

    // 16 values in bloodwork
    public List<double> BloodworkData { get; set; }

    // XRayImage
    public Texture2D XRayImage;

    // Diagnosis
    public DiagnosisState Diagnosis { get; set; }

    #endregion

    // Default constructor
    public PatientData()
    {

    }


}
