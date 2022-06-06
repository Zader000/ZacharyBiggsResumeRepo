package traxRouteFinder;

import java.io.BufferedReader;
import java.io.FileReader;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

import edu.princeton.cs.algs4.BreadthFirstPaths;
import edu.princeton.cs.algs4.Graph;
import edu.princeton.cs.algs4.In;
import edu.princeton.cs.algs4.Queue;

/**
 * Main back-end work horse for the Program. Creates the graph and all stations.
 * Finds the shortest path, (Least amount of stops), to the destination station.
 * 
 * @author Zach Biggs
 */
public class RouteFinder
{
	private BreadthFirstPaths bfs;
	private Graph map;
	private List<Station> stations;

	public RouteFinder()
	{
		In in = new In("src/traxRouteFinder/Resource/LinesMap");
		map = new Graph(in);
		initializeStations();
	}
	
	// Reads .csv file to get all station information and initialize it into Station objects.
	private void initializeStations()
	{
		this.stations = new ArrayList<>();
		Integer id, locationId;
		String name, csvline = "";
		Line line;
		String[] tokens;
		try (BufferedReader reader = new BufferedReader(new FileReader("src/traxRouteFinder/Resource/stations.csv")))
		{
			
			while ((csvline = reader.readLine()) != null)
			{
				tokens = csvline.split(",");
				
				id = Integer.parseInt(tokens[0]);
				locationId = Integer.parseInt(tokens[1]);
				name = tokens[2];
				line = Line.valueOf(tokens[3]);

				stations.add(new Station(id, locationId, name, line));
			}
			Collections.sort(stations);
		}
		catch (Exception e)
		{
			
		}
		
	}
	
	/**
	 * Finds the best route to take from origin station to the destination station.
	 * 
	 * @param originLocationId Location ID of the Origin Station.
	 * @param destinationLocationId Location ID of the Destination Station.
	 * @return Returns a list of stations that represents each stop/rail change to get to the destination.
	 */
	public List<Station> getRoute(int originLocationId, int destinationLocationId)
	{
		List<Station> originStations = getStationsFromLocation(originLocationId);
		List<Station> destStations = getStationsFromLocation(destinationLocationId);
		List<Station> route = new ArrayList<>();
		int originId = -1;
		int destId = -1;
		int minRouteDist = Integer.MAX_VALUE;
		
		for (Station og : originStations)
		{
			for (Station dest : destStations)
			{
				this.bfs = new BreadthFirstPaths(this.map, og.getId());
				int distance = this.bfs.distTo(dest.getId());
				if (distance < minRouteDist) 
				{
					minRouteDist = distance;
					originId = og.getId();
					destId = dest.getId();
				}
			}
		}
		
		this.bfs = new BreadthFirstPaths(this.map, originId);
		
		for (Integer i : this.bfs.pathTo(destId))
			route.add(stations.get(i));
		return route;
	}

	private List<Station> getStationsFromLocation(int locationId)
	{
		List<Station> output = new ArrayList<>();
		
		for (Station s : this.stations)
			if (s.getLocationId() == locationId)
				output.add(s);
		return output;
	}
	
	/**
	 * Returns a string of directions on how to get to the destination from the origin.
	 * 
	 * @param originLocationId int Location ID of the Origin Station
	 * @param destinationLocationId int Location ID of the Destination Station
	 * @return Returns a formatted string containing the instructions.
	 */
	public String getDirections(int originLocationId, int destinationLocationId)
	{
		StringBuilder message = new StringBuilder("");
		List<Station> route = getRoute(originLocationId, destinationLocationId);
		
		message.append("Start out on the " + route.get(0).getLine().toString() 
				+ " Line at the " + route.get(0).getName() + " Station.\n");
		
		if (route.get(0).getLine() == route.get(route.size() - 1).getLine())
		{
			message.append("Stay on the train until your destination at the " + route.get(route.size() - 1).getName() 
					+ " Station.");
		}
		else
		{
			Queue<Station> queue = new Queue<>();
			
			for (Station s : route)
				queue.enqueue(s);
			
			Station s1, s2;
			while (queue.size() > 1)
			{
				s1 = queue.dequeue();
				s2 = queue.peek();
				if (s1.getLine() != s2.getLine())
					message.append("Switch trains at " + s1.getName() + " to the " + s2.getLine().toString() + " Line.\n");	
			}
			message.append("Continue on that train until your destination at the " + route.get(route.size() - 1).getName() 
					+ " Station.");
		}
		return message.toString();
	}
}
