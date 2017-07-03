using System;
using System.Collections.Generic;

public class Node 
{
	private int col;
	private int raw;

	static List<Cell> list;

	private static int id = 0;


	public Node(int col,int raw){
		this.raw = raw;
		this.col = col;
		list = new List<Cell>();
	}

	public List<Cell> genarate(int dif){

		for (int y = 0; y < raw; y++)
		{
			for(int x = 0; x<col;x++){
				Cell cell = new Cell(x,y);
				list.Add(cell);

			}
		}
		Cell vist = new Cell(0,0);
		vist.setVisted(true);
		list.Add(vist);
		list[0].setVisted(true);
		id++;
		list [0].setIndex (id);
		bool condition = true;
		Cell visited = list[0];

		while (condition)
		{
			Cell next = neighbour(visited);
			if(next!=null){
				id++;
				next.setVisted(true);
				next.setIndex (id);
				visited = next;
			}
			else{
				condition = false;

			}
		}
//		for (int x = 0; x < dif; x++) {
//			Cell first = list [x];
//			bool con = first.getTrack();
//
//		}
		return list;
	}
	int index(int i , int j){
		Console.WriteLine(i+" "+j);
		if(i<0||j<0||i>col-1||j>raw-1){

			return list.Count-1;
		}
		return i + j*col;
	}
	private Cell neighbour(Cell c){
		Console.WriteLine (c.getVisited ());
		List<Cell> neighbours = new List<Cell>();
		Cell top = list[index(c.getI(),c.getJ()-1)];
		Cell right = list[index(c.getI()+1,c.getJ())];
		Cell bottom = list[index(c.getI(),c.getJ()+1)];
		Cell left = list[index(c.getI()-1,c.getJ())];
		Console.WriteLine("keep");
		if(!top.getVisited()){
			neighbours.Add(top);
			top.setVisted(true);
		}
		if(!right.getVisited()){
			neighbours.Add(right);
			right.setVisted(true);
		}
		if(!bottom.getVisited()){
			neighbours.Add(bottom);
			bottom.setVisted(true);
		}
		if(!left.getVisited()){
			neighbours.Add(left);
			left.setVisted(true);
		}
		if(neighbours.Count>0){
			Random rnd = new Random();
			int k = rnd.Next(0, 1000);
			int r = k%neighbours.Count;
			Console.WriteLine(r+" "+neighbours.Count);
			neighbours[r].setVisted(false);
			neighbours [r].setTracked (true);

			return neighbours[r];

		}
		else
		{
			Console.WriteLine(neighbours.Count+"null");
			return null;
		}

	}

}

public class Cell {
	private int i;
	private int j;
	private int row;
	private int col;
	private bool visited = false;
	private bool track = false;
	private int index = 0;

	public Cell(int i, int j){
		this.i = i;
		this.j = j;
	}
	public int getI(){
		return i;
	}

	public int getJ(){
		return j;
	}
	public bool getVisited(){
		return visited;
	}
	public void setVisted(bool var){
		visited = var;
	}
	public void setTracked(bool track){
		this.track = track;
	}
	public bool getTrack(){
		return track;
	}
	public void setIndex(int index){
		this.index = index;
	}
	public int getIndex(){
		return index;
	}

}

