using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(ObjectClickHandler))]
[RequireComponent(typeof(PlanetRotation))]
[RequireComponent(typeof(TrashSpawner))]
public class Planet : MonoBehaviour
{
    public Vector3 Scale { get; private set; }

    private void Start()
    {
        Scale = transform.localScale;
    }

    public void SetPlanetScale(int multiply)
    {
        transform.localScale = new Vector3(transform.localScale.x + multiply, transform.localScale.y + multiply, transform.localScale.z + multiply);
        Scale = transform.localScale;
    }
}
