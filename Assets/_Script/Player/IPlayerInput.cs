using UnityEngine;

public interface IPlayerInput
{
    Vector2 MoveInput { get; }

    bool JumpInputDown { get; }

}