using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "MyAssets/LevelData")]
public class LevelData : ScriptableObject
{
    [SerializeField] private int levelId;
    [SerializeField] private int levelNumber;
    [SerializeField] private bool levelPassed;
    [SerializeField] private float passTime;

    public int LevelId { get => levelId; }
    public int LevelNumber { get => levelNumber; }
    public bool LevelPassed { get => levelPassed; set => levelPassed = value; }
    public float PassTime { get => passTime; set => passTime = value; }
}