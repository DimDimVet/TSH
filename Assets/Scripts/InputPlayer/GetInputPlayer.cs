using UnityEngine;
using UnityEngine.InputSystem;
using static EventManager;
public enum Mode
{
    Turn,
    AvtoRif
}
public class GetInputPlayer : MonoBehaviour
{
    //Назначим в массив вариации режимов
    private Mode[] modes = { Mode.Turn, Mode.AvtoRif };
    private int countMode = 0;
    private bool isTrigerClick = true;

    private InputData inputData;//кэш структура хранения всех данных ввода
    public InputData InputData { get { return inputData; } /*set { inputData = value; }*/ }
    private InputPlayer inputActions;//кэш MapInput
    public int ThisHash { get { return thisHash; } set { thisHash = value; } }
    public bool IsDead { get { return isDead; } set { isDead = value; } }
    private int thisHash;
    private bool isDead = false;

    void OnEnable()
    {
        thisHash = this.gameObject.GetHashCode();
        OnIsDead += StopRun;
        inputData = new InputData();
        inputActions = new InputPlayer();
        if (inputActions != null)
        {
            //Карта Key
            {
                inputActions.KeyMap.WASD.started += contex => inputData.Move = contex.ReadValue<Vector2>();
                inputActions.KeyMap.WASD.performed += contex => inputData.Move = contex.ReadValue<Vector2>();
                inputActions.KeyMap.WASD.canceled += contex => inputData.Move = contex.ReadValue<Vector2>();

                inputActions.KeyMap.Look.started += contex => { inputData.Mouse = contex.ReadValue<Vector2>(); inputData.MousePosition = Mouse.current.position.ReadValue(); };
                inputActions.KeyMap.Look.performed += contex => { inputData.Mouse = contex.ReadValue<Vector2>(); inputData.MousePosition = Mouse.current.position.ReadValue(); };
                inputActions.KeyMap.Look.canceled += contex => { inputData.Mouse = contex.ReadValue<Vector2>(); inputData.MousePosition = Mouse.current.position.ReadValue(); };

                inputActions.KeyMap.MouseLeftButton.started += context => { inputData.MouseLeftButton = context.ReadValue<float>(); inputData.MousePosition = Mouse.current.position.ReadValue(); };
                inputActions.KeyMap.MouseLeftButton.performed += context => { inputData.MouseLeftButton = context.ReadValue<float>(); inputData.MousePosition = Mouse.current.position.ReadValue(); };
                inputActions.KeyMap.MouseLeftButton.canceled += context => { inputData.MouseLeftButton = context.ReadValue<float>(); inputData.MousePosition = Mouse.current.position.ReadValue(); };

                inputActions.KeyMap.MouseMiddleButton.started += context => { inputData.MouseMiddleButton = context.ReadValue<float>(); inputData.MousePosition = Mouse.current.position.ReadValue(); };
                inputActions.KeyMap.MouseMiddleButton.performed += context => { inputData.MouseMiddleButton = context.ReadValue<float>(); inputData.MousePosition = Mouse.current.position.ReadValue(); };
                inputActions.KeyMap.MouseMiddleButton.canceled += context => { inputData.MouseMiddleButton = context.ReadValue<float>(); inputData.MousePosition = Mouse.current.position.ReadValue(); };

                inputActions.KeyMap.MouseRightButton.started += context => { inputData.MouseRightButton = context.ReadValue<float>(); inputData.MousePosition = Mouse.current.position.ReadValue(); };
                inputActions.KeyMap.MouseRightButton.performed += context => { inputData.MouseRightButton = context.ReadValue<float>(); inputData.MousePosition = Mouse.current.position.ReadValue(); };
                inputActions.KeyMap.MouseRightButton.canceled += context => { inputData.MouseRightButton = context.ReadValue<float>(); inputData.MousePosition = Mouse.current.position.ReadValue(); };

                inputActions.KeyMap.Shoot.started += context => { inputData.Shoot = context.ReadValue<float>(); };
                inputActions.KeyMap.Shoot.performed += context => { inputData.Shoot = context.ReadValue<float>(); };
                inputActions.KeyMap.Shoot.canceled += context => { inputData.Shoot = context.ReadValue<float>(); };

                inputActions.KeyMap.Mode.started += context => { inputData.Mode = context.ReadValue<float>(); SelectMoveMode(); };
                inputActions.KeyMap.Mode.performed += context => { inputData.Mode = context.ReadValue<float>(); };
                inputActions.KeyMap.Mode.canceled += context => { inputData.Mode = context.ReadValue<float>(); };
            }
            //Карта UI
            {
                inputActions.UIMap.WASDUI.started += contex => inputData.Move = contex.ReadValue<Vector2>();
                inputActions.UIMap.WASDUI.performed += contex => inputData.Move = contex.ReadValue<Vector2>();
                inputActions.UIMap.WASDUI.canceled += contex => inputData.Move = contex.ReadValue<Vector2>();
            }
            //запустим 
            inputActions.Enable();
        }
        else
        {
            print($"Нет MapInput");
        }
    }
    private void OnDisable()
    {
        //остановим 
        inputActions.Disable();
        OnIsDead -= StopRun;
    }
    private void StopRun(int _thisHash, bool _isDead, int costObject)
    {
        if (thisHash == _thisHash) { isDead = _isDead; }
    }
    private void SelectMoveMode()
    {
        if (inputData.Mode != 0)
        {
            if (isTrigerClick)
            {
                isTrigerClick = false;
                countMode++;
                if (countMode >= modes.Length) { countMode = 0; }

                for (int i = 0; i < modes.Length; i++)
                {
                    if ((int)modes[i] == countMode)
                    {
                        inputData.ModeAction = (Mode)countMode;
                        print(countMode);
                    }
                }
                isTrigerClick = true;
            }
        }
    }

}
