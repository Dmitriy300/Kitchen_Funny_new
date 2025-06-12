using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    private Player _player;
    private float _footstepTimer;
    private float _footstepTimeerMax = 0.1f;
    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        _footstepTimer-= Time.deltaTime;
        if (_footstepTimer < 0f)
        {
            _footstepTimer = _footstepTimeerMax;
            
            if (_player.IsWalking())
            {
                float volume = 30f;
                SoundManager.Instance.PlayFootstepsSound(_player.transform.position, volume);
            }
            
        }
    }


}
