using System;

namespace Graph_05
{
	class Program
	{
		static void Main()
		{
			Graph graph = new Graph();

			Node node1 = new Node(1);
			Node node2 = new Node(2);
			Node node3 = new Node(3);
			Node node4 = new Node(4);

			graph.PushNode(node1); graph.PushNode(node2); graph.PushNode(node3); graph.PushNode(node4);

			graph.ConnectNodes(node1, node2, 4);
			graph.ConnectNodes(node2, node3, 1);
			graph.ConnectNodes(node3, node4, 5);
			

			graph.PrintMatrix();

			Console.WriteLine(graph.CountUnclosedPaths());
		}
	}
}
