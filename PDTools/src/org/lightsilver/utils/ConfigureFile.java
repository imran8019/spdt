/**
 * 
 */
package org.lightsilver.utils;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.util.HashMap;

/**
 * Represent the config file.  A config file is a plain text file which contains multiple lines of "variables" as below:
<blockquote>
<pre>
name = Johnson McDonald
age = 16
</pre>
</blockquote>
 * 
 * @author lightsilver
 * @version 1.1
 *
 */
public class ConfigureFile {
	private File file;
	private HashMap<String,String> map = new HashMap<String,String>();

	/**
	 * 
	 * @param fileName the file name of the config file
	 */
	public ConfigureFile(String fileName) { 
		this(new File(fileName)); 
	}
	
	public ConfigureFile(File cfgFile) {
		file = cfgFile;
	}

	/**
	 * Reads the config file in.
	 * @throws IOException
	 */
	public void read() throws IOException {
		BufferedReader in = new BufferedReader(
				new InputStreamReader(
						new FileInputStream(file)));
		String line;
		while ((line = in.readLine()) != null ) {
			int idx = line.indexOf('=');
			if ( idx ==-1 ) continue;
			String key = line.substring(0, idx).trim();
			String value = line.substring(idx+1).trim();
			map.put(key, value);
		}
		in.close();
	}
	
	/**
	 * Writes the config into the file.
	 * @throws IOException
	 */
	public void write() throws IOException {
		BufferedWriter out = new BufferedWriter(
				new OutputStreamWriter(
						new FileOutputStream(file)));
		out.write(toString());
		out.close();
	}
	
	/**
	 * Test if the configure file has the variable.
	 * @param key the variable to test.
	 * @return true if there is such a variable.
	 */
	public final boolean has(String key) { return map.containsKey(key); }
	
	/**
	 * Returns the value of the variable. 
	 * @param key the name of the variable
	 * @return the value of the variable, null if no such variable exits.
	 */
	public final String get(String key) { return map.get(key); }
	
	/**
	 * Returns the value of the variable or the inputed value if there's no such variable.
	 * @param key the name of the variable.
	 * @param value the alternative value of the variable.
	 * @return the value of the variable, <code>value</code> if no such variable exits.
	 */
	public String get(String key, String value) { 
		if ( has(key) )
			return map.get(key);
		else
			return value;
	}
	
	/**
	 * Returns the value of the variable or the inputed value if there's no such variable.
	 * @param key the name of the variable.
	 * @param value the alternative value of the variable.
	 * @return the value of the variable, <code>value</code> if no such variable exits.
	 */
	public int getInt(String key, int value) {
		int ret = value;
		if ( has(key) ) {
			try {
				ret = Integer.parseInt(map.get(key));
			} catch (NumberFormatException e) {
				ret = value; 
			}
		}
		return ret;
	}
	
	/**
	 * Sets the value of the key (variable).
	 * If the key exits, replace the value stored, otherwise a new varibale is to be stored.
	 * @param key the name of the varibale
	 * @param value the value of the variable
	 * @return the stored value, or null if not exits
	 */
	public final String set(String key, String value) {
		return map.put(key, value);
	}
	
	public String toString() {
		StringBuffer sb = new StringBuffer();
		for ( String key : map.keySet() ) {
			sb.append(key+" = "+map.get(key)+"\n");
		}
		return sb.toString();
	}
	
	/**
	 * used to test the class.
	 * @param args
	 * @throws IOException 
	 */
	public static void main(String[] args) throws IOException {
		ConfigureFile config = new ConfigureFile("config.ini");
		config.read();
		System.out.println(config.toString());
	}

}
