using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Enemy[] enemies;

    private void Start()
    {
        if (player != null)
        {
            foreach (Enemy enemy in enemies)
            {
                if (enemy != null)
                {
                    enemy.SetTarget(player.transform);
                }
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void OnGUI()
    {
        if (player != null)
        {
            GUI.Label(new Rect(10, 10, 300, 20), $"Player Health: {player.Data.Health:F0}/{player.Data.MaxHealth:F0}");
        }

        int yOffset = 30;
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null && enemies[i].Data.IsAlive())
            {
                GUI.Label(new Rect(10, yOffset, 300, 20), 
                    $"Enemy {i + 1}: {enemies[i].Data.Health:F0} HP - {enemies[i].GetCurrentState()}");
                yOffset += 20;
            }
        }
    }
}

