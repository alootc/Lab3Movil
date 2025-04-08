using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nave Data", menuName = "ScriptableObjects/Sensors", order = 2)]
public class NaveData : ScriptableObject
{
    [System.Serializable]

    public class NaveDTO
    {
        public Sprite  imagen;

        public int health_max;
        public int move_speed;
        public int speed;
    }

    public List<NaveDTO> naves;


}
