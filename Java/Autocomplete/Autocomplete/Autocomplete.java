package a03;

import java.util.Arrays;

import a03.Term.ByPrefixOrder;
import a03.Term.ByReverseWeightOrder;

/**
 * Provides a platform to bring the complete autocomplete functionality together.
 * Stores all the possible terms in an array and provides methods to search with the given prefix sorted by 
 * their weight.
 * 
 * @author Zach Biggs
 *
 */
public class Autocomplete
{
	private Term[] terms;
	
	public Autocomplete(Term[] terms)
	{
		if (terms == null)
			throw new NullPointerException("terms parameter may not be null");
		this.terms = new Term[terms.length];
		for (int i = 0; i < terms.length; i++)
			this.terms[i] = terms[i];
	}
	
	/**
	 * Returns an array with all the terms that match with the given prefix.
	 * 
	 * @param prefix The prefix that the method will use to search.
	 * @return Returns an array of matching terms.
	 */
	public Term[] allMatches(String prefix)
	{
		if (prefix == null)
			throw new NullPointerException("prefix parameter may not be null");
		Arrays.sort(this.terms);
		
		int firstIndex = BinarySearchDeluxe.firstIndexOf(this.terms, new Term(prefix, 0.0), new ByPrefixOrder(prefix.length()));
		int lastIndex = BinarySearchDeluxe.lastIndexOf(this.terms, new Term(prefix, 0.0), new ByPrefixOrder(prefix.length()));
		Term[] matches = new Term[numberOfMatches(prefix)];
		if (firstIndex == -1 || lastIndex == -1)
			return matches;
		else if (firstIndex == lastIndex)
			matches[0] = this.terms[firstIndex];
		else
		{
			matches = Arrays.copyOfRange(this.terms, firstIndex, lastIndex + 1);
			Arrays.sort(matches, new ByReverseWeightOrder());
		}

		return matches;
	}
	
	/**
	 * Finds the number of matches based on the given prefix. 
	 * 
	 * @param prefix The String prefix to be searched with.
	 * @return Returns the count of matches found.
	 */
	public int numberOfMatches(String prefix)
	{
		if (prefix == null)
			throw new NullPointerException("prefix parameter may not be null");
		Arrays.sort(this.terms);
		
		int firstIndex = BinarySearchDeluxe.firstIndexOf(this.terms, new Term(prefix, 0.0), new ByPrefixOrder(prefix.length()));
		int lastIndex = BinarySearchDeluxe.lastIndexOf(this.terms, new Term(prefix, 0.0), new ByPrefixOrder(prefix.length()));
		if (firstIndex == -1 || lastIndex == -1)
			return 0;
		
		return (lastIndex + 1) - firstIndex;
	}
}
