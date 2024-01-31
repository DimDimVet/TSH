using static EventBus;
public class HealtLoot : Loot
{
    private bool isTriger = false;
    public override void SetEssence(int hash)
    {
        if (!isTriger) { GetHealtLoot(hash, Healt); isTriger = true; }
    }
    public override void ReternEssence()
    {
        IsReternLoot(this.gameObject.GetHashCode());
    }
}
