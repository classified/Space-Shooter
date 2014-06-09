

var graphic = TextureGUI();
var startPoint = Location();
var GUIColor:Color = Color.white;
var noGuiStyle : GUIStyle;
var stars : Texture[];
var guiTextureCount : int;	
private var orignalWidth : float;
private var orignalHeight:float;
private var scale:Vector3;

function Start() {
	graphic.setAnchor();
	orignalWidth = Screen.width;
	orignalHeight = Screen.height;
 
}

function Update() {
	if (graphic.texture){
		startPoint.updateLocation();
	}
	
	
	
}

function OnGUI() {
	if (graphic.texture){
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
		//Scaling GUI MATRIX FOR ALL RESOLUTION
		scale.x = Screen.width /orignalWidth;
		scale.z = Screen.height / orignalHeight;
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
    }
		GUI.Box(Rect(0,Screen.height / 2 - 150, Screen.width , graphic.texture.height),
			graphic.texture,noGuiStyle);
		//	GUI.Box(Rect(0,Screen.height / 2 -150, Screen.width, Screen.height /2),graphic.texture,noGuiStyle);
			Debug.Log("Texture Width" + scaledWidth.ToString());
			Debug.Log("Texture Height" + scaledHeight.ToString());
	}
	GUI.matrix = svMat;
	
}