package org.lightsilver.utils;
import org.w3c.dom.*;
import org.dom4j.Document;
import org.dom4j.DocumentHelper;
import org.dom4j.Element;

//import org.apache.xerces.parsers.DOMParser;

public class XMLParser {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		try {
            DOMParser parser = new DOMParser();
            parser.parse(args[0]);
            Document doc = parser.getDocument();

            NodeList nodes = doc.getElementsByTagName("servlet");
            System.out.println("There are " + nodes.getLength() +                "  elements.");

        } catch (Exception ex) {
            System.out.println(ex);
        }
	}

}


