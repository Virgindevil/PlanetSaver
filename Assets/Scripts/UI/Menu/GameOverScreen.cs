using UnityEngine.SceneManagement;
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

        _health.OnDied += Open; 

        _adManager.OnAdClosedMainThread += HandleAdFinished;
        _adManager.LoadInterstitialAd();
    }

    private void HandleAdFinished()
    {
        _health.Refill();
        base.Continue();
    }
    
    private void OnDestroy()
    {
        _health.OnDied -= Open;

        if (_adManager != null) 
            _adManager.OnAdClosedMainThread -= HandleAdFinished;
    }

    public void ShowAdAndContinue()
    {
        _adManager.ShowAd();
    }

    public override void Continue()
    {
        base.Continue();
        SceneManager.LoadScene(0);
    }
}
