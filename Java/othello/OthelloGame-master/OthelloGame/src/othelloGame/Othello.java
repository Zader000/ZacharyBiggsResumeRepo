package othelloGame;

import java.awt.EventQueue;
import java.awt.BorderLayout;

import javax.swing.*;
import javax.swing.border.EmptyBorder;

/**
 * @author Joshua Stoddard & Zach Biggs
 *
 */
@SuppressWarnings("serial")
public class Othello extends JFrame {

	private JPanel contentPane;
	private TitleAndScore titleAndScore;
	private GameBoard gameBoard;

	/**
	 * Launch application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					Othello frame = new Othello();
					frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Creates the frame for the GUI.
	 */
	public Othello() {
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(200, 200, 550, 400);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		contentPane.setLayout(new BorderLayout(0, 0));
		setContentPane(contentPane);

		gameBoard = createGameBoard();
		contentPane.add(gameBoard, BorderLayout.CENTER);

		titleAndScore = createTitleAndScore();
		contentPane.add(titleAndScore, BorderLayout.EAST);
	}

	/**
	 * Creates the gameBoard, which is a Panel that contains all of the buttons on
	 * the Othello board.
	 * 
	 * @return gameBoard
	 */
	private GameBoard createGameBoard() {
		gameBoard = new GameBoard();
		return gameBoard;
	}

	/**
	 * Creates the titleAndScore, which is a panel that contains both the title and
	 * the current score.
	 * 
	 * @return titleAndScore
	 */
	private TitleAndScore createTitleAndScore() {
		titleAndScore = new TitleAndScore();
		return titleAndScore;
	}
	

}
