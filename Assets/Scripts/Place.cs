using UnityEngine;

public class Place : MonoBehaviour
{
    public GameObject[] blockPrefabs;
    public GameObject[] previewPrefabs;
    private GameObject currentPreview;
    private int currentBlockIndex = 0;
    public Ball ballController;
    public LayerMask blockLayer;
    public float gridSize = 1f;
    public float groundLevel = 0f;

    void Start()
    {
        UpdatePreview();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            CycleBlock();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RotateBlock();
        }

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, blockLayer))
            {
                if (hit.collider.CompareTag("Delete"))
                {
                    Destroy(hit.collider.gameObject);
                }
            }
        }

        RaycastHit previewHit;
        Ray previewRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(previewRay, out previewHit, Mathf.Infinity, blockLayer))
        {
            Vector3 previewPosition = SnapToGrid(previewHit.point);
            currentPreview.transform.position = previewPosition;
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, blockLayer))
            {
                Vector3 newBlockPosition = SnapToGrid(hit.point);
                newBlockPosition = AdjustHeightForStacking(newBlockPosition);

                Instantiate(blockPrefabs[currentBlockIndex], newBlockPosition, Quaternion.identity);
                ballController.StopMoving();
            }
        }
    }

    void UpdatePreview()
    {
        if (currentPreview != null)
        {
            Destroy(currentPreview);
        }
        currentPreview = Instantiate(previewPrefabs[currentBlockIndex]);
    }

    void CycleBlock()
    {
        currentBlockIndex = (currentBlockIndex + 1) % blockPrefabs.Length;
        UpdatePreview();
    }

    void RotateBlock()
    {
        if (currentPreview != null)
        {
            currentPreview.transform.Rotate(Vector3.up, 90f);
        }
    }

    Vector3 SnapToGrid(Vector3 originalPosition)
    {
        float snapX = Mathf.Round(originalPosition.x / gridSize) * gridSize;
        float snapZ = Mathf.Round(originalPosition.z / gridSize) * gridSize;
        return new Vector3(snapX, originalPosition.y, snapZ);
    }

    Vector3 AdjustHeightForStacking(Vector3 position)
    {
        RaycastHit hit;
        Vector3 origin = new Vector3(position.x, position.y + 10f, position.z);
        if (Physics.Raycast(origin, Vector3.down, out hit, Mathf.Infinity, blockLayer))
        {
            position.y = hit.point.y + gridSize;
        }
        else
        {
            position.y = groundLevel + (gridSize / 2);
        }

        return position;
    }
}