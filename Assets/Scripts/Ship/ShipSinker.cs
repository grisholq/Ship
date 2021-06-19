using UnityEngine;

public class ShipSinker : MonoBehaviour
{
    public bool IsSinking { get; set; }

    private void Awake()
    {
        IsSinking = false;
    }

    public void Sink()
    {
        IsSinking = true;
    }

    public void Rise()
    {
        IsSinking = false;
    }
}