using System;
using System.Collections.Generic;

public class CubeTracker{

	private float x;
	private float y;
	private float z;
	private bool gone;

	public CubeTracker(String name,float x, float z,float y){
		this.x = x;
		this.y = y;
		this.z = z;
	}

	public float getX(){
		return x;
	}

	public float getY(){
		return y;
	}
	public float getZ(){
		return z;
	}
	public void setCube(bool gone){
		this.gone = gone;
	}

	public bool getCube(){
		return gone;
	}
	public void getName(){
			
	}
}
