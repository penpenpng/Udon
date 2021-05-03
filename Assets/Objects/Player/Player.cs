using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Player : MonoBehaviour
{
    private InputHandler input;
    private SpriteRenderer sprite;
    private Animator animator;
    private new Rigidbody2D rigidbody;
    private bool isJumping = false;
    private const string ANIMATOR_MOVING_FLAG = "isMoving";
    private const string ANIMATOR_JUMPING_FLAG = "isJumping";
    private const float MOVING_VELOCITY = 1;
    private const float JUMPING_VELOCITY = 3;

    void Start()
    {
        input = new InputHandler();

        sprite = transform.GetComponentInChildren<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        input.CaptureInputs();

        if (input.MoveRight)
        {
            rigidbody.velocity = rigidbody.velocity.SetX(MOVING_VELOCITY);
            sprite.flipX = false;
        }
        else if (input.MoveLeft)
        {
            rigidbody.velocity = rigidbody.velocity.SetX(-MOVING_VELOCITY);
            sprite.flipX = true;
        }
        else
        {
            rigidbody.velocity = rigidbody.velocity.SetX(0);
        }

        if (!isJumping && input.Jump)
        {
            isJumping = true;
            rigidbody.velocity = rigidbody.velocity.SetY(JUMPING_VELOCITY);
        }

        animator.SetBool(ANIMATOR_MOVING_FLAG, !input.Stay);
        animator.SetBool(ANIMATOR_JUMPING_FLAG, isJumping);
    }

    // TODO: Call this
    private void OnGround()
    {
        isJumping = false;
    }

    private void OnDestory()
    {
        input.Dispose();
    }
}


static class InputActionExtensions
{
    public static bool IsActive(this InputAction action)
    {
        return action.ReadValue<float>() > 0;
    }
}

static class Vector2Extensions
{
    public static Vector2 SetX(this Vector2 v, float x)
    {
        return new Vector2(x, v.y);
    }

    public static Vector2 SetY(this Vector2 v, float y)
    {
        return new Vector2(v.x, y);
    }
}


enum MoveActions
{
    None,
    Left,
    Right,
}

public class InputHandler : IDisposable
{
    private InputControls inputs;
    private bool lastRight = false;
    private bool lastLeft = false;
    private bool lastJump = false;
    private bool? moveRightCache = null;
    private bool? moveLeftCache = null;
    private List<MoveActions> moveActionStack = new List<MoveActions>() { MoveActions.None };

    public InputHandler()
    {
        inputs = new InputControls();
        inputs.Enable();
    }

    public void CaptureInputs()
    {
        bool right = inputs.Player.MoveRight.IsActive();
        bool left = inputs.Player.MoveLeft.IsActive();
        bool jump = inputs.Player.Jump.IsActive();

        if (!lastRight && right)
        {
            moveActionStack.Add(MoveActions.Right);
        }

        if (lastRight && !right)
        {
            moveActionStack.RemoveAll(e => e == MoveActions.Right);
        }

        if (!lastLeft && left)
        {
            moveActionStack.Add(MoveActions.Left);
        }

        if (lastLeft && !left)
        {
            moveActionStack.RemoveAll(e => e == MoveActions.Left);
        }

        lastRight = right;
        lastLeft = left;
        lastJump = jump;

        moveRightCache = null;
        moveLeftCache = null;
    }

    public bool MoveRight
    {
        get
        {
            if (moveRightCache is null)
            {
                moveRightCache = moveActionStack.Last() == MoveActions.Right;
            }

            return (bool)moveRightCache;
        }
    }

    public bool MoveLeft
    {
        get
        {
            if (moveLeftCache is null)
            {
                moveLeftCache = moveActionStack.Last() == MoveActions.Left;
            }

            return (bool)moveLeftCache;
        }
    }

    public bool Stay
    {
        get
        {
            return !MoveRight && !MoveLeft;
        }
    }

    public bool Jump
    {
        get
        {
            return lastJump;
        }
    }

    public void Dispose()
    {
        inputs.Disable();
        inputs = null;
    }
}
