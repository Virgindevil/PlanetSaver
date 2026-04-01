using UnityEngine.SceneManagement;

public class GameOverScreen : Menu
{
    public override void Continue()
    {
        base.Continue();
        SceneManager.LoadScene(0);
    }
}
