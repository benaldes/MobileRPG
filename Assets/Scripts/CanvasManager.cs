using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private GameObject _combatCanvas;
    [SerializeField] private GameObject _worldCanvas;


    private void Awake()
    {
        GameManager.OnGameStateChanged += OnGameStateChange;
    }
    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= OnGameStateChange;
    }
    private void OnGameStateChange(Gamestate gamestate)
    {
        switch (gamestate)
        {
            case Gamestate.Combat:
                {
                    _combatCanvas.SetActive(true);
                    _worldCanvas.SetActive(false);
                }
                break;
            case Gamestate.exploration:
                {
                    _combatCanvas.SetActive(false);
                    _worldCanvas.SetActive(true);
                }
                break;
        }
    }
}
