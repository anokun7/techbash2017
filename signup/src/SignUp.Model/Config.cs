﻿using System;
using System.Collections.Generic;

namespace SignUp.Model
{
    public class Config
    {
        private static Dictionary<string, string> _Values = new Dictionary<string, string>();

        public static string DbConnectionString { get { return Get("DB_CONNECTION_STRING"); } }

        public static string DbMaxRetryCount { get { return Get("DB_MAX_RETRY_COUNT", "1"); } }

        public static string DbMaxDelaySeconds { get { return Get("DB_MAX_DELAY_SECONDS", "5"); } }

        private static string Get(string variable, string defaultValue = null)
        {
            if (!_Values.ContainsKey(variable))
            {
                var value = Environment.GetEnvironmentVariable(variable, EnvironmentVariableTarget.Machine);
                if (string.IsNullOrEmpty(value))
                {
                    value = Environment.GetEnvironmentVariable(variable, EnvironmentVariableTarget.Process);
                }
                if (string.IsNullOrEmpty(value))
                {
                    value = defaultValue;
                }
                _Values[variable] = value;
            }
            return _Values[variable];
        }
    }
}