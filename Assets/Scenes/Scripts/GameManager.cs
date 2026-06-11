using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isGameOver = false;

    void Update()
    {
        if (isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                // Restart the current scene
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public void EndGame()
    {
        isGameOver = true;
    }

    void OnGUI()
    {
        if (isGameOver)
        {
            float screenWidth = Screen.width;
            float screenHeight = Screen.height;

            // Draw a subtle dark overlay for better text contrast
            Texture2D texture = new Texture2D(1, 1);
            texture.SetPixel(0, 0, new Color(0, 0, 0, 0.6f));
            texture.Apply();
            GUI.skin.box.normal.background = texture;
            GUI.Box(new Rect(0, 0, screenWidth, screenHeight), GUIContent.none);

            // Configure style for "Game Over!" text
            GUIStyle gameOverStyle = new GUIStyle();
            gameOverStyle.fontSize = 300;
            gameOverStyle.fontStyle = FontStyle.Bold;
            gameOverStyle.normal.textColor = new Color(0.9f, 0.2f, 0.2f); // Sleek modern red
            gameOverStyle.alignment = TextAnchor.MiddleCenter;

            // Configure style for instruction text
            GUIStyle restartStyle = new GUIStyle();
            restartStyle.fontSize = 80;
            restartStyle.normal.textColor = Color.white;
            restartStyle.alignment = TextAnchor.MiddleCenter;

            // Draw labels
            Rect gameOverRect = new Rect(0, -180f, screenWidth, screenHeight);
            GUI.Label(gameOverRect, "Game Over!", gameOverStyle);

            Rect restartRect = new Rect(0, 220f, screenWidth, screenHeight);
            GUI.Label(restartRect, "Press 'R' to Restart", restartStyle);
        }
    }
}
