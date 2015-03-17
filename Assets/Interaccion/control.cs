using UnityEngine;
using System.Collections;


public class control : MonoBehaviour {
	private Camera Camara; // Camera used by the player
	private manejador manejadorDelJuego; // GameObject responsible for the management of the game
	private int clicks = 0;
	private Transform pieza1, pieza2;
	
	// Use this for initialization
	void Start ()
	{
		//Camara = GameObject.FindGameObjectWithTag("MainCamera").GetComponents(); // Find the Camera's GameObject from its tag
		Camara = Camera.main;
		manejadorDelJuego = gameObject.GetComponent<manejador>();
	}
	
	// Update is called once per frame
	void Update () {
		// Look for Mouse Inputs
		//GetMouseInputs();
		
	}

	public void HayClick(Vector3 posicion) {
		Debug.Log ("Hay click en " + posicion.ToString ());
	}

	public void CargarPieza(Transform pieza) {
		Debug.Log ("Pieza = " + pieza.ToString ());
		if (clicks == 0) {
						pieza1 = pieza;
						clicks++;
				} else {
			pieza2 = pieza;
			clicks--;
			mover();
				}
	}

	private void mover() {
		//temp = pieza1.GetChild(0).
		Vector3 poxAux;
		Vector3 poxAux2;
		Transform transAux;
		GameObject objAux;
		Transform pieza = pieza1.GetChild (0);
		poxAux2 = pieza.position;
		Debug.Log (pieza.position);
		poxAux = pieza2.position - pieza1.position;
		pieza.position = Vector3.zero;
		pieza.parent = pieza2;
		Debug.Log (pieza.position);
		pieza.position = poxAux2 + poxAux;
		//poxAux = pieza1.GetChild (0).transform.position;
		//pieza1.GetChild(0).transform.parent = pieza2;
		//pieza2.GetChild (0).transform.position = poxAux;

	}

	
	// Detect Mouse Inputs
	void GetMouseInputs()
	{
		Ray _ray;
		RaycastHit _hitInfo;
		
		// Select a piece if the gameState is 0 or 1
		if(manejadorDelJuego.gameState < 2)
		{
			// On Left Click
			if(Input.GetMouseButtonDown(0))
			{
				_ray = Camara.ScreenPointToRay(Input.mousePosition); // Specify the ray to be casted from the position of the mouse click
				
				// Raycast and verify that it collided
				if(Physics.Raycast (_ray,out _hitInfo))
				{
					// Select the piece if it has the good Tag
					if(_hitInfo.collider.gameObject.tag == ("PiecePlayer1"))
					{
						manejadorDelJuego.SelectPiece(_hitInfo.collider.gameObject);
						manejadorDelJuego.ChangeState (1);
					}
				}
			}
		}
		
		// Move the piece if the gameState is 1
		if(manejadorDelJuego.gameState == 1)
		{
			Vector2 selectedCoord;
			
			// On Left Click
			if(Input.GetMouseButtonDown(0))
			{
				_ray = Camara.ScreenPointToRay(Input.mousePosition); // Specify the ray to be casted from the position of the mouse click
				
				// Raycast and verify that it collided
				if(Physics.Raycast (_ray,out _hitInfo))
				{
					
					// Select the piece if it has the good Tag
					if(_hitInfo.collider.gameObject.tag == ("Cube"))
					{
						selectedCoord = new Vector2(_hitInfo.collider.gameObject.transform.position.x,_hitInfo.collider.gameObject.transform.position.y);
						manejadorDelJuego.MovePiece(selectedCoord);
						manejadorDelJuego.ChangeState (0);
					}
				}
			}
		}
	}
}
