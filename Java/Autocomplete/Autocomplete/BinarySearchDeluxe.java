package a03;

import java.util.Comparator;

/**
 * 
 * @author Zach Biggs
 *
 */
public class BinarySearchDeluxe
{
	/**
	 * Performs a binary search with the array sorted by the given <code>Comparator<></code>.
	 * Then returns the first index of the given <code>Key</code>.
	 * The function assumes that the given array has already been sorted by the given comparator.
	 * 
	 * 
	 * @param <Key> Type of the Array
	 * @param a Arrays to be searched
	 * @param key Element that the search is looking for.
	 * @param comparator The comparator that the array has been previously sorted by.
	 * @throws Throws a <code>NullPointerException</code> if any of the parameters are null.
	 * @return Returns first index of the given <code>Key</code>.
	 */
	@SuppressWarnings("unchecked")
	public static <Key> int firstIndexOf(Key[] a, Key key, Comparator<Key> comparator)
	{
		// Check for nulls
		if (a == null
				|| key == null
				|| comparator == null)
			throw new NullPointerException("None of the parameters may be null");
		Object[] copy = new Object[a.length];
		for (int i = 0; i < a.length; i++)
			copy[i] = a[i];
		
		// Do the Binary Search
		int lo = 0;
		int hi = copy.length - 1;
		int index = -1;
		while (lo <= hi)
		{
			int mid = lo + (hi - lo) / 2;
			if (comparator.compare(key, (Key) copy[mid]) < 0)
				hi = mid - 1;
			else if (comparator.compare(key, (Key) copy[mid]) > 0)
				lo = mid + 1;
			else 
			{
				index = mid;
				break;
			}
		}
		// Find the first index of the given key
		if (index >= 1 ) 
		{
			while(comparator.compare((Key) copy[index - 1], key) == 0 && index - 1 >= 0)
			{
				index--;
				if (index == 0)
					break;
			}	
		}
		return index;
	}
	
	/**
	 * Performs a binary search with the array sorted by the given <code>Comparator<></code>.
	 * Then returns the last index of the given <code>Key</code>.
	 * The function assumes that the given array has already been sorted by the given comparator.
	 * 
	 * 
	 * @param <Key> Type of the Array
	 * @param a Arrays to be searched
	 * @param key Element that the search is looking for.
	 * @param comparator The comparator that the array has been previously sorted by.
	 * @throws Throws a <code>NullPointerException</code> if any of the parameters are null.
	 * @return Returns last index of the given <code>Key</code>.
	 */
	@SuppressWarnings("unchecked")
	public static <Key> int lastIndexOf(Key[] a, Key key, Comparator<Key> comparator)
	{
		//Check for nulls
		if (a == null
				|| key == null
				|| comparator == null)
			throw new NullPointerException("None of the parameters may be null");
		
		//copy array
		Object[] copy = new Object[a.length];
		for (int i = 0; i < a.length; i++)
			copy[i] = a[i];
		
		// Do the Binary Search
		int lo = 0;
		int hi = a.length - 1;
		int index = -1;
		while (lo <= hi)
		{
			int mid = lo + (hi - lo) / 2;
			if (comparator.compare(key, (Key) copy[mid]) < 0)
				hi = mid - 1;
			else if (comparator.compare(key, (Key) copy[mid]) > 0)
				lo = mid + 1;
			else 
			{
				index = mid;
				break;
			}
		}
		
		//Find the last index of
		if (index < copy.length - 1) 
		{
			while(comparator.compare((Key) copy[index + 1], key) == 0 && index + 1 < copy.length)
			{
				index++;
				if (index == copy.length - 1)
					break;
			}
		}
		return index;
	}
}
