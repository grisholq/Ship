using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsLoader : Singleton<LevelsLoader>
{
    [SerializeField] private LevelData loadedLevelData;

    public LevelData LoadedLevelData { get => loadedLevelData; }

    private const int mainMenuIndex = 0;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void LoadMainMenu()
    {
        UndloadCurrentLevel();
        SceneManager.LoadSceneAsync(mainMenuIndex);
        loadedLevelData = null;
    }
    
    public void LoadLevel(LevelData levelData)
    {
        UndloadCurrentLevel();
        SceneManager.LoadSceneAsync(levelData.LevelId);
        loadedLevelData = levelData;
    }
    
    public void RestartCurrentLevel()
    {
        if(LoadedLevelData != null)
        {
            LoadLevel(LoadedLevelData);
        }
    }

    private void UndloadCurrentLevel()
    { 
        if(loadedLevelData != null)
        SceneManager.UnloadSceneAsync(loadedLevelData.LevelId);
    }
}