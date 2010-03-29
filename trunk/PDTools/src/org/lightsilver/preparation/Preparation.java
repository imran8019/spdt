package org.lightsilver.preparation;

import java.io.FileOutputStream;
import java.io.IOException;
import java.io.OutputStreamWriter;
import java.io.Writer;
import java.util.ArrayList;
import java.util.Collections;

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
		//ArrayList<Integer> removal = new ArrayList<Integer>();
		for(int i = 0; i < ASS.size(); i++) 
		{
			//for each submission, check it with the start. check(submission, start[line])
			int firstIdentical = lc.check(submissions.get(index).getLines(), ASS.get(i));
			if (firstIdentical < 0)
				continue;
			String starti = ASS.get(i);
			if(starti.trim().replaceAll(" +", " ").startsWith("//"))
			{
				//System.out.println("fileid="+index+"fId="+firstIdentical+"I="+i+"starti="+ASS.get(i));

			//	System.out.println("to be removed="+submissions.get(index).getLines().get(firstIdentical));
			//	if(!removal.contains(firstIdentical))
					//removal.add(firstIdentical);//submissions.get(index).getLines().remove(firstIdentical);
			}
		}
		//Collections.sort(removal);
		//for(int i:removal)
		//{
			//System.out.print(i+"#");
		//}
		//submissions.get(index).removeMulLines(removal);
		//for (String k:submissions.get(index).getLines())
		//{
			//System.out.println("#@"+k);
		//}
	}
	
	Preparation() throws IOException
	{
		config.read();
		startFile();
		int AssignmentID = config.getInt("AssignmentID", 2);
		int FileNum = config.getInt("FileNum", 25);
		String pa = config.get("RSM");
		boolean rsm_flag = config.get("RSM_FLAG").equals("1") ? true : false;
		System.out.println(config.get("RSM")+config.get("RSM_FLAG")+rsm_flag);
		//while(true){if(2>3)break;}
		String[] names = new String[FileNum];
		FileOutputStream fos = new FileOutputStream("rsm.bat");   
		Writer out = new OutputStreamWriter(fos, "utf-8");
		if(rsm_flag)
			out.write("@echo off\nset RSM_HOME=C:\\Program Files\\MSquared\\M2 RSM\\\nset EXE_RSM=\"%RSM_HOME%\"\\rsm.exe\n");
		for(int i = 1; i <= FileNum; i++)
		{
			String tmp = "pa" + String.valueOf(AssignmentID) + "_"
							  + String.valueOf(i / 100)
							  + String.valueOf((i % 100 - i % 10) / 10)
							  + String.valueOf(i % 10) + ".cs";
			names[i - 1] = tmp;
			String argv = pa.replace("%", tmp);
			
			if(rsm_flag)
				out.write("%EXE_RSM% " + argv + "\n");   

			//System.out.println("file:" + names[i - 1]);
			readFiles(config.get("Path", "samples/") + names[i - 1]);
			deal(i - 1);
		}
		out.close();   
		fos.close();  
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
