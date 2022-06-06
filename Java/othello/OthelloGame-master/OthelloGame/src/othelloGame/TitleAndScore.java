package othelloGame;

import java.awt.*;
import java.awt.event.*;

import javax.swing.*;

/**
 * @author Joshua Stoddard & Zach Biggs
 *
 */
@SuppressWarnings("serial")
public class TitleAndScore extends JPanel {

	private static int darkScoreCount = 2;
	private static int lightScoreCount = 2;
	private static JLabel darkScoreLbl;
	private static JLabel lightScoreLbl;
	private static JLabel winnerAndTurnLbl;
	private JLabel lblOthello;
	private static String winner;
	
	/**
	 * Creates the title and score
	 * panel, adds labels for player
	 * 1 and 2 scores and a reset button.
	 */
	public TitleAndScore() {
		setLayout(new GridLayout(5, 0, 0, 0));
		{
			lblOthello = new JLabel("Othello");
			lblOthello.setFont(new Font("Dialog", Font.BOLD, 24));
			lblOthello.setHorizontalAlignment(SwingConstants.CENTER);
			add(lblOthello);
		}
		
		JLabel darkScore = createDarkScoreLbl();
		add(darkScore);
		
		JLabel lightScore = createLightScoreLbl();
		add(lightScore);
		
		JLabel winner = createTurnAndWinnerLbl();
		add(winner);
		
		
	}

	/**
	 * Creates the Player 1 score label
	 * which keeps track of the number of
	 * wins for Player 1.
	 * 
	 * @return player1Score
	 */
	private JLabel createDarkScoreLbl() {
		darkScoreLbl = new JLabel("Dark: " + darkScoreCount);
		darkScoreLbl.setHorizontalAlignment(SwingConstants.CENTER);
		return darkScoreLbl;
	}
	
	/**
	 * Creates the Player 2 score label
	 * which keeps track of the number of
	 * wins for Player 2.
	 * 
	 * @return player2Score
	 */
	private JLabel createLightScoreLbl() {
		lightScoreLbl = new JLabel("Light: " + lightScoreCount);
		lightScoreLbl.setHorizontalAlignment(SwingConstants.CENTER);
		return lightScoreLbl;
	}
	
	/**
	 * @return the darkScoreCount
	 */
	public static int getDarkScoreCount() {
		return darkScoreCount;
	}

	/**
	 * @param darkScoreCount the darkScoreCount to set
	 */
	public static void setDarkScoreCount(int darkScoreCount) {
		TitleAndScore.darkScoreCount = darkScoreCount;
	}

	/**
	 * @return the lightScoreCount
	 */
	public static int getLightScoreCount() {
		return lightScoreCount;
	}
	
	/**
	 * @param lightScoreCount the lightScoreCount to set
	 */
	public static void setLightScoreCount(int lightScoreCount) {
		TitleAndScore.lightScoreCount = lightScoreCount;
	}
	
	/**
	 * @return winnerLbl
	 */
	private JLabel createTurnAndWinnerLbl() {
		winnerAndTurnLbl = new JLabel("Black's Turn");
		winnerAndTurnLbl.setHorizontalAlignment(SwingConstants.CENTER);
		return winnerAndTurnLbl;
	}
	
	/**
	 * @return the winnerAndTurnLbl
	 */
	public static JLabel getWinnerAndTurnLbl() {
		return winnerAndTurnLbl;
	}
	
	/**
	 * @return winner
	 */
	public static String getWinner() {
		return winner;
	}

	/**
	 * @param winner the winner to set
	 */
	public static void setWinner(String winner) {
		TitleAndScore.winner = winner;
	}
	
	
	public static void updateScore() {
		JButton[][] buttons = GameBoard.getGameBoardBtnArray(); 
		int dark = 0;
		int light = 0;
		for (int i = 0; i < 8; i++) {
			for (int j = 0; j < 8; j++) {
				if (buttons[i][j].getIcon() == GameBoard.getBlackOrWhiteImageArray()[0]) {
					dark++;
				} else if (buttons[i][j].getIcon() == GameBoard.getBlackOrWhiteImageArray()[1]) {
					light++;
				}
			}
		}
		darkScoreCount = dark;
		lightScoreCount = light;
		darkScoreLbl.setText("Dark: " + darkScoreCount);
		lightScoreLbl.setText("Light: " + lightScoreCount);
	}
	
}
