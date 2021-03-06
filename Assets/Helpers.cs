﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HelperNamespace
{
    // Enums to avoid using cryptic ints or having to rely on string comparisons
    #region CustomStateEnums
    public enum SymptomState
    {
        General,
        Head,
        Neck,
        Heart,
        Lungs,
        Extremities,
        Abdomen,
        Oxygen,
        Imaging,
        Bloodwork,
        Skin,
        Nothing
    }

    public enum ReasoningState
    {
        Correct,
        Incorrect1,
        Incorrect2,
        Incorrect3,
        Undecided
    }


    public enum DiagnosisState
    {
        Undiagnosed,
        COPD,
        Pneumonia,
        CHF
    }


    #endregion


    // Class to store constants that need to be referenced
    public static class PlayLoopData
    {
        #region ReasoningDictionary
        public static Dictionary<SymptomState, Dictionary<ReasoningState, string>> ReasoningValues =
            new Dictionary<SymptomState, Dictionary<ReasoningState, string>>
            {
                {
                    SymptomState.General,
                    new Dictionary<ReasoningState, string>
                    {
                        {ReasoningState.Correct, "Fever is a clue that points towards infections, like pneumonia."},
                        {ReasoningState.Incorrect1, "Respiratory failure patients with a fever guarantees pnuemonia as the underlying cause"},
                        {ReasoningState.Incorrect2, "High blood pressure is often an indicator of COPD."},
                        {ReasoningState.Incorrect3, "Confusion is an unlikely symptom of Pneumonia."}
                    }
                },
                {
                    SymptomState.Neck,
                    new Dictionary<ReasoningState, string>
                    {
                        {ReasoningState.Correct, "CHF patients often have distended jugular veins."},
                        {ReasoningState.Incorrect1, "Respiratory failure patients with distended jugular veins garuntees CHF as the underlying cause."},
                        {ReasoningState.Incorrect2, "Distended Jugular Veins will not occur in Pnuemonia patients."},
                        {ReasoningState.Incorrect3, "Distended Jugular Veins are a common finding in COPD"}
                    }
                },
                {
                    SymptomState.Heart,
                    new Dictionary<ReasoningState, string>
                    {
                        {ReasoningState.Correct, "CHF patients often have an abnormal heart rate or rhythm"},
                        {ReasoningState.Incorrect1, "Pneumonia patients nearly always present with irregular heart rhythm"},
                        {ReasoningState.Incorrect2, "COPD patients often have slower than normal heart rates"},
                        {ReasoningState.Incorrect3, "An irregular heart rhythm means CHF must be the cause"}
                    }
                },
                {
                    SymptomState.Lungs,
                    new Dictionary<ReasoningState, string>
                    {
                        {ReasoningState.Correct,    "COPD patients often have wheezing sounds."},
                        {ReasoningState.Incorrect1, "Pnuemonia patients often wheeze when exhaling."},
                        {ReasoningState.Incorrect2, "COPD patients tend to have crackling sounds in their lungs."},
                        {ReasoningState.Incorrect3, "CHF patients will have crackling in focal areas of the lungs"}
                    }
                },
                {
                    SymptomState.Extremities,
                    new Dictionary<ReasoningState, string>
                    {
                        {ReasoningState.Correct,    "Leg swelling (edema) is a common symptom of CHF"},
                        {ReasoningState.Incorrect1, "Edema is commonly found in the legs of COPD patients"},
                        {ReasoningState.Incorrect2, "CHF patients will always have edema in their extremities"},
                        {ReasoningState.Incorrect3, "Pneumonia patients will not have edema in their extremities"}
                    }
                },
                {
                    SymptomState.Abdomen,
                    new Dictionary<ReasoningState, string>
                    {
                        {ReasoningState.Correct,    "Abdomen distention can be a sign of CHF"},
                        {ReasoningState.Incorrect1, "COPD patients frequently present with abdomen distention"},
                        {ReasoningState.Incorrect2, "Pneumonia patients nearly always present with abdomen distention"},
                        {ReasoningState.Incorrect3, "Pneumonia patients will never present with a distended abdomen "}
                    }
                },
                {
                    SymptomState.Oxygen,
                    new Dictionary<ReasoningState, string>
                    {
                        {ReasoningState.Correct,    "COPD patients often have lower oxygen saturation levels than normal."},
                        {ReasoningState.Incorrect1, "COPD patients always have abnormal oxygen saturation levels"},
                        {ReasoningState.Incorrect2, "Pneumonia patients often have higher than normal oxygen saturation levels"},
                        {ReasoningState.Incorrect3, "CHF patients often have higher than normal oxygen saturation levels"}
                    }
                },
                {
                    SymptomState.Imaging,
                    new Dictionary<ReasoningState, string>
                    {
                        {ReasoningState.Correct, "Pneumonia patients have signs of pneumonia in particular areas of the lung"},
                        {ReasoningState.Incorrect1, "Pneumonia patients will have changes throughout the lungs"},
                        {ReasoningState.Incorrect2, "COPD patients will have abnormalities in specific areas of the lungs"},
                        {ReasoningState.Incorrect3, "CHF patients will have signs of fluid only in specific regions of the lungs"}
                    }
                },
                {
                    SymptomState.Bloodwork,
                    new Dictionary<ReasoningState, string>
                    {
                        {ReasoningState.Correct,    "Pneumonia Patients often have high WBC, CHF Patients often have high BNP levels"},
                        {ReasoningState.Incorrect1, "COPD patients often have a high WBC"},
                        {ReasoningState.Incorrect2, "Pneumonia patients often have high BNP"},
                        {ReasoningState.Incorrect3, "CHF patients often have a high WBC"}
                    }
                }
            }; // Outer dictionary definition

        #endregion



    }


}