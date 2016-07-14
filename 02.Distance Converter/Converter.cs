namespace NetCoreSamples
{

    public class Converter
    {

        public static double KilometersToMiles(double kilometers)
        {
	        return kilometers * 0.621371192;
        }

        public static double MilesToKilometers(double miles)
        {
            return miles * 1.609344;
        }

    }
}