using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioGameMixer;
    [SerializeField] private AudioData _volumeData;
    [SerializeField] private AudioSource _buttonSound;

    //[SerializeField] private AudioSource _mainGameBackground;
    [Header("AudioGameBackground")]

    [SerializeField] private AudioSource _pauseSound;
    // [SerializeField] private AudioSource _labyrinthBackground;
    public AudioSource _backgroundMusic;

    public static MusicManager Instance { get; private set; }
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

    
    }
    private void Update()
    {
        _backgroundMusic = Camera.main.GetComponent<AudioSource>();
    }

    void Start()
    {
        
    }
    private void OnEnable()
    {
        PlayerController.OnPaused += PlayButtonSound;
        
    }
    private void OnDisable()
    {
        PlayerController.OnPaused -= PlayButtonSound;
    }
    public void Setmaster(float f)
    {
        _volumeData._master = f;
        _audioGameMixer.SetFloat("Master", Mathf.Log10(f) * 20f);
    }
    public void SetMusic(float f)
    {
        _volumeData._music = f;
        _audioGameMixer.SetFloat("Music", Mathf.Log10(f) * 20f);
    }
    public void SetSFX(float f)
    {
        _volumeData._SFX = f;
        _audioGameMixer.SetFloat("SFX", Mathf.Log10(f) * 20f);
    }
    public void PlayButtonSound()
    {
        _buttonSound.Play();
    }
    public void PlayPauseSound()
    {
        _pauseSound.Play();
    }
    public void StopPauseSound()
    {
        _pauseSound.Stop();
    }
    public void PlayBackground()
    {
        _backgroundMusic.Play();
    }
    public void StopBackground()
    {
        _backgroundMusic.Pause();
    }
}
