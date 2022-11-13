using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceManager : MonoBehaviour
{
    public LayerMask layerMask;

    private WorldManager worldManager;

    public delegate void OnMouseDown();
    public OnMouseDown onMouseDown;

    private TileSelector tileSelector;

    private void Start()
    {
        tileSelector = new TileSelector(Camera.main,layerMask,this);
        worldManager = WorldManager.GetInstance();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            onMouseDown();
        }
    }
}
