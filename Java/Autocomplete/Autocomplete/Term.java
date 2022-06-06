package a03;

import java.util.Comparator;

/**
 * Stores a string term and a double that represents the weight of the term. For example how often a word is used
 * or the population of a city. Provides <code>Comparators</code> to sort terms for use in the search algorithms
 * and in the <code>Autocomplete</code> class.
 * 
 * @author Zach Biggs
 *
 */
public class Term implements Comparable<Term>
{
	private String query;
	double weight;
	
	public Term(String query, double weight)
	{
		if (query == null)
			throw new NullPointerException("The query cannot be null");
		if (weight < 0)
			throw new IllegalArgumentException("Weight must be positive");
		this.query = query;
		this.weight = weight;
	}

	/**
	 * Returns a new <code>Comparator</code> that orders by weight in descending order
	 * 
	 * @return Returns a <code>ByReverseWeightOrder</code> comparator.
	 */
	public static Comparator<Term> byReverseWeightOrder()
	{
		return new ByReverseWeightOrder();
	}
	
	/**
	 * Returns a new <code>Comparator</code> that orders lexographically but only according to the given prefix.
	 * 
	 * @param r A the prefix string to order by
	 * @return Returns a new <code>ByPrefixORder</code> comparator.
	 */
	public static Comparator<Term> byPrefixOrder(int r)
	{
		if (r < 0)
			throw new IllegalArgumentException("r many not be less than 0");
		return new ByPrefixOrder(r);
	}
	
	/**
	 * {@inheritDoc}
	 */
	@Override
	public int compareTo(Term o)
	{
		return this.query.compareToIgnoreCase(o.query);
	}
	
	/**
	 * {@inheritDoc}
	 */
	@Override
	public String toString()
	{
		return weight + "	" + query;
	}
	
	/**
	 * Comparator for ordering my reverse weight order.
	 * 
	 * @author Zach Biggs
	 *
	 */
	public static class ByReverseWeightOrder implements Comparator<Term>
	{
		/**
		 * 
		 */
		@Override
		public int compare(Term o1, Term o2)
		{
			if (o1.weight != o2.weight)
				return o1.weight < o2.weight ? 1 : -1;
			return 0;
		}
		
	}
	
	/**
	 * Comparator to order by a given prefix.
	 * 
	 * @author Zach Biggs
	 *
	 */
	public static class ByPrefixOrder implements Comparator<Term>
	{
		private int prefix;
		
		public ByPrefixOrder(int prefix)
		{
			this.prefix = prefix;
		}
		
		/**
		 * {@inheritDoc}
		 */
		@Override
		public int compare(Term o1, Term o2)
		{
			// Fix this shit.
			String copy1 = prefix > o1.query.length() ? o1.query : o1.query.substring(0, prefix);
			String copy2 = prefix > o2.query.length() ? o2.query : o2.query.substring(0, prefix);
			return copy1.compareToIgnoreCase(copy2);
		}
		
	}
}
