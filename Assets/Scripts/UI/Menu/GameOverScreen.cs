using Zenject;

public class GameOverScreen : Menu
{
    private Health _health;
    private AdManager _adManager;

    [Inject]
    public void Construct(Health health, AdManager adManager)
    {
        _health = health;
        _adManager = adManager;

        _adManager.OnAdClosedMainThread += HandleAdFinished;
        _adManager.LoadInterstitialAd();
    }

    private void HandleAdFinished()
    {
        _health.Refill();
        base.Continue();
    }

    public void Continue(bool showAd)
    {
        if (showAd && _adManager.IsAdCanBeShowed())
        {
            _adManager.ShowAd();
        }
        else
        {
            base.Continue();
        }
    }

    private void OnDestroy()
    {
        _adManager.OnAdClosedMainThread -= HandleAdFinished;
    }
}
