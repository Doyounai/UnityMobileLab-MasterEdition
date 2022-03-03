using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSwipeControl : SwipeDetector
{
    public HeroKnight _player;
    //Hitbox
    public HeroAttackHitbox _hitBox;

    protected override void SwipedDirection(float angle, Movement currentDirection)
    {
        base.SwipedDirection(angle, currentDirection);
        if (currentDirection == Movement.Left)
        {
            _player.ActionSwapDirection(-1);
            _player.ActionAttack();
            //Hitbox
            _hitBox.AttackZone(-1);
        }
        else if (currentDirection == Movement.Right)
        {
            _player.ActionSwapDirection(1);
            _player.ActionAttack();
            //Hitbox            
            _hitBox.AttackZone(1);
        }
        else if (currentDirection == Movement.Up)
        {
            _player.ActionJump();
        }
        else if (currentDirection == Movement.Down)
        {
            _player.ActionBlock();
        }
    }

}
