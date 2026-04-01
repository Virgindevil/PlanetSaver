using Zenject;

public class ProseedGeneration 
{
    private int _planetScaleMuliply = 5;
    private int _cameraDistanceMuliply = 10;
    private int _trashCountMuliply = 10;

    private Health _health;
    private MainCamera _camera;
    private Planet _planet;
    private TrashSpawner _trashSpawner;
    private TrashCounter _trashCounter;

    [Inject]
    public void Construct(Planet planet, MainCamera camera, Health health, TrashSpawner trashSpawner, TrashCounter trashCounter)
    {
        _health = health;
        _camera = camera;
        _planet = planet;
        _trashSpawner = trashSpawner;
        _trashCounter = trashCounter;
    }

    public void Proseed()
    {
        _camera.SetCameraPosition(_cameraDistanceMuliply);
        _planet.SetPlanetScale(_planetScaleMuliply);
        _trashSpawner.SetTrashCount(_trashSpawner.TrashNumber + _trashCountMuliply);
        _trashCounter.SetTrashNumber(_trashSpawner.TrashNumber);
        _trashSpawner.SpawnTrash();
        _health.Refill();
    }

}
