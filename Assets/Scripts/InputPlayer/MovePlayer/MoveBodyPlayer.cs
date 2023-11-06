using UnityEngine;

public class MovePlayer : GetInputPlayer
{
    public Transform towerTransform;

    [SerializeField] private MoveSettings moveSettings;
    private bool NotActionClass = false;
    //��� ��������
    private float speedForward, speedBack, speedTurn;
    private float weight, forceMove, forceTurn;
    private Rigidbody rigidbodyGameObject;
    private bool isRun = false;

    void Start()
    {
        if (moveSettings == null) { print($"�� ���������� Settings � MovePlayer"); NotActionClass = true; }
        SetRigibody();
        GetSetting();
    }

    private void GetSetting()
    {
        if (NotActionClass) { return; }//�������� �����������

        speedForward = moveSettings.SpeedForward;
        speedBack = moveSettings.SpeedBack;
        speedTurn = moveSettings.SpeedTurn;
        weight = moveSettings.Weight;
        forceMove = moveSettings.ForceMove;
        forceTurn = moveSettings.ForceTurn;
        rigidbodyGameObject.mass = weight;
        moveSettings.IsUpDate = false;
    }

    private void SetRigibody()
    {
        if (NotActionClass) { return; }//�������� �����������

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

                Vector3 newPosition = transform.position + (transform.forward) * speedForward * Time.deltaTime;
                gameObject.transform.position = newPosition;
                //if (rigidbodyGameObject.velocity.magnitude <= speedForward)
                //{
                //    rigidbodyGameObject.AddForce(transform.forward * Time.deltaTime * forceMove);
                //}
            }
            if (InputData.Move.y < 0)
            {

                Vector3 newPosition = transform.position + (-transform.forward) * speedBack * Time.deltaTime;
                gameObject.transform.position = newPosition;
                //if (rigidbodyGameObject.velocity.magnitude <= speedBack)
                //{
                //    rigidbodyGameObject.AddForce(-transform.forward * Time.deltaTime * forceMove);
                //}
            }

            if (InputData.Move.x > 0)
            {
                //Vector3 movement = new Vector3(InputData.Move.x, 0, 0);
                //Quaternion targetRot = Quaternion.LookRotation(Vector3.forward);
                //transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, speedTurn * Time.deltaTime);
                transform.Rotate(transform.up  * Time.deltaTime * speedTurn);//������� �����
                //rigidbodyGameObject.AddTorque(transform.up * Time.deltaTime * forceTurn / 2);

                //if (rigidbodyGameObject.angularVelocity.magnitude <= speedTurn)
                //{
                //    rigidbodyGameObject.AddTorque(transform.up * Time.deltaTime * forceTurn);
                //}
                //print($"{transform.up} {forceTurn}");
            }
            if (InputData.Move.x < 0)
            {
                //Vector3 movement = new Vector3(InputData.Move.x, 0, 0);
                //Quaternion targetRot = Quaternion.LookRotation(-Vector3.forward);
                //transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, speedTurn * Time.deltaTime);
                transform.Rotate(-transform.up * Time.deltaTime * speedTurn);//������� �����
                //rigidbodyGameObject.AddTorque(-transform.up * Time.deltaTime * forceTurn / 2);

                //if (rigidbodyGameObject.angularVelocity.magnitude <= speedTurn)
                //{
                //    rigidbodyGameObject.AddTorque(-transform.up * Time.deltaTime * forceTurn);
                //}
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
