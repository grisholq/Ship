using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private ShipRouteData playerRoute;

    public ShipRouteData PlayerRoute { get => playerRoute; }
}