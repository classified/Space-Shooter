
var isQuit=false;
var isSettings=false;
var isAbout=false;
	
function OnMouseEnter(){
//change text color
renderer.material.color=Color.blue;
}

function OnMouseExit(){
//change text color
renderer.material.color=Color.white;
}

function OnMouseUp(){
//is this quit
if (isQuit==true) {
//quit the game
Application.Quit();
}
else if(isSettings==true){
//load level
Application.LoadLevel(4);
}
else if(isAbout==true)
{
	GUI.Box(Rect(0,0,Screen.width,Screen.height),"This is a box");
}
}

function Update(){
//quit game if escape key is pressed
if (Input.GetKey(KeyCode.Escape)) { Application.Quit();
}

}

	
