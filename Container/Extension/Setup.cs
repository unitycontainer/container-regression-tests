﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regression;
using System.Collections;
using Unity.Builder;
#if UNITY_V4
using Microsoft.Practices.Unity.ObjectBuilder;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
#else
using Unity.Storage;
using Unity.Strategies;
#endif


namespace Container
{
    [TestClass]
    public partial class Extensions : PatternBase
    {
        #region Constants

        const string TESTING = "Extension";
        const string POLICY = "Policy";
        const string EXTENSION = "Container Extension";
        const string NAME_PATTERN = "Can add strategy to {1} step";
        const string LEGACY = "Legacy";

        #endregion


        #region Abstraction Layer
#if UNITY_V4
        IEnumerable AsEnumerable(IStagedStrategyChain chain)
        {
            return chain.MakeStrategyChain();
        }
#elif UNITY_V5 || UNITY_V6
        IEnumerable AsEnumerable(IStagedStrategyChain<BuilderStrategy, UnityBuildStage> chain)
        {
            return chain as IEnumerable;
        }
#else
        IEnumerable AsEnumerable(IStagedStrategyChain<BuilderStrategy, UnityBuildStage> chain)
        {
            return chain;
        }
#endif

        #endregion
    }
}
