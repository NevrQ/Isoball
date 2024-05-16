using UnityEngine;

public class Place : MonoBehaviour
{
    public GameObject[] blockPrefabs;
    private int currentBlockIndex = 0;
    public Ball ballController;
    public LayerMask blockLayer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            currentBlockIndex = (currentBlockIndex + 1) % blockPrefabs.Length;
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

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, blockLayer))
            {
                Vector3 newBlockPosition = hit.collider.gameObject.transform.position + Vector3.up;

                Instantiate(blockPrefabs[currentBlockIndex], newBlockPosition, Quaternion.identity);

                ballController.StopMoving();
            }
        }
    }
}