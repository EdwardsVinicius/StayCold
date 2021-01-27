using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Waves", menuName = "StayCold/Waves", order = 0)]
public class Wave : ScriptableObject
{
    [SerializeField] Hordes[] hordes;

    [Serializable]
    public class Hordes
    {
        public Enemy[] enemies;

        public Enemy[] GetHorde()
        {
            return enemies;
        }
    }

    public Hordes[] getHordes()
    {
        return hordes;
    }
}
