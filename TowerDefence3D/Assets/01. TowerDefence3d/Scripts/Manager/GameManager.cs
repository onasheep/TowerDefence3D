using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : GSingleton<GameManager>
{
    public int waveIdx = default;
    public float gameTime;

    public List<WaveData> waveDataList;
    public override void Awake()
    {
        base.Awake();
        waveIdx = 0;
    }


}
