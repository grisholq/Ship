using System;
using UnityEngine;

public class PlayerInputer : MonoBehaviour
{
    public event Action<Vector3> InputRecieved;

    private Vector3 lastInputPosition;

    private void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        if (Input.GetMouseButton(0) && Input.mousePosition != lastInputPosition)
        {
            InputRecieved(Input.mousePosition);
            lastInputPosition = Input.mousePosition;
        }
    }
}
