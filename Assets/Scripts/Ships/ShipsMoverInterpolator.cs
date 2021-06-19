using System;
using UnityEngine;

public class ShipsMoverInterpolator : MonoBehaviour
{
    public float Interpolation { get; set; }
    public event Action InterpolationDone;

    private void Awake()
    {
        Interpolation = 0;
    }

    public void Interpolate()
    {
        Interpolation += Time.deltaTime;

        if (Interpolation >= 1)
        {        
            Interpolation = 0;
            CallInterpolationDone();
        }
    }

    public void Reset()
    {
        Interpolation = 0;
    }

    private void CallInterpolationDone()
    {
        if(InterpolationDone != null)
        {
            InterpolationDone();
        }
    }
}