using System.Text;

namespace BinaryToString
{
    public class BinaryFractionToString
    {
        public static string GetStringRepresentation(double decimalFraction)
        {
            var stringBuilder = new StringBuilder("0.");

            for (int i = 0; i < 32; i++)
            {
                decimalFraction *= 2;

                if (decimalFraction < 1)
                {
                    stringBuilder.Append("0");
                }
                else if (decimalFraction >= 1)
                {
                    stringBuilder.Append("1");
                    decimalFraction -= 1;

                    if (decimalFraction == 0)
                    {
                        break;
                    }
                }
            }

            if (decimalFraction != 0)
            {
                return "ERROR";
            }

            return stringBuilder.ToString();
        }
    }
}