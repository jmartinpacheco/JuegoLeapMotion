using UnityEngine;
using System.Collections;
using Leap;

public class Movimiento : MonoBehaviour {
	Controller controller;
	HandController controladordemano;
	Hand mano;
	Finger dedo;
	public float velocidad;
	bool mirror_z_axis_ = false;
    public Transform cosa;
	public float damage=10.0f;
	//Pointable pointable = frame.Pointables.Frontmost;
	//float touchDistance = pointable.TouchDistance;

	// Use this for initialization
	void Start () {
		controller = new Controller();//Representa el controlador del Leap Motion, que nos da la información 
		controller.EnableGesture(Gesture.GestureType.TYPESWIPE);//Activamos el reconocimiento de gestos y le pasamos el tipo de gesto que queremos reconocer
		controller.Config.SetFloat ("Gesture.Swipe.MinLength", 200.0f);// Rango de lectura del gesto
		controller.Config.SetFloat ("Gesture.Swipe.MinVelocity", 750f);// Velocidad del gesto
		//controller.EnableGesture (Gesture.GestureType.TYPE_CIRCLE);
		//controller.Config.SetFloat ("Gesture.Circle.Minradius", 10.0f);
		//controller.Config.SetFloat("Gesture.Circle.MinArc", .5f);
		controller.Config.Save ();//salvamos los parametros anteriores
	
	}
	
	// Update is called once per frame
	void Update () {
		Frame frame = controller.Frame ();//nos da la información del “Frame” actual
		GestureList gestures = frame.Gestures();// generamos una lista de gestos leidas en cada frame
		HandList hands = frame.Hands; // creamos el identificador de manos
		Pointable pointable = frame.Pointables.Frontmost;
		Frame frameOfThisPointableObject = pointable.Frame;
		Hand firstHand = hands [0];//Leemos la mano derecha

		//print (ID);
		int extendedFingers = 0;
		for (int f = 0; f <hands[0].Fingers.Count; f++) {
			Finger digit = hands[0].Fingers [f];
			if (digit.IsExtended){
				extendedFingers++;
				//print(digit);
                //if (f == 3) Destroy(this.gameObject);
			}

		}

        float altura=firstHand.PalmPosition.y;
        if (altura >= 6.0f)
        {
            altura -= 4.0f;
        }

		//if(firstHand.PalmPosition.x)
        this.gameObject.transform.position = new Vector3(firstHand.PalmPosition.x * velocidad, altura * velocidad, -firstHand.PalmPosition.z * velocidad);
		print (firstHand.PalmPosition.z);
		//this.gameObject.transform.position = new Vector3(firstHand.PalmPosition.x * velocidad,0.0f,0.0f);

		Ray rayo = new Ray(this.gameObject.transform.position,transform.forward); 
		RaycastHit hit;  

		if(firstHand.PalmPosition.z<1.0f){
			if(Physics.Raycast(rayo, out hit, 10.0f))
				hit.transform.SendMessage("DisminuirVida",damage,SendMessageOptions.DontRequireReceiver);
		}


		}
	
//		
//			
    }


