using UnityEngine;
using Zenject;

public class ExtinguisherCapacity : MonoBehaviour
{
    Player _player;
    float _extinguishingTime;

    RectTransform _rectTransform;

    [Inject]
    void Construct(Player player)
    {
        _player = player;
        _extinguishingTime = _player.ExtinguishingTime;

        _rectTransform = GetComponent<RectTransform>();

        PlayerExtringuishing.Extinguishing += Extinguishing;
    }

    void Extinguishing()
    {
        float percentExtinguishingTimer = 1 - _player.ExtinguishingTimer / 100 * _extinguishingTime;
        _rectTransform.anchorMax = new Vector2(percentExtinguishingTimer, 1);
    }
}
