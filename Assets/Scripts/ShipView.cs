using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipView : MonoBehaviour
{

    public float speedMove;
    public Collider shipCollider;
    public Transform shipTransform;
    private Vector3 lastDirection = new Vector2(0,0);

    public void Move(Vector2 direction)
    {
        lastDirection = shipTransform.right * direction.x + shipTransform.forward * direction.y;
    }

    private void Update()
    {
        shipTransform.position += lastDirection * (Time.deltaTime * speedMove);
    }

    public Vector3 GetPosition()
    {
        return shipTransform.position;
    }

    public Vector3 GetBoundMin()
    {
        return shipCollider.bounds.min;
    }

    public Vector3 GetBoundMax()
    {
        return shipCollider.bounds.max;
    }
}
