using UnityEngine.SceneManagement;
using UnityEngine;
using System.Runtime.InteropServices;
using System;
using UnityEngine.UI;

public class GameMeneger : MonoBehaviour
{
    public static GameMeneger S;

    public BagroundManeger BM;


    [SerializeField] GameObject _buttomPauseUI;
    [SerializeField] GameObject _panelGameOver;
    [SerializeField] GameObject _panelFinish;
    [SerializeField] GameObject _panelPause;
    [SerializeField] GameObject _panelEnegry;
    [SerializeField] GameObject _panelCoins;

    [SerializeField] GameObject _panelVictory;
    [SerializeField] GameObject PauseOnStart;

    [Header("панель прогресса")]
    public Sprite VictorySprite;
    public Image DefaultImage;
    public Image VictoryImage;
    public float MaxScore;
    [SerializeField] Image _PanelBar;

    //[SerializeField] GameObject SoundBaground;
    [SerializeField] AudioSource BagroundSource;
    [SerializeField] bool MiusicInGame;
    [Header("поле с уровнем при паузе")]

    [SerializeField] TMPro.TextMeshProUGUI LevelName;
    

    public bool PauseOnStartTrue;
    //int Coins;
    bool FinishActive;
    bool GameOverActive;
    public string ActiveScene;
    [SerializeField] string MaxScene;

    [Header("PlayerPrefs")]
    [SerializeField] int AvailibleLevels;
    string KeyStringLevelsAvaileble = "KeyLevels";
    [SerializeField] int GetLevel;

    [SerializeField] int Coins;
    string KeyStringCoins = "KeyCoins";

    [SerializeField] GameObject ButtomyJump;





    //[DllImport("__Internal")]
    //private static extern void ShowAds();


    void Start()
    {
        

        BM = GetComponent<BagroundManeger>();

        
       
        _buttomPauseUI = GameObject.Find("ButtonPause");
        
        GetLevel = PlayerPrefs.GetInt(KeyStringLevelsAvaileble);

       
       
        if (S==null)S = this;

        //if (StaticValueShowAds.ShowAds == true)
        //{
        //    print("pauseAds");
        //    PauseOnStarts();
        //}
        
        else
        {
            ExitPauseOnStarts();
        }
        PauseOnStarts();

        //print(SceneManager.GetActiveScene().name);
        if (SceneManager.sceneCountInBuildSettings >= 1)
        {

            //LevelName.text = "Бой "+SceneManager.GetActiveScene().buildIndex;
        }

    }

    private int GetCoins
    {
        get
        {
            return Coins  = PlayerPrefs.GetInt(KeyStringCoins);
        }
    }
    //public void SetValueCoins(int ValCoint)
    //{
    //    if (ValCoint >= MaxScore)
    //    {
    //        DefaultImage.GetComponent<Image>().sprite = VictorySprite;
    //        GameFinish();


