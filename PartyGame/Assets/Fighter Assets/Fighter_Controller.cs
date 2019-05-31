using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter_Controller : MonoBehaviour {

   public string hControl;
   public string vControl;
   public string Attack;
   public string Jump;
   public string Defend;
   public float speed;
   public Animator anim;
   public float charge;


   // Start is called before the first frame update
   void Start() {

   }

   // Update is called once per frame
   void Update() {
      anim.SetInteger("speed", 0);
      if (Input.GetAxis(hControl) != 0 || Input.GetAxis(vControl) != 0) {
         transform.rotation = Quaternion.Euler(0, Mathf.Atan2(Input.GetAxis(hControl), Input.GetAxis(vControl)) * Mathf.Rad2Deg, 0);
         anim.SetInteger("speed", 1);
      }

      if (Input.GetKey(KeyCode.U)) {
         charge += Time.deltaTime;
         if (charge >= .3f && !anim.GetBool("direction held")) {
            anim.SetBool("direction held", true);
            anim.Play("Charge");
         }
      }

      if (Input.GetKeyUp(KeyCode.U)) {
         anim.SetBool("direction held", false);
         if (charge < .3f) {
            anim.Play("Slap");
         }
         charge = 0;
      }

   }
}
