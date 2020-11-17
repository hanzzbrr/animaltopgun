using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HypaGames.AnimalTopGun
{
    public class PhaseMap : MonoBehaviour
    {

    }
    public enum PhaseType { Rest, Fight, Boss }

    public class Phase
    {
        private PhaseType _phaseType;
        private float timeDuration;

        public Phase(PhaseType phaseType)
        {
            _phaseType = phaseType;
        }
        public Phase(PhaseType phaseType, float timeDuration)
        {
            _phaseType = phaseType;
        }
    }
}