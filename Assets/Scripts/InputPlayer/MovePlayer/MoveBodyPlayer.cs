using UnityEngine;
using static EventManager;

public class MoveBodyPlayer : GetInputPlayer
{
    [SerializeField] private MoveSettings moveSettings;
    //��� ��������
    private float speedForward, speedBack, speedTurn;
    private float weight;
    private Rigidbody rigidbodyGameObject;
    private Vector3 newPosition;
    private Vector3 eulerAngleVelocity;
    private Quaternion deltaRotation;
    private bool isRun = false;

    float kof;

    void Start()
    {
        if (moveSettings == null) { print($"�� ���������� Settings � MovePlayer"); }
        GetIsRun();
        GetSetting();
    }

    private void GetSetting()
    {
        speedForward = moveSettings.SpeedForward;
        speedBack = moveSettings.SpeedBack;
        eulerAngleVelocity.y = moveSettings.SpeedTurn;
        weight = moveSettings.Weight;
        rigidbodyGameObject.mass = weight;
        moveSettings.IsUpDate = false;
    }

    private void GetIsRun()
    {
        rigidbodyGameObject = gameObject.GetComponent<Rigidbody>();

        if (!(rigidbodyGameObject is Rigidbody))
        {
            rigidbodyGameObject = gameObject.AddComponent<Rigidbody>();
            rigidbodyGameObject.mass = weight;
            isRun = false;
        }
        else
        {
            isRun = true;
        }
    }

    private void Move()
    {
        
        if (isRun)
        {
            //������ � ������
            if (InputData.Move.y > 0 )
            {
                rigidbodyGameObject.velocity = transform.forward * speedForward;
                //newPosition = transform.position + (transform.forward) * speedForward * Time.deltaTime;
                //gameObject.transform.position = newPosition;
            }
            if (InputData.Move.y < 0 )
            {
                rigidbodyGameObject.velocity = -transform.forward * speedBack;
                //newPosition = transform.position + (-transform.forward) * speedBack * Time.deltaTime;
                //gameObject.transform.position = newPosition;
            }

            if (InputData.Move.x > 0)
            {
                deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.fixedDeltaTime);
                rigidbodyGameObject.MoveRotation(rigidbodyGameObject.rotation * deltaRotation);
                //transform.Rotate(transform.up * Time.deltaTime * speedTurn);//������� �����
            }
            if (InputData.Move.x < 0)
            {
                deltaRotation = Quaternion.Euler(-eulerAngleVelocity * Time.fixedDeltaTime);
                rigidbodyGameObject.MoveRotation(rigidbodyGameObject.rotation * deltaRotation);
                //transform.Rotate(-transform.up * Time.deltaTime * speedTurn);//������� �����
            }
        }
    }

    private void FixedUpdate()
    {
        if (IsDead) { return; }

        if (moveSettings.IsUpDate)
        {
            GetSetting();
        }
        Move();
    }
}
