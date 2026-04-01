using UnityEngine;

public abstract class Menu : MonoBehaviour
{
    public void Open()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);        
    }

    public void Exit()
    { 
        Application.Quit();
    }

    public virtual void Continue()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);        
    }
}
