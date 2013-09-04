namespace SampleService
{
    public class ArgumentChecker
    {
        public static bool CheckArgumentExists(string[] args, int index)
        {
            return args != null && args.Length > index;
        }

        public static bool CheckArgumentValue(string[] args, int index, string value)
        {
            if (!CheckArgumentExists(args, index))
                return false;
            
            return args[index] == value;
        }
    }
}
