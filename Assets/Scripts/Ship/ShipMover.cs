using UnityEngine;
using System;
using System.Collections.Generic;

[RequireComponent(typeof(ShipRouteData))]
public class ShipMover : MonoBehaviour
{
    [SerializeField] private bool looping;

    private ShipRouteData routeData;

    private IEnumerator<Tile> route;
    private Vector3 previous;
    private Vector3 current;

    public bool IsMoving { get; set; }

    private void Awake()
    {
        routeData = GetComponent<ShipRouteData>();
        IsMoving = false;
    }

    public void Inizialize()
    {
        IsMoving = true;
        route = routeData.Route.GetEnumerator();

        route.MoveNext();
        previous = route.Current.transform.position;
        route.MoveNext();
        current = route.Current.transform.position;
    }
    
    public void Reset()
    {
        IsMoving = false;

        if(route != null)
        {
            route.Reset();
            route.MoveNext();
            transform.position = route.Current.transform.position;
        }

        route = null;
        previous = Vector3.zero;
        current = Vector3.zero;
    }

    public void Move(float interpolation)
    {
        transform.position = Vector3.Lerp(previous, current, interpolation);
    }
    
    public void MoveInstantly()
    {
        transform.position = current;
    }

    public void NextPostion()
    {
        if(route.MoveNext())
        {
            previous = current;
            current = route.Current.transform.position;
        }
        else
        {
            HandleArrival();
        }
    }

    private void HandleArrival()
    {
        if(looping)
        {
            route.Reset();
            route.MoveNext();
            previous = route.Current.transform.position;
            route.MoveNext();
            current = route.Current.transform.position;
            transform.position = previous;
            return;
        }

        previous = transform.position;
        current = transform.position;
    }
}