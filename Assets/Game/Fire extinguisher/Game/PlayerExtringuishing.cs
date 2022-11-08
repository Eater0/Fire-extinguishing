using System;
using UnityEngine;

public class PlayerExtringuishing
{
    public static event Action Extinguishing;

    readonly Player _player;
    ParticleSystem _particle;
    float _extinguishingTime;

    float _extinguishingTimer;

    public PlayerExtringuishing(Player player)
    {
        _player = player;
        _particle = _player.Particle;
        _extinguishingTime = _player.ExtinguishingTime;

        HoldingButton.HoldingDownTheButton += HoldingDownTheButton;
        HoldingButton.UpTheButton += UpTheButton;
    }

    void HoldingDownTheButton()
    {
        if (!_particle.isPlaying && _extinguishingTimer <= _extinguishingTime)
        {
            _particle.Play();
        }

        if (_extinguishingTimer > _extinguishingTime)
            _particle.Stop();
        else if (_particle.isPlaying)
        {
            _extinguishingTimer += Time.deltaTime;
            _player.ExtinguishingTimer = _extinguishingTimer;
            Extinguishing();
        }
    }

    void UpTheButton()
    {
        _particle.Stop();
    }
}
