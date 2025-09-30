using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public int _recolectedBooks = 0;
    [SerializeField] private GameObject _win;
    [SerializeField] private GameObject _dialogue;

    //snaksdsanssadnqwjdnwsas
    [SerializeField] private GameObject _pauseBar;
    //jswsudsdnsjhndsfdvgfvffdb
    public bool _ispaused;

    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
           // DontDestroyOnLoad(this.gameObject);
        }
        
        
    }
    private void Start()
    {

    }
    void OnEnable()
    {
        PlayerController.OnPlayerGather += Recolecction;
        // PlayerController.OnPlayerDamage += Damage;
        PlayerController.OnTalk += Dialogue;
        //PlayerController.OnPaused += Pause;
    }
    private void OnDisable()
    {
        PlayerController.OnPlayerGather -= Recolecction;
        //PlayerController.OnPlayerDamage -= Damage;
        PlayerController.OnTalk -= Dialogue;
        //PlayerController.OnPaused -= Pause;
    }
    void Update()
    {
        Win();
    }
    void Win()
    {
        //Recolecction();
        if (_recolectedBooks == 6)
        {
            Debug.Log(" win");
            //ChangeScene("Menu");
            UIManager.Instance.Show(_win);
        }
    }
    void Recolecction()
    {
        _recolectedBooks++;
    }
   /* void Damage(int damage)
    {
        _lifePlayer -= damage;
    }*/
    public void ChangeScene( string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void Pause()
    {
        Time.timeScale = 0;
        UIManager.Instance.Show(_pauseBar);
        MusicManager.Instance.StopBackground();
        
        MusicManager.Instance.PlayPauseSound();

    }
    public void Resume()
    {
        // _ispaused = false;
        Time.timeScale = 1;
        UIManager.Instance.Back(_pauseBar);
        MusicManager.Instance.PlayBackground();
      
        MusicManager.Instance.StopPauseSound();
    }
    public void RealPause()
    {
        _ispaused = !_ispaused;
        if (_ispaused)
        {
            Pause();
        }
        else
        {
            Resume();
        }
    }
    public void Dialogue()
    {
        UIManager.Instance.Show(_dialogue);
    }
    public void ExitGame()
    {
         #if UNITY_EDITOR
                 UnityEditor.EditorApplication.isPlaying = false;
         
         #else
                     Application.Quit();
         #endif
    }
}