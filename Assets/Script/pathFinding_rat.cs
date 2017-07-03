using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathFinding_rat : MonoBehaviour {

	private Transform targetPath;

	private GameObject grid;

	public float vert = 0;

	public float speed = 5f;

	static int index = 0;

	int column = 3;

	int raw =3;

	private static List<GameObject> priority;

	Animator anim ;

	bool isRatRun = false;

	bool isRatIdeal = false;



	// Use this for initialization
	public void Start () {
		//initialize animator
		anim = GetComponent<Animator> ();


		grid = GameObject.Find ("Grid");

		//Set priority node list
		priority = new List<GameObject>();


		Node node = new Node (column, raw);
		List<Cell> nodes = node.genarate (1);

		gridGen (nodes,column,raw,5,1,5);

		getNextNode ();


		
	}

	void getNextNode(){
	
		anim.SetTrigger ("ideal");
		Vector3 vec = priority[0].transform.position-this.transform.localPosition;
		index = 0;
		float min = vec.magnitude;

		for (int x=1; x < priority.Count;x++) {
			Vector3 vec1 = priority[x].transform.position-this.transform.localPosition;
			Debug.Log (vec.magnitude+" "+vec1.magnitude+" "+min+" "+priority.Count);
			if (min>vec1.magnitude) {
				
				min = vec1.magnitude;

				index = x;
				//Debug.Log (index);
			}
		}
//		targetPath = grid.transform.GetChild (index);
//		index++;
	}

	// Update is called once per frame
	void Update () {


		anim.SetBool ("isRun", isRatRun);
		anim.SetBool ("isIdeal", isRatIdeal);
//		vert = Input.GetAxis ("Vertical");
//
////			animator.SetFloat ("rat_state", vert);
//			if (targetPath == null) {
//
//				getNextNode ();
//				if (targetPath == null) {
//
//				}
//			}
		if (Input.GetMouseButtonDown (0)) {
			isRatRun = true;
			isRatIdeal = false;
		}
		if (isRatRun) {
			
			ratRun ();
		}

		//priority[index].transform.localScale.z = priority [index].transform.localScale.z/2;

		

	}

	void ratRun(){
        Vector3 offset = new Vector3(2.5f, 0, 2.5f);
        Vector3 dir = priority[index].transform.position- this.transform.localPosition;
		dir.y = 0;


		float disThisFrame = speed * Time.deltaTime;

        //Debug.Log(dir.magnitude + " " + disThisFrame);
		if (dir.magnitude <= disThisFrame) {
			//reach the node
			//Debug.Log(index+" visited"); 
			priority.RemoveAt(index);
			getNextNode ();
        } else {
			//move towards node
            //Debug.Log(index+" " + dir.normalized);
//			transform.Translate (dir.normalized * disThisFrame);
//			ratRotation (dir);
			
			//Debug.DrawRay(transform.position, newDir, Color.red);
			
			transform.Translate (dir.normalized * disThisFrame);
			//transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (priority[index].transform.position), 1);
		}
	}

	void reachGoal(){
		Destroy (gameObject	);
	}

	void ratRotation(Vector3 di){
		
	}

//	public int[,] generateGrid() // POSSIBLE UPDATE:: WHEN RESETING GRID ROW, REMEMBER PREVIOUS ORDER TO AVOID SAME COMFLICTION TWICE
//	{
//		Random rand = new Random ();
//		ArrayList availableColumnNumbers = new ArrayList ();
//		ArrayList availableRowNumbers = new ArrayList ();
//		ArrayList availableNumbers = new ArrayList ();
//		int[,] grid = new int[_gridSize, _gridSize];
//
//		availableColumnNumbers = resetArrayList (); // create a list that holds the numbers 1 - Grid Size
//		availableRowNumbers = resetArrayList (); // create a list that holds the numbers 1 - Grid Size
//
//		for (int row = 0; row < _gridSize; row++) { // loop through rows
//			for (int column = 0; column < _gridSize; column++) { // loop through columns
//				if (row == 0) { // if row to be filled if the first row
//					int position = rand.Next (availableRowNumbers.Count); // Generate a random position
//					grid [row, column] = (int)availableRowNumbers [position]; // place available row numbers
//					availableRowNumbers.RemoveAt (position); // update available row numbers
//				} else { // row to be filled has constraints. Fill in, taking constraints into consideration
//					// update available column number, finds out what values are already in the column, and generates the only available values 
//					availableColumnNumbers = getAvailableColumnNumbers (grid, column);
//					// combine available Rows and Columns to get a list of available numbers for that cell
//					availableNumbers = getSimilarNumbers (availableRowNumbers, availableColumnNumbers);
//
//					if (availableNumbers.Count != 0) { // if there are available numbers to place,
//						int position = rand.Next (availableNumbers.Count);
//						grid [row, column] = (int)availableNumbers [position]; // place available number
//						availableRowNumbers.Remove ((int)availableNumbers [position]); // update available row numbers
//					} else { // Confliction: There are no available numbers (restart entire row)
//						grid = resetRow (grid, row); // reset the entire row where confliction occured
//						column = -1; // start again at begining of column
//						availableRowNumbers = resetArrayList (); // reset Array List
//					}
//				}
//			}
//			availableRowNumbers = resetArrayList ();// reset available row array
//		}
//		return grid;
//	}

	public void gridGen(List<Cell> list,int row, int col,float l,float w, float h){
	
		Vector3 size = new Vector3 (l,w,h);    //This is the size of our cube-grid. (5x1x5)


		for (int x = 0; x < row; x++)
		{
			for (int z = 0; z < col; z++)
				{
				if (list [x * col + z].getTrack () == true) {
					GameObject newRoom = GameObject.CreatePrimitive(PrimitiveType.Cube);
					newRoom.name = list [x * col + z].getIndex()+"";

					newRoom.transform.localScale = size;
					newRoom.transform.position = new Vector3(x * size.x, -1, z * size.z);
					newRoom.GetComponent<Renderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
					newRoom.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
					newRoom.transform.SetParent (grid.transform);
					priority.Add(newRoom);
					}
				}
			
		}
	}
}

