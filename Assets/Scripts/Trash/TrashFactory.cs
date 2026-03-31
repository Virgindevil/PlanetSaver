using UnityEngine;
using Zenject;

public class TrashFactory
{
    private readonly DiContainer _container;

    public TrashFactory(DiContainer container)
    {
        _container = container;
    }

    public Trash Create(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent)
    {
        return _container.InstantiatePrefabForComponent<Trash>(
            prefab, position, rotation, parent
        );
    }
}
