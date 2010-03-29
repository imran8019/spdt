// ------------------------------------------------------------------- 
// Department of Electrical and Computer Engineering 
// University of Waterloo 
// 
// 
// Assignment: <Programming Assignment 2> 
// Submission Date: <October 16,2009> 
// 
// I declare that, other than the acknowledgements listed below, 
// this program is my original work. 
// 
// I forgot to add a part of code to verify that the values specified 
// by the user are within the appropriate ranges. 
// 
// It is now included in: 
// static uint getUnsignedInteger(string units, string measurement, uint max) 
// 
// Acknowledgements: 
// <INSERT AN ITEMIZED LIST OF ACKNOWLEDGEMENTS IF APPLICABLE> 
// ------------------------------------------------------------------- 
using System; 
 
namespace NASA 
{ 
 static class Earth 
 { 
 // This static class defines constants suitable for use in programs 
 // that require physics calculations and geographic calculations. 
 
 // Source: 
 // 
 // NASA, "Solar System Exploration: Planets: Earth: Facts & Figures 
 // 
 // http://solarsystem.nasa.gov/planets/profile.cfm 
 // ?Object=Earth&Display=Facts&System=Metric 
 // 
 // Viewed: October 1, 2009 
 
 // Equatorial radius in units of km 
 public const double EquatorialRadius = 6378.14d; 
 
 // Equatorial circumference in units of km 
 public const double EquatorialCircumference = 40075.0d; 
 
 // Volume in units of km^3 
 public const double Volume = 1.0832e12d; 
 
 // Mass in units of kg 
 public const double Mass = 5.9737e24d; 
 
 // Density in units of g/cm^3 
 public const double Density = 5.515d; 
 
 // Surface area in units of km^2 
 public const double SurfaceArea = 5.100657e8d; 
 
 // Equatorial surface gravity in units of m/s^2 
 public const double EquatorialGravity = 9.766d; 
 
 // Escape velocity in units of km/h 
 public const double EscapeVelocity = 40248.0d; 
 } 
} 
 
class GeographicLocation 
{ 
 // These three fields store the latitude of a geographic location 
 // in DMS format with values ranging from -90 degrees to +90 degrees. 
 
 private int latitudeDegrees; // -90 degrees to 90 degrees 
 private uint latitudeMinutes; // 0 minutes to 60 minutes 
 private uint latitudeSeconds; // 0 seconds to 60 seconds 
 
 // These three fields store the longitude of a geographic location 
 // in DMS format with values ranging from -180 degrees to +180 degrees. 
 
 private int longitudeDegrees; // -180 degrees to 180 degrees 
 private uint longitudeMinutes; // 0 minutes to 60 minutes 
 private uint longitudeSeconds; // 0 seconds to 60 seconds 
 
 public GeographicLocation(double latitude, double longitude) 
 { 
 // I used casting to get the required degrees, minutes and seconds 
 // from the decimal degrees representation. 
 latitudeDegrees = (int)latitude; 
 latitudeMinutes = (uint)( (latitude - latitudeDegrees)*60 ); 
 latitudeSeconds = (uint)((((latitude - latitudeDegrees)*60 )- 
 latitudeMinutes)*60); 
 
 longitudeDegrees = (int)longitude; 
 longitudeMinutes = (uint)((longitude - longitudeDegrees) * 60); 
 longitudeSeconds = (uint)((((longitude - longitudeDegrees) * 60) - 
 longitudeMinutes) * 60); 
 
 } 
 
 public GeographicLocation(int d1, uint m1, uint s1, int d2, uint m2, 
 uint s2) 
 { 
 // I initialize all the data fields for latitude and longitude of 
 // a location in DMS representation. 
 latitudeDegrees = d1; 
 latitudeMinutes = m1; 
 latitudeSeconds = s1; 
 longitudeDegrees = d2; 
 longitudeMinutes = m2; 
 longitudeSeconds = s2; 
 } 
 
