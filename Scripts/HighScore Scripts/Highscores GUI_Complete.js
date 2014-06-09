import PreviewLabs.PlayerPrefs;	




var numHighscores:int = 8; // the number of highscores to display on the screen

class highscore {
	var name:String;
	var score:int;
	var kills:int;
	var gameID:int;
	
}

var scoreArray = new highscore[numHighscores];
scoreArray[0].name = "Rajan";


var namesOffset:Vector2 ;
var roundsOffset:Vector2;
var killsOffset:Vector2 ;

var center = Location();
var screenW : int;
var screenH : int;
var yesSkin : Texture;
var noSkin : Texture;
var objectState : boolean;



public static var nameAdd : String = "Enter Name";

function Start() {

	
	screenW = Screen.width;
	screenH = Screen.height;

}

var heightOffset:float = 35;

var maximum:float = 0.5;
var pulseNum:float = 0.0;
var colorPulse:Color = Color(1,.35,0,1);

function Update () {
	center.updateLocation();
	pulseNum = Mathf.PingPong(Time.time*2, maximum); // outputs 0-1
	pulseNum /= 2; // change to 0-.5
	pulseNum += 0.5;	// change to .5-1
	colorPulse = Color.Lerp(Color.black, Color.white, pulseNum);
	

}

var textGuiStyle : GUIStyle;




