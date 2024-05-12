using UnityEngine;

public class BlockPlacement : MonoBehaviour
{
    public GameObject[] blockPrefabs;
    public LayerMask placementLayer;

    private int selectedBlockIndex = -1;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (selectedBlockIndex != -1)
            {
                PlaceBlock();
            }
        }
    }

    void PlaceBlock()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, placementLayer))
        {
            Vector3 placementPosition = hit.point;

            Instantiate(blockPrefabs[selectedBlockIndex], placementPosition, Quaternion.identity);
        }
    }

    public void SelectBlock(int blockIndex)
    {
        selectedBlockIndex = blockIndex;
    }
}
