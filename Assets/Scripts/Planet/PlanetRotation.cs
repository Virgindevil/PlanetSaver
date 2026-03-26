using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 10f;

    void Update()
    {
        Vector3 rotation = transform.eulerAngles;
        rotation.y += _rotateSpeed * Time.deltaTime;
        transform.eulerAngles = rotation;
    }
}