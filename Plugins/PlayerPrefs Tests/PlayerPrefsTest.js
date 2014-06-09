//import PreviewLabs.PlayerPrefs;

var summer:int = 1;
var started:boolean = false;


function StoreStuff () {
	started = true;
	for (var i:int=0;i<1000;i++) {
		var randomNum = Random.value * 10;
		PlayerPrefs.SetInt(i + "_rounds",randomNum);
	}
	
	for (i=0;i<1000;i++) {
		summer += PlayerPrefs.GetInt(i + "_rounds");
	}
	finished = true;
}

function Update() {
	if (!started && Time.time > 1) {
		StoreStuff ();
		started = true;
	}
}

var finished:boolean=false;
var firstRun:boolean=false;
var startTime:float = 0;
var endTime:float = 0;


function OnGUI () {
	if (started && !firstRun) {
		startTime = Time.time;
		firstRun = true;
	}
	
	GUI.Box(Rect(400,400,400,40),startTime.ToString());
	
	if (finished) {
		endTime = Time.time;
		finished = false;
	}
	
	GUI.Box(Rect(400,500,400,40),endTime.ToString() + " and " + summer);
}