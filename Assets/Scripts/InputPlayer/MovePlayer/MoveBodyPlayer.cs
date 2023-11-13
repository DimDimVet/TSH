using UnityEngine;
using static EventManager;

public class MoveBodyPlayer : GetInputPlayer
{
    [SerializeField] private MoveSettings moveSettings;
    private bool NotActionClass = false;
    //��� ��������
    private float speedForward, speedBack, speedTurn;
    private float weight;
    private Rigidbody rigidbodyGameObject;
    private Vector3 newPosition;
    private bool isRun = false;

    void Start()
    {
        if (moveSettings == null) { print($"�� ���������� Settings � MovePlayer"); NotActionClass = true; return; }
        GetIsRun();
        GetSetting();
    }

    private void GetSetting()
    {
        speedForward = moveSettings.SpeedForward;
        speedBack = moveSettings.SpeedBack;
        speedTurn = moveSettings.SpeedTurn;
        weight = moveSettings.Weight;
        rigidbodyGameObject.mass = weight;
        moveSettings.IsUpDate = false;
    }

    private void GetIsRun()
    {
        if (IsActivObjectHash(gameObject.GetHashCode())) { }

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
            if (InputData.Move.y > 0)
            {
                newPosition = transform.position + (transform.forward) * speedForward * Time.deltaTime;
                gameObject.transform.position = newPosition;
            }
            if (InputData.Move.y < 0)
            {
                newPosition = transform.position + (-transform.forward) * speedBack * Time.deltaTime;
                gameObject.transform.position = newPosition;
            }

            if (InputData.Move.x > 0)
            {
                transform.Rotate(transform.up * Time.deltaTime * speedTurn);//������� �����
            }
            if (InputData.Move.x < 0)
            {
                transform.Rotate(-transform.up * Time.deltaTime * speedTurn);//������� �����
            }
        }
    }

    private void FixedUpdate()
    {
        if (NotActionClass) { return; }//�������� �����������

        if (moveSettings.IsUpDate)
        {
            GetSetting();
        }
        Move();
    }
}
