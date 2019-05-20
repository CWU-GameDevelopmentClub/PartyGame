using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox_Fighter : MonoBehaviour
{
  public float duration;
  public float damage;
  private float existed = 0;

  // Start is called before the first frame update
  void Start()
  {
      
  }

  // Update is called once per frame
  void Update() {
    if (duration < existed) {
      Destroy(gameObject);
    }
    existed += Time.deltaTime;
  }
}
