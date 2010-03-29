
package org.lightsilver.utils;

import java.util.ArrayList;

/**
 * @author lightsilver
 *
 */
public class LineComparator {
	private static final LineComparator thisCom = new LineComparator();
	private static final double threshold = 0.95F;
	
	private LineComparator() {}
	
	public static LineComparator getCom() { /*System.out.println(thisCom);*/ return thisCom; }

	
	private boolean isSame(String src, String ass)
	{
		String src2 = src.trim().replaceAll(" +", " ");
		String ass2 = ass.trim().replaceAll(" +", " ");	
		//System.out.println("src2="+src2);
		//System.out.println("ass2="+ass2);
		int len = src2.length() < ass2.length() ? -1 : ass2.length();
		if(len < 0) return false;
		if(src2.length() != ass2.length()) return false;
		int cnt = 0;
		for (int i = 0; i < len; i++)
		{
			if(src2.charAt(i) == ass2.charAt(i))
				cnt++;
		}
		//System.out.println(cnt + "#" + len);
		return (cnt >= (threshold * len));
	}
	/**
	 * Give input Sample and Assignment one line, pick the first identical
	 *  line number for the ass.
	 * @param arrayList
	 * @param ass
	 * @return
	 */
	public int check(ArrayList<String> arrayList, String ass)
	{
		//ArrayList<String> tmp = new ArrayList<String>(arrayList);
		int linenum = -1;
		//case 1, src starts w/ // -> removed
		int startline = 0;
		for (int i = 0; i < arrayList.size(); i++)
		{
//			i = startline+1;
			if(isSame(arrayList.get(i), ass) == true)
			{
				linenum = i;
				if(ass.trim().replaceAll(" +"," ").startsWith("//"))
					arrayList.remove(i);
//				startline = i;
				//System.out.println("src[" + linenum + "]=" + arrayList.get(linenum) + ", ass=" + ass);
				break;
			}
		}
		//case 2, src is a function line -> keep
		//case 3, src is provided -> removed 
		return linenum;
	}
	private void f(int a, ArrayList<String> weq)
	{
		ArrayList dq = new ArrayList<String>(weq);
		dq.add("67xsg");
		a = 0;
	}

	/**
	 * @Title: main
	 * @Description: TODO(这里用一句话描述这个方法的作用)
	 * @param @param args    设定文件
	 * @return void    返回类型
	 */
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		ArrayList<String> d = new ArrayList<String>();
		d.add("asfa");
		int dd = 3;
		LineComparator lc = LineComparator.getCom();
		lc.f(dd,d);
		System.out.println(d.get(0));
		System.out.println(d);		
		System.out.println(lc.isSame("//  add", "      //        add "));
		System.out.println(lc.isSame("// -------------------------------------------------------------------", "// "));

	}

}
