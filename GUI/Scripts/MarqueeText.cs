using UnityEngine;
using System.Collections;

[RequireComponent (typeof (GUIText))]
public class MarqueeText : MonoBehaviour {


		string message = "Scrolling... Check me out";
		public bool leftToRight = true;
		public bool rightToLeft = false;
		public bool upward = false;
		public bool downward = false;
		public float xScrollSpeed = 50;
		private float xPosition	= 0;
		public float yScrollSpeed = 0;
		private float yPosition	= 0;
		public GUIText outputText;
		
		
		Rect messageRect;
		
		
		void OnGUI ()
		{
			//this sets the size of the text (width and height) into the dimensions variable
			Vector2 dimensions = GUI.skin.label.CalcSize(new GUIContent(message));
			
			//sets the size of the rectangle that the text is printed on
			//helpful to have accurate scrolling off screen
			messageRect.width  =  dimensions.x;
			messageRect.height =  dimensions.y;
			
			//limits these events to every frame. Otherwise, the scrolling text will speed up with any input
			if (Event.current.type == EventType.Repaint)
			{
				//This sets the string to the text of the GUIText
				outputText.text = message;
				
				//This increments the positions	accordingly
				scrollingText();
				
				//This sets the positions changed by the scrollingText() function to the offset pixel values
				outputText.pixelOffset = new Vector2(xPosition, yPosition);
				
				//this functions checks to see if the text has gone past the screen
				//if it has, then it resets it
				reset();
			}
		}	
		
		
		void scrollingText()
		{		
			if(leftToRight == true)
				xPosition += -2*(xScrollSpeed/100);
			if(rightToLeft == true)
				xPosition += 2*(xScrollSpeed/100);
			if(downward == true)
				yPosition += -2*(yScrollSpeed/100);
			if(upward == true)
				yPosition += 2*(yScrollSpeed/100);
		}
		
		
		void reset()
		{
			// If the message has moved past the right side, move it back to the left
			if (xPosition > 0) 
				xPosition = -Screen.width - messageRect.width;
			if(xPosition < -Screen.width - messageRect.width)
				xPosition = 0;
			if (yPosition > Screen.height + messageRect.height)
				yPosition = 0 + -messageRect.height;
			if (yPosition < -messageRect.height)
				yPosition = Screen.height + messageRect.height;
		}

}
