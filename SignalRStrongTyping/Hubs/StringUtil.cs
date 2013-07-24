
namespace Hubs
{
	public static class StringUtil
	{
        public static string FirstLower(string text)
        {
            return text.Substring(0, 1).ToLower() + text.Substring(1);
        }
    }
}
