using UnityEngine;

public class Player : MonoBehaviour
{
   [SerializeField] private float speed = 200f;
   [SerializeField] private string inputNameHorizontal;
   [SerializeField] private string inputNameVertical;

   private Rigidbody _rb;
 
   private float _inputHorizontal;
   private float _inputVertical;
   private bool _interactive;
   [SerializeField] private bool animating;

   public void SetInteractive(bool state)
   {
      _interactive = state;
   }
   
   private void Start()
   {
      _rb = GetComponent<Rigidbody>();
   }

   private void Update()
   {
      _inputHorizontal = Input.GetAxis(inputNameHorizontal);
      _inputVertical = Input.GetAxis(inputNameVertical);
   }
   
   private void FixedUpdate()
   {
      if (animating)
      {
         _rb.AddForce(Vector3.forward*20.0f);
      }
      if (_interactive)
      {
         _rb.velocity = new Vector3(_inputHorizontal * speed * Time.fixedDeltaTime, _rb.velocity.y, _inputVertical * speed * Time.fixedDeltaTime);
      }
   }
}
