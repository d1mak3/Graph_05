namespace Graph_05
{
	// Вершина графа
	class Node
	{
		public int Number { get; }
		public bool IsChecked { get; private set; }

		public Node(int newNum)
		{
			Number = newNum;
			IsChecked = false;
		}

		public void Check()
		{
			IsChecked = true;
		}

		public void Uncheck()
		{
			IsChecked = false;
		}
	}
}
