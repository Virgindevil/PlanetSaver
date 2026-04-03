using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class GameOverScreen : Menu
{
    private Health _health;

    [Inject]
    public void Construct(Health health)
    {
        _health = health;
    }

    public override void Continue()
    {
        base.Continue(); 
        SceneManager.LoadScene(0); 
    }

    public void Continue(bool isAd)
    {
        if (isAd)
        {
            Debug.Log("Показываем рекламу...");
            base.Continue();
            _health.Refill();
        }
    }
}
