using System;

namespace MorseCodeInterpreter
{
    public interface IMorseCodeNode
    {
        string Value { get; }
        IMorseCodeNode Dot { get; }
        IMorseCodeNode Dash { get; }
    }

    public sealed class MorseCodeNode : IMorseCodeNode
    {
        public string Value { get; private set; }
        public IMorseCodeNode Dot { get; private set; }
        public IMorseCodeNode Dash { get; private set; }

        public MorseCodeNode(string value, IMorseCodeNode dashNode, IMorseCodeNode dotNode)
        {
            Value = value;
            Dot = dotNode;
            Dash = dashNode;
        }      
    }

    public sealed class MorseCodeLeaf : IMorseCodeNode
    {
        public string Value { get; private set; }
        public IMorseCodeNode Dot { get { return new NullMorseCodeLeaf(); } }
        public IMorseCodeNode Dash { get { return  new NullMorseCodeLeaf();} }

        public MorseCodeLeaf(string value)
        {
            Value = value;
        }
    }

    public sealed class NullMorseCodeLeaf : IMorseCodeNode
    {
        public string Value { get { return ""; } }
        public IMorseCodeNode Dot { get { return this; } }
        public IMorseCodeNode Dash { get { return this; } }        
    }


    public static class MorseCodeBuilder
    {
        public static IMorseCodeNode Build()
        {
            var zeroNode = new MorseCodeLeaf("0");
            var nineNode = new MorseCodeLeaf("9");
            var dashNode = new MorseCodeNode("", zeroNode, nineNode);
            var nullMorseCodeLeaf = new NullMorseCodeLeaf();
            var eightNode = new MorseCodeLeaf("8");
            var dotNode = new MorseCodeNode("", nullMorseCodeLeaf, eightNode);
            var oNode = new MorseCodeNode("O", dashNode, dotNode);
            var qNode = new MorseCodeNode("Q", nullMorseCodeLeaf, nullMorseCodeLeaf);
            var sevenNode = new MorseCodeLeaf("7");
            var zNode = new MorseCodeNode("Z", nullMorseCodeLeaf, sevenNode);
            var gNode = new MorseCodeNode("G", qNode, zNode);
            var mNode = new MorseCodeNode("M", oNode, gNode);
            var yNode = new MorseCodeLeaf("Y");
            var cNode = new MorseCodeLeaf("C");
            var kNode = new MorseCodeNode("K", yNode, cNode);
            var xNode = new MorseCodeLeaf("X");
            var sixNode = new MorseCodeLeaf("6");
            var bNode = new MorseCodeNode("B", nullMorseCodeLeaf, sixNode);
            var dNode = new MorseCodeNode("D", xNode, bNode);
            var nNode = new MorseCodeNode("N", kNode, dNode);
            var tNode = new MorseCodeNode("T", mNode, nNode);
            var oneNode = new MorseCodeLeaf("1");
            var jNode = new MorseCodeNode("J", oneNode, nullMorseCodeLeaf);
            var pNode = new MorseCodeLeaf("P");
            var wNode = new MorseCodeNode("W", jNode, pNode);
            var lNode = new MorseCodeLeaf("L");
            var rNode = new MorseCodeNode("R", nullMorseCodeLeaf, lNode);
            var aNode = new MorseCodeNode("A", wNode, rNode);
            var twoNode = new MorseCodeLeaf("2");
            var udNode = new MorseCodeNode("", twoNode, nullMorseCodeLeaf);
            var fNode = new MorseCodeLeaf("F");
            var uNode = new MorseCodeNode("U", udNode, fNode);
            var threeNode = new MorseCodeLeaf("3");
            var vNode = new MorseCodeNode("V", threeNode, nullMorseCodeLeaf);
            var fourNode = new MorseCodeLeaf("4");
            var fiveNode = new MorseCodeLeaf("5");
            var hNode = new MorseCodeNode("H", fourNode, fiveNode);
            var sNode = new MorseCodeNode("S", vNode, hNode);
            var iNode = new MorseCodeNode("I", uNode, sNode);
            var eNode = new MorseCodeNode("E", aNode, iNode);
            var startNode = new MorseCodeNode("", tNode, eNode);
            return startNode;
        }
    }
}