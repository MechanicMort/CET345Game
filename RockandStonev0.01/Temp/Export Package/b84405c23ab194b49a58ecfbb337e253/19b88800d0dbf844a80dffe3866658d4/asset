using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;
namespace RandomNameGeneratorLibrary
{
    public abstract class BaseNameGenerator
    {
        private const string ResourcePathPrefix = "RandomNameGeneratorLibrary.Resources.";
        protected readonly System.Random RandGen;

        protected BaseNameGenerator()
        {
            RandGen = new System.Random();
        }

        protected BaseNameGenerator(System.Random randGen)
        {
            RandGen = randGen;
        }

        private static Stream ReadResourceStreamForFileName(string resourceFileName)
        {
#if NET40
            return Assembly.GetExecutingAssembly()
                    .GetManifestResourceStream(ResourcePathPrefix + resourceFileName);
#else
          //  return typeof(BaseNameGenerator).GetTypeInfo().Assembly
           //     .GetManifestResourceStream(ResourcePathPrefix + resourceFileName);

            return Assembly.GetExecutingAssembly()
                    .GetManifestResourceStream(ResourcePathPrefix + resourceFileName);
#endif
        }

        protected static string[] ReadResourceByLine(string resourceFileName)
        {
            // var stream = ReadResourceStreamForFileName(resourceFileName);

            Debug.Log("SHOULD LOAD:::" + resourceFileName);
            TextAsset asset = Resources.Load("Resources."+resourceFileName) as TextAsset;
            
            if (asset == null)
            {
                Debug.Log("ASSET IS NULL");
                throw new Exception("NO ASSETS LOADED");
            }
            Stream stream = new MemoryStream(asset.bytes);
            //BinaryReader br = new BinaryReader(s);


            var list = new List<string>();

            var streamReader = new StreamReader(stream);
            string str;

            while ((str = streamReader.ReadLine()) != null)
            {
                if (str != string.Empty)
                    list.Add(str);
            }

            return list.ToArray();
        }
    }
}