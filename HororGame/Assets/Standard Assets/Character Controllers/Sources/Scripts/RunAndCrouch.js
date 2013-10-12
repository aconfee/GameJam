// Update player speeds by accessing character motor 
// global speed var

var walkSpeed: float = 7; // regular speed
var runSpeed: float = 20; // run speed
 
private var chMotor: CharacterMotor;
private var ch: CharacterController;
 
function Start()
{
	chMotor = GetComponent(CharacterMotor);
	ch = GetComponent(CharacterController);
}
 
function Update()
{
	var speed = walkSpeed;
	
	if (ch.isGrounded && Input.GetKey("left shift") || Input.GetKey("right shift"))
	{
		speed = runSpeed;
	}
	
	chMotor.movement.maxForwardSpeed = speed; // set max speed
}