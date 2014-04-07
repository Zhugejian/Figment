
// Require a character controller to be attached to the same game object
@script RequireComponent(CharacterController)

public var idleAnimation : AnimationClip;
public var walkAnimation : AnimationClip;

public var walkMaxAnimationSpeed : float = 0.75;


private var _animation : Animation;

enum CharacterState {
	Idle = 0,
	Walking = 1,
}

private var _characterState : CharacterState;

// The speed when walking
var walkSpeed = 2.0;

// Related to jumping?
private var groundedTimeout = 0.25;

// The camera doesnt start following the target immediately but waits for a split second to avoid too much waving around.
private var lockCameraTimer = 0.0;

// The current move direction in x-z
private var moveDirection = Vector3.zero;
// The current vertical speed
private var verticalSpeed = 0.0;
// The current x-z move speed
private var moveSpeed = 0.0;

// The last collision flags returned from controller.Move
private var collisionFlags : CollisionFlags; 

// Are we moving backwards (This locks the camera to not do a 180 degree spin)
private var movingBack = false;
// Is the user pressing any keys?
private var isMoving = false;

private var isControllable = true;

function Awake ()
{
	moveDirection = transform.TransformDirection(Vector3.forward);
	
	_animation = GetComponent(Animation);
	if(!_animation)
		Debug.Log("The character you would like to control doesn't have animations. Moving her might look weird.");
	
	/*
public var idleAnimation : AnimationClip;
public var walkAnimation : AnimationClip;
public var runAnimation : AnimationClip;
public var jumpPoseAnimation : AnimationClip;	
	*/
	if(!idleAnimation) {
		_animation = null;
		Debug.Log("No idle animation found. Turning off animations.");
	}
	if(!walkAnimation) {
		_animation = null;
		Debug.Log("No walk animation found. Turning off animations.");
	}			
}


//function UpdateSmoothedMovementDirection ()
//{
//	var cameraTransform = Camera.main.transform;
//	var grounded = IsGrounded();
//	
//	// Forward vector relative to the camera along the x-z plane	
//	var forward = cameraTransform.TransformDirection(Vector3.forward);
//	forward.y = 0;
//	forward = forward.normalized;
//
//	// Right vector relative to the camera
//	// Always orthogonal to the forward vector
//	var right = Vector3(forward.z, 0, -forward.x);
//
//	var v = Input.GetAxisRaw("Vertical");
//	var h = Input.GetAxisRaw("Horizontal");
//
//	// Are we moving backwards or looking backwards
//	if (v < -0.2)
//		movingBack = true;
//	else
//		movingBack = false;
//	
//	var wasMoving = isMoving;
//	isMoving = Mathf.Abs (h) > 0.1 || Mathf.Abs (v) > 0.1;
//		
//	// Target direction relative to the camera
//	var targetDirection = h * right + v * forward;
//	
//	// Grounded controls
//	if (grounded)
//	{
//		// Lock camera for short period when transitioning moving & standing still
//		lockCameraTimer += Time.deltaTime;
//		if (isMoving != wasMoving)
//			lockCameraTimer = 0.0;
//
//		// We store speed and direction seperately,
//		// so that when the character stands still we still have a valid forward direction
//		// moveDirection is always normalized, and we only update it if there is user input.
//		if (targetDirection != Vector3.zero)
//		{
//			// If we are really slow, just snap to the target direction
//			if (moveSpeed < walkSpeed * 0.9 && grounded)
//			{
//				moveDirection = targetDirection.normalized;
//			}
//			// Otherwise smoothly turn towards it
//			else
//			{
//				moveDirection = Vector3.RotateTowards(moveDirection, targetDirection, rotateSpeed * Mathf.Deg2Rad * Time.deltaTime, 1000);
//				
//				moveDirection = moveDirection.normalized;
//			}
//		}
//		
//		// Smooth the speed based on the current target direction
//		var curSmooth = speedSmoothing * Time.deltaTime;
//		
//		// Choose target speed
//		//* We want to support analog input but make sure you cant walk faster diagonally than just forward or sideways
//		var targetSpeed = Mathf.Min(targetDirection.magnitude, 1.0);
//	
//		_characterState = CharacterState.Idle;
//		
//		// Pick speed modifier
//		if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift))
//		{
//			targetSpeed *= runSpeed;
//			_characterState = CharacterState.Running;
//		}
//		else if (Time.time - trotAfterSeconds > walkTimeStart)
//		{
//			targetSpeed *= trotSpeed;
//			_characterState = CharacterState.Trotting;
//		}
//		else
//		{
//			targetSpeed *= walkSpeed;
//			_characterState = CharacterState.Walking;
//		}
//		
//		moveSpeed = Mathf.Lerp(moveSpeed, targetSpeed, curSmooth);
//		
//		// Reset walk time start when we slow down
//		if (moveSpeed < walkSpeed * 0.3)
//			walkTimeStart = Time.time;
//	}
//	// In air controls
//	else
//	{
//		// Lock camera while in air
//		if (jumping)
//			lockCameraTimer = 0.0;
//
//		if (isMoving)
//			inAirVelocity += targetDirection.normalized * Time.deltaTime * inAirControlAcceleration;
//	}
//	
//
//		
//}


function Update() {
	
	if (!isControllable)
	{
		// kill all inputs if not controllable.
		Input.ResetInputAxes();
	}

	//UpdateSmoothedMovementDirection();
	
	// Calculate actual motion
	var movement = moveDirection * moveSpeed + Vector3 (0, verticalSpeed, 0);
	movement *= Time.deltaTime;
	
	// Move the controller
	var controller : CharacterController = GetComponent(CharacterController);
	collisionFlags = controller.Move(movement);
	
	// ANIMATION sector
	if(_animation) { 
		if(controller.velocity.sqrMagnitude < 0.1) {
			_animation.CrossFade(idleAnimation.name);
		}
		else 
		{
			if(_characterState == CharacterState.Walking) {
				_animation[walkAnimation.name].speed = Mathf.Clamp(controller.velocity.magnitude, 0.0, walkMaxAnimationSpeed);
				_animation.CrossFade(walkAnimation.name);	
			}
		}
	}
	// ANIMATION sector
	
	// Set rotation to the move direction
	if (IsGrounded())
	{
		
		transform.rotation = Quaternion.LookRotation(moveDirection);
			
	}	
	else
	{
		var xzMove = movement;
		xzMove.y = 0;
		if (xzMove.sqrMagnitude > 0.001)
		{
			transform.rotation = Quaternion.LookRotation(xzMove);
		}
	}
}

function OnControllerColliderHit (hit : ControllerColliderHit )
{
//	Debug.DrawRay(hit.point, hit.normal);
	if (hit.moveDirection.y > 0.01) 
		return;
}

function GetSpeed () {
	return moveSpeed;
}


function IsGrounded () {
	return (collisionFlags & CollisionFlags.CollidedBelow) != 0;
}

function GetDirection () {
	return moveDirection;
}

function IsMovingBackwards () {
	return movingBack;
}

function GetLockCameraTimer () 
{
	return lockCameraTimer;
}

function IsMoving ()  : boolean
{
	return Mathf.Abs(Input.GetAxisRaw("Vertical")) + Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5;
}

function Reset ()
{
	gameObject.tag = "Player";
}

