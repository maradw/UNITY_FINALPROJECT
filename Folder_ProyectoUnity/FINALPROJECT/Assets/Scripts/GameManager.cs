using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int _recolectedBooks = 0;
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
    }
    private void OnDisable()
    {
        PlayerController.OnPlayerGather -= Recolecction;
        //PlayerController.OnPlayerDamage -= Damage;
    }
    void Update()
    {
        //Recolecction();
        if(_recolectedBooks == 6)
        {
            Debug.Log(" win");
            ChangeScene("Menu");
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
    public void ExitGame()
    {
         #if UNITY_EDITOR
                 UnityEditor.EditorApplication.isPlaying = false;
         
         #else
                     Application.Quit();
         #endif
    }
}