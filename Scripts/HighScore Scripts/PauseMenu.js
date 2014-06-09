

var graphic = TextureGUI(); //(28,23);
var startPoint = Location();
var GUIColor:Color = Color.white;
var noGuiStyle : GUIStyle;
var pauseCall : GameObject;

function Start() {
	graphic.setAnchor();
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
	if (GUI.Button(Rect(graphic.offset.x+startPoint.offset.x ,graphic.offset.y+startPoint.offset.y,graphic.texture.width, graphic.texture.height),graphic.texture,noGuiStyle)) {
					
					Time.timeScale = 0;
					Instantiate(pauseCall,transform.position,transform.rotation);
					
	}	
	
}