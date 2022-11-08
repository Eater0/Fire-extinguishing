using UnityEngine;
using UnityEngine.UI;

public class PlayerMove
{
    readonly Player _player;
    readonly Slider _slide;

    public PlayerMove(Player player, Slider slider)
    {
        _player = player;
        _slide = slider;

        slider.onValueChanged.AddListener(delegate { Move(); });
    }

    void Move()
    {
        Vector3 playerPostion = _player.Position;
        Vector3 newPosition = new Vector3(playerPostion.x, _slide.value, playerPostion.z);

        _player.Position = newPosition;
    }
}
