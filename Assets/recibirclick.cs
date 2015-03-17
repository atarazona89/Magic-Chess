using UnityEngine;
using System.Collections;

public class recibirclick : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		//Debug.Log ("hay click en posicion");
		Vector3 posicion = transform.position;
		//Debug.Log (
		Transform pieza;
		pieza = gameObject.GetComponentInChildren<Transform> ();
		SendMessageUpwards ("HayClick", posicion);
		SendMessageUpwards ("CargarPieza", pieza);
	}
}
