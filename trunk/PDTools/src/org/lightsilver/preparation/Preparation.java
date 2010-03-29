package org.lightsilver.preparation;

import java.io.IOException;
import java.util.ArrayList;

import org.lightsilver.utils.ConfigureFile;
import org.lightsilver.utils.LineComparator;
import org.lightsilver.entity.Submission;

public class Preparation {

	private ArrayList<Submission> submissions = new ArrayList<Submission>();
	private Submission start = null;
	ConfigureFile config = new ConfigureFile("config.ini");


	private void readFiles(String filename) throws IOException
	{
		submissions.add(new Submission(filename));
	}
	private void startFile() throws IOException
	{
		start = new Submission(config.get("Start", "samples/pa2-2009-sp.cs"));
	}
	
	private void deal(int index)
	{
		LineComparator lc = LineComparator.getCom();
		ArrayList<String> ASS = start.getLines();
		for(int i = 0; i < ASS.size(); i++) 
		{
			lc.check(submissions.get(index).getLines(), ASS.get(i));
		}
	}
	
	Preparation() throws IOException
	{
		config.read();
		startFile();
		int AssignmentID = config.getInt("AssignmentID", 2);
		int FileNum = config.getInt("FileNum", 25);
		String[] names = new String[FileNum];
		for(int i = 1; i <= FileNum; i++)
		{
			String tmp = "pa" + String.valueOf(AssignmentID) + "_"
							  + String.valueOf(i / 100)
							  + String.valueOf((i % 100 - i % 10) / 10)
							  + String.valueOf(i % 10) + ".cs";
			names[i - 1] = tmp;
			System.out.println("file:" + names[i - 1]);
			readFiles(config.get("Path", "samples/") + names[i - 1]);
			deal(i - 1);
		}
	}
	/**
	 * @Title: main
	 * @Description: TODO(这里用一句话描述这个方法的作用)
	 * @param @param args    设定文件
	 * @return void    返回类型
	 * @throws IOException 
	 * @throws IOException 
	 */
	public static void main(String[] args) throws IOException {
		// TODO Auto-generated method stub
		Preparation p = new Preparation();
		
	}

}
