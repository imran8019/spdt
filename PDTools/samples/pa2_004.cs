// -------------------------------------------------------------------
// Department of Electrical and Computer Engineering
// University of Waterloo
//
//
// Assignment:       Programing Assignment 2
// Submission Date:  16 October 2009
//
// I declare that this program is my original work.
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
        //     ?Object=Earth&Display=Facts&System=Metric
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

class  GeographicLocation
{
    // These three fields store the latitude of a geographic location
    // in DMS format with values ranging from -90 degrees to +90 degrees.

    private int latitudeDegrees;        // -90 degrees to 90 degrees
    private uint latitudeMinutes;       // 0 minutes to 60 minutes
    private uint latitudeSeconds;       // 0 seconds to 60 seconds

    // These three fields store the longitude of a geographic location
    // in DMS format with values ranging from -180 degrees to +180 degrees.

    private int longitudeDegrees;       // -180 degrees to 180 degrees
    private uint longitudeMinutes;      // 0 minutes to 60 minutes
    private uint longitudeSeconds;      // 0 seconds to 60 seconds


    public GeographicLocation(double latitude, double longitude)
    {
        // This constructor should initialize all data fields contained
        // within an instance of a GeographicLocation object using the
        // parameters provided.  The parameter latitude represents the
        // latitude of a location in decimal degrees format.  The
        // parameter longitude represents the longitude of a location
        // in decimal degrees format.  This method should not produce 
        // any console output.

        //Convert the latitude to DMS
        latitudeDegrees = (int)latitude; //Get integer degrees
        latitude -= latitudeDegrees; //Get value of degrees after decimal
        latitude *= 60; //Multiply to get minutes

        latitudeMinutes = (uint)latitude; //Get integer minutes
        latitude -= latitudeMinutes; //Get value of minutes after decimal
        latitude *= 60; //Multiply to get seconds

        latitudeSeconds = (uint)latitude; //Get integer seconds

        //Convert the longitude to DMS
        longitudeDegrees = (int)longitude; //Get integer degrees
        longitude -= longitudeDegrees; //Get value of degrees after decimal
        longitude *= 60; //Multiply to get minutes

        longitudeMinutes = (uint)longitude; //Get integer minutes
        longitude -= longitudeMinutes; //Get value of minutes after decimal
        longitude *= 60; //Multiply to get seconds

        longitudeSeconds = (uint)longitude; //Get integer seconds   

    }

    public GeographicLocation(int d1, uint m1, uint s1, int d2,
        uint m2, uint s2)
    {
        // This constructor should initialize all data fields contained
        // within an instance of a GeographicLocation object using the
        // parameters provided.  The parameters (d1,m1,s1) represent the 
        // latitude of a location in DMS format.  The parameters (d2,m2,s2)
        // represent the longitude of a location in DMS format.  This 
        // method should not produce any console output.

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
                throw new  ArgumentOutOfRangeException( "value");
            }
        }
    }//Do not modify

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
                throw new  ArgumentOutOfRangeException( "value");
            }
        }
    }//Do not modify

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
                throw new  ArgumentOutOfRangeException( "value");
            }
        }
    }//Do not modify

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
                throw new  ArgumentOutOfRangeException( "value");
            }
        }
    }//Do not modify

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
                throw new  ArgumentOutOfRangeException( "value");
            }
        }
    }//Do not modify

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
                throw new  ArgumentOutOfRangeException( "value");
            }
        }
    }//Do not modify

    public double LatitudeRadians
    {
        // This property should return take in a decimal degrees representation
        // of the latitude data fields contained within an instance of a 
        // GeographicLocation object.  The value should be returned in units 
        // of radians.  This property should not produce any console output.

        
        get 
        {
            //Convert to radians, then return positive value if the 
            //initial value is positive, negative value if the initial
            //value is negative.
            double latitudeRadians = ( Math.Abs(latitudeDegrees) +
                                        (latitudeMinutes / 60d) +
                                        (latitudeSeconds / 3600d)) *
                                        ( Math.PI / 180d);
            if (latitudeDegrees < 0)
            {

                return latitudeRadians * -1;
            }
            else
            {
                return latitudeRadians;
            }
        }
    }

    public double LongitudeRadians
    {
        get
        {
                //Convert to radians, then return positive value if the 
                //initial value is positive, negative value if the initial
                //value is negative.
                double longitudeRadians = ( Math.Abs(longitudeDegrees) + 
                                         (longitudeMinutes / 60d) +
                                         (longitudeSeconds / 3600d)) * 
                                         ( Math.PI / 180d);

                if (longitudeDegrees < 0)
                {
                    return longitudeRadians * -1;
                }
                else
                {
                    return longitudeRadians;
                }
            
        }
    }

    public override string ToString()
    {
        //Determine if the location is in the Northern or Southern Hemisphere
        char latPos;
        char longPos;
        if (latitudeDegrees >= 0)
        {
            latPos =  'N';
        }
        else 
        {
            latPos =  'S';
        }

        //Determine if the location is in the Eastern or Western Hemisphere
        if (longitudeDegrees >= 0)
        {
            longPos =  'E';
        }
        else 
        {
            longPos =  'W';
        }

        //Write in DMS format, with the hemispheres included
        return string.Format( "{0}'b0{1}'{2}\" {6} , {3}'b0{4}'{5}\" {7} ",
                             Math.Abs(latitudeDegrees), latitudeMinutes,
                            latitudeSeconds,  Math.Abs(longitudeDegrees),
                            longitudeMinutes, longitudeSeconds,
                            latPos, longPos);

    }

    public double Distance( GeographicLocation myLocation)
    {
        // This instance method calculates the distance from the current
        // instance location to another GeographicLocation specified by
        // a parameter that refers to the location.

        // DO NOT MODIFY THIS METHOD.

        double latitudeDD1 = myLocation.LatitudeRadians;
        double longitudeDD1 = myLocation.LongitudeRadians;
        double latitudeDD2 = LatitudeRadians;
        double longitudeDD2 = LongitudeRadians;

        double sinLambda =  Math.Sin(longitudeDD1 - longitudeDD2);
        double cosLambda =  Math.Cos(longitudeDD1 - longitudeDD2);

        double distance = NASA. Earth.EquatorialRadius *  Math.Atan2( Math.Sqrt(
             Math.Cos(latitudeDD1) * sinLambda *
             Math.Cos(latitudeDD1) * sinLambda +
            ( Math.Cos(latitudeDD2) *  Math.Sin(latitudeDD1) -
             Math.Sin(latitudeDD2) *  Math.Cos(latitudeDD1) *
            cosLambda) *
            ( Math.Cos(latitudeDD2) *  Math.Sin(latitudeDD1) -
             Math.Sin(latitudeDD2) *  Math.Cos(latitudeDD1) *
            cosLambda)),
            ( Math.Sin(latitudeDD2) *  Math.Sin(latitudeDD1) +
             Math.Cos(latitudeDD2) *  Math.Cos(latitudeDD1) *
            cosLambda));
        return (distance);
    }
}

