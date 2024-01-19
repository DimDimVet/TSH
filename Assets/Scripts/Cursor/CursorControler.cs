using UnityEngine;
using static EventManager;

public class CursorControler : MonoBehaviour
{
    [SerializeField] private Texture2D defaultCur;
    [SerializeField] private Texture2D activCur;

    private void Start()
    {
        Cursor.SetCursor(defaultCur, Vector2.zero, CursorMode.Auto);
        //Cursor.SetCursor(activCur, Vector2.zero, CursorMode.Auto);
    }
    private void OnEnable()
    {
        OnSelectCursor += SwitchCursor;
    }

    private void SwitchCursor(bool isActivCursor)
    {
        if (isActivCursor) { Cursor.SetCursor(activCur, Vector2.zero, CursorMode.Auto); }
        else { Cursor.SetCursor(defaultCur, Vector2.zero, CursorMode.Auto); }
    }
}
