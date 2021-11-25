using System.Text;

namespace PM.Algorithms
{
    public static class Extentions
    {
        public static Node ExtractNode(this string pairStr)
        {
            var node = new Node();
            var array = pairStr.ToCharArray();
            var i = 1;
            while(array[i] != ',')
            {
                node.AppendToChild(array[i]);
                i++;
            }
            i++;
            while(array[i] != ')')
            {
                node.AppendToParent(array[i]);
                i++;
            }

            return node;
        }
    }

    public class Node
    {
        private StringBuilder parent; 
        private StringBuilder child;
        public Node()
        {
            this.parent = new StringBuilder();
            this.child = new StringBuilder();
        }

        public void AppendToParent(char item)
        {
            this.parent.Append(item);
        }

        public void AppendToChild(char item)
        {
            this.child.Append(item);
        }
        public string Parent { get { return this.parent.ToString(); } }
        public string Child { get { return this.child.ToString(); } }
    }
}
