package othelloGame;

import java.awt.*;
import java.awt.event.*;

import javax.swing.*;

/**
 * This creates the Othello gameboard
 * with all of the buttons where the 
 * player pieces can go, either white or black
 * depending on player turn.
 * 
 * @author Joshua Stoddard & Zach Biggs
 *
 */

@SuppressWarnings("serial")
public class GameBoard extends JPanel {
	
	private static JButton[][] gameBoardBtnArray = new JButton[8][8];
	private static ImageIcon[] blackOrWhiteImageArray = {
			new ImageIcon(GameBoard.class.getResource("/resources/black-disk.png")),
			new ImageIcon(GameBoard.class.getResource("/resources/white-disk.png"))
	};
	private static int turnNumber = 0;
	
	/**
	 * Creates the Game Board panel
	 * and adds the buttons to it.
	 */
	public GameBoard() {
		setLayout(new GridLayout(8, 8, 0, 0));
		
		for(int xI = 0; xI < 8; xI++) {
			for(int yI = 0; yI < 8; yI++) {
				createGameBoardBtns(xI, yI);
				add(gameBoardBtnArray[xI][yI]);
			}
		}
		
		//starting position
		gameBoardBtnArray[3][3].setIcon(blackOrWhiteImageArray[1]);
		gameBoardBtnArray[4][4].setIcon(blackOrWhiteImageArray[1]);
		
		gameBoardBtnArray[4][3].setIcon(blackOrWhiteImageArray[0]);
		gameBoardBtnArray[3][4].setIcon(blackOrWhiteImageArray[0]);
		
	}

	/**
	 * Creates the buttons on the game
	 * board and what happens when they
	 * are clicked.
	 * 
	 * @param index
	 */
	private void createGameBoardBtns(int rowIndex, int columnIndex) {
		gameBoardBtnArray[rowIndex][columnIndex] = new JButton();
		
		gameBoardBtnArray[rowIndex][columnIndex].addActionListener(new ActionListener() {
			
			public void actionPerformed(ActionEvent e) {
				
				if (GameLogic.checkIfValidMove(turnNumber, rowIndex, columnIndex)) {
					turnNumber++;
					if(turnNumber % 2 == 1) {
						GameLogic.placePiece(blackOrWhiteImageArray[0], rowIndex, columnIndex);
						TitleAndScore.getWinnerAndTurnLbl().setText("White's Turn");
					}
					else {
						GameLogic.placePiece(blackOrWhiteImageArray[1], rowIndex, columnIndex);
						TitleAndScore.getWinnerAndTurnLbl().setText("Black's Turn");
					}
					TitleAndScore.updateScore();
					GameLogic.checkForWin();
					repaint();
				}
			}
		});	
	}

	/**
	 * @return the blackOrWhiteImageArray
	 */
	public static ImageIcon[] getBlackOrWhiteImageArray() {
		return blackOrWhiteImageArray;
	}

	/**
	 * @return the gameBoardBtnArray
	 */
	public static JButton[][] getGameBoardBtnArray() {
		return gameBoardBtnArray;
	}

	/**
	 * @param gameBoardBtnArray the gameBoardBtnArray to set
	 */
	public static void setGameBoardBtnArray(JButton[][] gameBoardBtnArray) {
		GameBoard.gameBoardBtnArray = gameBoardBtnArray;
	}
	
}
