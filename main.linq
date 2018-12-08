<Query Kind="Program">
  <Namespace>System</Namespace>
</Query>

void Main()
{
	var problem = new problem2part2();
	var pathPrepend = "C:\\Users\\USERNAME\\Desktop\\AdventOfCode2018\\input\\" ;
	var path = pathPrepend + "NUM.txt";
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
		
	}
	
}
public class problem2part2 : iProblem
{
	public string execute(string[] data)
	{
			
	}
}