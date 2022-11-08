using UnityEngine;
using Zenject;

[RequireComponent(typeof(ParticleSystem))]
public class Fire : MonoBehaviour
{
    Player _player;
    float _extinguishingTime;

    ParticleSystem _particle;
    float _startLifeTime;

    [Inject]
    [System.Obsolete]
    void Construct(Player player)
    {
        _player = player;
        _extinguishingTime = player.ExtinguishingTime;

        _particle = GetComponent<ParticleSystem>();
        _startLifeTime = _particle.startLifetime;

        PlayerExtringuishing.Extinguishing += Extinguishing;
    }

    [System.Obsolete]
    void Update()
    {
        if (_particle.maxParticles != 0 && _particle.startLifetime < _startLifeTime && !_player.Particle.isPlaying)
            _particle.startLifetime += _startLifeTime / (_extinguishingTime * 3) * Time.deltaTime;
    }

    [System.Obsolete]
    void Extinguishing()
    {
        Vector2 position = _player.Position;

        if (_particle.startLifetime < 0.001)
            _particle.maxParticles = 0;
        else if (position.y >= -0.5 && position.y <= 0.25)
            _particle.startLifetime -= _startLifeTime / _extinguishingTime * Time.deltaTime;
        else if (position.y > 0.25 && position.y <= 1.25)
            _particle.startLifetime -= _startLifeTime / (_extinguishingTime * 2) * Time.deltaTime;
    }
}
