using UnityEngine;
using UnityEngine.UI;
using TMPro;
using InfiniteBricks.Core;

namespace InfiniteBricks.UI
{
    /// <summary>
    /// Manages UI elements and creates runtime UI components
    /// </summary>
    public class UIManager : MonoBehaviour
    {
        [Header("FPS Display Settings")]
        [SerializeField] private bool createFPSDisplay = true;
        [SerializeField] private Vector2 fpsDisplayPosition = new Vector2(10, 10);
        [SerializeField] private Vector2 fpsDisplaySize = new Vector2(200, 100);
        
        [Header("Test Controls")]
        [SerializeField] private bool createTestControls = true;
        [SerializeField] private GameObject testObjectPrefab;
        
        private Canvas uiCanvas;
        private FPSDisplay fpsDisplay;
        private int spawnedObjectCount = 0;
        
        private void Awake()
        {
            CreateUICanvas();
            
            if (createFPSDisplay)
                CreateFPSDisplay();
                
            if (createTestControls)
                CreateTestControlPanel();
        }
        
        private void CreateUICanvas()
        {
            GameObject canvasObj = new GameObject("UI Canvas");
            uiCanvas = canvasObj.AddComponent<Canvas>();
            uiCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
            
            canvasObj.AddComponent<CanvasScaler>();
            canvasObj.AddComponent<GraphicRaycaster>();
        }
        
        private void CreateFPSDisplay()
        {
            GameObject fpsPanel = new GameObject("FPS Display Panel");
            fpsPanel.transform.SetParent(uiCanvas.transform, false);
            
            RectTransform panelRect = fpsPanel.AddComponent<RectTransform>();
            panelRect.anchorMin = new Vector2(1, 1);
            panelRect.anchorMax = new Vector2(1, 1);
            panelRect.pivot = new Vector2(1, 1);
            panelRect.anchoredPosition = -fpsDisplayPosition;
            panelRect.sizeDelta = fpsDisplaySize;
            
            Image background = fpsPanel.AddComponent<Image>();
            background.color = new Color(0, 0, 0, 0.7f);
            
            GameObject fpsTextObj = new GameObject("FPS Text");
            fpsTextObj.transform.SetParent(fpsPanel.transform, false);
            
            RectTransform textRect = fpsTextObj.AddComponent<RectTransform>();
            textRect.anchorMin = Vector2.zero;
            textRect.anchorMax = Vector2.one;
            textRect.offsetMin = new Vector2(10, 10);
            textRect.offsetMax = new Vector2(-10, -10);
            
            TextMeshProUGUI fpsText = fpsTextObj.AddComponent<TextMeshProUGUI>();
            fpsText.text = "FPS: 0";
            fpsText.fontSize = 18;
            fpsText.alignment = TextAlignmentOptions.TopLeft;
            
            fpsDisplay = fpsTextObj.AddComponent<FPSDisplay>();
        }
        
        private void CreateTestControlPanel()
        {
            GameObject controlPanel = new GameObject("Test Control Panel");
            controlPanel.transform.SetParent(uiCanvas.transform, false);
            
            RectTransform panelRect = controlPanel.AddComponent<RectTransform>();
            panelRect.anchorMin = new Vector2(0, 1);
            panelRect.anchorMax = new Vector2(0, 1);
            panelRect.pivot = new Vector2(0, 1);
            panelRect.anchoredPosition = new Vector2(10, -10);
            panelRect.sizeDelta = new Vector2(250, 200);
            
            Image background = controlPanel.AddComponent<Image>();
            background.color = new Color(0.1f, 0.1f, 0.1f, 0.9f);
            
            VerticalLayoutGroup layout = controlPanel.AddComponent<VerticalLayoutGroup>();
            layout.padding = new RectOffset(10, 10, 10, 10);
            layout.spacing = 10;
            
            CreateButton(controlPanel.transform, "Spawn 100 Objects", SpawnTestObjects);
            CreateButton(controlPanel.transform, "Clear Objects", ClearTestObjects);
            CreateButton(controlPanel.transform, "Toggle VSync", ToggleVSync);
            CreateButton(controlPanel.transform, "Reset FPS Stats", ResetFPSStats);
        }
        
        private void CreateButton(Transform parent, string text, UnityEngine.Events.UnityAction action)
        {
            GameObject buttonObj = new GameObject($"Button - {text}");
            buttonObj.transform.SetParent(parent, false);
            
            Image buttonImage = buttonObj.AddComponent<Image>();
            buttonImage.color = new Color(0.3f, 0.3f, 0.3f, 1f);
            
            Button button = buttonObj.AddComponent<Button>();
            button.targetGraphic = buttonImage;
            button.onClick.AddListener(action);
            
            GameObject textObj = new GameObject("Text");
            textObj.transform.SetParent(buttonObj.transform, false);
            
            RectTransform textRect = textObj.AddComponent<RectTransform>();
            textRect.anchorMin = Vector2.zero;
            textRect.anchorMax = Vector2.one;
            textRect.offsetMin = Vector2.zero;
            textRect.offsetMax = Vector2.zero;
            
            TextMeshProUGUI buttonText = textObj.AddComponent<TextMeshProUGUI>();
            buttonText.text = text;
            buttonText.alignment = TextAlignmentOptions.Center;
            buttonText.fontSize = 14;
            
            LayoutElement layoutElement = buttonObj.AddComponent<LayoutElement>();
            layoutElement.preferredHeight = 30;
        }
        
        private void SpawnTestObjects()
        {
            if (testObjectPrefab == null)
            {
                testObjectPrefab = GameObject.CreatePrimitive(PrimitiveType.Cube);
                testObjectPrefab.SetActive(false);
            }
            
            for (int i = 0; i < 100; i++)
            {
                GameObject obj = Instantiate(testObjectPrefab);
                obj.SetActive(true);
                obj.transform.position = new Vector3(
                    Random.Range(-20f, 20f),
                    Random.Range(0f, 10f),
                    Random.Range(-20f, 20f)
                );
                obj.transform.rotation = Random.rotation;
                obj.transform.localScale = Vector3.one * Random.Range(0.5f, 2f);
                
                Renderer renderer = obj.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material.color = Random.ColorHSV();
                }
                
                Rigidbody rb = obj.AddComponent<Rigidbody>();
                spawnedObjectCount++;
            }
            
            Debug.Log($"Spawned 100 objects. Total: {spawnedObjectCount}");
        }
        
        private void ClearTestObjects()
        {
            GameObject[] cubes = GameObject.FindObjectsOfType<GameObject>();
            int cleared = 0;
            
            foreach (var obj in cubes)
            {
                if (obj.GetComponent<Rigidbody>() != null && obj != testObjectPrefab)
                {
                    Destroy(obj);
                    cleared++;
                }
            }
            
            spawnedObjectCount = 0;
            Debug.Log($"Cleared {cleared} test objects");
        }
        
        private void ToggleVSync()
        {
            QualitySettings.vSyncCount = QualitySettings.vSyncCount == 0 ? 1 : 0;
            Debug.Log($"VSync: {(QualitySettings.vSyncCount > 0 ? "ON" : "OFF")}");
        }
        
        private void ResetFPSStats()
        {
            if (fpsDisplay != null)
            {
                fpsDisplay.ResetStats();
                Debug.Log("FPS statistics reset");
            }
        }
    }
}