using UnityEngine;

public class LoopGround : MonoBehaviour
{
    public float speed = 1f;
    public float width = 6f;
    private SpriteRenderer _spriteRenderer;
    private Vector2 _startSize;
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _startSize = new Vector2(_spriteRenderer.size.x, _spriteRenderer.size.y);
    }

    // Update is called once per frame
    void Update()
    {
        _spriteRenderer.size = new Vector2(_spriteRenderer.size.x + speed * Time.deltaTime, _spriteRenderer.size.y);
        if (_spriteRenderer.size.x >= width)
        {
            _spriteRenderer.size = _startSize;
        }
    }
}
