using UnityEngine;
using InfiniteBricks.UI;

namespace InfiniteBricks.Core
{
    /// <summary>
    /// Sets up a basic test scene with UI and test objects
    /// </summary>
    public class TestSceneSetup : MonoBehaviour
    {
        [Header("Scene Setup")]
        [SerializeField] private bool setupOnAwake = true;
        [SerializeField] private bool createGround = true;
        [SerializeField] private bool createLighting = true;
        
        private void Awake()
        {
            if (setupOnAwake)
            {
                SetupScene();
            }
        }
        
        public void SetupScene()
        {
            if (createGround)
                CreateGround();
                
            if (createLighting)
                SetupLighting();
                
            CreateUIManager();
            SetupCamera();
        }
        
        private void CreateGround()
        {
            GameObject ground = GameObject.CreatePrimitive(PrimitiveType.Plane);
            ground.name = "Ground";
            ground.transform.position = Vector3.zero;
            ground.transform.localScale = new Vector3(5, 1, 5);
            
            Renderer renderer = ground.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = new Color(0.3f, 0.3f, 0.3f);
            }
        }
        
        private void SetupLighting()
        {
            Light existingLight = FindObjectOfType<Light>();
            if (existingLight == null)
            {
                GameObject lightObj = new GameObject("Directional Light");
                Light light = lightObj.AddComponent<Light>();
                light.type = LightType.Directional;
                light.intensity = 1f;
                light.transform.rotation = Quaternion.Euler(50f, -30f, 0f);
            }
        }
        
        private void CreateUIManager()
        {
            GameObject uiManagerObj = new GameObject("UI Manager");
            uiManagerObj.AddComponent<UIManager>();
        }
        
        private void SetupCamera()
        {
            Camera mainCamera = Camera.main;
            if (mainCamera == null)
            {
                GameObject cameraObj = new GameObject("Main Camera");
                mainCamera = cameraObj.AddComponent<Camera>();
                cameraObj.tag = "MainCamera";
            }
            
            mainCamera.transform.position = new Vector3(0, 5, -10);
            mainCamera.transform.rotation = Quaternion.Euler(20f, 0f, 0f);
        }
    }
}