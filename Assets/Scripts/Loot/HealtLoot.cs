using static EventManager;
public class HealtLoot : Loot
{
    private bool isTriger=false;
    public override void SetEssence(int hash)//��� �� ������� � �������� ������
    {
        if (!isTriger) { GetHealtLoot(hash, Healt); isTriger = true; }
    }
    public override void ReternEssence()//���������� ���
    {
        //print(this.gameObject.GetHashCode());
       IsReternLoot(this.gameObject.GetHashCode());
    }
}
