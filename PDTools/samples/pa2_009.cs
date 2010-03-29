// ------------------------------------------------------------------- 
// Department of Electrical and Computer Engineering 
// University of Waterloo 
// 
// 
// Assignment: <Assignment 2: Great Circle Distances> 
// Submission Date: <October 14, 2009> 
// 
// I declare that, other than the acknowledgements listed below, 
// this program is my original work. 
// 
// Acknowledgements: 
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
 // This constructor should initialize all data fields contained 
 // within an instance of a GeographicLocation object using the 
 // parameters provided. The parameter latitude represents the 
 // latitude of a location in decimal degrees format. The 
 // parameter longitude represents the longitude of a location 
 // in decimal degrees format. This method should not produce 
 // any console output. 
 
 // INSERT THE CODE FOR THIS CONSTRUCTOR HERE... 
 
 latitudeDegrees = (int)latitude; 
 // The integer part of the value of latitude 
 // is stored as an integer from -90 to 90, 
 // representing latitude degrees 
 latitudeMinutes = (uint)Math.Abs((latitude - latitudeDegrees) * 60); 
 // The absolute integer value of 60 times the decimal 
 // value of latitude substracted by latitude in 
 // integer degrees is stored as an unsigned integer 
 // from 0 to 60, representing latitude minutes 
 latitudeSeconds = (uint)(Math.Abs(((latitude - 
 latitudeDegrees) * 60 - latitudeMinutes) * 60)); 
 // The absolute integer value of 3600 times the 
 // decimal value of latitude subtracted by latitude in 
 // integer degrees and 60 times the minutes value of 
 // latitude is stored as an unsigned integer 
 // from 0 to 60, representing latitude seconds 
 longitudeDegrees = (int)longitude; 
 // The integer part of the value of longitude 
 // is stored as an integer from -180 to 180, 
 // representing longitude degrees 
 longitudeMinutes = (uint)Math.Abs((longitude - longitudeDegrees) * 60); 
 // The absolute integer value of 60 times the decimal 
 // value of longitude substracted by longitude in 
 // integer degrees is stored as an unsigned integer 
 // from 0 to 60, representing longitude minutes 
 longitudeSeconds = (uint)Math.Abs(((longitude - 
 longitudeDegrees) * 60 - longitudeMinutes) * 60); 
 // The absolute integer value of 3600 times the 
 // decimal value of longitude subtracted by longitude 
 // in integer degrees and 60 times the minutes value 
 // of longitude is stored as an unsigned integer 
 // from 0 to 60, representing longitude seconds 
 } 
 
 public GeographicLocation(int d1, uint m1, uint s1, int d2, uint m2, uint s2) 
 { 
 
 // This constructor should initialize all data fields contained 
 // within an instance of a GeographicLocation object using the 
 // parameters provided. The parameters (d1,m1,s1) represent the 
 // latitude of a location in DMS format. The parameters (d2,m2,s2) 
 // represent the longitude of a location in DMS format. This 
 // method should not produce any console output. 
 
 // INSERT THE CODE FOR THIS CONSTRUCTOR HERE... 
 
 // These three fields store the latitude of a geographic location 
 // in DMS format with values ranging from -90 degrees to +90 degrees. 
 
 latitudeDegrees = d1; // -90 degrees to 90 degrees 
 latitudeMinutes = m1; // 0 minutes to 60 minutes 
 latitudeSeconds = s1; // 0 seconds to 60 seconds 
 
 // These three fields store the longitude of a geographic location 
 // in DMS format with values ranging from -180 degrees to +180 degrees. 
 
 longitudeDegrees = d2; // -180 degrees to 180 degrees 
 longitudeMinutes = m2; // 0 minutes to 60 minutes 
 longitudeSeconds = s2; // 0 seconds to 60 seconds 
 } 
 
 public int LatitudeDegrees 
 { 
 // The LatitudeDegrees property is not used in Fall 2009 but it is provided 
 // for completeness. 
 
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
 // The LatitudeMinutes property is not used in Fall 2009 but it is provided 
 // for completeness. 
 
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
 // This property should return a decimal degrees representation 
 // of the latitude data fields contained within an instance of a 
 // GeographicLocation object. The value should be returned in units 
 // of radians. This property should not produce any console output. 
 
 // INSERT THE CODE FOR THIS PROPERTY HERE... 
 
 get 
 { 
 double latitudeRadians; 
 // this the latitude value in radians to be returned 
 
 if (latitudeDegrees < 0) 
 latitudeRadians = (latitudeDegrees - (latitudeMinutes/60.0) 
 - (latitudeSeconds/3600.0))*Math.PI/180.0; 
 // if the latitude value is negative, minutes and seconds must 
 // be subtracted rather than added to latitude degrees 
 else 
 latitudeRadians = (latitudeDegrees + (latitudeMinutes/60.0) 
 + (latitudeSeconds/3600.0))*Math.PI/180.0; 
 // this calculation transforms the DMS form of latitude into 
 // a real degree value, which is then converted to radians. 
 // The calculation in the if clause of this statement 
 // performs a similar conversion for negative values 
 return latitudeRadians; 
 } 
 } 
 
 public double LongitudeRadians 
 { 
 // This property should return a decimal degrees representation 
 // of the longitude data fields contained within an instance of a 
 // GeographicLocation object. The value should be returned in units 
 // of radians. This property should not produce any console output. 
 
 // INSERT THE CODE FOR THIS PROPERTY HERE... 
 get 
 { 
 double longitudeRadians; 
 // this the longitude value in radians to be returned 
 
 if (longitudeDegrees < 0) 
 longitudeRadians = (longitudeDegrees - (longitudeMinutes/60.0) 
 - (longitudeSeconds/3600.0))*Math.PI/180.0; 
 // if the longitude value is negative, minutes and seconds must 
 // be subtracted rather than added to longitude degrees 
 else 
 longitudeRadians = (longitudeDegrees + (longitudeMinutes/60.0) 
 + (longitudeSeconds/3600.0))*Math.PI/180.0; 
 // this calculation transforms the DMS form of latitude into 
 // a real degree value, which is then converted to radians. 
 // The calculation in the if clause of this statement 
 // performs a similar conversion for negative values 
 
 return longitudeRadians; 
 } 
 } 
 
 public override string ToString() 
 { 
 // This instance method should return a string representation of the 
 // data fields contained within an instance of a GeographicLocation 
 // object. The format of the string should exactly match the sample 
 // console output. This method should not produce any console 
 // output. 
 
 // INSERT THE CODE FOR THIS INSTANCE METHOD HERE... 
 char northSouth, eastWest; 
 if (latitudeDegrees < 0) 
 northSouth = 'S'; 
 // If the latitude value is negative it will be interpreted as South 
 else 
 northSouth = 'N'; 
 // If the latitude value is positive it will be interpreted as North 
 if (longitudeDegrees < 0) 
 eastWest = 'W'; 
 // If the longitude value is negative it will be interpreted as West 
 else 
 eastWest = 'E'; 
 // If the longitude value is positive it will be interpreted as East 
 
 string coordinatesDMS; // this is the DMS string to be output in Main 
 coordinatesDMS = string.Format("{0}°{1}'{2}\" {3}, {4}°{5}'{6}\" {7}", 
 Math.Abs(latitudeDegrees), latitudeMinutes, 
 latitudeSeconds, northSouth, Math.Abs(longitudeDegrees), 
 longitudeMinutes, longitudeSeconds, eastWest); 
 // This creates an output string with degrees, minutes and seconds 
 // with compass positions for the latitude and longitude of a location 
 
 return coordinatesDMS; 
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
 
 lonDegrees = getInteger("degrees", "longitude", -180, 180); 
 
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
 
 static uint getUnsignedInteger(string units, string measurement, uint max) 
 { 
 // This method should obtain an unsigned integer value within 
 // the specified range from a user via the console window. This 
 // method is similar to the getInteger() method provided. 
 
 // INSERT THE CODE FOR THIS STATIC METHOD HERE... 
 
 int inputValue; // this integer will be used to determine whether 
 // given inputs are in the range from 0 to max and 
 // return the first value to satisfy those conditions 
 
 do 
 { 
 Console.WriteLine("\nEnter the {0} of the {1} ranging", 
 units, measurement); 
 Console.Write(" from {0}\" to {1}\" as an integer: ", 
 0, max); 
 // These lines identify the variable being requested and the 
 // acceptable range of input values 
 inputValue = int.Parse(Console.ReadLine()); 
 // The input string is parsed to retrieve an integer value 
 } while (inputValue < 0 || inputValue > max); 
 // this loop will run at least once and repeat until an integer 
 // value between 0 and max is recieved 
 return (uint) inputValue; 
 // An acceptable positive input is returned as an unsigned integer 
 } 
}