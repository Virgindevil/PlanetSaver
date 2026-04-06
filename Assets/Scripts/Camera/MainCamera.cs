using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Vector3 Position { get; private set; }

    private void Start()
    {
        Position = transform.position;
    }

    public void SetCameraPosition(int multiply)
    {
        float currentZ = Position.z - multiply;
        transform.position = new Vector3(transform.position.x, transform.position.y, currentZ);
        Position = transform.position;
    }
}
