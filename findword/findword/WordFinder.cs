namespace WordFinder
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class WordFinder
    {
        private readonly HashSet<string> matrix;
		
		public WordFinder(IEnumerable<string> matrix)
		{
			this.matrix = new HashSet<string>(matrix);
		}
		
		public IEnumerable<string> Find(IEnumerable<string> wordstream)
		{
			var leftRightSearchString = string.Join(string.Empty, wordstream);
			
			var characterMatrix = wordstream
				.Select(row => row.ToCharArray())
				.ToArray();
			var topDownSearchStringBuilder = new StringBuilder();
			for (var i = 0; i < characterMatrix.Length; i++)
			{
				for(var j = 0; j < characterMatrix[i].Length; j++)
				{
					topDownSearchStringBuilder.Append(characterMatrix[j][i]);
				}
			}
			var topDownSearchString = topDownSearchStringBuilder.ToString();
			
			var resultSet = new HashSet<string>();
			resultSet.UnionWith(matrix.Where(searchTerm => 
												 leftRightSearchString.Contains(searchTerm)));
			resultSet.UnionWith(matrix.Where(searchTerm => 
												 topDownSearchString.Contains(searchTerm)));
			
			return resultSet.ToList();
		}
    }
}
