using Core;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public GameObject healthView;

    private void Start()
    {
        Subscribe();
    }

    private void HidePlayerUI()
    {
        healthView.gameObject.SetActive(false);
    }

    private void Subscribe()
    {
        GameManager.Instance.player.health.OnDeath += HidePlayerUI;
    }
    
    private void UnSubscribe()
    {
        GameManager.Instance.player.health.OnDeath -= HidePlayerUI;
    }

    private void OnDestroy()
    {
        UnSubscribe();
    }
}
