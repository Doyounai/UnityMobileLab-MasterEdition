using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroVirtualController : MonoBehaviour
{
    public HeroKnight _player;

    private bool m_Jump;
    public VirtualButtonState _JumpButton;
    private bool m_Block;
    public VirtualButtonState _BlockButton;
    //Key Virtual JoyStick
    public VirtualJoystick _VirtualJoy;

    public void Start()
    {
        _player = GetComponent<HeroKnight>();
    }
    private void FixedUpdate()
    {

        // Jump State
        if (_JumpButton._currentState == VirtualButtonState.State.Down
                                   && m_Jump == false)
        {
            m_Jump = true;
            _player.ActionJump();
        }
        else if (_JumpButton._currentState == VirtualButtonState.State.Up
                                    && m_Jump == true)
        {
            m_Jump = false;
        }
        // Block State
        if (_BlockButton._currentState == VirtualButtonState.State.Down
                                   && m_Block == false)
        {
            m_Block = true;
            _player.ActionBlock();
        }
        else if (_BlockButton._currentState == VirtualButtonState.State.Up
                                    && m_Block == true)
        {
            m_Block = false;
        }

        _player.ActionSwapDirection(_VirtualJoy.InputVector.x);
        _player.ActionBodyMove(_VirtualJoy.InputVector.x);
        _player.ActionRun(_VirtualJoy.InputVector.x);
    }
    
}