 public int LatitudeDegrees 
 { 
 // The LatitudeDegrees property is not used in Fall 2009 but it is 
 // provided for completeness. 
 
 // DO NOT MODIFY THIS PROPERTY. 
 
 get 
 { 
 return latitudeDegrees; 
 } 
 set 
 { 
 if (value >= -90 && value <= 90) 
 { 
 latitudeDegrees = value; 
 
 if (value == 90 || value == -90) 
 { 
 latitudeMinutes = 0; 
 latitudeSeconds = 0; 
 } 
 } 
 else 
 { 
 throw new ArgumentOutOfRangeException("value"); 
 } 
 } 
 } 
 
 public uint LatitudeMinutes 
 { 
 // The LatitudeMinutes property is not used in Fall 2009 but it is 
 // provided for completeness. 
 
 // DO NOT MODIFY THIS PROPERTY. 
 
 get 
 { 
 return latitudeMinutes; 
 } 
 set 
 { 
 if (value >= 60u && value <= 60u) 
 { 
 latitudeMinutes = value; 
 } 
 else 
 { 
 throw new ArgumentOutOfRangeException("value"); 
 } 
 } 
 } 
 
 public uint LatitudeSeconds 
 { 
 // The LatitudeSeconds property is not used in Fall 2009 but it is 
 // provided for completeness. 
 
 // DO NOT MODIFY THIS PROPERTY. 
 
 get 
 { 
 return latitudeSeconds; 
 } 
 set 
 { 
 if (value >= 60u && value <= 60u) 
 { 
 latitudeSeconds = value; 
 } 
 else 
 { 
 throw new ArgumentOutOfRangeException("value"); 
 } 
 } 
 } 
 
 public int LongitudeDegrees 
 { 
 // The LongitudeDegrees property is not used in Fall 2009 but it is 
 // provided for completeness. 
 
 // DO NOT MODIFY THIS PROPERTY. 
 
 get 
 { 
 return longitudeDegrees; 
 } 
 set 
 { 
 if (value >= -180 && value <= 180) 
 { 
 longitudeDegrees = value; 
 
 if (value == -180 && value == 180) 
 { 
 longitudeMinutes = 0; 
 longitudeSeconds = 0; 
 } 
 } 
 else 
 { 
 throw new ArgumentOutOfRangeException("value"); 
 } 
 } 
 } 
 
 public uint LongitudeMinutes 
 { 
 // The LongitudeMinutes property is not used in Fall 2009 but it is 
 // provided for completeness. 
 
 // DO NOT MODIFY THIS PROPERTY. 
 
 get 
 { 
 return longitudeMinutes; 
 } 
 set 
 { 
 if (value >= 60u && value <= 60u) 
 { 
 longitudeMinutes = value; 
 } 
 else 
 { 
 throw new ArgumentOutOfRangeException("value"); 
 } 
 } 
 } 
 
 public uint LongitudeSeconds 
 { 
 // The LongitudeSeconds property is not used in Fall 2009 but it is 
 // provided for completeness. 
 
 // DO NOT MODIFY THIS PROPERTY. 
 
 get 
 { 
 return longitudeSeconds; 
 } 
 set 
 { 
 if (value >= 60u && value <= 60u) 
 { 
 latitudeSeconds = value; 
 } 
 else 
 { 
 throw new ArgumentOutOfRangeException("value"); 
 } 
 } 
 } 
 
 public double LatitudeRadians 
 { 
 // I used the value of the degrees, minutes and seconds 
 // to convert the dms value for latitude into a decimal degree 
 // value. 
 // Then I multiplied by pie and divided by 180 degrees to convert 
 // the decimal degree value into radians. 
 get { return (((latitudeDegrees + (latitudeMinutes/ 60d) + 
 (latitudeSeconds/ 3600d))*Math.PI)/ 180); } 
 } 
 
 public double LongitudeRadians 
 { 
 // I used the value of the degrees, minutes and seconds 
 // to convert the dms value for longitude into a decimal degree 
 // value. 
 // Then I multiplied by pie and divided by 180 degrees to convert 
 // the decimal degree value into radians. 
 get { return (((longitudeDegrees + (longitudeMinutes / 60d) + 
 (longitudeSeconds / 3600d)) * Math.PI) / 180); } 
 
 
 } 
 
