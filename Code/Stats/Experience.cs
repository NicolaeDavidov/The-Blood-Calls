﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDevTV.Saving;
using System;

namespace RPG.Stats
{
    public class Experience : MonoBehaviour, ISaveable
    {
        [SerializeField] float experiencePoints = 0;

        public event Action onExperienceGained;

        public void GainExperience(float expirience)
        {
            experiencePoints += expirience;
            onExperienceGained();
        }

        public object CaptureState()
        {
            return experiencePoints;
        }

        public float GetPoints()
        {
            return experiencePoints;
        }

        public void RestoreState(object state)
        {
            experiencePoints = (float)state; 
        }

        
    }
}
