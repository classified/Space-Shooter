



function Update () {
	
	if(transform.position.x <= -3.2f)
	{
		transform.position.x = -3.2f;
	}
	if(transform.position.x >= 3.2f)
	{
		transform.position.x = 3.2f;
	}
	if(transform.position.z <= -4.0f)
	{
		transform.position.z = -4.0f;
	}
	if(transform.position.z >= 6f)
	{
		transform.position.z = 6f;
	}


}