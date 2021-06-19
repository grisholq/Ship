using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;

    public LevelData LevelData { get; set; }

    private void Awake()
    {
        LevelData = LevelsLoader.Instance.LoadedLevelData;
    }

    public void WriteLevelData()
    {
        if(LevelData.LevelPassed)
        {
            if(LevelData.PassTime < playerData.PlayerRoute.Route.Count)
            {
                LevelData.PassTime = playerData.PlayerRoute.Route.Count;
            }
        }

        LevelData.LevelPassed = true;
        LevelData.PassTime = playerData.PlayerRoute.Route.Count;
    }    

    public void ReturnToMainMenu()
    {
        LevelsLoader.Instance.LoadMainMenu();
    }
    
    public void RestartLevel()
    {
        LevelsLoader.Instance.RestartCurrentLevel();
    }
}