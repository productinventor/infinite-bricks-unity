using UnityEngine;
using TMPro;

namespace InfiniteBricks.Core
{
    /// <summary>
    /// Displays frame rate information with color-coded performance indicators
    /// </summary>
    public class FPSDisplay : MonoBehaviour
    {
        [Header("Display Settings")]
        [SerializeField] private float updateInterval = 0.5f;
        [SerializeField] private bool showMinMax = true;
        [SerializeField] private bool showAverage = true;
        
        [Header("Color Thresholds")]
        [SerializeField] private float goodFPS = 60f;
        [SerializeField] private float warningFPS = 30f;
        [SerializeField] private Color goodColor = Color.green;
        [SerializeField] private Color warningColor = Color.yellow;
        [SerializeField] private Color badColor = Color.red;
        
        private TextMeshProUGUI fpsText;
        private float deltaTime = 0f;
        private float timeSinceUpdate = 0f;
        private int frameCount = 0;
        
        private float currentFPS = 0f;
        private float averageFPS = 0f;
        private float minFPS = float.MaxValue;
        private float maxFPS = 0f;
        
        private float totalTime = 0f;
        private int totalFrames = 0;
        
        private void Start()
        {
            Debug.Log("FPSDisplay Start() called");
            
            // Try to find TextMeshProUGUI
            fpsText = GetComponent<TextMeshProUGUI>();
            if (fpsText != null)
            {
                Debug.Log("TextMeshProUGUI found successfully!");
                return;
            }
            
            // If not found, try the world space version
            var worldTextMesh = GetComponent<TextMeshPro>();
            if (worldTextMesh != null)
            {
                Debug.LogError("Found TextMeshPro (world space) instead of TextMeshProUGUI (UI). Please use UI Text.");
                enabled = false;
                return;
            }
            
            // Debug all components
            Debug.Log("No TextMeshPro components found. All components:");
            foreach (Component comp in GetComponents<Component>())
            {
                Debug.Log($"  - {comp.GetType().FullName}");
            }
            
            Debug.LogError("FPSDisplay requires a TextMeshProUGUI component!");
            enabled = false;
        }
        
        private void Update()
        {
            deltaTime += Time.unscaledDeltaTime;
            timeSinceUpdate += Time.unscaledDeltaTime;
            frameCount++;
            
            totalTime += Time.unscaledDeltaTime;
            totalFrames++;
            
            if (timeSinceUpdate >= updateInterval)
            {
                CalculateFPS();
                UpdateDisplay();
                ResetInterval();
            }
        }
        
        private void CalculateFPS()
        {
            currentFPS = frameCount / timeSinceUpdate;
            
            if (currentFPS < minFPS && totalFrames > 10)
                minFPS = currentFPS;
                
            if (currentFPS > maxFPS)
                maxFPS = currentFPS;
                
            if (totalTime > 0)
                averageFPS = totalFrames / totalTime;
        }
        
        private void UpdateDisplay()
        {
            string displayText = $"FPS: {currentFPS:0.0}";
            
            if (showAverage)
                displayText += $"\nAvg: {averageFPS:0.0}";
                
            if (showMinMax)
                displayText += $"\nMin: {minFPS:0.0} Max: {maxFPS:0.0}";
            
            fpsText.text = displayText;
            fpsText.color = GetColorForFPS(currentFPS);
        }
        
        private Color GetColorForFPS(float fps)
        {
            if (fps >= goodFPS)
                return goodColor;
            else if (fps >= warningFPS)
                return warningColor;
            else
                return badColor;
        }
        
        private void ResetInterval()
        {
            timeSinceUpdate = 0f;
            frameCount = 0;
        }
        
        /// <summary>
        /// Resets all FPS statistics
        /// </summary>
        public void ResetStats()
        {
            currentFPS = 0f;
            averageFPS = 0f;
            minFPS = float.MaxValue;
            maxFPS = 0f;
            totalTime = 0f;
            totalFrames = 0;
            deltaTime = 0f;
            timeSinceUpdate = 0f;
            frameCount = 0;
        }
    }
}