namespace Graph_05
{
	// Дуга графа
	class Edge
	{
		public Node StartNode { get; }
		public Node FinishNode { get; }
		public int Weight { get; }

		public Edge(Node newStart, Node newFinish, int weight)
		{
			StartNode = newStart;
			FinishNode = newFinish;
			Weight = weight;
		}
	}
}
