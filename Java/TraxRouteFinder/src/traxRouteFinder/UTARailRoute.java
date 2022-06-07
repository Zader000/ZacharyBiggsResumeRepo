package traxRouteFinder;

import java.awt.BorderLayout;
import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;

import edu.princeton.cs.algs4.In;
import edu.princeton.cs.algs4.ST;

import javax.swing.JLabel;
import javax.swing.JOptionPane;

import java.awt.Font;
import javax.swing.SwingConstants;
import java.awt.FlowLayout;
import javax.swing.JTextField;
import javax.swing.JButton;
import java.awt.event.ActionListener;
import java.io.IOException;
import java.net.URI;
import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse;
import java.util.ArrayList;
import java.awt.event.ActionEvent;
import javax.swing.ImageIcon;
import java.awt.SystemColor;
import javax.swing.JComboBox;
import java.awt.GridLayout;
import javax.swing.border.LineBorder;
import java.awt.Color;

/**
 * Main GUI for program.
 * 
 * @author Zach Biggs
 *
 */
@SuppressWarnings("serial")
public class UTARailRoute extends JFrame
{

	private JPanel contentPane;
	private RouteFinder rf;
	private ST<String, Integer> stations;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args)
	{
		EventQueue.invokeLater(new Runnable()
		{
			public void run()
			{
				try
				{
					UTARailRoute frame = new UTARailRoute();
					frame.setVisible(true);
				} catch (Exception e)
				{
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the frame.
	 */
	public UTARailRoute()
	{
		rf = new RouteFinder();
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 800, 950);
		contentPane = new JPanel();
		contentPane.setBackground(SystemColor.inactiveCaption);
		contentPane.setBorder(null);
		contentPane.setLayout(new BorderLayout(0, 0));
		setContentPane(contentPane);

		createLblTitle();

		initializeST();

		JPanel panel = createPanel();

		createLblImage();

	}

	private void initializeST()
	{
		this.stations = new ST<>();
		In in = new In("src/traxRouteFinder/Resource/stations.csv");
		Integer locationId;
		String name, csvline;
		String[] tokens;

		while (in.hasNextLine())
		{
			csvline = in.readLine();
			tokens = csvline.split(",");

			locationId = Integer.parseInt(tokens[1]);
			name = tokens[2];

			stations.put(name, locationId);
		}
	}

	private void createLblImage()
	{
		JLabel lblImage = new JLabel("");
		lblImage.setHorizontalAlignment(SwingConstants.CENTER);
		lblImage.setIcon(new ImageIcon("src/traxRouteFinder/Resource/mapimage.png"));
		contentPane.add(lblImage, BorderLayout.CENTER);
	}

	private JPanel createPanel()
	{
		JPanel panel = new JPanel();
		panel.setBackground(SystemColor.controlLtHighlight);
		contentPane.add(panel, BorderLayout.SOUTH);
		panel.setLayout(new GridLayout(1, 5, 10, 5));

		JLabel lblStart = new JLabel("Start:");
		lblStart.setHorizontalAlignment(SwingConstants.RIGHT);
		lblStart.setFont(new Font("Tahoma", Font.PLAIN, 24));
		panel.add(lblStart);

		JComboBox<String> comboBoxStart = new JComboBox<>();
		comboBoxStart.setForeground(SystemColor.desktop);
		comboBoxStart.setBackground(SystemColor.menu);
		panel.add(comboBoxStart);

		JLabel lblStop = new JLabel("Stop: ");
		lblStop.setFont(new Font("Tahoma", Font.PLAIN, 24));
		lblStop.setHorizontalAlignment(SwingConstants.RIGHT);
		panel.add(lblStop);

		JComboBox<String> comboBoxStop = new JComboBox<>();
		comboBoxStop.setForeground(SystemColor.desktop);
		comboBoxStop.setBackground(SystemColor.menu);
		panel.add(comboBoxStop);

		for (String name : stations.keys())
		{
			comboBoxStart.addItem(name);
			comboBoxStop.addItem(name);
		}

		JButton btnFind = new JButton("Find");
		btnFind.addActionListener(new ActionListener()
		{
			public void actionPerformed(ActionEvent e)
			{
				if (comboBoxStart.getSelectedItem() == comboBoxStop.getSelectedItem())
				{
					JOptionPane.showMessageDialog(contentPane, "Start and Stop may NOT be the same.", "Error", JOptionPane.ERROR_MESSAGE);
				}
				else
				{
					int start = stations.get((String) comboBoxStart.getSelectedItem());
					int stop = stations.get((String) comboBoxStop.getSelectedItem());
					JOptionPane.showMessageDialog(contentPane, rf.getDirections(start, stop));
				}
			}
		});
		btnFind.setBackground(SystemColor.controlHighlight);
		btnFind.setFont(new Font("Tahoma", Font.PLAIN, 24));
		panel.add(btnFind);

		return panel;
	}

	private void createLblTitle()
	{
		JLabel lblTitle = new JLabel("UTA Rail Route Finder");
		lblTitle.setForeground(SystemColor.menuText);
		lblTitle.setHorizontalAlignment(SwingConstants.CENTER);
		lblTitle.setFont(new Font("Tahoma", Font.PLAIN, 40));
		contentPane.add(lblTitle, BorderLayout.NORTH);
	}

}
