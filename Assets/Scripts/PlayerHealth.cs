using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxLive = 2;
    public int actualLive;
    public GameObject defeatPanel;
    public GameObject victoryPanel;

    void Start()
    {
        actualLive = maxLive;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            actualLive--;

            if (actualLive <= 0)
            {
                DefPanel();
            }
        }
        if (other.CompareTag("Goal"))
        {
            VicPanel();
        }

    }

    void DefPanel()
    {
        defeatPanel.SetActive(true);
    }
    void VicPanel()
    {
        victoryPanel.SetActive(true);
    }
}