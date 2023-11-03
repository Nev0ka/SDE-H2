namespace RNG
{
    public class RNGGenarator
    {
        public static int GetValueForItem(int value)
        {
            int highestValue = value*10;
            int lowestValue = value*5;

            var random = new Random();
            return random.Next(lowestValue,highestValue);
        }
    }
}