using UnityEngine;

public class ExplosionEffectScaleController : MonoBehaviour
{
    public void ResetScale()
    {
        transform.localScale = Vector3.one;
    }

    public void IncreaseScale(float multiply)
    {
        transform.localScale *= multiply;
    }
}