function OnGUI () {
	
	if(screenW == 320 && screenH == 480)
	{
		for (var l=0;l<numHighscores;l++){
			
			//center.offset.x + Screen.width / 2 - 250
			//to find the Y position, take the center, add the offset, then add an offset based on the for loop iterator
			GUI.Box(Rect(center.offset.x + Screen.width /2 - 60 , center.offset.y +  l * heightOffset + Screen.height /2 - 280  ,220,40),
					scoreArray[l].name,textGuiStyle); // display the names
					
			GUI.Box(Rect(center.offset.x + Screen.width / 2 - 160, center.offset.y +  l * heightOffset +Screen.height /2 - 280,100,40),
					scoreArray[l].score.ToString(),textGuiStyle); // display the rounds

			GUI.Box(Rect(center.offset.x + Screen.width / 2 - 90, center.offset.y + l * heightOffset +Screen.height /2 - 280,100,40),
					scoreArray[l].kills.ToString(),textGuiStyle); // display the kills
		}
	}
	
	else if(screenW == 480 && screenH == 800)
	{	
		for (var i=0;i<numHighscores;i++){
		
		
			//center.offset.x + Screen.width / 2 - 250
			//to find the Y position, take the center, add the offset, then add an offset based on the for loop iterator
			GUI.Box(Rect(center.offset.x + Screen.width /2 - 350 , center.offset.y +  i * heightOffset + Screen.height /2 - 580  ,220,40),
					scoreArray[i].name,textGuiStyle); // display the names
					
			GUI.Box(Rect(center.offset.x + Screen.width / 2 - 160, center.offset.y +  i * heightOffset +Screen.height /2 - 580,100,40),
					scoreArray[i].score.ToString(),textGuiStyle); // display the rounds

			GUI.Box(Rect(center.offset.x + Screen.width / 2 - 90, center.offset.y + i * heightOffset +Screen.height /2 - 580,100,40),
					scoreArray[i].kills.ToString(),textGuiStyle); // display the kills
			
			
		}
		
		nameAdd = GUI.TextField(Rect(center.offset.x + Screen.width /2 - 470,center.offset.y + Screen.height /2 - 205,200, 40),nameAdd,30);
		
		if(GUI.Button(Rect(center.offset.x + Screen.width /2 - 240,center.offset.y + Screen.height /2 - 210, 220, 40),yesSkin,textGuiStyle))
		{
				
			//BridgeJTOC.Bridge.setHighScoreName(nameAdd);
				
		}
		/*if(GUI.Button(Rect(center.offset.x + Screen.width /2 - 120,center.offset.y + Screen.height /2 - 210, 220, 40),noSkin,textGuiStyle))
		{
			var abc = "";
			BridgeJTOC.Bridge.setHighScoreName(abc);
		}	*/	
	}
	else if(screenW == 480 && screenH == 854)
	{	
		for (var k=0;k<numHighscores;k++){
		
			
			//center.offset.x + Screen.width / 2 - 250
			//to find the Y position, take the center, add the offset, then add an offset based on the for loop iterator
			GUI.Box(Rect(center.offset.x + Screen.width /2 - 350 , center.offset.y +  k * heightOffset + Screen.height /2 - 760  ,220,40),
					scoreArray[k].name,textGuiStyle); // display the names
					
			GUI.Box(Rect(center.offset.x + Screen.width / 2 - 160, center.offset.y +  k * heightOffset +Screen.height /2 - 760,100,40),
					scoreArray[k].score.ToString(),textGuiStyle); // display the rounds

			GUI.Box(Rect(center.offset.x + Screen.width / 2 - 90, center.offset.y + k * heightOffset +Screen.height /2 - 760,100,40),
					scoreArray[k].kills.ToString(),textGuiStyle); // display the kills
		}
	}
	else if(screenW == 540 && screenH == 960)
	{	
		for (var j=0;j<numHighscores;j++){
		
			
			//center.offset.x + Screen.width / 2 - 250
			//to find the Y position, take the center, add the offset, then add an offset based on the for loop iterator
			GUI.Box(Rect(center.offset.x + Screen.width /2 - 400 , center.offset.y +  j * heightOffset + Screen.height /2 - 730  ,220,40),
					scoreArray[j].name,textGuiStyle); // display the names
					
			GUI.Box(Rect(center.offset.x + Screen.width / 2 - 200, center.offset.y +  j * heightOffset +Screen.height /2 - 730,100,40),
					scoreArray[j].score.ToString(),textGuiStyle); // display the rounds

			GUI.Box(Rect(center.offset.x + Screen.width / 2 - 110, center.offset.y + j * heightOffset +Screen.height /2 - 730,100,40),
					scoreArray[j].kills.ToString(),textGuiStyle); // display the kills
		}
	}
}
/*
function SyncPlayerPrefs() {
	for (var i=0;i<numHighscores;i++){
		if (!PreviewLabs.PlayerPrefs.HasKey("Highscore" + i + "rounds")) {
			PreviewLabs.PlayerPrefs.SetInt("Highscore" + i + "rounds",scoreArray[i].score);
		} else {
			scoreArray[i].score = PreviewLabs.PlayerPrefs.GetInt("Highscore" + i + "rounds");
		}
		
		if (!PreviewLabs.PlayerPrefs.HasKey("Highscore" + i + "kills")) {
			PreviewLabs.PlayerPrefs.SetInt("Highscore" + i + "kills",scoreArray[i].kills);
		} else {
			scoreArray[i].kills = PreviewLabs.PlayerPrefs.GetInt("Highscore" + i + "kills");
		}
		
		if (!PreviewLabs.PlayerPrefs.HasKey("Highscore" + i + "name")) {
			PreviewLabs.PlayerPrefs.SetString("Highscore" + i + "name",scoreArray[i].name);
		} else {
			scoreArray[i].name = PreviewLabs.PlayerPrefs.GetString("Highscore" + i + "name");
		}
		
		if (!PreviewLabs.PlayerPrefs.HasKey("Highscore" + i + "gameID")) {
			PreviewLabs.PlayerPrefs.SetInt("Highscore" + i + "gameID",scoreArray[i].gameID);
		} else {
			scoreArray[i].gameID = PreviewLabs.PlayerPrefs.GetInt("Highscore" + i + "gameID");
		}
	}
}

var newScorePosition:int = numHighscores+1;

function addNewHighscore() {

	newScorePosition = numHighscores+1;
	var ThisGameID = PreviewLabs.PlayerPrefs.GetInt("ThisGameID");
	var thisRounds = PreviewLabs.PlayerPrefs.GetInt("thisRounds");
	var thisTotalKills = PreviewLabs.PlayerPrefs.GetInt("thisTotalKills");
	
	for (thisHighscore in scoreArray) {
		if (thisHighscore.gameID == ThisGameID) {
			return; // exit if the new gameID is in the highscoreList already
		}
	}
	
	// how scoring works:
	// if more rounds were won, that score is higher, even if kills were lower
	// if rounds were equal, check the scores, if kills are equal, new score takes
	// next available spot
	
	for (var i:int=0;i<numHighscores;i++) { // for each highscore
		if (thisRounds > scoreArray[i].score) { // see if new score is higher
			newScorePosition = i; // if it is, set newScorePosition to that #
			i = numHighscores; // and exit the loop
		}else if(thisRounds == scoreArray[i].score) { // if rounds are equal
			if (thisTotalKills > scoreArray[i].kills) { // check if kills are greater
				newScorePosition = i;
				i = numHighscores; // and exit the loop
			}
		}
	}
	
	
	
	if (newScorePosition < numHighscores+1) { // if the new score is high enough to be in the highscore list
		enteredName = false; // we need to bring the keyboard up in the main loop.
		for (i = numHighscores;i>=newScorePosition;i--) { // go from end of highscore to "Highscore" (8 -> 1)
			if (i == newScorePosition) { // if this is a new highscore
				PreviewLabs.PlayerPrefs.SetString("Highscore" + i + "name",BridgeJTOC.Bridge.highScoreName); // save preferences variable
				scoreArray[i].name = BridgeJTOC.Bridge.highScoreName;
				PreviewLabs.PlayerPrefs.SetInt("Highscore" + i + "rounds",BridgeJTOC.Bridge.scoreBridge);
				scoreArray[i].score = BridgeJTOC.Bridge.scoreBridge;
				PreviewLabs.PlayerPrefs.SetInt("Highscore" + i + "kills",BridgeJTOC.Bridge.killsBridge);
				scoreArray[i].kills = BridgeJTOC.Bridge.killsBridge;
				PreviewLabs.PlayerPrefs.SetInt("Highscore" + i + "gameID",ThisGameID);
				scoreArray[i].gameID = ThisGameID;
			} else {
				PreviewLabs.PlayerPrefs.SetString("Highscore" + i + "name",scoreArray[i-1].name); // take one up and put into current #
				PreviewLabs.PlayerPrefs.SetInt("Highscore" + i + "rounds",scoreArray[i-1].score);
				PreviewLabs.PlayerPrefs.SetInt("Highscore" + i + "kills",scoreArray[i-1].kills);
				PreviewLabs.PlayerPrefs.SetInt("Highscore" + i + "gameID",scoreArray[i-1].gameID);
			}
		}
	}
}
//	PreviewLabs.PlayerPrefs.Save();
*/