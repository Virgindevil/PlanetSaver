using System.ComponentModel;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Planet _planet;
    [SerializeField] private Score _scoreUI;
    [SerializeField] private TrashSpawner _trashSpawner;
    [SerializeField] private TrashCounter _trashCounterUI; 

    public override void InstallBindings()
    {
        Container.BindInstance(_camera).AsSingle();
        Container.BindInstance(_planet).AsSingle();
        Container.BindInstance(_scoreUI).AsSingle();
        Container.BindInstance(_trashSpawner).AsSingle();
        Container.BindInstance(_trashCounterUI).AsSingle();

        Container.Bind<TrashFactory>().AsSingle();
        Container.Bind<ProseedGeneration>().AsSingle();
                
        Container.Bind<Health>().FromComponentInHierarchy().AsSingle();
        Container.Bind<WinScreen>().FromComponentInHierarchy().AsSingle();
        Container.Bind<GameOverScreen>().FromComponentInHierarchy().AsSingle();
    }
}
