using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Tile selectedTile;

    private void Awake()
    {
        ResManager.Instance.Create();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("1111111");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, LayerMask.NameToLayer("Tile")))
            {
                Debug.Log("2221111");
                selectedTile = hit.transform.GetComponent<Tile>();
                Debug.LogFormat("seltile is null ? {0}", selectedTile == null);
                if (selectedTile != null)
                { 
                }
                else { /* Do nothing */ }

            }

        }
    }
}
