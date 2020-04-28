using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float moveSpeed = 40f;
    public Animator animator;

    PlayerInputActions inputActions;
    private Vector2 moveVector;
    private bool jump = false;
    private bool crouch = false;

    // Start is called before the first frame update
    void Awake()
    {
        this.inputActions = new PlayerInputActions();
        this.moveVector = new Vector2();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        controller.Move(moveVector.x * moveSpeed * Time.fixedDeltaTime, crouch, jump);
        this.jump = false;
    }

    void OnMove(UnityEngine.InputSystem.InputValue inputValue)
    {
        this.moveVector = inputValue.Get<Vector2>();
        animator.SetFloat("Speed", Mathf.Abs(moveVector.x));
    }

    void OnJump(UnityEngine.InputSystem.InputValue inputValue)
    {
        this.jump = true;
        animator.SetBool("IsJumping", true);
    }

    public void OnJumpLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    void OnCrouch(UnityEngine.InputSystem.InputValue inputValue)
    {
        this.crouch = inputValue.isPressed;
    }

    public void OnCrouching(bool isCrouching)
    {
        Debug.Log("OnCrouching(" + isCrouching + ") invoked");
        animator.SetBool("IsCrouching", isCrouching);
    }
}
