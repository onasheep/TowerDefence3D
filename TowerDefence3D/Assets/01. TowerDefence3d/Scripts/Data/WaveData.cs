using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveData", menuName = "WaveData", order = int.MinValue)]
public class WaveData : ScriptableObject
{
    public int waveIdx;
    public int blueMonCnt;    
    public int redMonCnt;
    public float bonusHp;
}
