using System;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    #region Variables

    private GameInput gameInput;
    //private PlayerController playerController;
    private PlayerStateMachine playerStateMachine;

    #endregion

    #region Unity Methods
    
    private void Awake()
    {
        //var characterControlsArray = FindObjectsByType<PlayerController>(FindObjectsSortMode.None);
        var characterControlsArray = FindObjectsByType<PlayerStateMachine>(FindObjectsSortMode.None);
        var playerInput = GetComponent<PlayerInput>();
        var index = playerInput.playerIndex;
        //playerController = characterControlsArray.FirstOrDefault(m => m.GetPlayerIndex() == index);
        playerStateMachine = characterControlsArray.FirstOrDefault(m => m.GetPlayerIndex() == index);
        
        //We create a new ControllerMap and assign it to the right player
        gameInput = new GameInput();
        
        InputDevice joinedDevice = playerInput.devices.FirstOrDefault();

        //if the joined device is a Keyboard or Mouse, assign both Keyboard & Mouse
        if (joinedDevice is Keyboard || joinedDevice is Mouse)
        {
            gameInput.devices = new InputDevice[] { Keyboard.current, Mouse.current };
            playerInput.SwitchCurrentControlScheme("Keyboard&Mouse", Keyboard.current, Mouse.current);
        }
        else
        {
            //Otherwise, keep the default device
            gameInput.devices = new[] { joinedDevice };
        }
    }

    /// <summary>
    /// Enable the ControllerMap
    /// Subscribe methods to certain buttons
    /// </summary>
    private void OnEnable()
    {
        gameInput.Enable();

        // gameInput.Player.Move.performed += playerController.OnMove;
        // gameInput.Player.Move.canceled += playerController.OnMove;
        //
        // gameInput.Player.Jump.started += playerController.OnJump;
        // gameInput.Player.Jump.canceled += playerController.OnJump;
        //
        // gameInput.Player.Dash.performed += playerController.OnDash;
        // gameInput.Player.Dash.canceled += playerController.OnDash;
        //
        // gameInput.Player.Block.performed += playerController.OnBlock;
        // gameInput.Player.Block.canceled += playerController.OnBlock;
        //
        // gameInput.Player.Jab.performed += playerController.OnLightAttack;
        //
        // gameInput.Player.HeavyAttack.performed += playerController.OnHeavyAttack;
        //
        // gameInput.Player.SpecialAttack.performed += playerController.OnSpecialAttack;
        
        gameInput.Player.Move.performed += playerStateMachine.OnMove;
        gameInput.Player.Move.canceled += playerStateMachine.OnMove;

        gameInput.Player.Jump.started += playerStateMachine.OnJump;
        gameInput.Player.Jump.canceled += playerStateMachine.OnJump;

        gameInput.Player.Dash.performed += playerStateMachine.OnDash;
        gameInput.Player.Dash.canceled += playerStateMachine.OnDash;

        gameInput.Player.Block.performed += playerStateMachine.OnBlock;
        gameInput.Player.Block.canceled += playerStateMachine.OnBlock;
        
        gameInput.Player.Jab.performed += playerStateMachine.OnLightAttack;

        gameInput.Player.HeavyAttack.performed += playerStateMachine.OnHeavyAttack;

        gameInput.Player.SpecialAttack.performed += playerStateMachine.OnSpecialAttack;
    }

    /// <summary>
    /// Disable the ControllerMap
    /// Desubscribe methods to certain buttons
    /// </summary>
    private void OnDisable()
    {
        gameInput.Disable();
        
        // gameInput.Player.Move.performed -= playerController.OnMove;
        // gameInput.Player.Move.canceled -= playerController.OnMove;
        //
        // gameInput.Player.Jump.started -= playerController.OnJump;
        // gameInput.Player.Jump.canceled -= playerController.OnJump;
        //
        // gameInput.Player.Dash.performed -= playerController.OnDash;
        // gameInput.Player.Dash.canceled -= playerController.OnDash;
        //
        // gameInput.Player.Block.performed -= playerController.OnBlock;
        // gameInput.Player.Block.canceled -= playerController.OnBlock;
        //
        // gameInput.Player.Jab.performed -= playerController.OnLightAttack;
        //
        // gameInput.Player.HeavyAttack.performed -= playerController.OnHeavyAttack;
        //
        // gameInput.Player.SpecialAttack.performed -= playerController.OnSpecialAttack;
        
        gameInput.Player.Move.performed -= playerStateMachine.OnMove;
        gameInput.Player.Move.canceled -= playerStateMachine.OnMove;

        gameInput.Player.Jump.started -= playerStateMachine.OnJump;
        gameInput.Player.Jump.canceled -= playerStateMachine.OnJump;

        gameInput.Player.Dash.performed -= playerStateMachine.OnDash;
        gameInput.Player.Dash.canceled -= playerStateMachine.OnDash;

        gameInput.Player.Block.performed -= playerStateMachine.OnBlock;
        gameInput.Player.Block.canceled -= playerStateMachine.OnBlock;
        
        gameInput.Player.Jab.performed -= playerStateMachine.OnLightAttack;

        gameInput.Player.HeavyAttack.performed -= playerStateMachine.OnHeavyAttack;

        gameInput.Player.SpecialAttack.performed -= playerStateMachine.OnSpecialAttack;
    }

    #endregion
}
