using UnityEngine;

public class ControlDireccion : MonoBehaviour 
{
	public enum TipoInput {AWSD, Arrows}
	public TipoInput InputAct = TipoInput.AWSD;

	float Giro = 0;
	
	public bool Habilitado = true;
	CarController carController;
		
	//---------------------------------------------------------//
	public FixedJoystick joystick;
	// Use this for initialization
	void Start () 
	{
		carController = GetComponent<CarController>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		carController.SetGiro(joystick.Horizontal);
		carController.SetAcel(joystick.Vertical<=0.1f ? 0.1f : joystick.Vertical);

    }

	public float GetGiro()
	{
		return Giro;
	}
	
}
