using Zenject;

public class ProseedGeneration 
{
    private int _planetScaleMuliply = 5;
    private int _cameraDistanceMuliply = 10;
    private int _trashCountMuliply = 10;
    private float _trashScaleMuliply = 0.3f;
    private float _explosionScaleMuliply = 1.3f;

    private Health _health;
    private MainCamera _camera;
    private Planet _planet;
    private Explode _explode;
    private TrashSpawner _trashSpawner;
    private TrashCounter _trashCounter;

    [Inject]
    public void Construct(Planet planet, MainCamera camera, Health health, 
        TrashSpawner trashSpawner, TrashCounter trashCounter, Explode explode)
    {
        _health = health;
        _camera = camera;
        _planet = planet;
        _explode = explode;
        _trashSpawner = trashSpawner;
        _trashCounter = trashCounter;

        _explode.ResetScale();
    }

    public void Proseed()
    {
        _camera.SetCameraPosition(_cameraDistanceMuliply);
        _planet.SetPlanetScale(_planetScaleMuliply);
        _trashSpawner.SetTrashCount(_trashSpawner.TrashNumber + _trashCountMuliply);
        _trashCounter.SetTrashNumber(_trashSpawner.TrashNumber);
        _trashSpawner.IncreaseTrashScale(_trashScaleMuliply);
        _trashSpawner.SpawnTrash();
        _explode.IncreaseScale(_explosionScaleMuliply);
        _health.Refill();
    }

}
