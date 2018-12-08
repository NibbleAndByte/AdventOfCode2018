<Query Kind="Program">
  <Namespace>System</Namespace>
</Query>


void Main()
{
	var problem = new problem2part2();
	var pathPrepend = "C:\\Users\\USERNAME\\Desktop\\AdventOfCode2018\\input\\" ;
	var path = pathPrepend + "2.txt";
	var data = parseFileAsArray(path);
	Console.WriteLine(problem.execute(data));
}

public string[] parseFileAsArray(string path)
{
	try 
	{
		using (StreamReader sr = new StreamReader(path))
		{
			var fileContent = sr.ReadToEnd();
			var splitArray = fileContent.Split('\n');
			return splitArray;
		}
	}
	catch (Exception e)
	{
		Console.WriteLine(e.Message);
		return new string[0];
	}
}

public interface iProblem
{
	string execute(string[] data);
}

public class problem2 : iProblem
{
	public string execute(string[] data)
	{
		var numOfTwoDigit = 0;
		var numOfThreeDigit = 0;
		foreach (string entry in data)
		{
			var charDict = new Dictionary<char,int>();
			foreach (char c in entry)
			{
				addToDictionary(c, charDict);
			}
			charDict.OrderBy(x=>x.Value);
			
			if (charDict.ContainsValue(2))
				numOfTwoDigit++;
			if (charDict.ContainsValue(3))
				numOfThreeDigit++;			
		}
		
		Console.WriteLine(numOfTwoDigit + " " + numOfThreeDigit);
		return (numOfTwoDigit * numOfThreeDigit).ToString();
	}
	
	
	private void addToDictionary(char c, Dictionary<char,int> dict)
	{
		int currentCount;
		dict.TryGetValue(c, out currentCount);
		if (currentCount == 0)
		{
			dict.Add(c,1);			
		}
		else
		{
			dict[c] = ++currentCount;
		}		
	}
	
}
public class problem2part2 : iProblem
{
	public string execute(string[] data)
	{
		foreach (string entry in data)
		{			
			foreach (string inner in data)
			{
				if (inner.Length == 0 )
				{
					continue; // Linqpad doesn't seem to support the string split override to have a StringSplitOption ¯\_(ツ)_/¯
				}
				var diffChars = 0;
				for(int i = 0; i < entry.Length; i++)
				{
					if (!(entry[i] == inner[i]))
						diffChars++;
				}
				if (diffChars == 1)
				{
					return ("Found: " + entry + ", other: "+ inner);
				}
			}
		}
		return "Not found";		
	}
}