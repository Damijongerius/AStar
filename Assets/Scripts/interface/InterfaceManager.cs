using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class InterfaceManager : MonoBehaviour
{
    public LayerMask layerMask;

    private WorldManager worldManager;

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
        worldManager = WorldManager.GetInstance();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            onMouseDown();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("enter");
            onEnter();
        }
    }

    

    public static InterfaceManager Instance()
    {
        return instance;
    }
}
