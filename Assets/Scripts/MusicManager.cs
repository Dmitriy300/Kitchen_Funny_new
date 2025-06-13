using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private const string PLAYER_VOLUME_KEY = "MusicVolume";

    public static MusicManager Instance { get; private set; }


    private AudioSource _audioSource;
    private float _volume = 0.3f;


    private void Awake()
    {
        Instance = this;

        _audioSource = GetComponent<AudioSource>();
        _volume = PlayerPrefs.GetFloat(PLAYER_VOLUME_KEY, 0.3f);
        _audioSource.volume = _volume;

    }

    public void ChangeVolume()
    {
        _volume += 0.1f;
        if (_volume > 1f)
        {
            _volume = 0f;
        }
        _audioSource.volume = _volume;
        PlayerPrefs.SetFloat(PLAYER_VOLUME_KEY, _volume);
        PlayerPrefs.Save();
    }

    public float GetVolume()
    {
        return _volume;
    }
}
