
using System.Collections.Concurrent;
using System.Collections.Generic;


namespace PM.Algorithms
{
    public static class TreeConstructionHelper
    {

        public static bool IsBinaryTree(List<string> inputStr)
        {
            var parentDic = new ConcurrentDictionary<string, int>();
            var childDic = new ConcurrentDictionary<string, int>();

            if (inputStr.Count == 1)
            {
                return true;
            }
            foreach (var subStr in inputStr)
            {
                var node = subStr.ExtractNode();

                if (CheckExistMoreThan2Child(parentDic, node.Parent))
                {
                    return false;
                }

                if (CheckExistMoreThan1Parent(childDic, node.Child))
                {
                    return false;
                }

            }

            int numberOfRootNode = 0;

            numberOfRootNode = CountNumberOfRootNodes(parentDic, childDic, numberOfRootNode);

            return numberOfRootNode == 1;

        }

        private static bool CheckExistMoreThan1Parent(ConcurrentDictionary<string, int> childDic, string child)
        {
            var result = false;
            if (childDic.ContainsKey(child)) // if there is any node by more than 1 pranet return false
            {
                result = true;
            }
            else
            {
                childDic[child] = 1;
            }

            return result;
        }

        private static bool CheckExistMoreThan2Child(ConcurrentDictionary<string, int> parentDic, string parent)
        {
            var result = false;
            if (parentDic.ContainsKey(parent)) // if there is more than 2 child for any node return false
            {
                parentDic[parent] +=1;
                if (parentDic[parent] > 2)
                {
                    result = true;
                }
            }
            else
            {
                parentDic[parent] = 1;
            }

            return result;
        }

        private static int CountNumberOfRootNodes(ConcurrentDictionary<string, int> parentDic, ConcurrentDictionary<string, int> childDic, int numberOfRootNode)
        {
            foreach (var item in parentDic)
            {
                if (!childDic.ContainsKey(item.Key))
                {
                    numberOfRootNode++;
                }
            }

            return numberOfRootNode;
        }



    }
}
