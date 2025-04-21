using UnityEngine;

public class AnimatedSprite : MonoBehaviour
{

    // ANIMATION SETS
    public Sprite[] runningSprite;
    public Sprite[] jumpingSprite;
    public Sprite[] currentSprites;

    // SPRITE RENDERER
    public SpriteRenderer spriteRenderer;
    private int frame;


    public enum AnimationState { Running, Jumping }

    private AnimationState currentState = AnimationState.Running;
    private void Awake()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();

        currentSprites = runningSprite;
    }

    private void OnEnable()
    {
        Invoke(nameof(Animate), 0f);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    public void SetRunningState()
    {
        if (currentState != AnimationState.Running)
        {
            currentState = AnimationState.Running;
            currentSprites = runningSprite;

            frame = 0;
        }
    }

    public void SetJumpingState()
    {
        if (currentState != AnimationState.Jumping)
        {
            currentState = AnimationState.Jumping;
            currentSprites = jumpingSprite;

            frame = 0;
        }
    }

    private void Animate()
    {
        frame++;

        if (frame >= currentSprites.Length)
        {
            frame = 0;
        }

        if (frame >= 0 && frame < currentSprites.Length)
        {
            spriteRenderer.sprite = currentSprites[frame];
        }

        Invoke(nameof(Animate), 1f / GameManager.Instance.gameSpeed);
    }


}
