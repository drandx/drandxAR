//////////////////////////////////////////////////////////////
// AnimationController.js
// Penelope iPhone Tutorial
//
// AnimationController plays the appropriate animations for Penelope
// and the blending between them. It uses the character's
// movement direction to determine which animation should be played.
//////////////////////////////////////////////////////////////

// The Animation component that this script controls
var animationTarget : Animation; 

// Different speeds depending on movement direction
var maxForwardSpeed : float = 6;
var maxBackwardSpeed : float = 3;
var maxSidestepSpeed : float = 4;

private var character : CharacterController;
private var thisTransform : Transform;
private var jumping : boolean = false;
private var minUpwardSpeed = 2;

function Start()
{
	// Cache component lookup at startup instead of doing this every frame
	character = GetComponent( CharacterController );
	thisTransform = transform;

	// Set up animation settings that aren't configurable from the editor
	animationTarget.wrapMode = WrapMode.Loop;
	
	animationTarget[ "punch" ].wrapMode = WrapMode.Once;
	animationTarget[ "jump" ].wrapMode = WrapMode.Once;
	
	animationTarget[ "punch" ].layer = 2;
	animationTarget[ "jump" ].layer = 2;
	
}

function OnEndGame()
{
	// Don't update animations when the game has ended
	this.enabled = false;
}

private var buttonAStatus : byte = -1;
private var buttonBStatus : byte = -1;

function playAnimationAttackStart(){
	//print("Started playAnimation For Button A");
	animationTarget.CrossFade( "punch" );
	buttonAStatus = 1;
}

function playAnimationAttackEnd(){
	//print("Ended playAnimation For Button A");
	buttonAStatus = 0;
}


function playAnimationDefenceStart(){
	//print("Started playAnimation For Button B");
	animationTarget.CrossFade( "jump" );
	buttonBStatus = 1;
}

function playAnimationDefenceEnd(){
	//print("Started playAnimation For Button B");
	buttonBStatus = 0;
}

function Update()
{			
	var characterVelocity = character.velocity;
	
	// When monitoring movement we check horizontal and vertical movement 
	// separately to decide what animations to play.
	var horizontalVelocity : Vector3 = characterVelocity;
	horizontalVelocity.y = 0; // ignore any vertical movement
	var speed = horizontalVelocity.magnitude;

	var upwardsMotion = Vector3.Dot( thisTransform.up, characterVelocity );
	
	//print("Character Speed = " + speed);
	var t = 0.0;
	
	if(speed > 0){
		// Adjust the animation speed to match with how fast the
		// character is moving forward
		
		t = Mathf.Clamp( Mathf.Abs( speed / maxForwardSpeed ), 0, maxForwardSpeed );
		animationTarget[ "run" ].speed = Mathf.Lerp( 0.25, 1, t );
		animationTarget.CrossFade( "run" );
	}
	else if(speed == 0 && buttonAStatus==1){ //Button A is started
		//animationTarget.CrossFade( "LOSE" );
	}
	else if(speed == 0 && buttonBStatus==1){ //Button B is started
		//animationTarget.CrossFade( "WIN" );
	}
	else{
		// Play the idle animation by default
		animationTarget.CrossFade( "idle" );
	}
}
