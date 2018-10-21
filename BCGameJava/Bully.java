package game;

import java.util.*;


public class Bully {
	
	String target;
	public void dic() {
	Map<Integer,String> dictionary=new HashMap<Integer,String>();
	dictionary.put(0,"brick");
	dictionary.put(1,"blind");
	dictionary.put(2,"sample");
	dictionary.put(3,"simple");
	dictionary.put(4,"world");
	dictionary.put(5,"winter" );
	dictionary.put(6,"hope");
	dictionary.put(7,"computer");
	dictionary.put(8,"flight");
	dictionary.put(9,"break");
	dictionary.put(10,"pocket");
	dictionary.put(11,"dinosaur");
	dictionary.put(12,"lucky");
	dictionary.put(13,"police");
	dictionary.put(14,"planet");
	dictionary.put(15,"slip");
	
	int rand=(int)(Math.random()*dictionary.size());
	target=dictionary.get(rand);
	
	
	
	}

	}