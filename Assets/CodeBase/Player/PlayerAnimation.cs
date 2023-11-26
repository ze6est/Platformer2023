using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerAnimation : MonoBehaviour
{
    private readonly int Speed = Animator.StringToHash(nameof(Speed));

    [SerializeField] private Movement _movement;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void OnValidate()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();        
    }

    private void OnEnable() => 
        _movement.Moved += OnMoved;

    private void OnDisable() => 
        _movement.Moved -= OnMoved;

    private void OnMoved(float speed)
    {
        if(speed > 0)
            _spriteRenderer.flipX = false;
        if(speed < 0)
            _spriteRenderer.flipX = true;        

        float speedAbs = Mathf.Abs(speed);

        _animator.SetFloat(Speed, speedAbs);
    }
}