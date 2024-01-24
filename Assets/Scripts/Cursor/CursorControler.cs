using UnityEngine;
using static EventBus;

public class CursorControler : MonoBehaviour
{
    [SerializeField] private Texture2D defaultCur;
    [SerializeField] private Texture2D activCur;
    [SerializeField, Range(0, 512)] private float positionDefaultCurX, positionDefaultCurY;
    private Vector2 setDefaultCur;
    private void Start()
    {
        setDefaultCur = new Vector2(positionDefaultCurX, positionDefaultCurY);
        Cursor.SetCursor(defaultCur, setDefaultCur, CursorMode.Auto);
    }
    private void OnEnable()
    {
        OnSelectCursor += SwitchCursor;
    }

    private void SwitchCursor(bool isActivCursor)
    {
        if (isActivCursor) { Cursor.SetCursor(activCur, setDefaultCur, CursorMode.Auto); }
        else { Cursor.SetCursor(defaultCur, setDefaultCur, CursorMode.Auto); }
    }
}
