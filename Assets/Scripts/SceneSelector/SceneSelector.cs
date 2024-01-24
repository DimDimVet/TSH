using UnityEngine;
using UnityEngine.SceneManagement;
using static EventBus;

public class SceneSelector : MonoBehaviour
{
    [SerializeField] private SceneSetting sceneSetting;
    private Construction thisObject;

    private bool isOffUI = false, isDeadPlayer = false, isVictory = false;
    private bool isRun = false;
    void Start()
    {
        if (sceneSetting == null) { print($"Ќе заполнены пол€ в {gameObject.name}"); return; }
    }
    private void OnEnable()
    {
        OnIsDead += KillPlayer;
        OnEnableUIElement += OffUIElement;
        OnIsVictory += VictoryPlayer;
    }
    private void VictoryPlayer(int thisHash, bool _isVictory)
    {
        if (thisObject.Hash == thisHash) { isVictory = _isVictory; }
    }
    private void OffUIElement(bool isOffUIElement)
    {
        isOffUI = isOffUIElement;
    }

    private void KillPlayer(int thisHash, bool isDead, int costObject)
    {
        if (thisObject.Hash == thisHash) { isDeadPlayer = isDead; }
    }
    private void SelectScenes()
    {
        if (isDeadPlayer & isOffUI) { SceneManager.LoadScene(sceneSetting.OverSceneIndex); }
        if (isVictory & isOffUI) { SceneManager.LoadScene(sceneSetting.VictorySceneIndex); }
    }
    private void GetSet()
    {
        thisObject = GetPlayer();
    }
    private void GetIsRun()
    {
        if (!isRun)//если общее разрешение на запуск false
        {
            if (thisObject.Hash != 0) { isRun = true; }
            else { isRun = false; GetSet(); print($"Ќе установлены компоненты в {gameObject.name}"); }
        }
    }
    private void FixedUpdate()
    {
        if (!isRun)//если общее разрешение на запуск false
        {
            GetIsRun();
            return;
        }
        SelectScenes();
    }

}
