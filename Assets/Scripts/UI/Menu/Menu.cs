using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Menu : MonoBehaviour
{
    public void Open()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;  
    }

    public void Exit()
    { 
        Application.Quit();
    }

    public virtual void Continue()
    { 
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
