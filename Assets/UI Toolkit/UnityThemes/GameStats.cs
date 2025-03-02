using UnityEngine;
using UnityEngine.UIElements;

public class UI : MonoBehaviour
{
    private Label pointsLabel;
    private Label healthLabel;
    private Label waveLabel;
    private Label enemiesLabel;

    private Player player;
    private CombatManager combatManager;

    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        pointsLabel = root.Q<Label>("point");
        healthLabel = root.Q<Label>("health");
        waveLabel = root.Q<Label>("wave");
        enemiesLabel = root.Q<Label>("enemiesleft");

        player = Player.Instance;
        combatManager = FindObjectOfType<CombatManager>();
    }

    void Update()
    {
        if (player != null && healthLabel != null)
        {
            healthLabel.text = "Health: " + player.GetComponent<HealthComponent>().Health;
        }

        if (combatManager != null)
        {
            if (pointsLabel != null)
            {
                pointsLabel.text = "Points: " + combatManager.totalPoints;
            }
            if (waveLabel != null)
            {
                waveLabel.text = "Wave: " + combatManager.waveNumber;
            }
            if (enemiesLabel != null)
            {
                enemiesLabel.text = "Enemies Left: " + combatManager.totalEnemies;
            }
        }
    }
}