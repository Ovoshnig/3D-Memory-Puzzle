using UnityEngine;

public class Arm : MonoBehaviour
{
    [SerializeField] private CameraController cameraController;

    private bool isItemSelected = false;
    private bool isAlreadySelected = false;

    public bool IsItemSelected { get => isItemSelected; }
    public bool IsAlreadySelected { get => isAlreadySelected; set => isAlreadySelected = value; }

    private void Update()
    {
        if (cameraController.LastHit != null && cameraController.LastHit.CompareTag("Item") && Input.GetKeyDown(KeyCode.Mouse0) && !isItemSelected)
        {
            transform.parent.gameObject.GetComponent<PlayerController>().isInputBlocked = true;
            isItemSelected = true;
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && isItemSelected) 
        {
            transform.parent.gameObject.GetComponent<PlayerController>().isInputBlocked = false;
            isItemSelected = false;
            isAlreadySelected = false;
        }
    }
}
