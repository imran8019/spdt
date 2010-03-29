
package org.lightsilver.utils;

import java.util.ArrayList;

/**
 * @author lightsilver
 *
 */
public class LineComparator {
	private static final LineComparator thisCom = new LineComparator();
	private static final double threshold = 0.9F;
	
	private LineComparator() {}
	
	public static LineComparator getCom() { System.out.println(thisCom); return thisCom; }

	private boolean isSame(String src, String ass)
	{
		String src2 = src.trim();
		String ass2 = ass.trim();
		int len = src2.length() < ass2.length() ? src2.length() : ass2.length();
		int cnt = 0;
		for (int i = 0; i < len; i++)
		{
			if(src2.charAt(i) == ass2.charAt(i))
				cnt++;
		}
		System.out.println(cnt + "#" + len);
		return (cnt >= (threshold * len));
	}
	public int check(ArrayList<String> arrayList, String ass)
	{
		int linenum = -1;
		//case 1, src starts w/ // -> removed
		for (int i = 0; i < arrayList.size(); i++)
		{
			if(isSame(arrayList.get(i), ass) == true)
			{
				linenum = i;	
				break;
			}
		}
		//case 2, src is a function line -> keep
		System.out.println("src[" + linenum + "]=" + arrayList.get(linenum) + ", ass=" + ass);
		//case 3, src is provided -> removed 
		return linenum;
	}


	/**
	 * @Title: main
	 * @Description: TODO(这里用一句话描述这个方法的作用)
	 * @param @param args    设定文件
	 * @return void    返回类型
	 */
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		LineComparator lc = LineComparator.getCom();
		System.out.println(lc.isSame("//  add", "      //        add "));

	}

}
