package org.lightsilver.entity;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;

public class Submission {

	private ArrayList<String> lines;
	
	public ArrayList<String> getLines() {
		return lines;
	}
	
	public Submission(String file) throws IOException
	{
		lines = new ArrayList<String>();
		FileReader reader = new FileReader(file);
	    BufferedReader br = new BufferedReader(reader); 
	    String s1 = null;
	    while((s1 = br.readLine()) != null) {   
	    	System.out.println("IN FILE" + file + ": " + s1);
	    	lines.add(s1);
	    }
	}
	
	
}
