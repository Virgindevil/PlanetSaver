using UnityEngine;
using Zenject;

public class Health : MonoBehaviour
{
    private TrashSpawner _trashSpawner;

    [Inject]
    public void Construct(TrashSpawner trashSpawner)
    {
        _trashSpawner = trashSpawner;
    }

    private void Start()
    {
        var trashes = _trashSpawner.GetComponentsInChildren<Trash>();
        Debug.Log($"Найдено мусора: {trashes.Length}");
    }
}
