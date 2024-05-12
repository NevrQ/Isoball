using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public int blockIndex;

    void Start()
    {
        Button button = GetComponent<Button>();

        button.onClick.AddListener(SelectBlock);
    }

    void SelectBlock()
    {
        FindObjectOfType<BlockPlacement>().SelectBlock(blockIndex);
    }
}
