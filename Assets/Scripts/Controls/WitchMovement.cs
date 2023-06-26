using UnityEngine;

public class WitchMovement : MonoBehaviour
{
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _movementSpeed;

    private Camera _camera;
    private Vector3 _movementDir;

    private float _constantSpeed = 1000f;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        _animator.SetFloat("speed", _joystick.Direction.magnitude);

        if (_joystick.Direction.magnitude > 0)
        {
            _movementDir = _camera.transform.TransformDirection(_joystick.Direction);
            _movementDir.y = 0;
            _movementDir.Normalize();
            transform.forward = _movementDir;
            _rb.velocity = Time.deltaTime * _constantSpeed * _movementSpeed * new Vector3(_joystick.Direction.x,0,_joystick.Direction.y);
        }

        if (_joystick.Direction.magnitude<0.01f) 
        {
            _rb.velocity = Vector3.zero;
        }

    }

}
