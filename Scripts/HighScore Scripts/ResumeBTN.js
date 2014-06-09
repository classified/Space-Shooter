

var graphic = TextureGUI(); //(28,23);
var startPoint = Location();
var GUIColor:Color = Color.white;
var noGuiStyle : GUIStyle;
var PauseMenu : GameObject;
var screenH : int;
var screenW : int;
var scale : Vector3;
function Start() {
	graphic.setAnchor();
	screenH = Screen.height;
	screenW = Screen.width;
}

function Update() {
	if (graphic.texture){
		startPoint.updateLocation();
	}
}

function OnGUI() {
	GUI.color = GUIColor;
	var textureHeight : int = graphic.texture.height;
    var textureWidth : int = graphic.texture.width;
    var screenHeight :int = Screen.height;
    var screenWidth :int= Screen.width;
    
    var screenAspectRatio : int= (screenWidth / screenHeight);
    var textureAspectRatio :int = (textureWidth / textureHeight);
 
    var scaledHeight:int;
    var scaledWidth:int;
	//var xPosition : int = screenWidth / 2 - (scaledHeight / 2) - 240;
	scale.x = Screen.width /Screen.width;
	scale.z = Screen.height / Screen.height;
	scale.y = 1f;
	var svMat = GUI.matrix;
			
	Debug.Log(scale.x.ToString());
	Debug.Log(scale.y.ToString());
	GUI.matrix =Matrix4x4.TRS(Vector3.zero,Quaternion.identity,scale);
    
    if (textureAspectRatio <= screenAspectRatio)
    {
        // The scaled size is based on the height
        scaledHeight = screenHeight;
        scaledWidth = (screenHeight * textureAspectRatio);
    }
    else
    {
        // The scaled size is based on the width
        scaledWidth = screenWidth;
        scaledHeight = (scaledWidth / textureAspectRatio);
    }//Rect(graphic.offset.x+startPoint.offset.x - 115,graphic.offset.y+startPoint.offset.y,scaledWidth, scaledHeight),graphic.texture,noGuiStyle
/*	if (GUI.Button(Rect(45,graphic.offset.y+startPoint.offset.y ,250, 40),graphic.texture,noGuiStyle)) {
				Time.timeScale = 1;
				Destroy(this.gameObject);
				Destroy(PauseMenu);
	}	*/
	//if(screenW == 480 && screenH == 854)
	//{
		if (GUI.Button(Rect(30,Screen.height /2 + 40,graphic.texture.width, graphic.texture.height),graphic.texture,noGuiStyle)) {
				Time.timeScale = 1;
				Destroy(this.gameObject);
				Destroy(PauseMenu);
		}	
	//}
	GUI.matrix = svMat;
	
}