    //    }
    //    //print(ValCoint);
    //    float coinsBar = ValCoint;
    //    _PanelBar.fillAmount = coinsBar / MaxScore;
    //}

    
    //загрузка с меню уровней
    public void LoadSceneInMenuLevel(string NameScene)
    {
        //int NumLevel = Convert.ToInt32(NameScene);
        SceneManager.LoadScene(NameScene);

    }
    //проигрыш
    public void GameOver()
    {
        
        if (Time.timeScale != 1) Time.timeScale = 1;

        if (FinishActive) return;
        _panelGameOver.SetActive(true);
        GameOverActive = true;
        
        
        //BagroundSource.Pause();

        
    }
    //рестарт
    public void Restart()
    {
        if (Time.timeScale < 1) Time.timeScale = 1;
       

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    //финиш и победа
    public void GameOverFinish()
    {
       
        if(FinishActive) return;
        //BagroundSource.Pause();
        
        _buttomPauseUI.SetActive(false);
        
        _panelEnegry.SetActive(false);
        _panelCoins.SetActive(false);
        if (GameOverActive) return;
        _panelFinish.SetActive(true);
        
        FinishActive = true;
        ActiveScene = SceneManager.GetActiveScene().name;

        //LevelPlus(ActiveScene);
       

        //Time.timeScale = 0;
       
    }
    private void GameVictory()
    {
        if (FinishActive) return;
        //BagroundSource.Pause();

        _buttomPauseUI.SetActive(false);

        _panelEnegry.SetActive(false);
        _panelCoins.SetActive(false);
        _panelVictory.SetActive(true);

        FinishActive = true;
    }
    //пауза
    public void Pause()
    {
        string ActiveScene = SceneManager.GetActiveScene().name;
        //LevelName.text = ActiveScene;
        _panelPause.SetActive(true);

        _buttomPauseUI.SetActive(false);
        _panelEnegry.SetActive(false);
        _panelCoins.SetActive(false);

        Time.timeScale = 0f;
        BagroundManeger.S.GamePause = true;
      
        _buttomPauseUI.SetActive(false);
        //BagroundSource.Pause();
    }
    //снятие с паузы
    public void continium()
    {
        if (Time.timeScale < 1) Time.timeScale = 1;
        //BagroundSource.Play();
        _buttomPauseUI.SetActive(true);
        _panelEnegry.SetActive(true);
        _panelCoins.SetActive(true);

        _panelPause.SetActive(false);
       
        
        Time.timeScale = 1;
        
        BagroundManeger.S.GamePause = false;
    }
    //выход в меню уровней
    public void loadSceneLevels()
    {
        //LevelPlus(ActiveScene);
        if (Time.timeScale < 1) Time.timeScale = 1;
        SceneManager.LoadScene("LevelsMenu");
    }


    //увеличение доступных уровней при победе
    public void LevelPlus(string ActiveScene)
    {
        //getLastLevel();
        //AvailibleLevels = GetLevel;
        //MaxScene = LevelMenu.MaxScene;
        //Debug.Log(MaxScene + "  max scene");
        //Debug.Log(ActiveScene + "  active scene");
        //Debug.Log(AvailibleLevels + "  доступная scene");
        //Debug.Log(GetLevel + "  получаемая scene");
        //Debug.Log(LevelMenu.LevelAvaileble + "  LevelMenu.LevelAvaileblee");
        //if (ActiveScene == LevelMenu.MaxScene)
        //{
        //    AvailibleLevels++;
        //    SetLevels();
        //}

    }
    public void ContiniumVictory()
    {
        if (Time.timeScale < 1) Time.timeScale = 1;
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //запуск последнего уровня
    public void StartTheLastLevel()
    {
        int Lev = GetLevel + 1;
        if (Lev == 1)
        {
            Lev = 2;
        }
        if (Lev == SceneManager.sceneCountInBuildSettings)
        {
            Debug.LogError("allScenes");
            Lev--;
        }
        if (Time.timeScale < 1) Time.timeScale = 1;
       

        SceneManager.LoadScene(Lev);
    }
    // получаем последний уровень
    public void getLastLevel()
    {
        GetLevel = PlayerPrefs.GetInt(KeyStringLevelsAvaileble);
        if (GetLevel == 0)
        {
            GetLevel = 1;
        }
    }

    //устанавливаем данные в преферс
    public void SetLevels()
    {
        PlayerPrefs.SetInt(KeyStringLevelsAvaileble, AvailibleLevels);
        PlayerPrefs.Save();
    }
    //сброс преферса только для теста
    public void PlayerPreferReset()
    {
        AvailibleLevels = 1;
        PlayerPrefs.SetInt(KeyStringLevelsAvaileble, AvailibleLevels);
        PlayerPrefs.Save();
        GetLevel = 0;
    }
   

    public void PauseOnStarts()
    {   
        BM.GamePause=true;

        PauseOnStartTrue = true;
       
        //BagroundSource.Pause();
        Time.timeScale = 0f;
        //ShowAds();
       
        //Debug.Log("tryPause");
        if (PauseOnStart == null)
        {
            Invoke("PauseOnStarts", 0.5f);
            return;
        }
       
        //Debug.Log("pauseOnStartActive");
        PauseOnStart.SetActive(true);
        _buttomPauseUI.SetActive(false);
        _panelEnegry.SetActive(false);
        _panelCoins.SetActive(false);
    }
    
    public void ExitPauseOnStarts()
    {
        BagroundManeger.S.GamePause = false;
        PauseOnStartTrue = false;
        PauseOnStart.SetActive(false);
        Time.timeScale = 1f;
        //BagroundSource.Play();
        _buttomPauseUI.SetActive(true);
        StartEnergyPlayer.S.upgratePlayers();
        _panelEnegry.SetActive(true);
        _panelCoins.SetActive(true);



    }
    public void SoundPause()
    {
        //BagroundSource.Pause();
        Time.timeScale = 0;
    }
    public void SoundPlay()
    {
        if (PauseOnStartTrue==true) return;
        //BagroundSource.Play();
        if(Time.timeScale<1)Time.timeScale = 1;
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            return;
        }
        //if (PauseOnStart.activeInHierarchy) Time.timeScale = 0;
    }
    public void GameOverFinishInvoke()
    {
        Invoke("GameOverFinish",3f);
    }
    public void GameVictoryInvoke()
    {
        Invoke("GameFinish", 3f);
    }
}
