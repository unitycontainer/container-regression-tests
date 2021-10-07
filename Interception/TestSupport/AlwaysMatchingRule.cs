﻿using System.Reflection;
using Unity;
using Unity.Interception;

namespace Unity.Interception.Tests
{
    /// <summary>
    /// A simple matching rule class that always matches. Useful when you want
    /// a policy to apply across the board.
    /// </summary>
    public class AlwaysMatchingRule : IMatchingRule
    {
        public string Name { get; set; }

        [InjectionConstructor]
        public AlwaysMatchingRule()
        {
        }

        public bool Matches(MethodBase member)
        {
            Name = member.Name;

            return true;
        }
    }
}
