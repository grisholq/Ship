using UnityEngine;

[CreateAssetMenu(fileName = "TileWayShowerData", menuName = "MyAssets/WayShower")]
public class WayShowerData : ScriptableObject
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private Vector3 upEulers;
    [SerializeField] private Vector3 rotationAxis;
    [SerializeField] private float rotationAngle;

    public Sprite Sprite { get => sprite; }

    public Vector3 GetEulers(Direction direction)
    {
        return upEulers + rotationAxis * rotationAngle * (int)direction;
    }
}