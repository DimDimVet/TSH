using static EventManager;
public class HealtLoot : Loot
{
    private bool isTriger=false;
    public override void SetEssence(int hash)//что то предаем в найденый объект
    {
        if (!isTriger) { GetHealtLoot(hash, Healt); isTriger = true; }
    }
    public override void ReternEssence()//возвращаем лут
    {
       IsReternLoot(this.gameObject.GetHashCode());
    }
}
