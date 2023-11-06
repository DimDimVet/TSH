using UnityEngine;

public class MoveTurnPlayer : GetInputPlayer
{
    [SerializeField] private Camera currentCamera;
    [SerializeField] private TurnSettings turnSettings;
    private bool NotActionClass = false;
    //кэш
    private Rigidbody rigidbodyGameObject;
    private float weightTurn, forceMove, forceTurn;
    private bool isRun = false;


    private Vector3 directionCamera;

    void Start()
    {
        if (turnSettings == null) { print($"Не установлен Settings в MoveTurnPlayer"); NotActionClass = true; }
        SetRigibody();
        GetSetting();
    }
    private void GetSetting()
    {
        if (NotActionClass) { return; }//Проверка разрешнения
        weightTurn = turnSettings.WeightTurn;
        var temp = turnSettings.SpeedTurn;
        turnSettings.IsUpDate = false;
    }
    private void SetRigibody()
    {
        //if (NotActionClass) { return; }//Проверка разрешнения

        //rigidbodyGameObject = gameObject.GetComponent<Rigidbody>();
        //if (!(rigidbodyGameObject is Rigidbody))
        //{
        //    rigidbodyGameObject = gameObject.AddComponent<Rigidbody>();
        //    rigidbodyGameObject.mass = weight;
        //    isRun = false;
        //}
        //else
        //{
        //    isRun = true;
        //}
    }
    private void TurnMove()
    {
        isRun = true;
        if (isRun)
        {
            if (InputData.MouseLeftButton != 0)
            {
                Vector3 gg = new Vector3(InputData.MousePosition.x, InputData.MousePosition.y, 0);
                Ray ray = currentCamera.ScreenPointToRay(gg);//луч...до мышки

                if (Physics.Raycast(ray, out RaycastHit hitInfo))
                {
                    Vector3 targetDirection = hitInfo.point - gameObject.transform.position;
                    Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
                    Debug.DrawRay(gameObject.transform.position, targetDirection, Color.blue);
                    gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, targetRotation, Time.deltaTime * 5f);
                }
            }



            //if (player.MovePlayer.InputData.MouseRightButton != 0)
            //{
            //    transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * player.MovePlayer.InputData.Mouse.x, Space.World);
            //    //positionDispleyMouse = (Vector2)player.MovePlayer.InputData.MousePosition;
            //    //directionCamera = currentPointCamera - (positionDispleyMouse);
            //    //gameObject.transform.Rotate(new Vector3(0, 1, 0), directionCamera.x * 180 * mouseSensor, Space.World);
            //    ////gameObject.transform.Translate(new Vector3(0, 0, -10));
            //    //currentPointCamera = positionDispleyMouse;
            //    //temp

            //    //directionCamera = currentPointCamera - /*currentCamera.ScreenToViewportPoint(Input.mousePosition)*/;
            //    ////print(pos);
            //    //transform.position = player.Transform.position;
            //    //transform.Rotate(new Vector3(0, 1, 0), directionCamera.x * 180, Space.World);
            //    //transform.Translate(new Vector3(0, 0, -10));
            //    //currentPointCamera = /*currentCamera.ScreenToViewportPoint(Input.mousePosition)*/;
            //}
        }
    }
    private void FixedUpdate()
    {
        if (NotActionClass) { return; }//Проверка разрешнения

        if (turnSettings.IsUpDate)
        {
            GetSetting();
        }
        TurnMove();
    }

}
