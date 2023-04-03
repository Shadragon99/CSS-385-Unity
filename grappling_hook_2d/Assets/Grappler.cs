using UnityEngine;

public class Grappler : MonoBehaviour
{
    public Camera mainCamera;
    public LineRenderer _lineRenderer;
    public DistanceJoint2D _distanceJoint;
    public bool isGrappleOn;


    void Start()
    {
        _distanceJoint.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isGrappleOn = true;
            Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            _lineRenderer.SetPosition(0, mousePos);
            _lineRenderer.SetPosition(1, transform.position);
            _distanceJoint.connectedAnchor = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            _distanceJoint.enabled = true;
            _lineRenderer.enabled = true;
        } else if (Input.GetKeyUp(KeyCode.Mouse0))
        {   
            isGrappleOn = false;
            _distanceJoint.enabled = false;
            _lineRenderer.enabled = false;
        }

        if (_distanceJoint.enabled)
        {
            _lineRenderer.SetPosition(1, transform.position);
        }
    }
}
