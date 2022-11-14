using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class TileSelector
{
    public Camera MainCam;
    public LayerMask layerMask;

    public GameObject start;
    public GameObject goal;

    private bool clicked = true;

    // // \\ // \\ // \\
    public TileSelector(Camera _mainCam, LayerMask _layerMask, InterfaceManager _instance)
    {
        MainCam = _mainCam;
        this.layerMask = _layerMask;

        _instance.onMouseDown += OnMouseDown;
        _instance.onEnter += OnCalculationStart;
    }
    // \\ // \\ // \\ //

    // // \\ // \\ // \\
    private void OnMouseDown()
    {
        Ray ray = MainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 200f, layerMask))
        {
            if (clicked)
            {
                if(start != null)
                {
                    start.layer = 0;
                    start.transform.position = new Vector3(start.transform.position.x, 0f, start.transform.position.z);
                }
                start = hitInfo.transform.gameObject;
                start.transform.position = new Vector3(start.transform.position.x, 0.15f, start.transform.position.z);
                start.layer = 9;
                clicked = false;
            }
            else
            {
                if(goal != null)
                {

                    goal.layer = 0;
                    goal.transform.position = new Vector3(goal.transform.position.x, 0f, goal.transform.position.z);
                }
                goal = hitInfo.transform.gameObject;
                goal.transform.position = new Vector3(goal.transform.position.x, 0.15f, goal.transform.position.z);
                goal.layer = 9;
                clicked = true;
            }
        }
    }
    // \\ // \\ // \\ //


    // // \\ // \\ // \\
    public void OnCalculationStart()
    {
        if(start != null && goal != null)
        {

            WorldManager.GetInstance().CalculatePath(start,goal);
        }
    }
    // \\ // \\ // \\ //
}
