namespace Utility
{
    using BillingSystem.Models;
    using System;
    using System.Web;

    public static class SessionWrapper
    {
        private static T GetFromApplication<T>(string key)
        {
            return (T) HttpContext.Current.Application[key];
        }

        private static T GetFromSession<T>(string key)
        {
            object obj2 = HttpContext.Current.Session[key];
            if (obj2 == null)
            {
                return default(T);
            }
            return (T) obj2;
        }

        private static void SetInApplication<T>(string key, T value)
        {
            if (value == null)
            {
                HttpContext.Current.Application.Remove(key);
            }
            else
            {
                HttpContext.Current.Application[key] = value;
            }
        }

        private static void SetInSession<T>(string key, T value)
        {
            if (value == null)
            {
                HttpContext.Current.Session.Remove(key);
            }
            else
            {
                HttpContext.Current.Session[key] = value;
            }
        }

        public static string ForSessionOnly
        {
            get
            {
                return GetFromSession<string>("ForSessionOnly");
            }
            set
            {
                SetInSession<string>("ForSessionOnly", value);
            }
        }

        public static UserModels User
        {
            get
            {
                return GetFromSession<UserModels>("User");
            }
            set
            {
                SetInSession<UserModels>("User", value);
            }
        }
    }
}

