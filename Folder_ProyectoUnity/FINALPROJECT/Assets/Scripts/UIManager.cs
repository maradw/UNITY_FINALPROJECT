using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    [SerializeField] private Transform _titleGame;
    [SerializeField] private float _effectTitle;
    [SerializeField] private Transform _newTitlePos;

    [SerializeField] private Ease EaseParam;
    bool snapping = false;

    [SerializeField] private GameObject _audioMenu;
    [SerializeField] private Transform _audioMenuOrigin;
    [SerializeField] private Transform _newAudioMenuPOs;
    [SerializeField] private GameObject _menuButtons;
    [SerializeField] private float _effectDown;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

       // DontDestroyOnLoad(this);
        _audioMenu.SetActive(false);
    }
    void Start()
    {

        _titleGame.DOMoveY(_newTitlePos.position.y, _effectTitle, snapping).SetEase(EaseParam);
    }
    public void ShowAudioSett()
    {
        _audioMenu.SetActive(true);
        _menuButtons.SetActive(false);
        _audioMenu.transform.DOMoveY(_newAudioMenuPOs.position.y, _effectDown, snapping).SetEase(EaseParam);
    }
    public void HideAudioSett()
    {
        _audioMenu.transform.DOMoveY(_audioMenuOrigin.position.y, _effectDown, snapping).SetEase(EaseParam);
        _audioMenu.SetActive(false);
        _menuButtons.SetActive(true);

    }
    public void Back(GameObject gameBar)
    {
        gameBar.SetActive(false);
    }
    public void Show(GameObject gameBar)
    {
        gameBar.SetActive(true);

    }
}
