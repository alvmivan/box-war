using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public ShipView shipView;

    public bool byDistance;

    public Arsenal arsenal;

    private Camera cam;

    private readonly ScreenInput input = new ScreenInput();

    private Vector2 initialDistance;


    private void Start() => cam = Camera.main;
    private void OnEnable() => arsenal.EnableAll();
    private void OnDisable() => arsenal.DisableAll();


    Vector2 GetPlayerInput()
    {
        if (!input.IsPressed()) return new Vector2(0, 0);

        var shipWorldPosition = shipView.GetPosition();
        var inputScreenPosition = input.GetPositionAtScreen();
        var shipScreenPosition = cam.WorldToScreenPoint(shipWorldPosition);

        var distance = (Vector3) inputScreenPosition - shipScreenPosition;

        if (input.JustPressed())
        {
            initialDistance = distance;
        }

        if (!byDistance)
        {
            return distance.normalized;
        }
        else
        {
            inputScreenPosition -= initialDistance;
            return ((Vector3) inputScreenPosition - shipScreenPosition).normalized;
        }
    }

    private void Update()
    {
        var move = GetPlayerInput();
        
        move = BoundMovement(move);

        shipView.Move(move);
    }


    private Vector2 BoundMovement(Vector2 move)
    {
        var viewMin = cam.WorldToViewportPoint(shipView.GetBoundMin());
        var viewMax = cam.WorldToViewportPoint(shipView.GetBoundMax());

        const float viewportOffset = 0.05f;

        if (viewMax.x >= 1 - viewportOffset && move.x > 0)
        {
            move.x = 0;
        }

        if (viewMin.x <= viewportOffset && move.x < 0)
        {
            move.x = 0;
        }

        if (viewMax.y >= 1 - viewportOffset && move.y > 0)
        {
            move.y = 0;
        }

        if (viewMin.y <= viewportOffset && move.y < 0)
        {
            move.y = 0;
        }

        return move;
    }
}


public class ScreenInput
{
    public bool JustPressed()
    {
        return Input.GetMouseButtonDown(0);
    }

    public bool JustReleased()
    {
        return Input.GetMouseButtonDown(0);
    }

    public Vector2 GetPositionAtScreen()
    {
        return Input.mousePosition;
    }

    public bool IsPressed()
    {
        return Input.GetMouseButton(0);
    }
}