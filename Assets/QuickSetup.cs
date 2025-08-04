using UnityEngine;

/// <summary>
/// Quick setup script that doesn't depend on custom assemblies
/// This will work immediately in Unity without assembly compilation
/// </summary>
public class QuickSetup : MonoBehaviour
{
    [Header("Quick Setup")]
    public bool setupOnStart = true;
    
    void Start()
    {
        if (setupOnStart)
        {
            SetupBasicScene();
        }
    }
    
    void SetupBasicScene()
    {
        // Create basic FPS display using Unity's built-in UI
        CreateSimpleFPSDisplay();
        
        // Setup basic scene elements
        SetupBasicLighting();
        CreateGround();
        
        Debug.Log("Quick scene setup complete! Add this to any GameObject to get started.");
    }
    
    void CreateSimpleFPSDisplay()
    {
        // Find or create canvas
        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas == null)
        {
            GameObject canvasObj = new GameObject("Canvas");
            canvas = canvasObj.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvasObj.AddComponent<UnityEngine.UI.CanvasScaler>();
            canvasObj.AddComponent<UnityEngine.UI.GraphicRaycaster>();
        }
        
        // Create simple FPS text
        GameObject fpsTextObj = new GameObject("FPS Text");
        fpsTextObj.transform.SetParent(canvas.transform, false);
        
        RectTransform rect = fpsTextObj.AddComponent<RectTransform>();
        rect.anchorMin = new Vector2(1, 1);
        rect.anchorMax = new Vector2(1, 1);
        rect.pivot = new Vector2(1, 1);
        rect.anchoredPosition = new Vector2(-10, -10);
        rect.sizeDelta = new Vector2(200, 50);
        
        UnityEngine.UI.Text fpsText = fpsTextObj.AddComponent<UnityEngine.UI.Text>();
        fpsText.text = "FPS: 0";
        fpsText.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        fpsText.fontSize = 18;
        fpsText.color = Color.green;
        fpsText.alignment = TextAnchor.UpperRight;
        
        // Add FPS updater
        fpsTextObj.AddComponent<SimpleFPSUpdater>();
    }
    
    void SetupBasicLighting()
    {
        if (FindObjectOfType<Light>() == null)
        {
            GameObject lightObj = new GameObject("Directional Light");
            Light light = lightObj.AddComponent<Light>();
            light.type = LightType.Directional;
            light.transform.rotation = Quaternion.Euler(50f, -30f, 0f);
        }
    }
    
    void CreateGround()
    {
        if (GameObject.Find("Ground") == null)
        {
            GameObject ground = GameObject.CreatePrimitive(PrimitiveType.Plane);
            ground.name = "Ground";
            ground.transform.localScale = new Vector3(5, 1, 5);
        }
    }
}

/// <summary>
/// Simple FPS updater that works without custom assemblies
/// </summary>
public class SimpleFPSUpdater : MonoBehaviour
{
    private UnityEngine.UI.Text fpsText;
    private float deltaTime = 0f;
    private float updateInterval = 0.5f;
    private float timeSinceUpdate = 0f;
    private int frameCount = 0;
    
    void Start()
    {
        fpsText = GetComponent<UnityEngine.UI.Text>();
    }
    
    void Update()
    {
        deltaTime += Time.unscaledDeltaTime;
        timeSinceUpdate += Time.unscaledDeltaTime;
        frameCount++;
        
        if (timeSinceUpdate >= updateInterval)
        {
            float fps = frameCount / timeSinceUpdate;
            fpsText.text = $"FPS: {fps:0.0}";
            
            // Color coding
            if (fps >= 60f)
                fpsText.color = Color.green;
            else if (fps >= 30f)
                fpsText.color = Color.yellow;
            else
                fpsText.color = Color.red;
            
            timeSinceUpdate = 0f;
            frameCount = 0;
        }
    }
}