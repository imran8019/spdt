/**
 * 
 */
package org.lightsilver.utils;

import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStreamWriter;
import java.io.Writer;
import java.util.Iterator;
import java.util.List;

import org.dom4j.Attribute;
import org.dom4j.Document;
import org.dom4j.DocumentException;
import org.dom4j.DocumentHelper;
import org.dom4j.Element;
import org.dom4j.Node;
import org.dom4j.VisitorSupport;
import org.dom4j.io.OutputFormat;
import org.dom4j.io.SAXReader;
import org.dom4j.io.XMLWriter;
import org.xml.sax.EntityResolver;
import org.xml.sax.InputSource;
import org.xml.sax.SAXException;
/**
 * @author lightsilver
 *
 */
public class XMLTest {

	/**
	 * @Title: main
	 * @Description: TODO(这里用一句话描述这个方法的作用)
	 * @param @param args    设定文件
	 * @return void    返回类型
	 */
	Document doc = null;

	
	public Document loadXML(String xmlfile)
    throws FileNotFoundException, DocumentException{
    SAXReader reader = new SAXReader();
    doc = reader.read(new FileInputStream(xmlfile));
    return doc;
}

public void printDoc(Document doc) throws IOException {
	Writer out = new OutputStreamWriter(System.out,"gb2312");
    OutputFormat format = OutputFormat.createPrettyPrint();
    XMLWriter writer = new XMLWriter(out, format);
    writer.write(this.doc);
    out.flush();
 }

public class MyVisitor extends VisitorSupport {
    public void visit(Element element){
        System.out.println("#"+element.getName());
    }
    public void visit(Attribute attr){
        System.out.println("@"+attr.getName());
    }
 }

public void treeWalk() {
    treeWalk(doc.getRootElement());
 }
 public void treeWalk(Element element) {
    for (int i = 0, size = element.nodeCount(); i < size; i++)     {
        Node node = element.node(i);
        if (node instanceof Element) {
           System.out.println(node.getName() + "@" + node.getText());
           treeWalk((Element) node);
        } else { // do something....
        }
    }
}
 public void bar(Document document) {
     List list = document.selectNodes( "/ms2rsm/report" );
     Node node = document.selectSingleNode("/m2rsm/report/total_all_function_analysis");
     System.out.println(list);
     System.out.println(node);
     String name = node.valueOf( "name" );
     String name2 = node.valueOf( "function_count" );
     String name3 = node.valueOf( "name" );
     System.out.println(name+"#"+name2);
  }

	public XMLTest() throws DocumentException, IOException, SAXException {
	      Document doc = loadXML("RSM/pa2_001.cs.xml"); //载入XML文档
	      //System.out.println(doc.asXML()+"\n\n\n\n\n\n\n\n\n#########");
			//Element root = doc.getRootElement();
			//treeWalk();
			bar(doc);
//			for ( Iterator i = root.elementIterator(); i.hasNext(); ) {
//			       Element element = (Element) i.next();
//			       //System.out.println("!"+element.getName());
//			       String var = element.getStringValue();
//			       //System.out.println(var.toString());
//			       // do something
//			}
			/*for ( Iterator i = root.attributeIterator(); i.hasNext(); ) {
			       Attribute attribute = (Attribute) i.next();
			       System.out.println("#Attr="+attribute.asXML());
			       // do something
			}*/
			//root.accept(new MyVisitor());
			//MyVisitor v = new MyVisitor();
			//v.visit(root);
	      //printDoc(doc); //打印XML文档
	  }
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		try {
			new XMLTest();
		} catch (FileNotFoundException e) {
			e.printStackTrace();
		} catch (DocumentException e) {
			e.printStackTrace();
		} catch (IOException e) {
			e.printStackTrace();
		} catch (SAXException e) {
			e.printStackTrace();
		}
	}

}
