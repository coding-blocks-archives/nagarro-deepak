

namespace nagarro_deepak
{
    public class TreeNodeNext : TreeNode
    {
        public TreeNode next;
        public TreeNodeNext(int x) : base(x)
        {
            this.next = null;
        }

        static void joinLevel(TreeNodeNext root){
            
        }

        static public void main2()
        {
            TreeNodeNext root = Tree.createTree();
            TreeNodeNext.joinLevel(root);

        }
    }
}