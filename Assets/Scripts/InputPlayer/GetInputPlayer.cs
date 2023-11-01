using Unity.Mathematics;
using UnityEngine;

public class GetInputPlayer : MonoBehaviour
{
    private InputData inputData;//структура хранения всех данных ввода
    //public InputData InputData { get { return inputData; } set { inputData = value; } }
    private InputPlayer inputActions;//кэш MapInput
    void OnEnable()
    {
        inputData = new InputData();
        inputActions = new InputPlayer();

        if (inputActions != null)
        {
            //Карта Key
            {
                inputActions.KeyMap.WASD.started += contex => inputData.Move = contex.ReadValue<float2>();
                inputActions.KeyMap.WASD.performed += contex => inputData.Move = contex.ReadValue<float2>();
                inputActions.KeyMap.WASD.canceled += contex => inputData.Move = contex.ReadValue<float2>();

                inputActions.KeyMap.Look.started += contex => inputData.Mouse = contex.ReadValue<float2>();
                inputActions.KeyMap.Look.performed += contex => inputData.Mouse = contex.ReadValue<float2>();
                inputActions.KeyMap.Look.canceled += contex => inputData.Mouse = contex.ReadValue<float2>();

                inputActions.KeyMap.Shoot.started += context => { inputData.Shoot = context.ReadValue<float>(); };
                inputActions.KeyMap.Shoot.performed += context => { inputData.Shoot = context.ReadValue<float>(); };
                inputActions.KeyMap.Shoot.canceled += context => { inputData.Shoot = context.ReadValue<float>(); };
            }
            //Карта UI
            {
                inputActions.UIMap.WASDUI.started += contex => inputData.Move = contex.ReadValue<float2>();
                inputActions.UIMap.WASDUI.performed += contex => inputData.Move = contex.ReadValue<float2>();
                inputActions.UIMap.WASDUI.canceled += contex => inputData.Move = contex.ReadValue<float2>();
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
    }
    private void OnDestroy()
    {
        //остановим 
        inputActions.Disable();
    }
}
