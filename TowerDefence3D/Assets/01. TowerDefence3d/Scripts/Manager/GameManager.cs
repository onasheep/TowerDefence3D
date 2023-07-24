using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : GSingleton<GameManager>
{
    public int waveIdx = default;
    public int gold = default;
    public int hp = default;

    public List<WaveData> waveDataList;
    public MapBoard mapBoard;

    public override void Awake()
    {
        base.Awake();
        waveIdx = 0;
        mapBoard = GFunc.GetRootObj("MapBoard").GetComponent<MapBoard>();
    }


}
