namespace observers6
{
    public static class WindDirectionDetector
    {
        public static string DetectWindDirection( double avgWindDirection )
        {
            if( avgWindDirection > 315 || avgWindDirection <= 45 )
            {
                return "North";
            }
            if( avgWindDirection > 45 && avgWindDirection <= 135 )
            {
                return "East";
            }
            if( avgWindDirection > 135 && avgWindDirection <= 225 )
            {
                return "South";
            }
            if( avgWindDirection > 225 && avgWindDirection <= 315 )
            {
                return "West";
            }

            return "";
        }
    }
}
