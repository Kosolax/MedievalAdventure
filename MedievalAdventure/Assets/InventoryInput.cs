using UnityEngine;

public class InventoryInput : MonoBehaviour
{
    [SerializeField] private GameObject inventoryGameObject;
    [SerializeField] private KeyCode[] toggleInventoryKeys;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < this.toggleInventoryKeys.Length; i++)
        {
            if(Input.GetKeyDown(this.toggleInventoryKeys[i]))
            {
                this.inventoryGameObject.SetActive(!this.inventoryGameObject.activeSelf);

                if(this.inventoryGameObject.activeSelf)
                {
                    this.ShowMouseCursor();
                }
                else
                {
                    this.HideMouseCursor();
                }
                break;
            }
        }
    }

    public void ShowMouseCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void HideMouseCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
