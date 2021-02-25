﻿using UnityEngine;
using UnityEngine.UI;
using VehiclePhysics.Timing;

namespace Perrinn424.UI
{
    public class TimeLapDifference : MonoBehaviour
    {
        [SerializeField]
        private LapTimer lapTime = default;

        [SerializeField]
        private Text electricRecord = default;
        [SerializeField]
        private Text overallRecord = default;

        private TimeDiff919 diff = new TimeDiff919();

        private string format = "+0.0 s;-0.0 s;0.0 s";

        private void Update()
        {
            float currentLapTime = lapTime.currentLapTime;
            float currentLapDistance = Project424.Telemetry424.m_lapDistance;

            diff.Update(currentLapTime, currentLapDistance);

            electricRecord.text = diff.VolkswagenDiff.ToString(format);
            overallRecord.text = diff.PorscheDiff.ToString(format);
        }
    } 
}
