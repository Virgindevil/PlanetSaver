using Zenject;

public class WinScreen : Menu
{
    private ProgressionSystem _proseedGeneration;
    private TrashCounter _trashCounter;

    [Inject]
    public void Construct(ProgressionSystem proseedGeneration, TrashCounter trashCounter)
    {
        _proseedGeneration = proseedGeneration;
        _trashCounter = trashCounter;
        _trashCounter.OnAllTrashCollected += Open;
    }

    public override void Continue()
    {
        base.Continue();
        _proseedGeneration.StartNextLevel();
    }

    private void OnDestroy() => _trashCounter.OnAllTrashCollected -= Open;
}
