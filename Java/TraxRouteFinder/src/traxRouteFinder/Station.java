package traxRouteFinder;

/**
 * Class that represents the various stations in the UTA rail system.
 * Stations that have multiple lines are separated with their own id but share
 * their name a location ID for ease of checking if a train switch is necessary along the route.
 * 
 * @author Zach Biggs
 *
 */
public class Station implements Comparable<Station>
{
	private int id;
	private int locationId;
	private String name;
	private Line line;
	
	public Station(int id, int locationId, String name, Line line)
	{
		this.id = id;
		this.locationId = locationId;
		this.name = name;
		this.line = line;
	}

	/**
	 * Returns the stations name.
	 * @return Returns the name as a string.
	 */
	public String getName()
	{
		return name;
	}

	/**
	 * Gets the line associated with this station
	 * @return Returns the corresponding line from the line enum. 
	 */
	public Line getLine()
	{
		return line;
	}
	
	/**
	 * Gets ID
	 * @return Return ID of station returns int.
	 */
	public int getId()
	{
		return this.id;
	}
	
	/**
	 * Gets location ID
	 * @return Returns location id returns int.
	 */
	public int getLocationId()
	{
		return this.locationId;
	}
	
	/**
	 * {@inheritDoc}
	 */
	@Override
	public String toString()
	{
		return "ID: " + id + " LocationID: " + locationId + " Name: " + name + " Line: " + line.toString();
	}

	/**
	 * Compares by the station's id number.
	 * {@inheritDoc}
	 */
	@Override
	public int compareTo(Station that)
	{
		return this.id - that.id;
	}
}
