namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            //String Line of code Example fron .CSV = "34.073638, -84677017, TacoBell Acwort....
            logger.LogInfo("Begin parsing");

            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            // Cells[0] = "34.073638";
            // Cells[1] = "-84677017";
            // Cells[2] = "TacoBell Acwort....";

            // double lattitude = 34.073638  / line 35 36 example of what code is doing.
            // string name = TacoBell Acwort.... no conversion needed allready a string 

            var cells = line.Split(',');

            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                // Log that and return null
                logger.LogError("Array Length is less than 3");
                
                // Do not fail if one record parsing fails, return null
                return null; // TODO Implement
            }

            // grab the latitude from your array at index 0
            double latitude;
            double.TryParse(cells[0], out latitude);
            // grab the longitude from your array at index 1
            double longitude;
            double.TryParse(cells[1], out longitude);
            // grab the name from your array at index 2
            string name = cells[2];


            // Your going to need to parse your string as a `double`
            // which is similar to parsing a string as an `int`

            // You'll need to create a TacoBell class
            // that conforms to ITrackable

            // Then, you'll need an instance of the TacoBell class
            // With the name and point set correctly
            //Import - CVS.\employee.cvs | foreach object 

            TacoBell tb1 = new TacoBell();

            tb1.Name = name;

            var point = new Point();
            point.Latitude = latitude;
            point.Longitude = longitude;
            tb1.Location = point;



            // Then, return the instance of your TacoBell class
            // Since it conforms to ITrackable

            return tb1;

           
        }
    }
}