using Zenject;

public class ProgressionSystem : IInitializable
{
    private int _planetScaleMultiplier = 5;
    private int _cameraDistanceMultiplier = 10;
    private int _trashCountIncrement = 10;
    private float _trashScaleIncrement = 0.3f;
    private float _explosionScaleMultiply = 1.3f;
    private float _explosionDamageMultiply = 1.3f;

    private Health _health;
    private MainCamera _camera;
    private Planet _planet;
    private ExplosionEffectScaleController _explode;
    private TrashSpawner _trashSpawner;
    private TrashCounter _trashCounter;

    [Inject]
    public void Construct(Planet planet, MainCamera camera, Health health, 
        TrashSpawner trashSpawner, TrashCounter trashCounter, ExplosionEffectScaleController explode)
    {
        _health = health;
        _camera = camera;
        _planet = planet;
        _explode = explode;
        _trashSpawner = trashSpawner;
        _trashCounter = trashCounter;
    }

    public void Initialize()
    {
        _explode.ResetScale();
    }

    // ReSharper disable Unity.PerformanceAnalysis
    public void StartNextLevel()
    {
        _camera.SetCameraPosition(_cameraDistanceMultiplier);
        _planet.SetPlanetScale(_planetScaleMultiplier);
        _trashSpawner.SetTrashCount(_trashSpawner.TrashNumber + _trashCountIncrement);
        _trashCounter.SetTrashNumber(_trashSpawner.TrashNumber);
        _trashSpawner.IncreaseTrashScale(_trashScaleIncrement);
        _trashSpawner.SetTrashDamageMultiplier(_explosionDamageMultiply);
        _trashSpawner.SpawnTrash();
        _explode.IncreaseScale(_explosionScaleMultiply);
        _health.Refill();
    }

}
