using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool IsPassable { get;  set; }
    public bool isTurret = default;
    public bool isObstacle = default;




    private void Awake()
    {
        isObstacle = false;
        IsPassable = true;
        isTurret = false;
    }
    // Start is called before the first frame update

}
