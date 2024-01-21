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
        GetHealts(getHash, (int)essence);
        return true;
    }
}
