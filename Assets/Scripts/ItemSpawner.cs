using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject dominoPrefab;
    public GameObject wedgePrefab;

    private GameObject currentPreview;
    private GameObject selectedPrefab;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        HandleSelectionInput();
        UpdatePreviewPosition();
        HandlePlacement();
    }

    void HandleSelectionInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SetSelectedItem(ballPrefab);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            SetSelectedItem(dominoPrefab);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            SetSelectedItem(wedgePrefab);
    }

    void SetSelectedItem(GameObject prefab)
    {
        selectedPrefab = prefab;

        if (currentPreview != null)
            Destroy(currentPreview);

        currentPreview = Instantiate(selectedPrefab);
        currentPreview.GetComponent<Collider>().enabled = false;

        MakePreviewMaterial(currentPreview);
    }

    void UpdatePreviewPosition()
    {
        if (currentPreview == null) return;

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            currentPreview.transform.position = hit.point;
        }
    }
    void HandlePlacement()
    {
        if (currentPreview == null || selectedPrefab == null) return;

        if (Input.GetMouseButtonDown(0)) // Left click
        {
            Vector3 spawnPos = currentPreview.transform.position;

            // Apply offset in the Z direction (relative to camera)
            Vector3 offset = cam.transform.forward * -1f; // 1 unit forward
            spawnPos += offset;

            // Instantiate the object
            GameObject placedItem = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);

            // Ensure the object calls the appropriate setup and activation methods
            PlaceableItem placeableItem = placedItem.GetComponent<PlaceableItem>();
            if (placeableItem != null)
            {
                placeableItem.OnSetup();
                placeableItem.OnActivate();
            }
        }
    }


    void MakePreviewMaterial(GameObject obj)
    {
        Renderer[] renderers = obj.GetComponentsInChildren<Renderer>();
        foreach (Renderer rend in renderers)
        {
            Material mat = rend.material;
            mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, 0.5f);
            mat.shader = Shader.Find("Transparent/Diffuse");
        }
    }
}
