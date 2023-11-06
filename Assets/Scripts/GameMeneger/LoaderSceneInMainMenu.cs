using UnityEngine.SceneManagement;
using UnityEngine;

public class LoaderSceneInMainMenu : MonoBehaviour
{
    [SerializeField] private MenegerModify menegerModify;

    [SerializeField] private int GetAcniveScene;
    string KeyStringLevelsAvaileble = "KeyLevel";

    string KeyStringActivePlayer = "KeyPlayer";

    [SerializeField] private int activePlayer;
    void Start()
    {
        GetAcniveScene = PlayerPrefs.GetInt(KeyStringLevelsAvaileble);
    }

    public void LoadSceneLast()
    {
        activePlayer = menegerModify.FreeIndexPlayer;
        PlayerPrefs.SetInt(KeyStringActivePlayer, activePlayer);
        if(GetAcniveScene == 0) GetAcniveScene = 1;
        SceneManager.LoadScene(GetAcniveScene);

        
    }
    void Update()
    {
        
    }
}
