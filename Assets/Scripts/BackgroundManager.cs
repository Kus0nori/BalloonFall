using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    public Sprite[] backgrounds;
    private int _levelChangeTrigger;
    private void Awake()
    {
        backgrounds = new Sprite[6];
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (_levelChangeTrigger > backgrounds.Length)
        {
            _levelChangeTrigger = 0;
        }
        if(_levelChangeTrigger == ScoreSystem.CurrentLevel) return;
        if (backgrounds[^1] == null) return;
        ChangeBackground();
        _levelChangeTrigger++;
    }

    private void ChangeBackground()
    {
        _spriteRenderer.sprite = backgrounds[ScoreSystem.CurrentLevel - 1];
    }
}
