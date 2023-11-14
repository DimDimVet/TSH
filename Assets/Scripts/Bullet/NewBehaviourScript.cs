using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //public class Bull : MonoBehaviour
    //{
    //    public bool isRun = false;

    //    [SerializeField] private ParticleSystem particleSys;
    //    [SerializeField] private TrailRenderer trailRender;
    //    [SerializeField] private BullSettings bullSettings;

    //    private int hashGO;
    //    private RegistratorConstruction rezultGO;

    //    [SerializeField] private GameObject decalGO;
    //    private int damage;
    //    private int speed;
    //    private Collider collaiderBullet;
    //    private Vector3 startPos;
    //    public Vector3 EndPos;
    //    public Renderer rendererGO;
    //    private RaycastHit hit;
    //    public bool isStop;

    //    private float shootDelay = 5f;
    //    private float shootTime = float.MinValue;

    //    private GameObject decal;
    //    private SpriteRenderer spriteRender;
    //    private int thisGO;

    //    private void Awake()
    //    {
    //        thisGO = gameObject.GetHashCode();
    //        rendererGO = GetComponent<Renderer>();

    //        damage = bullSettings.Damage;
    //        speed = bullSettings.Speed;
    //        collaiderBullet = gameObject.GetComponent<Collider>();
    //        startPos = transform.position;

    //        if (isRun == false)
    //        {
    //            collaiderBullet.enabled = isRun;
    //            rendererGO.enabled = isRun;
    //            particleSys.Stop();
    //            trailRender.enabled = isRun;
    //        }

    //        InstDecal();
    //    }

    //    public void ShootBull(bool _isRun, Transform _startPos)
    //    {
    //        transform.position = _startPos.position;
    //        transform.rotation = _startPos.rotation;
    //        startPos = transform.position;

    //        EndPos = _startPos.position;
    //        EndPos.y = _startPos.position.y + 2f;
    //        isRun = _isRun;

    //    }

    //    private void InstDecal()
    //    {
    //        decal = Instantiate(decalGO);
    //        spriteRender = decal.GetComponent<SpriteRenderer>();
    //        spriteRender.enabled = false;
    //    }

    //    public void MoveBull()
    //    {
    //        if (isStop)
    //        {
    //            OnBull(true);
    //            transform.Translate(Vector3.forward * speed * Time.deltaTime);
    //        }
    //        else
    //        {
    //            EndPos = transform.position;
    //        }

    //        CollisionBull(out isStop);
    //    }

    //    private void OnBull(bool isOn)
    //    {
    //        rendererGO.enabled = isOn;

    //        if (isOn)
    //        {
    //            particleSys.Play();
    //        }
    //        else
    //        {
    //            particleSys.Stop();
    //        }

    //        trailRender.enabled = isOn;
    //    }

    //    private void CollisionBull(out bool _isStop)
    //    {
    //        if (Physics.Linecast(startPos, transform.position, out hit))
    //        {
    //            _isStop = false;

    //            ExecutorCollision(hit);

    //            decal.transform.position = hit.point + hit.normal * 0.001f;
    //            decal.transform.rotation = Quaternion.LookRotation(-hit.normal);
    //            spriteRender.enabled = true;

    //            if (Time.time < shootTime * 1.1f)
    //            {
    //                return;
    //            }
    //            else
    //            {
    //                shootTime = Time.time;
    //            }
    //            spriteRender.enabled = false;

    //            OnBull(false);
    //            transform.position = EndPos;

    //            isRun = false;
    //        }
    //        else
    //        {
    //            if (Time.time < shootTime + shootDelay)
    //            {
    //                _isStop = true;
    //                return;
    //            }
    //            else
    //            {
    //                _isStop = false;
    //                OnBull(false);
    //                transform.position = EndPos;
    //                isRun = false;
    //                shootTime = Time.time;
    //            }
    //        }
    //    }

    //    private void FixedUpdate()
    //    {
    //        if (isRun)//если есть разрешения запустим работу пули
    //        {
    //            MoveBull();
    //        }
    //    }

    //    private void ExecutorCollision(RaycastHit hit)
    //    {
    //        //ищем объект
    //        hashGO = hit.collider.gameObject.GetHashCode();

    //        rezultGO = GetObjectHash(hashGO);
    //        //Healt
    //        if (rezultGO.Hash == hashGO && thisGO != hashGO)
    //        {
    //            if (rezultGO.Healt != null)
    //            {
    //                GetDamageHash(hashGO, damage);
    //            }
    //        }
    //        else
    //        {
    //            Debug.Log("No Script");
    //        }
    //    }
    //}
}
