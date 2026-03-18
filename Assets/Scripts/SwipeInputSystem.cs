using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SwipeInputSystem : MonoBehaviour
{
    private Control mobileControl;
    private TileBoard tileBoard;

    private Vector2 startPos;
    private Vector2 endPos;

    public float minDistance = 50f;

    private void Awake()
    {
        mobileControl = new Control();
        tileBoard = GetComponent<TileBoard>();

        mobileControl.Touch.Press.performed += ctx =>
        {
            startPos = mobileControl.Touch.Position.ReadValue<Vector2>();
        };
        mobileControl.Touch.Press.canceled += ctx =>
        {
            endPos = mobileControl.Touch.Position.ReadValue<Vector2>();
            DetectSwipe();
        };

        

    }

    

    private void DetectSwipe()
    {
        Vector2 direction = endPos - startPos;

        if(direction.magnitude < minDistance)
        {
            return;
        }

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0f)
            {
                tileBoard.MoveTiles(Vector2Int.right, tileBoard.gridWidth - 2, -1, 0, 1);
            }
            else
            {
                tileBoard.MoveTiles(Vector2Int.left, 1, 1, 0, 1);
            }
        }
        else
        {
            if (direction.y > 0f)
            {
                // Debug.Log("ÉÏ»¬");
                tileBoard.MoveTiles(Vector2Int.up, 0, 1, 1, 1);
            }
            else
            {
                // Debug.Log("ÏÂ»¬");
                tileBoard.MoveTiles(Vector2Int.down, 0, 1, tileBoard.gridHeight - 2, -1);
            }
        }
    }

    private void OnEnable()
    {
        mobileControl.Enable();
    }

    private void OnDisable()
    {
        mobileControl.Disable();
    }
}
