using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField] private Vector3 deltaPos;
    [SerializeField] private float distance;
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private AudioSource slideSource;
    [SerializeField] private Arm arm;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private GameObject canvas;

    private GameObject clone;
    private bool isThisSelected = false;
    private bool isEqual = false;
    private RaycastHit raycastHit = new RaycastHit();

    public bool IsEqual { get => isEqual; }

    private void Start()
    {
        clone = Instantiate(this.gameObject, transform.position + new Vector3(0, 13, 0), new Quaternion());
        Destroy(clone.GetComponent<ItemController>());
        clone.tag = "Untagged";
        transform.position += deltaPos;
    }

    void Update()
    {
        if (cameraController.LastHit == transform.gameObject && arm.IsItemSelected && !arm.IsAlreadySelected)
        {
            isThisSelected = true;
            arm.IsAlreadySelected = true;
        }
        else if (isThisSelected && !arm.IsItemSelected) 
        {
            canvas.transform.SetParent(null);
            canvas.transform.position = new Vector3(0, -15, 0);
            isThisSelected = false;
        }

        if (isThisSelected)
        {
            canvas.transform.SetParent(transform);
            canvas.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.25001f);
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (transform.localScale.y == 1)
                {
                    Ray ray1 = new Ray(transform.position + new Vector3(0f, 0.25f, 0f), transform.right);
                    Ray ray2 = new Ray(transform.position - new Vector3(0f, 0.25f, 0f), transform.right);
                    if (!Physics.Raycast(ray1, out raycastHit, transform.localScale.x / 2 + 0.25f) && !Physics.Raycast(ray2, out raycastHit, transform.localScale.x / 2 + 0.25f)) 
                    {
                        transform.localPosition += transform.right * distance;
                        slideSource.pitch = Random.Range(0.6f, 1.4f);
                        slideSource.Play();
                    }
                }
                else
                {
                    Ray ray = new Ray(transform.position, transform.right);
                    if (!Physics.Raycast(ray, out raycastHit, transform.localScale.x / 2 + 0.25f))
                    {
                        transform.localPosition += transform.right * distance;
                        slideSource.pitch = Random.Range(0.6f, 1.4f);
                        slideSource.Play();
                    }
                }
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                if (transform.localScale.y == 1)
                {
                    Ray ray1 = new Ray(transform.position + new Vector3(0f, 0.25f, 0f), -transform.right);
                    Ray ray2 = new Ray(transform.position - new Vector3(0f, 0.25f, 0f), -transform.right);
                    if (!Physics.Raycast(ray1, out raycastHit, transform.localScale.x / 2 + 0.25f) && !Physics.Raycast(ray2, out raycastHit, transform.localScale.x / 2 + 0.25f))
                    {
                        transform.localPosition -= transform.right * distance;
                        slideSource.pitch = Random.Range(0.6f, 1.4f);
                        slideSource.Play();
                    }
                }
                else
                {
                    Ray ray = new Ray(transform.position, -transform.right);
                    if (!Physics.Raycast(ray, out raycastHit, transform.localScale.x / 2 + 0.25f))
                    {
                        transform.localPosition -= transform.right * distance;
                        slideSource.pitch = Random.Range(0.6f, 1.4f);
                        slideSource.Play();
                    }
                }
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                if (transform.localScale.x == 1)
                {
                    Ray ray1 = new Ray(transform.position + new Vector3(0.25f, 0f, 0f), transform.up);
                    Ray ray2 = new Ray(transform.position - new Vector3(0.25f, 0f, 0f), transform.up);
                    if (!Physics.Raycast(ray1, out raycastHit, transform.localScale.y / 2 + 0.25f) && !Physics.Raycast(ray2, out raycastHit, transform.localScale.y / 2 + 0.25f))
                    {
                        transform.localPosition += transform.up * distance;
                        slideSource.pitch = Random.Range(0.6f, 1.4f);
                        slideSource.Play();
                    }
                }
                else
                {
                    Ray ray = new Ray(transform.position, transform.up);
                    if (!Physics.Raycast(ray, out raycastHit, transform.localScale.y / 2 + 0.25f))
                    {
                        transform.localPosition += transform.up * distance;
                        slideSource.pitch = Random.Range(0.6f, 1.4f);
                        slideSource.Play();
                    }
                }
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                if (transform.localScale.x == 1)
                {
                    Ray ray1 = new Ray(transform.position + new Vector3(0.25f, 0f, 0f), -transform.up);
                    Ray ray2 = new Ray(transform.position - new Vector3(0.25f, 0f, 0f), -transform.up);
                    if (!Physics.Raycast(ray1, out raycastHit, transform.localScale.y / 2 + 0.25f) && !Physics.Raycast(ray2, out raycastHit, transform.localScale.y / 2 + 0.25f))
                    {
                        transform.localPosition -= transform.up * distance;
                        slideSource.pitch = Random.Range(0.6f, 1.4f);
                        slideSource.Play();
                    }
                }
                else
                {
                    Ray ray = new Ray(transform.position, -transform.up);
                    if (!Physics.Raycast(ray, out raycastHit, transform.localScale.y / 2 + 0.25f))
                    {
                        transform.localPosition -= transform.up * distance;
                        slideSource.pitch = Random.Range(0.6f, 1.4f);
                        slideSource.Play();
                    }
                }
            }
        }

        isEqual = transform.position == clone.transform.position - new Vector3(0, 13, 0);
    }
}