class  PA2_2009
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

         Console.WriteLine( "\nGreat Circle Distance Estimator");

         Console.WriteLine( "\nThis program calculates the distance between a");
         Console.WriteLine( "location specified by the user and a location at");
         Console.WriteLine( "the University of Waterloo in the RCH Building.");

         Console.WriteLine( "\nLatitude Entry");

         Console.WriteLine( "\nEnter a latitude specified in DMS format.");
         Console.WriteLine( "    RCH Building is 43u00b028'13\"");
         Console.WriteLine( "    degrees = 43, minutes = 28, seconds = 13");

        latDegrees = getInteger( "degrees",  "latitude", -90, 90);

        if (latDegrees == -90 || latDegrees == 90)
        {
            latMinutes = 0;
            latSeconds = 0;
        }
        else
        {
            latMinutes = getUnsignedInteger( "minutes",  "latitude", 60u);
            latSeconds = getUnsignedInteger( "seconds",  "latitude", 60u);
        }

         Console.WriteLine( "\nLongitude Entry");

         Console.WriteLine( "\nEnter a longitude specified in DMS format.");
         Console.WriteLine( "    RCH Building is -80u00b032'27\"");
         Console.WriteLine( "    degrees = -80, minutes = 32, seconds = 27");

        lonDegrees = getInteger( "degrees",  "longitude", -180, 180);

        if (lonDegrees == -180 || lonDegrees == 180)
        {
            lonMinutes = 0;
            lonSeconds = 0;
        }
        else
        {
            lonMinutes = getUnsignedInteger( "minutes",  "longitude", 60);
            lonSeconds = getUnsignedInteger( "seconds",  "longitude", 60);
        }

        // The user-specified location is location 0
        location0 = new  GeographicLocation(
            latDegrees, latMinutes, latSeconds,
            lonDegrees, lonMinutes, lonSeconds);

        // The RCH building at UW is always location 1
        location1 = new  GeographicLocation(43, 28, 13, -80, 32, 27);

         Console.WriteLine( "\nSpecified Location = {0}", location0);
         Console.WriteLine( "RCH Building       = {0}", location1);

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
             Console.WriteLine( "\nEnter the {0} of the {1} ranging",
                units, measurement);
             Console.Write( "    from {0} to {1} as an integer: ",
                min, max);
            inputValue = int.Parse( Console.ReadLine());
        } while (inputValue < min || inputValue > max);

        return (inputValue);
    }

    static uint getUnsignedInteger(string units, string measurement, uint max)
    {
        // This method should obtain an unsigned integer value within
        // the specified range from a user via the console window.  This
        // method is similar to the getInteger() method provided.

        // Obtains the unsigned integer values of minutes and seconds
        // for latitude and longitude

        uint inputValue;

        do
        {
             Console.WriteLine( "\nEnter the {0} of the {1} ranging",
                units, measurement);
             Console.Write( "    from 0 to {0} as an unsigned integer: ",
                max);
            inputValue = uint.Parse( Console.ReadLine());
        } while (inputValue < 0 || inputValue > max);

        return (inputValue);


    }
}
}