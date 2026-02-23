namespace cherrydev
{
    public abstract class OneChildNode : Node
    {
        public Node ChildNode;

        public override Node GetNextNode()
        {
            return ChildNode;
        }

    }
}