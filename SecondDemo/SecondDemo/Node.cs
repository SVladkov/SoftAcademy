using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecondDemo
{
    struct Node
    {
        public int? id;
        public string name;
        public string data;
        public List<Node> children;

        public Node(int? id, string name, string data, List<Node> children)
        {
            this.id = id;
            this.name = name;
            this.data = data;
            this.children = children;
        }

        public void AddChild(Node child)
        {
            children.Add(child);
        }
    }
}