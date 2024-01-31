using UnityEngine;

public class AnimControllerPlayer : GetInputPlayer
{
    [SerializeField] private AnimControllerMovePlayerSettings animSettings;
    private Animator animator;
    private float speedAnim;
    private string tankPlayerTrackRight, tankPlayerTrackForward, tankPlayerTrackLeft, tankPlayerTrackBack;
    private bool isRun = false;
    void Start()
    {
        if (animSettings == null) { print($"Не установлен Settings в MoveTurnPlayer"); }
        GetSetting();
    }
    private void GetSetting()
    {
        speedAnim = animSettings.SpeedAnim;
        tankPlayerTrackRight = animSettings.TankPlayerTrackRight;
        tankPlayerTrackLeft = animSettings.TankPlayerTrackLeft;
        tankPlayerTrackForward = animSettings.TankPlayerTrackForward;
        tankPlayerTrackBack = animSettings.TankPlayerTrackBack;
    }
    private void GetIsRun()
    {
        if (!isRun)
        {
            animator = gameObject.GetComponent<Animator>();
            if (animator != null) { isRun = true; }
            else { isRun = false; print($"AnimControllerPlayer не получила Animator"); }
        }
    }
    private void AnimAction()
    {
        if (isRun)
        {
            if (InputData.Move.y > 0)
            {
                animator.SetFloat(tankPlayerTrackForward, speedAnim);
            }
            else
            {
                animator.SetFloat(tankPlayerTrackForward, 0);
            }
            if (InputData.Move.y < 0)
            {
                animator.SetFloat(tankPlayerTrackBack, speedAnim);
            }
            else
            {
                animator.SetFloat(tankPlayerTrackBack, 0);
            }

            if (InputData.Move.x > 0)
            {
                animator.SetFloat(tankPlayerTrackRight, speedAnim);
            }
            else
            {
                animator.SetFloat(tankPlayerTrackRight, 0);
            }
            if (InputData.Move.x < 0)
            {
                animator.SetFloat(tankPlayerTrackLeft, speedAnim);
            }
            else
            {
                animator.SetFloat(tankPlayerTrackLeft, 0);
            }
        }
    }
    private void FixedUpdate()
    {
        if (IsDead) { return; }

        if (animSettings.IsUpDate)
        {
            GetSetting();
        }
        if (!isRun)
        {
            GetIsRun();
            return;
        }
        AnimAction();
    }

}
