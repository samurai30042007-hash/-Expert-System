using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace VVII_laba3
{
    internal class ExpertSystem
    {
        Dictionary<string, Node>? Tree = null;
        Stack<string>? stackNodes = new(2);
        internal async Task ReadJsonFile(string path)
        {
            List<Node> nodes;
            using (StreamReader fs = new(path))
            {
                string json =  await fs.ReadToEndAsync();
                if (string.IsNullOrEmpty(json))
                {
                    throw new ArgumentNullException(path, "Empty file");
                }
                nodes = JsonSerializer.Deserialize<List<Node>>(json)!;
            }
            Tree = new(nodes.Count);
            for (int i = 0; i < nodes.Count; i++)
            {
                Tree.Add(nodes[i].Id, nodes[i]);
            }
        }

        internal Node FindNode( string answer)
        {
            if (Tree is null)
            {
                throw new ArgumentNullException("Tree", "Null Value");
            }
            
            return Tree[answer];
        }
        

        
    }
}