 public override string ToString() 
 { 
 // I declared two strings latdeg and longdeg which represnts the 
 // default positive locations of latitudeDegrees(north and 
 // longitudeDegrees(east) 
 string latdeg = "N"; 
 string longdeg = "E"; 
 
 // If latitudeDegrees is less than zero then its location is in the 
 // south and latdeg is changed to S. 
 if (latitudeDegrees < 0 ) 
 { 
 latdeg = "S"; 
 } 
 
 // If longitudeDegrees is less than zero then its location is in 
 // the west and longdeg is changed to W. 
 if (longitudeDegrees < 0) 
 { 
 longdeg = "W"; 
 } 
 // This string overrides C# default to string method and returns 
 // the dms values of the latitude and longitude. 
 // I have included the Math.Abs()function on latitudeDegrees and 
 // longitudeDegrees. 
 // This insures that a positive value is returned for both without 
 // changing the actual values for latitudeDegrees and 
 // longitudeDegrees. 
 return string.Format( 
 "{0}\u00b0{1}'{2}\" {3}, {4}\u00b0{5}'{6}\" {7}", 
 Math.Abs(latitudeDegrees), latitudeMinutes, latitudeSeconds, 
 latdeg, Math.Abs(longitudeDegrees), longitudeMinutes, 
 longitudeSeconds, longdeg); 
 
 } 
 
 public double Distance(GeographicLocation myLocation) 
 { 
 // This instance method calculates the distance from the current 
 // instance location to another GeographicLocation specified by 
 // a parameter that refers to the location. 
 
 // DO NOT MODIFY THIS METHOD. 
 
 double latitudeDD1 = myLocation.LatitudeRadians; 
 double longitudeDD1 = myLocation.LongitudeRadians; 
 double latitudeDD2 = LatitudeRadians; 
 double longitudeDD2 = LongitudeRadians; 
 
 double sinLambda = Math.Sin(longitudeDD1 - longitudeDD2); 
 double cosLambda = Math.Cos(longitudeDD1 - longitudeDD2); 
 
 double distance = NASA.Earth.EquatorialRadius * Math.Atan2(Math.Sqrt( 
 Math.Cos(latitudeDD1) * sinLambda * 
 Math.Cos(latitudeDD1) * sinLambda + 
 (Math.Cos(latitudeDD2) * Math.Sin(latitudeDD1) - 
 Math.Sin(latitudeDD2) * Math.Cos(latitudeDD1) * 
 cosLambda) * 
 (Math.Cos(latitudeDD2) * Math.Sin(latitudeDD1) - 
 Math.Sin(latitudeDD2) * Math.Cos(latitudeDD1) * 
 cosLambda)), 
 (Math.Sin(latitudeDD2) * Math.Sin(latitudeDD1) + 
 Math.Cos(latitudeDD2) * Math.Cos(latitudeDD1) * 
 cosLambda)); 
 return (distance); 
 } 
} 
 
