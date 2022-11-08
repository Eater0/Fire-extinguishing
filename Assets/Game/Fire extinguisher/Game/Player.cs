using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    [SerializeField] ParticleSystem _particle;
    [SerializeField] float _extinguishingTime;

    float _extinguishingTimer;

    [Inject]
    void Construct(PlayerMove playerMove, PlayerExtringuishing playerExtringuishing)
    {

    }

    public float ExtinguishingTime
    {
        get { return _extinguishingTime; }
    }

    public float ExtinguishingTimer
    {
        get { return _extinguishingTimer; }
        set { _extinguishingTimer = value; }
    }

    public ParticleSystem Particle
    {
        get { return _particle; }
    }

    public Vector3 Position
    {
        get { return transform.position; }
        set { transform.position = value; }
    }
}
