using UnityEngine;

public class LegacyInputHandler : MonoBehaviour, IPlayerInput
{
    public Vector2 MoveInput => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

    public bool JumpInputDown => Input.GetKeyDown(KeyCode.Space);

}