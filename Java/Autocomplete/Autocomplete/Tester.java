package a03;


public class Tester
{
	// TEST CLIENT
	public static void main(String[] args)
	{
		Term[] terms = {
				new Term("Cataratas", 1.0),
				new Term("Coffe", 1.2),
				new Term("Coffin", 1.1),
				new Term("Cobb", 1.3),
				new Term("Cow", 1.4),
				new Term("column", 1.0),
				new Term("Colorado", 3.0),
				new Term("Cat", 5.0),
				new Term("Cab", 2.1)
		};
		Autocomplete a = new Autocomplete(terms);
		
		System.out.println("TEST CLIENT");
		System.out.println("All Terms: ");
		for (Term t : terms)
			System.out.println(t);
		System.out.println("\nUser types co autocomplete shows following from the given list: ");
		Term[] hits = a.allMatches("co");
		for (Term t : hits)
			System.out.println(t.toString());
		System.out.println("\nUser types an additional l");
		hits = a.allMatches("col");
		for (Term t : hits)
			System.out.println(t.toString());
		System.out.println("\nUser deletes ol and types at:");
		hits = a.allMatches("cat");
		for (Term t : hits)
			System.out.println(t.toString());
			
	}
	
}
