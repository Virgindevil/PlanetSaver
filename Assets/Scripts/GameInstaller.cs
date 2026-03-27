using System.ComponentModel;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private TrashSpawner _trashSpawner;
    [SerializeField] private Score _scoreUI;
    [SerializeField] private TrashCounter _trashCounterUI; 

    public override void InstallBindings()
    {
        Container.BindInstance(_trashSpawner).AsSingle();
        Container.BindInstance(_scoreUI).AsSingle();
        Container.BindInstance(_trashCounterUI).AsSingle();
        Container.Bind<TrashFactory>().AsSingle();

        // Если Health тоже на сцене и нужен другим:
        Container.Bind<Health>().FromComponentInHierarchy().AsSingle();
    }
}
