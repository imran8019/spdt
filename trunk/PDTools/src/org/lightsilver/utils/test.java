package org.lightsilver.utils;

import java.io.IOException;
import java.util.ArrayList;

public class test {

	/**
	 * @Title: main
	 * @Description: TODO(这里用一句话描述这个方法的作用)
	 * @param @param args    设定文件
	 * @return void    返回类型
	 */
	public String[] a;
	
	public static void main(String[] args) throws IOException {
		// TODO Auto-generated method stub
		test t = new test();
		System.out.println(123);//t.gogo(12));
	}

	public void removeMulLines(ArrayList<Integer> removal, ArrayList<Integer> Ori)
	{
		int count = 0;
		for(int i : removal)
		{
			Ori.remove(i - count);
			count += 1;
		}
	}
	public int gogo(int as) throws IOException
	{
		//ConfigureFile config = new ConfigureFile("config.ini");

		//config.read();
		//String argv = config.get("RSM").replace("%", "001");
		a = new String[2];
		a[0] = "1";
		a[1] = "2";
		try 
		{ 
			//System.out.println(argv);
//			Runtime.getRuntime().exec("cmd /c start pause");// + argv);
			Runtime.getRuntime().exec("cmd /c start rsm.bat");
			
					//start excel \"" + 
					//path + "\""); 
		} 
		catch (IOException e) { e.printStackTrace(); } 
		
		
		/*//Collection c = new Collection();// = new Collection<Integer>();
		//c.add(1);
		//c.add(2);
		ArrayList<Integer> bla = new ArrayList<Integer>();
		ArrayList<Integer> rem = new ArrayList<Integer>();
		rem.add(0);
		rem.add(2);
		//bla.removeAll(c);
		bla.add(3);
		bla.add(4);
		bla.add(5);
		bla.add(6);
		removeMulLines(rem,bla);
		//bla.removeAll(rem);
		System.out.println(bla.get(0));
		System.out.println(bla.get(1));
		System.out.println(bla.get(2));
		System.out.println(bla.get(3));*/
		return 123;
	}
}
