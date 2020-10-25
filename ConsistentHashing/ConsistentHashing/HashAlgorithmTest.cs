using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KetamaHash.Utils
{
    public class HashAlgorithmTest
    {
        static Random ran = new Random();

        /** key's count */
        private int keyCount = 1000000;

        private int nodeCount = 10;

        private int virtualNodeCount = 160;

        public HashAlgorithmTest(int keyCount, int nodeCount, int virtualNodeCount)
        {
            this.keyCount = keyCount;
            this.nodeCount = nodeCount;
            this.virtualNodeCount = virtualNodeCount;
        }

        public static void Test(int keyCount, int nodeCount, int virtualNodeCount)
        {
            HashAlgorithmTest test = new HashAlgorithmTest(keyCount, nodeCount, virtualNodeCount);

            /** Records the times of locating node*/
            Dictionary<string, int> nodeRecord = new Dictionary<string, int>();

            List<string> allNodes = test.getNodes();
            KetamaNodeLocator locator = new KetamaNodeLocator(allNodes, virtualNodeCount);

            List<String> allKeys = test.getAllStrings();
            foreach (string key in allKeys)
            {
                string node = locator.GetPrimary(key);
                if (!nodeRecord.ContainsKey(node))
                {
                    nodeRecord[node] = 1;
                }
                else
                {
                    nodeRecord[node] = nodeRecord[node] + 1;
                }
            }

            Console.WriteLine($"Nodes count : {nodeCount}, Keys count : {keyCount}, Virtual node count : {virtualNodeCount}, Normal percent : {(float)100 / nodeCount}%");
            Console.WriteLine("-------------------- boundary  ----------------------");
            var distributions = new List<double>();
            foreach (string key in nodeRecord.Keys)
            {
                var distribution = (float)nodeRecord[key] / keyCount * 100;
                Console.WriteLine($"Node name : {key} - Times : {nodeRecord[key]} - Percent : {distribution}%");
                distributions.Add(distribution);
            }

            Console.WriteLine($"------------ Standard Deviation: {HashAlgorithmTest.StandardDeviation(distributions)}---------------");

            Console.ReadLine();
        }

        private static double StandardDeviation(List<double> data)
        {
            double stdDev = 0;
            double sumAll = 0;
            double sumAllQ = 0;

            //Sum of x and sum of x²
            for (int i = 0; i < data.Count; i++)
            {
                double x = data[i];
                sumAll += x;
                sumAllQ += x * x;
            }

            //Mean (not used here)
            //double mean = 0;
            //mean = sumAll / (double)data.Length;

            //Standard deviation
            stdDev = System.Math.Sqrt(
                (sumAllQ -
                (sumAll * sumAll) / data.Count) *
                (1.0d / (data.Count - 1))
                );

            return stdDev;
        }


        /**
         * Gets the mock node by the material parameter
         * 
         * @param nodeCount 
         * 		the count of node wanted
         * @return
         * 		the node list
         */
        private List<string> getNodes()
        {
            List<string> nodes = new List<string>();

            for (int k = 1; k <= nodeCount; k++)
            {
                string node = "node" + k;
                nodes.Add(node);
            }

            //在应用时，这里会添入memcached server的IP端口地址
            //nodes.Add("10.0.4.114:11211");
            //nodes.Add("10.0.4.114:11212");
            //nodes.Add("10.0.4.114:11213");
            //nodes.Add("10.0.4.114:11214");
            //nodes.Add("10.0.4.114:11215");
            return nodes;
        }

        /**
         *	All the keys	
         */
        private List<String> getAllStrings()
        {
            List<string> allStrings = new List<string>(keyCount);

            for (int i = 0; i < keyCount; i++)
            {
                allStrings.Add(generateRandomString(ran.Next(50)));
            }

            return allStrings;
        }

        /**
         * To generate the random string by the random algorithm
         * <br>
         * The char between 32 and 127 is normal char
         * 
         * @param length
         * @return
         */
        private String generateRandomString(int length)
        {
            StringBuilder sb = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                sb.Append((char)(ran.Next(95) + 32));
            }

            return sb.ToString();
        }
    }
}
