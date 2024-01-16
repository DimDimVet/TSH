using static EventManager;

public class HealtPlayer : Healt
{
    private int currentHealt;
    public override void SetEventsEnable()
    {
        OnGetEssence += GetHealt;
        currentHealt = HealtCount;
    }
    public override void SetEventsDisable()
    {
        OnGetEssence -= GetHealt;
    }

    private bool GetHealt(int getHash, float essence)
    {
        print("передаем");
        ControlDamage(getHash,-(int)essence);
        return true;
        //if (ThisHash == getHash)
        //{
        //    HealtCount += (int)essence;
        //    if (HealtCount > currentHealt) { HealtCount = currentHealt; }
        //    return true;
        //}
        //else { return false; }
    }

}
