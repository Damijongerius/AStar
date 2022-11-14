using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class InterfaceManager : MonoBehaviour
{
    public LayerMask layerMask;

    private WorldManager worldM;

    public delegate void OnMouseDown();
    public OnMouseDown onMouseDown;

    public delegate void OnEnter();
    public OnEnter onEnter;

    private TileSelector tileSelector;

    private static InterfaceManager instance;

    private void Start()
    {
        instance = this;
        tileSelector = new TileSelector(Camera.main,layerMask,this);
        worldM = WorldManager.GetInstance();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            onMouseDown();
            onEnter();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            WorldManager.GetInstance().Generate();
        }
    }

    

    public static InterfaceManager Instance()
    {
        return instance;
    }
}
