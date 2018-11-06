using UnityEngine;

public class playerCollision : MonoBehaviour {

	void OnCollisionEnter(Collision col){
		if (col.collider.tag == "RunnableWall") {
			Debug.Log ("Dodirujes zid.");
		}
	}

	//void Update
}
