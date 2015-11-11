using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour {
	
	public void PlayGame(){
		Application.LoadLevel ("IslandMain");
	}
	public void ExitGame(){
		Application.Quit ();
	}
	
}
