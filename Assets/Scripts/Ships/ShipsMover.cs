using UnityEngine;

[RequireComponent(typeof(ShipsMoverInterpolator))]
public class ShipsMover : MonoBehaviour
{
    [SerializeField] private ShipMover[] ships;

    private ShipsMoverInterpolator interpolator;

    public bool AreShipsMoving { get; set; }
    public bool PauseState { get; set; }

    private void Awake()
    {
        interpolator = GetComponent<ShipsMoverInterpolator>();
        interpolator.InterpolationDone += MoveShipsImmediately;

        AreShipsMoving = false;
        PauseState = false;
    }

    private void Update()
    {
        if (AreShipsMoving && !PauseState)
        {
            interpolator.Interpolate();
            MoveShips();
        }
    }

    public void StartMovingShips()
    {
        interpolator.Reset();
        AreShipsMoving = true;
        PauseState = false;
        foreach (var ship in ships)
        {
            ship.Inizialize();
        }
    }
    
    public void ResetShipsPositions()
    {
        AreShipsMoving = false;
        PauseState = true;
        foreach (var ship in ships)
        {
            ship.Reset();
        }
    }
    
    public void PauseMovingShips()
    {
        PauseState = true; 
    }
    
    public void ResumeMovingShips()
    {
        PauseState = false;
    }

    private void MoveShips()
    {
        foreach (var ship in ships)
        {
            ship.Move(interpolator.Interpolation);
        }
    }

    private void MoveShipsImmediately()
    {
        foreach (var ship in ships)
        {
            ship.MoveInstantly();
            ship.NextPostion();
        }
    }
}