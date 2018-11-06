using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float gravity = -25f;
	public float speedSmoothTime = 0.1f;
	public float jumpHeight = 5f;
	[Range(0,1)]
	public float airControlPercent;
	float targetSpeed;
	float animSpeed;

	public float velocityY;
	float speedSmoothVelocity;
	static float currentSpeed;

	[Range(0, 35)]
	float zaFormulu;

	Animator Animator;
	float speedPercent;
	float speedPercent2;
	bool uSkoku;
    bool skokwr;
	bool skocio;
    public bool isGrounded;
    public float qez;
	//otkucaji za srce
	public float heartBeats = 500f;
	public float jedan = 1;

	public float turnSmoothTime = 0.2f;
	public float turnSmoothVelocity;
    
    Transform cameraT;
	CharacterController controller;

	public float getCurrentSpeed(){
		return currentSpeed;
	}

	// Use this for initialization
	void Start () {
        qez = -1.3f;
        cameraT = Camera.main.transform;
		controller = GetComponent<CharacterController> ();

		Animator = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {

		Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		Vector2 inputDir = input.normalized;
		bool running = Input.GetKey (KeyCode.LeftShift);

		Move (inputDir, running);

		

		if (Input.GetKeyDown (KeyCode.Space)) {
			Jump();
		}

		if (Input.GetKey (KeyCode.K)) {
			controller.transform.position = Vector3.zero;
		}

        //Debug.Log ("Beats remaining: " + heartBeats);


        
        

        if (groundTouch())
        {
            
            isGrounded = true;
            Animator.SetBool("uSkoku", !isGrounded);
		}
        else
        {
            isGrounded = false;
            Animator.SetBool("uSkoku", !isGrounded);
        }
        //moje
        if (controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            uSkoku = true;
		}
        else
        {
            uSkoku = false;
        }

		if(Animator.GetBool("WallRun")){Animator.SetBool ("uSkoku", false);}

        //"SKOCIO" SE TRIGGERUJE KAD PRITISNES SPACE(I CONTROLLER.ISGROUNDED JE TRUE), A "USKOKU" DOK SI U VAZDUHU(TJ DOK JE CONTROLLER.ISGROUNDED = FALSE)

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            skocio = true;
        }
        else if (isGrounded)
        {
            skocio = false;
        }

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            skokwr = true;
        }
        else if (isGrounded)
        {
            skokwr = false;
        }
        else skokwr = true;
        
        Animator.SetBool("skocio", skocio);
        Animator.SetBool("skok", uSkoku);

        animSpeed = ((running) ? 35f : 6f) * inputDir.magnitude;
        Animator.SetFloat("speedPercent", animSpeed);

        Ray rightRay1 = drawRayVectorDeg(inputDir, 45);
        Ray rightRay2 = drawRayVectorDeg(inputDir, 80);
        Ray frontRay1 = drawRayVectorDeg(inputDir, 10);
        Ray frontRay2 = drawRayVectorDeg(inputDir, -10);
		Ray leftRay1 = drawRayVectorDeg(inputDir, -45);
		Ray leftRay2 = drawRayVectorDeg(inputDir, -80);

        RaycastHit hitSmth;
        bool wrpos = wallRunPossible(inputDir, frontRay2, frontRay2, new RaycastHit());
		bool wrposleft = wallRunPossible(inputDir, frontRay1, frontRay1, new RaycastHit());
        if (Animator.GetBool("skocio")) this.qez = -1.3f;
        if (wrpos)
        {
            float rez = -1.3f;
			if (skokwr && Physics.Raycast (rightRay2, out hitSmth) && Physics.Raycast (rightRay1, out hitSmth) && hitSmth.collider.tag == "RunnableWall" && hitSmth.distance < 4f) {
				rez = cube (qez, 1.3f, 0.01f);
				Debug.Log (" KVADRAD JE OVOLIKO : " + rez);
				velocityY += -rez;
				Debug.Log ("BRAVO!");
			}

		}else { Debug.Log("Not Possible"); qez = -1.3f; Animator.SetBool ("WallRun", false); }

		if (wrposleft)
		{
			float rez = -1.3f;
			if (skokwr && Physics.Raycast (leftRay2, out hitSmth) && Physics.Raycast (leftRay1, out hitSmth) && hitSmth.collider.tag == "RunnableWall" && hitSmth.distance < 4f) {
				rez = cube (qez, 1.3f, 0.01f);
				Debug.Log (" KVADRAD JE OVOLIKO : " + rez);
				velocityY += -rez;
				Debug.Log ("BRAVO!");
			}

		}else { Debug.Log("Not Possible"); qez = -1.3f; Animator.SetBool ("WallRun", false); }

		if ((skokwr && Physics.Raycast (leftRay2, out hitSmth) && Physics.Raycast (leftRay1, out hitSmth) && hitSmth.collider.tag == "RunnableWall" && hitSmth.distance < 4f) ||
		    (skokwr && Physics.Raycast (rightRay2, out hitSmth) && Physics.Raycast (rightRay1, out hitSmth) && hitSmth.collider.tag == "RunnableWall" && hitSmth.distance < 4f)) {
			Animator.SetBool ("WallRun", true);
		} else {
			Animator.SetBool ("WallRun", false);
		}
        
        //kraj mojeg

		if (Input.GetKey (KeyCode.T)) {
			Animator.Play ("WallRun");
		}

    }
    // x^2 jednacina 
    public float cube(float i, float j, float k)
    {
        if (i < j) this.qez += k;
        return i * i * i;
    }
    // WallRun Mogucnost 
    public bool wallRunPossible(Vector2 inp, Ray pos, Ray pos2, RaycastHit hitSmth)
    {

        bool rez = true;
        if (rez && skokwr)
        {


            if (Physics.Raycast(pos, out hitSmth) && hitSmth.distance < 2f)
            {
                rez = false;
            }
            if (Physics.Raycast(pos2, out hitSmth) && hitSmth.distance < 2f)
            {
                
                rez = false;
            }

        }
        else if (!Animator.GetBool("uSkoku")) {  rez =  true;   }
        
        return rez;
    }

    
    public Ray drawRayDown()
    {
        Vector3 bla = controller.transform.position;
        Vector3 pelvisRay1 = new Vector3(bla.x, bla.y + 1f, bla.z);
        Vector3 pelvisRay2 = Vector3.down + new Vector3(0, -0.5f, 0);
        Debug.DrawRay(pelvisRay1, pelvisRay2, Color.magenta);
        Ray rayDown = new Ray(pelvisRay1, pelvisRay2);
        return rayDown;

    }

    public bool groundTouch()
    {
        Ray rayDown = drawRayDown();
        RaycastHit hitGround;
        if (Physics.Raycast(rayDown, out hitGround) && hitGround.collider.tag == "Ground" && hitGround.distance < 2.75f)
        {
                return true;
        }
        else { return false; }


    }


    void FixedUpdate (){
		brojacZaJenduSekundu ();
	}

	//SRCE \/    \/    \/    \/    \/

	float pom = 1f;
	public void brojacZaJenduSekundu(){
		if (pom >= 100f) {
			if (getRunSpeed() == 0f) {
				beatMirovanje ();
				pom = 1f;
			} else if (getRunSpeed() == 0.5f) {
				beatHodanje ();
				pom = 1f;
			} else if (getRunSpeed() == 1f) {
				beatSprint ();
				pom = 1f;
			}
		} else {
			pom += 1f;
		}
	}

	public void beatMirovanje(){
		heartBeats--;
	}

	public void beatHodanje(){
		heartBeats -= 2f;
	}

	public void beatSprint(){
		heartBeats -= 3f;
	}

	static float getRunSpeed(){
		if (currentSpeed == 0f) {
			return 0;
		} else if(currentSpeed <= 6f){
			return 0.5f;
		}else{
			return 1f;
		}
	}

	//SRCE /\    /\    /\    /\    /\

	float formula(float brzina){
		float rez; 
		float rez2;
		if (brzina <= 7f) {
			rez = 0.08333f * brzina;
			if (brzina >= 5.9f && brzina < 7f) {
				return 0.5f;
			}
			return rez;
		} else{
			rez2 = 0.01724f * brzina + 0.5f;
			if (rez2 > 1f) {
				return 1f;
			}
			return rez2;
		}
	}

	float Walk(float wspeed){
		if (wspeed < 6f) {
			return wspeed + 0.2f;
		}
		else if ( wspeed >= 6f)
		{
			return 6f ;
		}

		else {
			return 0f;
		}
	}
    public Ray drawRayVectorDeg(Vector2 inputDir, int deg)
    {
        Vector3 player = controller.transform.position;
        Vector3 v1 = new Vector3(player.x, player.y + 4f, player.z);
     
        
        float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
        transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, GetModifiedSmoothTime(turnSmoothTime));
        Quaternion q1 =  Quaternion.Euler(0, deg + targetRotation, 0);
        
        
        Debug.DrawRay(v1, q1 * new Vector3(0,0,0.5f), Color.magenta);
        return new Ray(v1, q1 * new Vector3(0, 0, 0.5f));
        


    }
    
	void Move(Vector2 inputDir, bool running){
		if (inputDir != Vector2.zero) {
			float targetRotation = Mathf.Atan2 (inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
			transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, GetModifiedSmoothTime(turnSmoothTime));
		}

		velocityY += 3 * (Time.deltaTime * gravity);
		targetSpeed = ((running) ? ((targetSpeed > 35f) ? 35f : targetSpeed +0.8f)  :((targetSpeed > 6f)? ((targetSpeed <=7.3f)?6f:targetSpeed - 1.3f): Walk(targetSpeed))) * inputDir.magnitude;
		currentSpeed = Mathf.SmoothDamp (currentSpeed, targetSpeed, ref speedSmoothVelocity, GetModifiedSmoothTime(speedSmoothTime));

		Vector3 velocity = transform.forward * currentSpeed + Vector3.up * velocityY;
		controller.Move (velocity * Time.deltaTime);
		currentSpeed = new Vector2 (controller.velocity.x, controller.velocity.z).magnitude;

		if (controller.isGrounded) {
			velocityY = 0;
		}

		Animator.SetFloat ("speedPercent2", formula(targetSpeed));
	}

	void Jump(){
		if (isGrounded) {
			Debug.Log ("Sada si u skoku.");
			float jumpVelocity = 2.0f * (Mathf.Sqrt (-2 * gravity * jumpHeight));
			velocityY = jumpVelocity;
		}
	}

	float GetModifiedSmoothTime(float smoothTime){
		if (controller.isGrounded) {
			return smoothTime;
		}
		if (airControlPercent == 0) {
			return float.MaxValue;
		}
		return smoothTime / airControlPercent;
	}
}