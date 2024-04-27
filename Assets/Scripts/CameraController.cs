using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject lastHit;
    private Vector3 collision = Vector3.zero;

    private float mouseX;
    private float mouseY;
    private float xRotation = 0f;

    [Header("���������������� ����")]
    public float sensetivityMouse;
    public Transform Player;

    public GameObject LastHit { get => lastHit; }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        if (PlayerPrefs.GetInt("isSound") == 0)
            AudioListener.volume = 0;

        if (PlayerPrefs.HasKey("sensitivity"))
            sensetivityMouse = PlayerPrefs.GetFloat("sensitivity");
        else
        {
            sensetivityMouse = 75f;
            PlayerPrefs.SetFloat("sensitivity", sensetivityMouse);
        }
    }

    void Update()
    {
        if (Cursor.lockState == CursorLockMode.Locked) 
        {
            mouseX = Input.GetAxis("Mouse X") * sensetivityMouse * Time.deltaTime;
            mouseY = Input.GetAxis("Mouse Y") * sensetivityMouse * Time.deltaTime;

            Player.Rotate(mouseX * new Vector3(0, 1, 0));
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            transform.Rotate(-mouseY * new Vector3(1, 0, 0));
        }
    }

    private void LateUpdate()
    {
        Ray ray = new Ray(this.transform.position, this.transform.forward);
#if UNITY_EDITOR
        Debug.DrawRay(transform.position, transform.forward * 100f, Color.yellow);
#endif
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 5))
        {
            lastHit = hit.transform.gameObject;
            collision = hit.point;
        }
        else
        {
            lastHit = null;
        }
    }
}
