package org.lightsilver.utils;


//import org.dom4j.io.SAXReader;
import org.jdom.*;
import org.jdom.input.*;
import org.xml.sax.SAXException;

import java.io.*;
import java.util.*;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;
/**
 * <p>
 * Description:本类实现对XML的解析操作
 * </p>
 * <p>
 * Copyright: Copyright (c) 2007
 * </p>
 * <p>
 * Company:QC
 * </p>
 * 
 * @author yexb
 * @version v1.0
 */

public class XMLTest2 {

	public XMLTest2(){
		//构造函数
	}
	Document doc = null;
	
	/**
	 * 解析XML到HashMap
	 * 
	 * @param xml
	 *            String:传入的XML
	 * @param map
	 *            HashMap：解析后的MAP
	 * @return HashMap
	 * @throws JDOMException 
	 * @throws IOException 
	 * @throws ParserConfigurationException 
	 * @throws SAXException 
	 */
	
	public HashMap XMLToMap(String xml,HashMap<String,String> map) throws JDOMException, IOException, SAXException, ParserConfigurationException {
		if(map==null){
			map = new HashMap<String, String>();
		}
		Document doc = (Document) DocumentBuilderFactory.newInstance().newDocumentBuilder().parse( 
				new ByteArrayInputStream(xml.getBytes()));
		//InputStream in = new ByteArrayInputStream(xml.getBytes("utf-8"));
		//SAXBuilder builder = new SAXBuilder();
		//Document doc = builder.build(in);
		Element root = (Element) doc.getRootElement();
		boolean tag = elementToMap(root.getChildren(),map);
		if(!tag){
			map.clear();
		}
		return map;
	}

	 /**
	 * 把XML的内容的节点取出，转换成 Name = Value (键值对)的形式
	 */
	private boolean elementToMap(List list, HashMap<String, String> map) {
		for (int i = 0; i < list.size(); i++) {
			Element emt = (Element) list.get(i);
			if (emt.getTextTrim() != null && emt.getTextTrim().length() > 0) {
				map.put(emt.getName(), emt.getTextTrim());
			}
			List listChildern = emt.getChildren();
			if (listChildern.size() > 0) {
				elementToMap(listChildern, map);
			}
		}
		return true;
	}
	
	/**
	 * 转换XML属性值到HashMap
	 * 
	 * @param xml
	 *            String:传入的XML
	 * @param map
	 *            HashMap：解析后的MAP
	 * @return HashMap
	 * @throws JDOMException 
	 * @throws IOException 
	 */
	public HashMap xmlAttributeToMap(String xml , HashMap<String,String> map) throws JDOMException, IOException{
		if(map==null){
			map = new HashMap<String, String>();
		}
		InputStream in = new ByteArrayInputStream(xml.getBytes("utf-8"));
		SAXBuilder builder = new SAXBuilder();
		Document doc = builder.build(in);
		Element root = doc.getRootElement();
		boolean tag = attributeElementToMap(root.getChildren(),map);
		if(!tag){
			map.clear();
		}
		return map;
	}
	/**
	 * 把XML的内容节点取出，转换成 ParentName.SelfName = Value 的形式
	 */
	public boolean attributeElementToMap(List list , HashMap<String, String> map){
			for (int i = 0; i < list.size(); i++) {
				Element e = (Element) list.get(i);
				List l_att = e.getAttributes();
				for (int t = 0; t < l_att.size(); t++) {
					Attribute attribute = (Attribute) l_att.get(t);
					String name = attribute.getName();
					String value = attribute.getValue();
					map.put(name, value);// 属性
				}
				java.util.List listChildern = e.getChildren();
				if (listChildern.size() > 0) {
					attributeElementToMap(listChildern, map);
				}
			}
			return true;
	}
	
	public static void main(String[] args) throws JDOMException, IOException, SAXException, ParserConfigurationException {
		// TODO Auto-generated method stub
		XMLTest2 test = new XMLTest2();
		//Document doc = test.loadXML("RSM/pa2_001.cs.xml");//.asXML();
		//System.out.println(doc);
		HashMap<String, String> hm = test.XMLToMap("RSM/pa2_001.cs.xml", null);
		for(int i = 0; i < hm.size(); i++)
		{
			System.out.println(hm.toString());
		}
	}
}