using System;
using System.Configuration;

namespace Productivity.Controller.Helpers
{
    public static class ResourceLoader
    {
        public static T GetResourceAs<T>(string input)
        {
            var value = Lang.Base.ResourceManager.GetString(input);
            return (T) Convert.ChangeType(value, typeof(T));
        }

        public static T GetApplicationConfigurationAs<T>(string input)
        {
            var value = ConfigurationManager.AppSettings.Get(input);
            return (T) Convert.ChangeType(value, typeof(T));
        }
    }
}