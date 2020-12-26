using System;
using System.Collections.Generic;

namespace Graph_05
{
	class Graph
	{
		List<Node> _nodes = new List<Node>();
		List<Edge> _edges = new List<Edge>();
		string[,] _matrix = new string[0, 0];

		public void PushNode(Node newNode)
		{
			if (_nodes.Contains(newNode) == false && newNode.Number <= _nodes.Count + 1)
				_nodes.Add(newNode);
		}

		public void ConnectNodes(Node start, Node finish, int weight)
		{
			if (_nodes.Contains(start) == true && _nodes.Contains(finish) == true)
				_edges.Add(new Edge(start, finish, weight));
		}

		private void GenerateMatrix()
		{
			_matrix = new string[_nodes.Count + 1, _nodes.Count + 1];

			for (int i = 0; i < _nodes.Count + 1; ++i)
			{
				for (int j = 0; j < _nodes.Count + 1; ++j)
				{
					_matrix[i, j] = "0";
				}
			}
			_matrix[0, 0] = " ";

			for (int i = 1; i < _nodes.Count + 1; ++i)
			{
				_matrix[0, i] = $"X{i}";
				_matrix[i, 0] = $"X{i}";
			}

			foreach (Edge e in _edges)
				_matrix[e.StartNode.Number, e.FinishNode.Number] = $"{e.Weight}";
		}

		public void PrintMatrix()
		{
			GenerateMatrix();

			for (int i = 0; i < _nodes.Count + 1; ++i)
			{
				for (int j = 0; j < _nodes.Count + 1; ++j)
				{
					if (_matrix[j, i].IndexOf("X") != -1)
						Console.Write(_matrix[i, j] + "  ");
					else
						Console.Write(_matrix[i, j] + "   ");
				}
				Console.WriteLine('\n');
			}
		}

		public int CountUnclosedPaths()
		{
			int paths = 0;
			
			foreach(Edge e in _edges)
			{				
				if (e.StartNode.IsChecked == false)
				{
					if (CheckPathForClosed(e.StartNode) == false)
						++paths;
					else if (CheckPathForClosed(e.StartNode) == true && paths == 0)
						paths = 0;
					else
						--paths;
				}
			}

			return paths;
		}

		bool CheckPathForClosed(Node nodeToCheck)
		{
			if (nodeToCheck.IsChecked == true)
				return true;

			nodeToCheck.Check();

			bool isClosed = false;
			foreach(Edge e in _edges)
			{
				if (e.StartNode == nodeToCheck)
					isClosed = CheckPathForClosed(e.FinishNode);
			}

			return isClosed;
		}
	}
}
