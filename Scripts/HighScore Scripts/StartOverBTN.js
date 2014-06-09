
var graphic = TextureGUI(); //(28,23);
var startPoint = Location();
var GUIColor:Color = Color.white;
var noGuiStyle : GUIStyle;
var PauseMenu : GameObject;
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
    //graphic.offset.x+startPoint.offset.x - 115,graphic.offset.y+startPoint.offset.y -100 ,250, 45
/*	if(GUI.Button(Rect(215 ,graphic.offset.y+startPoint.offset.y ,250, 40),graphic.texture,noGuiStyle))
	{
				
			Destroy(PauseMenu);	
			Time.timeScale =1;
			Application.LoadLevel(Application.loadedLevel);
	}	*/
	//if(screenW == 480 && screenH == 854)
	//{
	Debug.Log("Screen Start :" +  (Screen.width / 2 - graphic.texture.height));
		if(GUI.Button(Rect(Screen.width - 130 ,Screen.height /2 + 40 ,graphic.texture.width, graphic.texture.height),graphic.texture,noGuiStyle))
		{
			//Debug.Log("Start Over Button");						
			Destroy(PauseMenu);	
			Time.timeScale =1;
			//Debug.Log("Name Of LoadedLevel is" + Application.loadedLevelName);
			Application.LoadLevel(Application.loadedLevel);
		}	
	//}
	
}