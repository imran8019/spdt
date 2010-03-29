package org.lightsilver.utils;

public class test {

	/**
	 * @Title: main
	 * @Description: TODO(这里用一句话描述这个方法的作用)
	 * @param @param args    设定文件
	 * @return void    返回类型
	 */
	public String[] a;
	
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		test t = new test();
		System.out.println(t.gogo(12));
	}

	
	public int gogo(int as)
	{
		a = new String[2];
		a[0] = "1";
		a[1] = "2";
		return 123;
	}
}
