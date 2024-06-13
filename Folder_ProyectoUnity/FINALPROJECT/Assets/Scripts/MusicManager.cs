using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioGameMixer;
    [SerializeField] private AudioData _volumeData;
    [SerializeField] private Slider _masterSlider;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _SFXSlider;
    void Start()
    {
        
    }
    public void Setmaster(float f)
    {
        _volumeData._master = f;
        _audioGameMixer.SetFloat("Master", Mathf.Log10(f) * 20f);
       // _masterSlider.value = _volumeData._master;
    }
    public void SetMusic(float f)
    {
        _volumeData._music = f;
        _audioGameMixer.SetFloat("Music", Mathf.Log10(f) * 20f);
        _musicSlider.value = _volumeData._master;
    }
    public void SetSFX(float f)
    {
        _volumeData._SFX = f;
        _audioGameMixer.SetFloat("SFX", Mathf.Log10(f) * 20f);
        _SFXSlider.value = _volumeData._master;
    }
}
