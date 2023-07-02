using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float _rotAngleX;
    [SerializeField] private float _dist;
    [SerializeField] private float _offsetY;
    [SerializeField] private Transform _target;

    private Quaternion _rot;
    private Vector3 _pos;

    private void Start()
    {
        _rot = Quaternion.Euler(_rotAngleX, 0, 0);
    }

    void LateUpdate()
    {
        _pos = _rot * new Vector3(0, 0, -_dist) + TargetPos();  
        transform.SetPositionAndRotation(_pos, _rot);
    }

    private Vector3 TargetPos() 
    {
        Vector3 targetPos = _target.position;
        targetPos.y = _offsetY;
        return targetPos;
    }
}
