using UnityEngine;

public class InputActions : MonoBehaviour
{
    private InputSystem_Actions _inputSystem;

    public float Horizontal;
    public float Vertical;
    
    public bool Jump;
    public bool releaseJump;
    public bool Attack;
    public bool Play;
    //public static bool Pause; // static makes it accessible to all script, this is the best way of doing it, less code in the scripts where it's used, used in PauseMenu
    
    private void Update()
    {
        //Pause = _inputSystem.Player.Settings.WasPressedThisFrame();
        Vertical = _inputSystem.Player.Move.ReadValue<Vector2>().y;
        Horizontal = _inputSystem.Player.Move.ReadValue<Vector2>().x;
        Jump = _inputSystem.Player.Jump.WasPressedThisFrame();
        releaseJump = _inputSystem.Player.Jump.WasReleasedThisFrame();
        Attack = _inputSystem.Player.Attack.WasPressedThisFrame();
        Play = _inputSystem.Player.Play.WasPressedThisFrame();
    }

    private void Awake() { _inputSystem = new InputSystem_Actions(); }

    private void OnEnable() { _inputSystem.Enable(); }

    private void OnDisable() { _inputSystem.Disable(); }
}
