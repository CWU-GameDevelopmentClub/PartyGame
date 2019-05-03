using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter_Controller : MonoBehaviour
{

  public string hControl;
  public string vControl;
  public float speed;
  

  // Start is called before the first frame update
  void Start()
  {
      
  }

  // Update is called once per frame
  void Update(){
    if (Input.GetAxis(hControl) != 0 || Input.GetAxis(vControl) != 0) {
      transform.rotation = Quaternion.Euler(0, Mathf.Atan2(Input.GetAxis(hControl), Input.GetAxis(vControl)) * Mathf.Rad2Deg, 0);
      transform.position += transform.forward * speed;
    }
  }
}
