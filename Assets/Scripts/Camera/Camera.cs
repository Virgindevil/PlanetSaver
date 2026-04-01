using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Vector3 Position { get; private set; }

    private void Start()
    {
        Position = transform.position;
        Debug.Log(Position);
    }

    public void SetCameraPosition(int multiply)
    {
        float currentZ = Position.z - multiply;
        transform.position = new Vector3(0, 0, currentZ);
        Position = transform.position;
    }
}
