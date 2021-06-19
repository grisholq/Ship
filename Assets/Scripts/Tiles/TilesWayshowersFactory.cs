using UnityEngine;

public class TilesWayshowersFactory : MonoBehaviour
{
    [SerializeField] private Color routeColor;
    [SerializeField] private int routePriority;

    [SerializeField] private Transform prefab;

    [SerializeField] private WayShowerData cross3;
    [SerializeField] private WayShowerData cross;
    [SerializeField] private WayShowerData route;
    [SerializeField] private WayShowerData corner;

    public Transform GetCross3(Direction direction) => InstantiateWayShower(cross3, direction);
    public Transform GetCross() => InstantiateWayShower(cross, default(Direction));
    public Transform GetRoute(Direction direction) => InstantiateWayShower(route, direction);
    public Transform GetCorner(Direction direction) => InstantiateWayShower(corner, direction);

    private Transform InstantiateWayShower(WayShowerData wayShower, Direction direction)
    {
        Transform instance = Instantiate(prefab);

        SpriteRenderer renderer = instance.GetComponent<SpriteRenderer>();
        renderer.sprite = wayShower.Sprite;
        renderer.color = routeColor;
        renderer.sortingOrder = routePriority;

        instance.eulerAngles = wayShower.GetEulers(direction);

        return instance;
    }
}