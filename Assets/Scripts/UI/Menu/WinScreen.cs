using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Zenject;

public class WinScreen : Menu
{
    private ProseedGeneration _proseedGeneration;

    [Inject]
    public void Construct(ProseedGeneration proseedGeneration)
    {
        _proseedGeneration = proseedGeneration;
    }

    public override void Continue()
    {
        base.Continue();
        _proseedGeneration.Proseed();
    }
}
