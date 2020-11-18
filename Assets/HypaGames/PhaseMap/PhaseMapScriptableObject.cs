using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HypaGames.PhaseMap
{
    [CreateAssetMenu(fileName = "Phase Map", menuName = "Hypa Games/Phase Map", order = 1)]
    [System.Serializable]
    public class PhaseMapScriptableObject : ScriptableObject
    {
        public List<PhaseScriptableObject> PhaseMap;
    }
}