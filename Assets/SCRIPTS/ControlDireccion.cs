using UnityEngine;

public class ControlDireccion : MonoBehaviour
{
    public enum TipoInput { AWSD, Arrows }
    public TipoInput InputAct = TipoInput.AWSD;

    float Giro = 0;

    public bool Habilitado = true;
    CarController carController;

    //---------------------------------------------------------//
    public FixedJoystick joystick;
    // Use this for initialization
    void Start()
    {
#if UNITY_ANDROID || UNITY_IOS 
        joystick.gameObject.SetActive(true);
#else
        joystick.gameObject.SetActive(false);
#endif
        carController = GetComponent<CarController>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_ANDROID || UNITY_IOS
        carController.SetGiro(joystick.Horizontal);
        carController.SetAcel(joystick.Vertical <= 0.1f ? 0.1f : joystick.Vertical);
#else
        switch (InputAct)
        {
            case TipoInput.AWSD:
                if (Habilitado)
                {
                    if (Input.GetKey(KeyCode.A))
                    {
                        Giro = -1;
                    }
                    else if (Input.GetKey(KeyCode.D))
                    {
                        Giro = 1;
                    }
                    else
                    {
                        Giro = 0;
                    }
                }
                break;
            case TipoInput.Arrows:
                if (Habilitado)
                {
                    if (Input.GetKey(KeyCode.LeftArrow))
                    {
                        Giro = -1;
                    }
                    else if (Input.GetKey(KeyCode.RightArrow))
                    {
                        Giro = 1;
                    }
                    else
                    {
                        Giro = 0;
                    }
                }
                break;
        }
        carController.SetGiro(Giro);
        carController.SetAcel(1);
#endif

    }

    public float GetGiro()
    {
        return Giro;
    }

}
