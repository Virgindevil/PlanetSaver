using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private MainCamera _camera;
    [SerializeField] private Planet _planet;
    [SerializeField] private Health _health;
    [SerializeField] private Score _scoreUI;
    [SerializeField] private BestScore _bestScoreUI;
    [SerializeField] private ExplosionEffectScaleController _explode;
    [SerializeField] private TrashSpawner _trashSpawner;
    [SerializeField] private TrashCounter _trashCounterUI; 

    // ReSharper disable Unity.PerformanceAnalysis
    public override void InstallBindings()
    {
        Container.BindInstance(_camera).AsSingle();
        Container.BindInstance(_planet).AsSingle();
        Container.BindInstance(_scoreUI).AsSingle();
        Container.BindInstance(_bestScoreUI).AsSingle();
        Container.BindInstance(_health).AsSingle();
        Container.BindInstance(_explode).AsSingle();
        Container.BindInterfacesAndSelfTo<TrashSpawner>().FromInstance(_trashSpawner).AsSingle().NonLazy();
        Container.BindInstance(_trashCounterUI).AsSingle();

        Container.Bind<TrashFactory>().AsSingle();
        Container.BindInterfacesAndSelfTo<ProgressionSystem>().AsSingle();

        Container.BindInterfacesAndSelfTo<AdManager>().AsSingle().NonLazy();

        Container.Bind<WinScreen>().FromComponentInHierarchy().AsSingle();
        Container.Bind<GameOverScreen>().FromComponentInHierarchy().AsSingle();
    }
}