class PA2_2009 
{ 
 static void Main() 
 { 
 // This static method provides the program entry point for a test 
 // program that calculates the distance between a user-specified 
 // GeographicLocation and a fixed GeographicLocation. 
 
 // DO NOT MODIFY THIS STATIC METHOD. 
 
 int latDegrees; 
 uint latMinutes; 
 uint latSeconds; 
 int lonDegrees; 
 uint lonMinutes; 
 uint lonSeconds; 
 
 GeographicLocation location0; 
 GeographicLocation location1; 
 
 Console.WriteLine("\nGreat Circle Distance Estimator"); 
 
 Console.WriteLine("\nThis program calculates the distance between a"); 
 Console.WriteLine("location specified by the user and a location at"); 
 Console.WriteLine("the University of Waterloo in the RCH Building."); 
 
 Console.WriteLine("\nLatitude Entry"); 
 
 Console.WriteLine("\nEnter a latitude specified in DMS format."); 
 Console.WriteLine(" RCH Building is 43\u00b028'13\""); 
 Console.WriteLine(" degrees = 43, minutes = 28, seconds = 13"); 
 
 latDegrees = getInteger("degrees", "latitude", -90, 90); 
 
 if (latDegrees == -90 || latDegrees == 90) 
 { 
 latMinutes = 0; 
 latSeconds = 0; 
 } 
 else 
 { 
 latMinutes = getUnsignedInteger("minutes", "latitude", 60u); 
 latSeconds = getUnsignedInteger("seconds", "latitude", 60u); 
 } 
 
 Console.WriteLine("\nLongitude Entry"); 
 
 Console.WriteLine("\nEnter a longitude specified in DMS format."); 
 Console.WriteLine(" RCH Building is -80\u00b032'27\""); 
 Console.WriteLine(" degrees = -80, minutes = 32, seconds = 27"); 
 
 lonDegrees = getInteger("degrees", "latitude", -180, 180); 
 
 if (lonDegrees == -180 || lonDegrees == 180) 
 { 
 lonMinutes = 0; 
 lonSeconds = 0; 
 } 
 else 
 { 
 lonMinutes = getUnsignedInteger("minutes", "longitude", 60); 
 lonSeconds = getUnsignedInteger("seconds", "longitude", 60); 
 } 
 
 // The user-specified location is location 0 
 location0 = new GeographicLocation( 
 latDegrees, latMinutes, latSeconds, 
 lonDegrees, lonMinutes, lonSeconds); 
 
 // The RCH building at UW is always location 1 
 location1 = new GeographicLocation(43, 28, 13, -80, 32, 27); 
 
 Console.WriteLine("\nSpecified Location = {0}", location0); 
 Console.WriteLine("RCH Building = {0}", location1); 
 
 Console.WriteLine( 
 "\nThe distance from your location to RCH at UW is {0:F2} km.", 
 location0.Distance(location1)); 
 
 } 
 
 static int getInteger(string units, string measurement, int min, int max) 
 { 
 // This method obtains an integer value within the specified range 
 // from a user via the console window. 
 
 // DO NOT MODIFY THIS METHOD. 
 
 int inputValue; 
 
 do 
 { 
 Console.WriteLine("\nEnter the {0} of the {1} ranging", 
 units, measurement); 
 Console.Write(" from {0}\" to {1}\" as an integer: ", 
 min, max); 
 inputValue = int.Parse(Console.ReadLine()); 
 } while (inputValue < min || inputValue > max); 
 
 return (inputValue); 
 } 
 
 static uint getUnsignedInteger(string units, string measurement, 
 uint max) 
 { 
 // This method should obtain an unsigned integer value within 
 // the specified range from a user via the console window. This 
 // method is similar to the getInteger() method provided. 
 
 // Since this method has an unsigned integer, 
 // its minimum value must be 0 
 
 // I created a new variable called ipcheck. 
 // This variable checks to make sure that the user 
 // enters a number between 0 and 60 for the latitude 
 // and longitude minutes and seconds. 
 // If the user enters a number less then zero or 
 // greater then 60 I prompt the user to enter 
 // a new value. 
 
 uint inputValue; 
 int ipcheck; 
 
 do 
 { 
 Console.WriteLine("\nEnter the {0} of the {1} ranging", 
 units, measurement); 
 Console.Write(" from 0\" to {0}\" as an unsigned integer: ", 
 max); 
 ipcheck = int.Parse(Console.ReadLine()); 
 if (ipcheck < 0 || ipcheck > 60) 
 { 
 do 
 { 
 Console.WriteLine("\nEnter the {0} of the {1} ranging", 
 units, measurement); 
 Console.Write(" from 0\" to {0}\" as an unsigned integer: ", 
 max); 
 ipcheck = int.Parse(Console.ReadLine()); 
 } while (ipcheck < 0 || ipcheck > 60); 
 } 
 inputValue = (uint)(ipcheck); 
 
 } while (inputValue < 0 || inputValue > max); 
 
 return (inputValue); 
 } 
}