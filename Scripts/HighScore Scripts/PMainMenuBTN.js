import EventTalk;

var LevelToLoad : String;
var graphic = TextureGUI(); //(28,23);
var startPoint = Location();
var GUIColor:Color = Color.white;
var noGuiStyle : GUIStyle;
var screenH : int;
var screenW : int;
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
    //GUI.Button(Rect(graphic.offset.x+startPoint.offset.x +50 ,graphic.offset.y+startPoint.offset.y,scaledWidth, scaledHeight),graphic.texture,noGuiStyle
	/*if (GUI.Button(Rect(130 ,graphic.offset.y+startPoint.offset.y,250, 40),graphic.texture,noGuiStyle)) {
					
					//PlayerPrefs.Save();
					Application.LoadLevel(LevelToLoad);
					
	}	*/
	//if(screenW == 480 && screenH == 854)
	//{
		if (GUI.Button(Rect(Screen.width /2 - 50,Screen.height /2 - 50,graphic.texture.width, graphic.texture.height),graphic.texture,noGuiStyle)) {
						
						EventTalk.EventTrigger.askToSaveScore = true;
						Application.LoadLevel(LevelToLoad);
						
		}	
	//}
}